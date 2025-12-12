using System.Collections.ObjectModel;

public class Machine
{
	private readonly ReadOnlyCollection<bool> indicatorLightDiagram;
	private readonly bool[] indicatorLights;
	private readonly int[][] buttons;

	/// <summary>
	/// Creates a new machine from a diagram like: .##.
	/// The length of the string describes the number of lights.
	/// '.' indicates an off position
	/// '#' indicates an on position
	/// </summary>
	public Machine(string indicatorLightDiagram, string buttonWiring)
	{
		var diagramParsed = new bool[indicatorLightDiagram.Length];
		for (int i = 0; i < diagramParsed.Length; i++)
			diagramParsed[i] = indicatorLightDiagram[i] != '.';
		this.indicatorLightDiagram = new ReadOnlyCollection<bool>(diagramParsed);

		indicatorLights = new bool[indicatorLightDiagram.Length];

		buttons = buttonWiring
			.Split(' ')
			.Select(b => b[1..^1].Split(','))
			.Select(x => x.Select(int.Parse).ToArray())
			.ToArray();
	}

	public int[] GetButton(int buttonIndex) => buttons[buttonIndex];
	public int ButtonCount => buttons.Length;

	/// <summary>
	/// Toggles each index of the indicator lights (true -> false and false -> true).
	/// </summary>
	public void PressButton(int[] indicesToPress)
	{
		foreach (int index in indicesToPress)
			indicatorLights[index] ^= true;
	}

	/// <summary>
	/// Returns true if the current indicator light state matches the diagram.
	/// </summary>
	public bool IsInitialized()
	{
		for (int i = 0; i < indicatorLightDiagram.Count; i++)
		{
			if (indicatorLightDiagram[i] != indicatorLights[i])
				return false;
		}
		return true;
	}

	public void Reset()
	{
		for (int i = 0; i < indicatorLights.Length; i++)
			indicatorLights[i] = false;
	}
}