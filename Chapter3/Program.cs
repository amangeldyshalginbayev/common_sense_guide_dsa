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
