using System.Diagnostics;
using System.Text.RegularExpressions;

public class Day7 : Puzzle
{
	public Day7(IInput input) : base(input)
	{
	}

	public class Directory
	{
		public readonly string Name;
		public readonly Directory? Parent;

		public long? Size;
		public List<Directory> Directories = new();
		public List<File> Files = new();

		public Directory(string name, Directory? parent = null)
		{
			this.Name = name;
			this.Parent = parent;
		}

		public void AddChildDir(Directory newDir) => Directories.Add(newDir);

		public void AddFile(File file) => Files.Add(file);

		public IEnumerable<Directory> Descendants()
		{
			yield return this;
			foreach (var child in Directories)
			foreach (var subChild in child.Descendants())
				yield return subChild;
		}

		public override string ToString() => $"{Name} {Size} B (DIR)";
	}

	public class File
	{
		public readonly string Name;
		public readonly long Size;

		public File(string name, long size)
		{
			this.Name = name;
			this.Size = size;
		}

		public override string ToString() => $"{Name} {Size} B (FILE)";
	}

	[Benchmark]
	public override object SolutionPart1()
	{
		Directory root = BuildFileTree();
		return root.Descendants()
			.Select(x => x.Size)
			.Where(x => x < 100000)
			.Sum()!;
	}

	private Directory BuildFileTree()
	{
		var root = new Directory(name: "/");

		Directory current = root;

		// Assuming the instruction set always starts at the root level with "$ cd /".
		foreach (string line in inputLines.Skip(1))
		{
			string[] split = line.Split(" ");
			if (line.StartsWith("$"))
			{
				if (split[1] == "cd")
				{
					string directoryName = split[2];

					if (directoryName == "..")
					{
						current = current.Parent;
					}
					else
					{
						current = current.Directories.Find(x => x.Name == directoryName);
					}

					Debug.Assert(current != null);
				}
			}
			else
			{
				if (split[0] == "dir")
				{
					var directory = new Directory(name: split[1], parent: current);
					current.AddChildDir(directory);
				}
				else
				{
					var file = new File(name: split[1], size: int.Parse(split[0]));
					current.AddFile(file);
				}
			}
		}

		ComputeSizes(root);

		return root;
	}

	private void ComputeSizes(Directory current)
	{
		if (current.Size.HasValue)
			return;

		long size = 0;

		foreach (Directory child in current.Directories)
		{
			ComputeSizes(child);
			size += child.Size!.Value;
		}

		size += current.Files.Sum(x => x.Size);
		current.Size = size;
	}

	public override object SolutionPart2()
	{
		const long totalDiskSize = 70000000L;
		const long desiredFreeSpace = 30000000L;

		Directory root = BuildFileTree();
		long usedSpace = root.Size!.Value;
		long unusedSpace = totalDiskSize - usedSpace;
		long delta = desiredFreeSpace - unusedSpace;

		return root.Descendants()
			.Select(x => x.Size)
			.Where(x => x > delta)
			.Min()!;
	}

	[Benchmark]
	public object SolutionPart1_B()
	{
		var pathStack = new Stack<string>();
		var sizes = new Dictionary<string, long>();

		foreach (string line in inputLines)
		{
			if (line.StartsWith("$ cd .."))
				pathStack.Pop();
			else if (line.StartsWith("$ cd"))
				pathStack.Push(string.Join("", pathStack) + line.Split(" ")[2]);
			else if (Regex.IsMatch(line, @"\d+"))
			{
				long size = long.Parse(line.Split(" ")[0]);
				foreach (var dir in pathStack)
					sizes[dir] = sizes.GetValueOrDefault(dir) + size;
			}
		}

		return sizes.Values.Where(x => x < 100000).Sum()!;
	}
}