namespace AdventOfCode.Day17;

public abstract class RingBuffer<T>
{
	private readonly T[] elements;
	private int index;

	public RingBuffer(T[] elements)
	{
		this.elements = elements;
	}

	public RingBuffer(IEnumerable<T> elements)
	{
		this.elements = elements.ToArray();
	}

	public T Next()
	{
		T element = elements[index];
		index = (index + 1) % elements.Length;
		return element;
	}
}

public class RockSpawner : RingBuffer<Rock>
{
	public RockSpawner(string input)
		: base(input.Split("\n\n").Select(x => new Rock(x)))
	{
	}
}

public class JetPattern : RingBuffer<int>
{
	public JetPattern(string input)
		: base(input.Select(ParseInstruction))
	{
	}

	private static int ParseInstruction(char c)
	{
		if (c == '>')
			return 1;
		else if (c == '<')
			return -1;
		else
			throw new InvalidDataException($"Found unknown symbol '{c}' in jet pattern input.");
	}
}