




//Ex10.1
//PrintEveryOther(0,10);
void PrintEveryOther(int low, int high) {
	if (low > high) {
		Console.WriteLine($"Konec fil'ma: low = {low}");
		return;
	}

	Console.WriteLine(low);
	PrintEveryOther(low + 2, high);
}


//Ex10.2
//Infinite call leading to stack over flow error

//Ex10.3
//Console.WriteLine(Sum(1,10));
int Sum(int low, int high) {
	if (high == low) {
		return low;
	}

	return high + Sum(low, high - 1);
}

//Ex10.4
object[] array = new object[]
{
    1,
    2,
    3,
    new object[] { 4, 5, 6 },
    7,
    new object[]
    {
        8,
        new object[]
        {
            9, 10, 11,
            new object[] { 12, 13, 14 }
        }
    },
    new object[]
    {
        15, 16, 17, 18, 19,
        new object[]
        {
            20, 21, 22,
            new object[]
            {
                23, 24, 25,
                new object[] { 26, 27, 29 }
            },
            30, 31
        },
        32
    },
    33
};

PrintElementsRecursive(array);

void PrintElementsRecursive(object obj)
{
    if (obj is IEnumerable<object> enumerable)
    {
        foreach (var item in enumerable)
        {
            PrintElementsRecursive(item);
        }
    }
    else
    {
        Console.Write($"{obj} ");
    }
}




//CountDown(10);
//CountDownRecursive(10);

void CountDown(int number) {
	for (var i = number; i >= 0; i--) {
		Console.WriteLine(i);
	}
}

void CountDownRecursive(int number) {
	Console.WriteLine(number);

	if (number == 0) {
		return;
	}

	CountDownRecursive(number - 1);
}

