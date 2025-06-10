

int[] BubbleSort(int[] numbers)
{
    var sorted_until_index = numbers.Length - 1;
    var sorted = false;

    while (!sorted)
    {
        sorted = true;
        for (var i = 0; i < sorted_until_index; i++)
        {
            if (numbers[i] > numbers[i + 1])
            {
                (numbers[i], numbers[i + 1]) = (numbers[i + 1], numbers[i]);
                sorted = false;
            }
        }

        sorted_until_index -= 1;
    }

    return numbers;
}

void PrintArray(int[] array) {
	foreach (var element in array) {
		Console.Write($"{element} ");
	}
}

PrintArray(BubbleSort([9,12,3,45,1,67,0,-1,2,2,4,9,5,18,30,20,33]));

bool HasDuplicateValue(int[] numbers) {
	var steps = 0;
	for (var i = 0; i < numbers.Length; i++) {
		for (var j = 0; j < numbers.Length; j++) {
			steps++;
			if (i != j && numbers[i] == numbers[j]) {
				Console.WriteLine($"\nHasDuplicateValue() took #{steps} steps.");
				return true;
			}
		}
	}
	Console.WriteLine($"\nHasDuplicateValue() took #{steps} steps.");
	return false;
}

HasDuplicateValue([1,2,3,4,5,6,7,8,9,9]);

bool HasDuplicateValueLinear(int[] numbers) {
	HashSet<int> existingNumbers = new HashSet<int>();
	var steps = 0;

	foreach (var t in numbers) {
		steps++;
		if (existingNumbers.Contains(t)) {
			Console.WriteLine($"HasDuplicateValueLinear took #{steps}.");
			return true;
		}
		existingNumbers.Add(t); 
	}

	Console.WriteLine($"HasDuplicateValueLinear took #{steps} steps.");
	return false;
}

//Console.WriteLine(HasDuplicateValueLinear([1,2,3,4,5,6,7,7]));


bool HasDuplicateValueLinearWithList(int[] numbers) {
    List<int> existingNumbers = new List<int>();
	var steps = 0;

	foreach (var t in numbers) {
		steps++;
 		if (existingNumbers.Contains(t)) {
			Console.WriteLine($"HasDuplicateValueLinearWithList() took #{steps}.");
			return true;
		}
		existingNumbers.Add(t);
	}
	Console.WriteLine($"HasDuplicateValueLinearWithList() took #{steps}.");
	return false;
}  

Console.WriteLine(HasDuplicateValueLinearWithList([1,2,3,4,5,6,7]));

//Ex4.3
// Compexity is O(N^2) as its nested loop
long FindGreatestProduct(int[] numbers) {
	var steps = 0;
	var greatestProduct = -1L;
	if (numbers.Length > 1) {
		greatestProduct = numbers[0] * numbers[1];
		for (var i = 0; i < numbers.Length; i++) {
			for (var j = 0; j < numbers.Length; j++) {
				steps++;
				var currentProduct = numbers[i] * numbers[j];
				if (i != j && currentProduct > greatestProduct) {
					greatestProduct = currentProduct;
				}
			}
		}
	}
	
	Console.WriteLine($"FindGreatestProduct() took #{steps} steps.");
	return greatestProduct;
}

var greatestProduct = FindGreatestProduct([1,2,3,3,1,2,3,5]);
Console.WriteLine(greatestProduct);

//Ex4.4
// Complexity is O(N)
int? FindGreatestNumber(int[] numbers) {
	int? greatestNumber = null;
	if (numbers != null && numbers.Any()) {
		greatestNumber = numbers[0];
		foreach (var n in numbers) {
			if (n > greatestNumber) {
				greatestNumber = n;
			}
		}
	}
	return greatestNumber;
}

Console.WriteLine($"Greatest number => {FindGreatestNumber([-100, -200, -300, 999, 1233, 123, 1, 12])}");




