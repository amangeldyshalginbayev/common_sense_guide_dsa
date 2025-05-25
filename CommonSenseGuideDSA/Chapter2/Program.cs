

int[] FindELementBinary(int[] numbers, int element)
{
    var lowerBound = 0;
    var upperBound = numbers.Length - 1;
    int steps = 0;

    while(lowerBound <= upperBound) {
        steps++;
        var midPoint = (lowerBound + upperBound) / 2;
        var midValue = numbers[midPoint];
        if (midValue == element) {
            return [midPoint, steps];
        }
        else if (midValue > element) {
            upperBound = midPoint - 1;
        }
        else if (midValue < element) {
            lowerBound = midPoint + 1;
        }
    }

    return [-1, steps];
    
}

int[] FindElementLinear(int[] numbers, int element) {
    int steps = 0;

    for (var i = 0; i < numbers.Length; i++) {
        steps++;
        if (numbers[i] == element) {
            return [i, steps];
        }
    }

    return [-1, steps];
}

void PrintSearchResult(int[] result) {
    Console.WriteLine($"Steps: {result[1]}, Index: {result[0]}");
}

PrintSearchResult(FindELementBinary([3, 17, 75, 80, 202], 202));
PrintSearchResult(FindElementLinear([3, 17, 75, 80, 202], 202));

PrintSearchResult(FindELementBinary(Enumerable.Range(1, 100).ToArray(), 202));
PrintSearchResult(FindElementLinear(Enumerable.Range(1, 100).ToArray(), 202));

//Exercises Chapter 2
PrintSearchResult(FindElementLinear([2, 4, 6, 8, 10, 12, 13], 8));
PrintSearchResult(FindELementBinary([2, 4, 6, 8, 10, 12, 13], 8));
PrintSearchResult(FindELementBinary(Enumerable.Range(1, 100_000).ToArray(), -5));



