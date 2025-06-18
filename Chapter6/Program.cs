using  static Common.Helper;

int[] InsertionSort(int[] numbers) {
	for (var i = 1; i < numbers.Length; i++) {
		var temp_value = numbers[i];
		var position = i - 1;

		while (position >= 0) {
			if (numbers[position] > temp_value) {
				numbers[position + 1] = numbers[position];
				position--;
			}
			else {
				break;
			}
		}
		
		numbers[position + 1] = temp_value;
	}
	return numbers;
}

PrintElements(InsertionSort([1,-1,-123,0,5,2,126,8,12,-1288712]));

// Ex6.1
// 3N^2 + 2N + 1 = O(N^2)

// Ex6.2
// N + logN = O(N)

// Ex6.3
// In worst case scenario when numbers array does not have 2 number that adds up to 10, then the complexity is O(N^2) as its nested loop
// In best case scenario when the first 2 numbers adds up to 10, the number of steps is 2, complexity is O(1)
// In average case scenario number of steps will be somewhere between 2 and N^2, but its still O(N^2) as the number of total comparisons 
// grows proportional to N² as the array grows.
bool TwoSum(int[] numbers) {
	for (var i = 0; i < numbers.Length; i++) {
		for (var j = 0; j < numbers.Length; j++) {
			if (i != j && numbers[i] + numbers[j] == 10) {
				return true;
			}
		}
	}
	return false;
}

Console.WriteLine(TwoSum([1,2,3,1,5]));

// O(N) complexity with extra O(N) memory allocation
bool TwoSumLinear(int[] numbers) {
	var seenNumbers = new HashSet<int>();
	
	foreach (var n in numbers) {
		var target = 10 - n;
		if (seenNumbers.Contains(target)) {
			return true;
		}
		seenNumbers.Add(n);
	}
	return false;
}

Console.WriteLine($"TwoSumLinear([1,2,3,4,0]) => {TwoSumLinear([1,2,3,4,0])}");

// Ex 6.4
bool containsX(string word) {
	var foundX = false;
	foreach (var c in word) {
		if (c == 'X') {
			foundX = true;
		}
	}
	return foundX;
}





