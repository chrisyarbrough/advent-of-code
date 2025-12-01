public class BenchmarkInput : InputFile
{
	// TODO
	public BenchmarkInput() 
		: base($"/Users/christopher.yarbrough/RiderProjects/AdventOfCode/AdventOfCode/{FindBenchmarkedType()}/Input.txt")
	{
	}

	private static string FindBenchmarkedType()
	{
		// Using this.GetType() won't work because BenchmarkDotNet generates a new class for the benchmarked methods
		// and compiles it to a different location.
		throw new NotImplementedException();
	}
}