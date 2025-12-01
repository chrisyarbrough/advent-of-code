public abstract class PuzzleTest<T> where T : Puzzle
{
	/// <param name="fileName">Without extension.</param>
	protected T CreateFromFile(string fileName)
	{
		return Create(new InputFile($"{typeof(T).Name}/{fileName}.txt"));
	}

	protected T CreateFromLines(string[] lines)
	{
		return Create(new InputLines(lines));
	}

	protected T CreateFromText(string text)
	{
		return Create(new InputText(text));
	}

	private static T Create(IInput input) => (T)Activator.CreateInstance(typeof(T), input)!;
}