using CommandLine;
using Microsoft.Extensions.Configuration;

[Verb("setup", HelpText = "Fetch the input for a puzzle and setup code files.")]
class SetupCommand : Command
{
	public override void Run()
	{
		var builder = new ConfigurationBuilder();
		builder.AddUserSecrets<Program>();
		string? sessionCookie = builder.Build()["SessionCookie"];

		if (sessionCookie == null)
		{
			Console.WriteLine("SessionCookie not found in user secrets. See the Readme for setup instruction.");
			return;
		}

		string dayName = "Day" + Day;
		Directory.CreateDirectory(dayName);

		HttpClient client = new();
		client.DefaultRequestHeaders.Add("Cookie", $"session={sessionCookie}");
		string input = client.GetStringAsync($"https://adventofcode.com/{DateTime.Now.Year}/day/{Day}/input").Result;
		WriteFile($"{dayName}/input.txt", input);

		CreateFromTemplate(
			"PuzzleTemplate.cs",
			dayName,
			$"{dayName}/{dayName}.cs");

		CreateFromTemplate(
			"../AdventOfCode.Tests/PuzzleTemplateTests.cs",
			dayName,
			$"../AdventOfCode.Tests/{dayName}Tests.cs");
	}

	private static void WriteFile(string path, string content)
	{
		if (File.Exists(path))
		{
			Console.WriteLine("Skipping existing file: " + path);
			return;
		}

		File.WriteAllText(path, content);
		Console.WriteLine($"Created {path}");
	}

	private static void CreateFromTemplate(string templatePath, string name, string outputPath)
	{
		string templateContent = File.ReadAllText(templatePath);
		templateContent = templateContent.Replace("PuzzleTemplate", name);
		WriteFile(outputPath, templateContent);
	}
}