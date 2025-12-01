public class Day6 : Puzzle
{
	public Day6(IInput input) : base(input)
	{
	}

	private string inputText => base.input.Text();

	public class RingBuffer<T>
	{
		private readonly T[] buffer;
		private int current;

		public RingBuffer(int size)
		{
			this.buffer = new T[size];
		}

		public void Add(T item)
		{
			buffer[current] = item;
			current = (current + 1) % buffer.Length;
		}

		public bool DistinctItems()
		{
			//return buffer.Distinct().Count() == buffer.Length;
			return buffer.ToHashSet().Count == buffer.Length;
		}
	}

	[Benchmark]
	public override object SolutionPart1()
	{
		var markerBuffer = new RingBuffer<char>(4);
		for (int i = 0; i < inputText.Length; i++)
		{
			markerBuffer.Add(inputText[i]);

			if (i >= 4 && markerBuffer.DistinctItems())
			{
				return i + 1;
			}
		}

		return -1;
	}

	[Benchmark]
	public object SolutionPart1_Short()
	{
		const int markerSize = 4;
		return Enumerable.Range(markerSize, inputText.Length)
			.First(index => inputText.Substring(index - 1, markerSize).ToHashSet().Count == markerSize);
	}

	[Benchmark]
	public object SolutionPart1_Hm()
	{
		char[] buffer = new char[4];

		for (int i = 0; i < inputText.Length - 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				buffer[(i + j) % 4] = inputText[i + j];
			}

			if (buffer.Distinct().Count() == 4)
			{
				return i + 4;
			}
		}

		return -1;
	}

	[Benchmark]
	public object SolutionPart1_Old()
	{
		var set = new HashSet<char>();
		const int markerSize = 4;

		for (int i = 0; i < inputText.Length - markerSize; i++)
		{
			set.Clear();
			for (int j = 0; j < markerSize; j++)
			{
				set.Add(inputText[i + j]);
			}

			if (set.Count == markerSize)
			{
				return i + markerSize;
			}
		}

		return -1;
	}

	public override object SolutionPart2()
	{
		var markerBuffer = new RingBuffer<char>(14);
		for (int i = 0; i < inputText.Length; i++)
		{
			markerBuffer.Add(inputText[i]);

			if (i >= 14 && markerBuffer.DistinctItems())
			{
				return i + 1;
			}
		}

		return -1;
	}
}