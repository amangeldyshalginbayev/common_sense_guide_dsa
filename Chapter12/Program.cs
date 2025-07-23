

//var callCount = 0;
//Console.WriteLine(FindMax([1,2,3,4], ref callCount));
//Console.WriteLine($"FinxMax() called {callCount} times");

int FindMax(int[] numbers, ref int callCount) {
	callCount++;
	if (numbers.Length == 1) {
		return numbers[0];
	}

	var maxOfRemainder = FindMax(numbers[1..], ref callCount);

	if (numbers[0] > maxOfRemainder) {
		return numbers[0];
	}
	else {
		return maxOfRemainder;
	}
}

var callCount = 0;
//Console.WriteLine(FindFibNumber(6, ref callCount));
//Console.WriteLine($"FinFibNumber() called {callCount} times");

int FindFibNumber(int n, ref int count) {
	count++;
	if (n == 0 || n == 1) {
		return n;
	}

	return FindFibNumber(n-1, ref count) + FindFibNumber(n-2, ref count);
}

//callCount = 0;
//Console.WriteLine(FindFibNumberMemo(6, ref callCount, new Dictionary<int, int>()));
//Console.WriteLine($"FindFibNumberMemo() called {callCount} times");
int FindFibNumberMemo(int n, ref int count, Dictionary<int, int> memo) {
	count++;
	if (n == 0 || n == 1) {
		return n;
	}

	if (!memo.ContainsKey(n)) {
		memo[n] = FindFibNumberMemo(n - 2, ref count, memo) + FindFibNumberMemo(n - 1, ref count, memo);
	}

	return memo[n];
}

//Console.WriteLine("Iterative Fib number finder");
//Console.WriteLine(FindFibIterative(6));
int FindFibIterative(int n) {
	if (n == 0) {
		return 0;
	}

	var a = 0;
	var b = 1;

	for (var i = 1; i < n; i++) {
		var temp = a;
		a = b;
		b = temp + a;
	}
	
	return b;
}

//Ex12.1
//Console.WriteLine(FindSum([90,20,80]));
//Console.WriteLine(FindSum([10,20,30]));
//Console.WriteLine(FindSum([90,5,8,4]));

int FindSum(int[] numbers) {
	if (numbers == null || numbers.Length == 0) {
		return 0;
	}

	var sumOfRest = FindSum(numbers[1..]);

	if ((numbers[0] + sumOfRest) > 100) {
		return sumOfRest;
	}
	else {
		return numbers[0] + sumOfRest;
	}
}


//Console.WriteLine(FindSumFixed([90,20,80]));
//Console.WriteLine(FindSumFixed([10,20,30]));
//Console.WriteLine(FindSumFixed([290,5,8,4]));

int FindSumFixed(int[] numbers, int currentSum = 0) {
	if (numbers == null || numbers.Length == 0) {
		return currentSum;
	}

	if (currentSum + numbers[0] > 100) {
		return FindSumFixed(numbers[1..], currentSum);
	}
	else {
		return FindSumFixed(numbers[1..], currentSum + numbers[0]);
	}
}

//Ex12.2
//Console.WriteLine(FindGolomb(12, new Dictionary<int, int>()));
int FindGolomb(int n, Dictionary<int, int> memo) {
	if (n == 1) {
		return 1;
	}

	if (memo.TryGetValue(n, out int cached)) {
		return cached;
	}
    	
	var golombN = 1 + FindGolomb(n - FindGolomb(FindGolomb(n - 1, memo), memo), memo);

	memo.Add(n, golombN);

	return golombN;

}

//Ex12.3
Console.WriteLine(CountUniquePaths(3, 7, new Dictionary<(int, int), int>()));
int CountUniquePaths(int rows, int columns, Dictionary<(int, int), int> memo) {
	if (rows == 1 || columns == 1) {
		return 1;
	}

	if (memo.TryGetValue((rows, columns), out int cached)) {
		return cached;
	}

	var result = CountUniquePaths(rows - 1, columns, memo) + CountUniquePaths(rows, columns - 1, memo);

	memo[(rows, columns)] = result;

	return result;
}







