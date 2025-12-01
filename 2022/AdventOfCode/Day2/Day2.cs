public class Day2 : Puzzle
{
	public Day2(IInput input) : base(input)
	{
	}

	[Benchmark]
	public override object SolutionPart1() => CalculateScore(InterpretInputPart1);

	[Benchmark]
	public override object SolutionPart2() => CalculateScore(InterpretInputPart2);

	/// <summary>
	/// The outcome of a round with the assigned score values.
	/// </summary>
	private enum Outcome
	{
		Loss = 0,
		Draw = 3,
		Win = 6
	}

	/// <summary>
	/// A shape with its assigned score values.
	/// </summary>
	private enum Shape
	{
		Rock = 1,
		Paper = 2,
		Scissors = 3
	}

	/// <summary>
	/// The way the score is calculated is always the same.
	/// Only the input is interpreted differently.
	/// </summary>
	private long CalculateScore(InputInterpreter inputInterpreter)
	{
		long totalScore = 0;

		foreach (string roundInput in inputLines)
		{
			string[] components = roundInput.Split(" ");
			Shape opponentShape = symbolToShape[components[0]];
			Round round = inputInterpreter(opponentShape, components[1]);
			totalScore += round.Score();
		}

		return totalScore;
	}

	/// <summary>
	/// The second part of the input can mean different things depending on the ruleset.
	/// </summary>
	private delegate Round InputInterpreter(Shape opponentShape, string secondInputComponent);

	private readonly struct Round
	{
		private readonly Shape myself;
		private readonly Outcome outcome;

		public Round(Shape myself, Outcome outcome)
		{
			this.myself = myself;
			this.outcome = outcome;
		}

		public int Score()
		{
			return (int)myself + (int)outcome;
		}
	}

	// This represents the ruleset as a ring collection:
	// Rock beats Scissors -> Scissors beats Paper -> Paper beats Rock
	// Alternatively, a dictionary lookup could be used to map more complex relationships.
	private readonly Shape[] ruleset = { Shape.Rock, Shape.Scissors, Shape.Paper };

	private Shape ShapeBeats(Shape thisShape)
	{
		int index = Array.IndexOf(ruleset, thisShape);
		return ruleset[(index + 1) % ruleset.Length];
	}

	private Shape ShapeIsBeatBy(Shape thisShape)
	{
		int index = Array.IndexOf(ruleset, thisShape);
		return ruleset[(index + ruleset.Length - 1) % ruleset.Length];
	}

	private readonly Dictionary<string, Shape> symbolToShape = new()
	{
		{ "A", Shape.Rock },
		{ "B", Shape.Paper },
		{ "C", Shape.Scissors },

		{ "X", Shape.Rock },
		{ "Y", Shape.Paper },
		{ "Z", Shape.Scissors }
	};

	private readonly Dictionary<string, Outcome> symbolToOutcome = new()
	{
		{ "X", Outcome.Loss },
		{ "Y", Outcome.Draw },
		{ "Z", Outcome.Win }
	};

	private Round InterpretInputPart1(Shape opponentShape, string secondInputComponent)
	{
		Shape myShape = symbolToShape[secondInputComponent];

		Outcome outcome;
		if (ShapeBeats(myShape) == opponentShape)
			outcome = Outcome.Win;
		else if (opponentShape == myShape)
			outcome = Outcome.Draw;
		else
			outcome = Outcome.Loss;

		return new Round(myShape, outcome);
	}

	private Round InterpretInputPart2(Shape opponentShape, string secondInputComponent)
	{
		Outcome desiredOutcome = symbolToOutcome[secondInputComponent];
		Shape myShape = desiredOutcome switch
		{
			Outcome.Draw => opponentShape,
			Outcome.Win => ShapeIsBeatBy(opponentShape),
			_ => ShapeBeats(opponentShape)
		};
		return new Round(myShape, desiredOutcome);
	}
}