// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

// Ex 3.1
// The following function takes 2 operations and it does not depent on the input (year), complexity is O(1)
bool IsLeapYear(int year) {
	return year % 100 == 0 ? year % 400 == 0 : year % 4 == 0;
}

// Ex 3.2
// The following function performs N operations for array size N, complexity is O(N)
int ArraySum(int[] numbers) {
	var sum = 0;
	for (var i = 0; i < numbers.Length; i++) {
		sum += numbers[i];
	}

	return sum;
}

// Ex 3.3
// Complexity is log(N), as we double the input size number of steps increased by 1
int FindChessBoardSpace(int numberOfGrains)
{
	var chessBoardSpace = 1;
	var placedGrains = 1;
	var steps = 0;

	while(placedGrains < numberOfGrains) {
		placedGrains *= 2;
		chessBoardSpace += 1;
		steps++;
	}

	Console.WriteLine("# steps: {0}", steps);
	return chessBoardSpace;
}

FindChessBoardSpace(100);
FindChessBoardSpace(200);
return;

// Ex 3.4 Complexity id O(N), as we visit each word in collection and check it
List<string> SelectAStrings(IEnumerable<string> words) {
	var aWords = new List<string>();
	var steps = 0;

	foreach (var word in words) {
		if (word.StartsWith("A")) {
			aWords.Add(word);
			steps++;
		}
	}
	Console.WriteLine("# steps: {0}", steps);
	return aWords;
}

// Ex 3.5


