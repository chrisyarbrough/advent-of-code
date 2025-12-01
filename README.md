# Advent of Code

My personal advent of code solutions. Beware of spoilers!

## Setup

Retrieve your session cookie:

1) Visit https://adventofcode.com/<year>/day/1/input
2) Right/Context-click and select 'Inspect' or open the developer console
3) Go to 'Application' in Chrome and 'Storage' in Safari
4) Copy the value for 'session' in https://adventofcode.com
5) Change working directory into AdventOfCode.csproj directory.
6) Run the following command to safely store the cookie on your machine:

```bash
dotnet user-secrets set SessionCookie <cookie>
```

## Usage

To initialize a template class and input file for a given day:

```bash
dotnet run -- setup 1
```

Code your solution and then either run the unit tests or print the solution like this:

```bash
dotner run -- solve 1
```
