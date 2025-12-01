public interface IInput
{
	string Text();
	string[] Lines();
	IEnumerable<string> EnumerateLines();
}