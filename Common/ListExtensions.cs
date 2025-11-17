namespace Common;

public static class ListExtensions
{
    /// <summary>
    /// Attempts to retrieve the element at the specified index in the list. Returns a boolean value indicating
    /// whether the retrieval was successful, and outputs the element if found.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list from which to retrieve the element.</param>
    /// <param name="index">The zero-based index of the element to retrieve.</param>
    /// <param name="value">When this method returns, contains the element at the specified index if the retrieval was successful; otherwise, the default value for the type of the element.</param>
    /// <returns>True if the element was successfully retrieved; otherwise, false if the index is out of range.</returns>
    public static bool TryGet<T>(this List<T> list, int index, out T value)
    {
        if (index >= 0 && index < list.Count)
        {
            value = list[index];
            return true;
        }

        value = default!;
        return false;
    }
}
