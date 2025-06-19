
double FindAverageOfEvenNumbers(int[] numbers) {
	double average = -1;

	if (numbers?.Any() ?? false) {
		double sum = 0;
		var count = 0;
		
		foreach(var n in numbers.Where(n => n % 2 == 0)) {
			sum += n;
			count++;
		}
		average = sum / count;
	}

	return average;
}

List<string> WordBuilder2Character(string[] words) {
	var collection = new List<string>();
	
	for (var i = 0; i < words.Length; i++) {
		for (var j = 0; j < words.Length; j++) {
			if (i != j) {
				collection.Add(words[i] + words[j]);
			}
		}
	}
	return collection;
}

List<string> WordBuilder3Character(string[] words) {
	var collection = new List<string>();
	
	for (var i = 0; i < words.Length; i++) {
		for (var j = 0; j < words.Length; j++) {
			for (var k = 0; k < words.Length; k++) {
				if (i != j && j != k && i != k) {
					collection.Add(words[i] + words[j] + words[k]);
				}
			}
		}
	}
	return collection;
}