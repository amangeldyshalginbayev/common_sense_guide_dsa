using Common;


//int[] numbers = [1,2,3];
//DoubleArray(numbers);
//PrintElements(numbers);


//Console.WriteLine(CountX("oxxo"));

//Console.WriteLine(CountNumberOfPathsRecursive(4));


//PrintElements(FindAnagrams("abcd"));

//Ex11.1
//Console.WriteLine(CountCharacters(["ab", "c", "def", "ghij"]));
int CountCharacters(string[] words) {
	
	if (words.Length == 0) {
		return 0;
	}

	words[1..].PrintElements();
	return words[0].Length + CountCharacters(words[1..]);
}


//Ex11.2
//var evens = FindEvenNumbers([6,5,4,3,2,1]);
//PrintElements(evens);
List<int> FindEvenNumbers(int[] numbers)
{
    if (numbers.Length == 0)
        return new List<int>();

    var rest = FindEvenNumbers(numbers[1..]);

    if (numbers[0] % 2 == 0)
    {
        rest.Insert(0, numbers[0]);
    }

    return rest;
}

//Ex11.3
//PrintElements(Enumerable.Range(1, 11).Select(i => FindTriangularNumber(i)));
int FindTriangularNumber(int n) {
	
	if (n == 1) {
		return 1;
	}
	
	return FindTriangularNumber(n-1) + n;
}

//Ex11.4
Console.WriteLine(FindIndex("abcdefghijklmnopqrstuvwxyz"));
int FindIndex(string word, int index = 0)
{
    if (index >= word.Length)
        return -1;

    if (word[index] == 'x')
        return index;

    return FindIndex(word, index + 1);
}

//Ex11.5
Console.WriteLine("Unique Paths Count >");
Console.WriteLine(CountUniquePaths(3, 7));
int CountUniquePaths(int rows, int cols) {
	if (rows == 1 || cols == 1) {
		return 1;
	}
	
	return CountUniquePaths(rows - 1, cols) + CountUniquePaths(rows, cols - 1);	
}



List<string> FindAnagrams(string word) {
	if (word.Length == 1) {
		return [word];
	}

	var collection = new List<string>();

	var substring_anagrams = FindAnagrams(word.Substring(1));

	foreach (var a in substring_anagrams) {
		for (var i = 0; i <= a.Length; i++) {
			var anagram = a.Insert(i, word[0].ToString());
			collection.Add(anagram);
		}
	}

	return collection;
}

int CountNumberOfPathsRecursive(int stairs) {
	if (stairs <= 0)
		return 0;
	if (stairs == 1)
		return 1;
	if (stairs == 2)
		return 2;
	if (stairs == 3)
		return 4;

	return CountNumberOfPathsRecursive(stairs - 1) + CountNumberOfPathsRecursive(stairs - 2) + CountNumberOfPathsRecursive(stairs - 3);
}

int CountX(string input)
{
    // Base case: empty string
    if (string.IsNullOrEmpty(input))
        return 0;

    // Check the first character, then recurse on the rest
    return (input[0] == 'x' ? 1 : 0) + CountX(input.Substring(1));
}

void DoubleArray(int[] array, int index = 0) {
	if (index >= array.Length) {
		return;
	}

	array[index] *= 2;
	DoubleArray(array, index + 1);
}
