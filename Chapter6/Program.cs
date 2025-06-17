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

PrintElements(InsertionSort([1,-1,-123,0,5,2,126,8,12]));