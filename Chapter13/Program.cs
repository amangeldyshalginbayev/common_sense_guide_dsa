

// Ex 13.1
// O(nlogn) 
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

// O(n)
int FindGreatestProduct(int[] numbers)
{
    if (numbers == null || numbers.Length < 3)
        throw new ArgumentOutOfRangeException(nameof(numbers), "Array should have at least 3 elements");

    int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue;

    foreach (var num in numbers)
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

//Console.WriteLine(FindGreatestProduct([100,2,3,10,1,0,7,20,6,5,30]));

// Ex 13.2
// O(nlogn) + O(n) = O(nlogn)
int FindMissingNumber(int[] numbers) {
    if (numbers == null || numbers.Length == 0) {
        throw new ArgumentOutOfRangeException();
    }

    // sort in nlog(n)
    Array.Sort(numbers);

    for (var i = 0; i < numbers.Length; i++) {
        if (i != numbers[i]) {
            return i;
        }
    }

    return -1;    
}

//Console.WriteLine(FindMissingNumber([2,4,3,1,5]));
//Console.WriteLine(FindMissingNumber([2,4,3,1,0]));
//Console.WriteLine(FindMissingNumber([0]));
//Console.WriteLine(FindMissingNumber([1]));

// Ex 13.3

int FindGreatestInQuadratic(int[] numbers)
{
    if (numbers == null || numbers.Length == 0)
        throw new ArgumentOutOfRangeException();

    int max = numbers[0];

    for (int i = 0; i < numbers.Length; i++)
    {
        bool isGreatest = true;

        for (int j = 0; j < numbers.Length; j++)
        {
            if (numbers[i] < numbers[j])
            {
                isGreatest = false;
                break;
            }
        }

        if (isGreatest)
            return numbers[i];
    }

    return max;
}


int FindGreatestInLog(int[] numbers) {

    if (numbers == null || numbers.Length == 0) {
        throw new ArgumentOutOfRangeException();
    }

    Array.Sort(numbers);

    return numbers[numbers.Length-1];
}

int FindGreatestInLinear(int[] numbers) {
    if (numbers == null || numbers.Length == 0) {
        throw new ArgumentOutOfRangeException();
    }

    var max = numbers[0];

    for (var i = 0; i < numbers.Length; i++) {
        if (numbers[i] > max) {
            max = numbers[i];
        }
    }
    
    return max;
}

Console.WriteLine(FindGreatestInQuadratic([1,3,-1,1298,7,6,3,4,6,15,8,8,0]));
Console.WriteLine(FindGreatestInLog([1,3,-1,1298,7,6,3,4,6,15,8,8,0]));
Console.WriteLine(FindGreatestInLinear([1,3,-1,1298,7,6,3,4,6,15,8,8,0]));

