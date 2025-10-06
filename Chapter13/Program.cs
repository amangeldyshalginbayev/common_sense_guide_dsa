

// Ex 13.1

// 2 approaches, use built in sorting then choose top 3 O(nlogn) 
// find 3 max values in one pass O(n)!
long FindGreatestProductBySorting(int[] numbers) {
	if (numbers == null || numbers.Length < 3) {
		throw new ArgumentOutOfRangeException("Min 3 numbers are required.");
	}

	// sort in nlog(n)
	Array.Sort(numbers);

	var n = numbers.Length;

	var product = numbers[n-1] * numbers[n-2] * numbers[n-3];

	return product;
}

int FindGreatestProduct(int[] numbers)
{
    if (numbers == null || numbers.Length < 3)
        throw new ArgumentOutOfRangeException(nameof(numbers), "Array should have at least 3 elements");

    int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue;

    foreach (int num in numbers)
    {
        if (num > max1)
        {
            max3 = max2;
            max2 = max1;
            max1 = num;
        }
        else if (num > max2)
        {
            max3 = max2;
            max2 = num;
        }
        else if (num > max3)
        {
            max3 = num;
        }
    }

    return max1 * max2 * max3;
}

