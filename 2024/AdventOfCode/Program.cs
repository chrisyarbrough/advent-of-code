using CommandLine;

Parser.Default.ParseArguments<SetupCommand, SolveCommand>(args)
	.WithParsed(x => ((Command)x).Run());