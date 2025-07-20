

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
Console.WriteLine(FindFibNumber(6, ref callCount));
Console.WriteLine($"FinFibNumber() called {callCount} times");

int FindFibNumber(int n, ref int count) {
	count++;
	if (n == 0 || n == 1) {
		return n;
	}

	return FindFibNumber(n-1, ref count) + FindFibNumber(n-2, ref count);
}

callCount = 0;
Console.WriteLine(FindFibNumberMemo(6, ref callCount, new Dictionary<int, int>()));
Console.WriteLine($"FindFibNumberMemo() called {callCount} times");
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