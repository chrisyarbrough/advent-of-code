using CommandLine;
using JetBrains.Annotations;

[UsedImplicitly(ImplicitUseTargetFlags.WithInheritors)]
abstract class Command
{
	[Value(0, MetaName = "day", Required = true, HelpText = "The day of the puzzle.")]
	public int Day { get; set; }

	public abstract void Run();
}