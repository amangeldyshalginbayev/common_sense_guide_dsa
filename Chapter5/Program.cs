

void SelectionSort(int[] numbers) {
	if (numbers != null && numbers.Length > 1) {
		for (var i = 0; i < numbers.Length - 1; i++) {
			var lowestNumberIndex = i;
			for (var j = i + 1; j < numbers.Length; j++) {
				if (numbers[j] < numbers[i]) {
					lowestNumberIndex = j;
				}
			}
			
			if (lowestNumberIndex != i) {
				(numbers[i], numbers[lowestNumberIndex]) = (numbers[lowestNumberIndex], numbers[i]);
			}
		}
	}
}

int[] numbers = [3, 7, -1, 0, -100, 33, 129, 6];
SelectionSort(numbers);

void PrintNumbers(int[] numbers) {
	foreach (var n in numbers) {
		Console.Write($"{n} ");
	}
}

PrintNumbers(numbers);