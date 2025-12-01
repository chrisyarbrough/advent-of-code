public class Day1 : Puzzle
{
	// public override object Part1(string input)
	// {
	// 	var safe = new Safe1(50);
	// 	var instructions = input.Split(Environment.NewLine);
	// 	foreach (var instruction in instructions)
	// 		safe.Rotate(instruction);
	// 	return safe.Password;
	// }

	public override object Part1(string input)
	{
		int dial = 50;
		return input
			.Split(Environment.NewLine)
			.Count(line =>
			{
				int steps = int.Parse(line[1..]);
				int direction = line[0] == 'R' ? 1 : -1;
				dial = (dial + steps * direction) % 100;
				return dial == 0;
			});
	}

	public override object Part2(string input)
	{
		var safe = new Safe2(50);
		var instructions = input.Split(Environment.NewLine);
		foreach (var instruction in instructions)
			safe.Rotate(instruction);
		return safe.Password;
	}

	public class Safe1(int startingNumber)
	{
		public int Password { get; set; }

		private const int size = 100;

		private int dial = startingNumber;

		public int Rotate(string instruction)
		{
			char direction = instruction[0];
			int delta = int.Parse(instruction[1..]);
			if (direction == 'L')
				delta *= -1;
			dial = Rotate(dial, delta);

			// Part1: Password is the number of times zero is hit after any rotation.
			if (dial == 0)
				Password++;

			return dial;
		}

		public static int Rotate(int number, int delta)
		{
			return Mod(number + delta, size);
		}

		private static int Mod(int x, int m)
		{
			// There can be more than one rotation.
			// x can be negative.
			return (x % m + m) % m;
		}
	}

	public class Safe2(int startingNumber)
	{
		public int Password { get; set; }

		private const int size = 100;

		private int dial = startingNumber;

		public int Rotate(string instruction)
		{
			int direction = instruction[0] == 'R' ? 1 : -1;
			int delta = int.Parse(instruction[1..]);

			for (int i = 0; i < delta; i++)
			{
				dial = Rotate(dial, direction);

				if (dial == 0)
					Password++;
			}
			return dial;
		}

		public static int Rotate(int number, int delta)
		{
			return Mod(number + delta, size);
		}

		private static int Mod(int x, int m)
		{
			// There can be more than one rotation.
			// x is always positive.
			return x % m;
		}
	}
}