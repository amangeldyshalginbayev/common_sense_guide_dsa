﻿using  static Common.Helper;

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

bool IsPalindrome(string word) {
	var leftIndex = 0;
	var rightIndex = word.Length - 1;
	var isPalindrome = true;

	while (leftIndex < word.Length / 2) {
		if (word[leftIndex] != word[rightIndex]) {
			isPalindrome = false;
			break;
		}
		rightIndex--;
		leftIndex++;
	}
	
	return isPalindrome;
}

//Console.WriteLine(IsPalindrome("kayak"));
//Console.WriteLine(IsPalindrome("abc"));


List<int> PairwiseProducts(int[] numbers) {
	List<int> products = new();
	
	for (var i = 0; i < numbers.Length - 1; i++) {
		for (var j = 0; j < numbers.Length; j++) {
			products.Add(numbers[i] * numbers[j]);
		}
	}
	return products;
}


List<int> PairwiseProductOfNumbers(int[] firstNumbers, int[] secondNumbers) {
	List<int> products = new();
	
	if ((firstNumbers?.Any() ?? false) && (secondNumbers?.Any() ?? false)) {
		for (var i = 0; i < firstNumbers.Length; i++) {
			for (var j = 0; j < secondNumbers.Length; j++) {
				products.Add(firstNumbers[i] * secondNumbers[j]);
			}
		}
	}

	return products;
} 

//Ex7.1
// Takes N/2 steps for size of N, O(N)
bool OneHundredSum(int[] numbers) {
	var leftIndex = 0;
	var rightIndex = numbers.Length - 1;
	
	while (leftIndex < numbers.Length / 2) {
		if (numbers[leftIndex] + numbers[rightIndex] != 100) {
			return false;
		}
		
		leftIndex++;
		rightIndex--;
	}
	
	return true;
}


//Console.WriteLine(OneHundredSum([1,2,3,4]));
//Console.WriteLine(OneHundredSum([1,99,1,99]));

// O(N+M) 
//Ex7.2
int[] MergeSortedNumbers(int[] firstNumbers, int[] secondNumbers) {
	var mergedNumbers = new List<int>();
	var firstPointer = 0;
	var secondPointer = 0;

	while (firstPointer < firstNumbers.Length || secondPointer < secondNumbers.Length) {
		if (firstPointer > firstNumbers.Length - 1) {
			mergedNumbers.Add(secondNumbers[secondPointer]);
			secondPointer++;
		}
		else if (secondPointer > secondNumbers.Length - 1) {
			mergedNumbers.Add(firstNumbers[firstPointer]);
			firstPointer++;
		}
		else if (firstNumbers[firstPointer] < secondNumbers[secondPointer]) {
			mergedNumbers.Add(firstNumbers[firstPointer]);
			firstPointer++;
		}
		else {
			mergedNumbers.Add(secondNumbers[secondPointer]);
			secondPointer++;
		}
	}
	
	return mergedNumbers.ToArray();
}

//PrintElements(MergeSortedNumbers([1,2,3,19], [4,5,6,8,99]));


//Ex7.3
// M - needle length, M - haystack length, O((M-N)*N)
bool FindNeedle(string needle, string haystack) {
	if (string.IsNullOrEmpty(needle)) return true;
	if (needle.Length > haystack.Length) return false;

	int haystackIndex = 0;

	while (haystackIndex <= haystack.Length - needle.Length) {
		int needleIndex = 0;
		bool found = true;

		while (needleIndex < needle.Length) {
			if (haystack[haystackIndex + needleIndex] != needle[needleIndex]) {
				found = false;
				break;
			}
			needleIndex++;
		}

		if (found) {
			return true;
		}

		haystackIndex++;
	}

	return false;
}

//Console.WriteLine(FindNeedle("bgb", "efhijwqopdkowefsabgbwedfwefw"));
//Console.WriteLine(FindNeedle("linux", "windows"));

//Ex7.4
//O(N^3)
long FindLargestProduct(int[] numbers) {
	if (numbers == null || numbers.Length < 3) {
		return -1;
	}
	var i = 0;
	
	var largestProduct = numbers[0] * numbers[1] * numbers[2];

	while (i < numbers.Length) {
		var j = i + 1;
		while (j < numbers.Length) {
			var k = j + 1;
			while (k < numbers.Length) {
				var product = numbers[i] * numbers[j] * numbers[k];
				if (product > largestProduct) {
					largestProduct = product;
				}
				k++;
			}
			j++;
		}
		i++;
	}
	
	return largestProduct;
}

//Rewrite with for loop for readability



//Console.WriteLine(FindLargestProduct([1,2,3,4,5,6,7,8,9,10]));
//Ex7.5
// O(logn) take half each time
string PickResume(string[] resumes)
{
    string eliminate = "top";

    while (resumes.Length > 1)
    {
        int mid = resumes.Length / 2;
        if (eliminate == "top")
        {
            resumes = resumes[..mid];
            eliminate = "bottom";
        }
        else
        {
            resumes = resumes[mid..]; 
            eliminate = "top";
        }
    }

    return resumes[0];
}

Console.WriteLine(PickResume(["A", "B", "C", "D", "E", "F", "G", "H", "I"]));

















