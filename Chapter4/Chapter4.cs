namespace Chapter4;

public static class Chapter4
{
    static int[] BubbleSort(int[] numbers)
    {
        var sorted_until_index = numbers.Length - 1;
        var sorted = false;

        while (!sorted) {
            sorted = true;
            for (var i = 0; i < sorted_until_index; i++) {
                if (numbers[i] > numbers[i+1]) {
                    (numbers[i], numbers[i+1]) = (numbers[i+1], numbers[i]);
                    sorted = false;
                }
            }
            sorted_until_index -= 1;
        }

        return numbers;
    
    }
}