using static Common.Helper;

//Ex8.1
// O(N+M), N - numbers1 length, M - numbers2 length
int[] FindIntersection(int[] numbers1, int[] numbers2)
{
    if (numbers1 == null || numbers2 == null)
        return [];

    numbers1 = numbers1.Distinct().ToArray();
    numbers2 = numbers2.Distinct().ToArray();

    var lookup = new Dictionary<int, bool>();

    foreach (var n in numbers1)
    {
        lookup[n] = true;
    }

    var result = new List<int>();
    foreach (var n in numbers2)
    {
        if (lookup.ContainsKey(n))
        {
            result.Add(n);
        }
    }

    return result.ToArray();
}

//PrintElements(FindIntersection([1,2,3],[33,45,65,1,123,4,5,7,2,123,5,3]));
//PrintElements(FindIntersection([123],[126]));

//Ex8.2
//O(N)
string FindDuplicate(string[] words) {
	var lookup = new Dictionary<string, bool>();
	var result = "";
	
	if (words != null) {
		foreach (var w in words) {
			if (!lookup.ContainsKey(w)) {
				lookup.Add(w, true);
			}
			else {
				result = w;
				break;
			}
		}
	}
	
	return result;
	
}

//Console.WriteLine(FindDuplicate(["a", "b", "c", "d", "c", "e", "f"]));
//Console.WriteLine(FindDuplicate(["a", "b", "c", "d", "p", "e", "f"]));
//Console.WriteLine(FindDuplicate(["a", "b", "c", "d", "p", "e", "a"]));

//Ex8.3
// O(N)
char FindMissing(string word)
{
    var seen = new Dictionary<char, bool>();

    foreach (var c in word)
    {
        if (char.IsLetter(c))
        {
            char lower = char.ToLower(c);
            if (!seen.ContainsKey(lower))
            {
                seen.Add(lower, true);
            }
        }
    }

    for (char c = 'a'; c <= 'z'; c++)
    {
        if (!seen.ContainsKey(c))
        {
            return c;
        }
    }

    return '\0';
}


//Console.WriteLine(FindMissing("the quick brown box jumps over a lazy dog"));

//Ex8.4
// O(N)
char FindFirstUnique(string word) {
	var seen = new Dictionary<char, bool>(); // key - character, value - is duplicated
    var result = '\0';    

    foreach (var c in word) {
        seen[c] = seen.ContainsKey(c);
    }

    foreach (var c in word) {
        if (!seen[c]) {
            result = c;
            break;
        }
    }

    return result;
    
}

//Console.WriteLine(FindFirstUnique("a"));
//Console.WriteLine(FindFirstUnique("aaabbbcccdddemj"));
//Console.WriteLine(FindFirstUnique("minimum"));







