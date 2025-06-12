

void SelectionSort(int[] numbers) {
	if (numbers != null && numbers.Length > 1) {
		for (var i = 0; i < numbers.Length - 1; i++) {
			var lowestNumberIndex = i;
			for (var j = i + 1; j < numbers.Length; j++) {
				if (numbers[j] < numbers[lowestNumberIndex]) {
					lowestNumberIndex = j;
				}
			}
			
			if (lowestNumberIndex != i) {
				(numbers[i], numbers[lowestNumberIndex]) = (numbers[lowestNumberIndex], numbers[i]);
			}
		}
	}
}

void PrintNumbers(int[] numbers) {
	foreach (var n in numbers) {
		Console.Write($"{n} ");
	}
}

int[] numbers = [3, 7, -1, 0, -100, 33, 129, 6];
SelectionSort(numbers);
PrintNumbers(numbers);

// Ex5.1
// 4N + 16 = O(N)

// Ex5.2
// 2N^2 = O(N^2)

// Ex5.3
// O(N)
int FindDoubledNumberSum(int[] numbers) {
	var sum = 0;
	var steps = 0;
	var operations = 0;
	foreach (var n in numbers) {
		steps++;
		operations += 2;
		sum += n * 2;
	}
	Console.WriteLine($"FindDoubledNumberSum() took {steps} steps, {operations} operations.");
	return sum;
}

numbers = [1,2,3];
Console.WriteLine(FindDoubledNumberSum(numbers)); 

// Ex5.4
// O(N)
void PrintWords(string[] words) {
	foreach (var t in words.Where(t => !string.IsNullOrEmpty(t))) {
		Console.WriteLine(t.ToUpper());
		Console.WriteLine(t.ToLower());
		Console.WriteLine($"{char.ToUpper(t[0])}{(t.Length > 1 ? t.Substring(1).ToLower() : string.Empty)}");
	}
}

string[] words = ["cat", "DoG", null, "", string.Empty, "A 123bCn "];
PrintWords(words);

// Ex5.5
// O(N^2)
void PrintSumForEveryOtherNumber(int[] numbers) {
	for (var i = 0; i < numbers.Length; i+=2) {
		for (var j = 0; j < numbers.Length; j++) {
			Console.WriteLine(numbers[i] + numbers[j]);
		}
	}
}
PrintSumForEveryOtherNumber([1,2,3,4]);
