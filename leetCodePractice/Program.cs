using System.Text;

public class Program
{

    public static void Main(String[] args)
    {
        //ListNode list1 = new ListNode(1, null);
        //list1 = new ListNode(2, list1);
        //list1 = new ListNode(4, list1);

        //ListNode list2 = new ListNode(1, null);
        //list2 = new ListNode(3, list2);
        //list2 = new ListNode(4, list2);

        //ListNode list3 = MergeTwoLists(list1, list2);

        //PrintListNodes(list3);

        //Console.WriteLine(IsAnagram("aaca", "ccac"));

        //var strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };

        //var anagrams = GroupAnagrams(strs);


        //TopKFrequent(new int[] {1, 1, 1, 2, 2, 100}, 2);

        //int[] arr = ProductOfArrayExceptSelf2(new int[] { 1, 2, 3, 4 });



        //  sudoku
        //[["5","3",".",".","7",".",".",".","."],["6",".",".","1","9","5",".",".","."],[".","9","8",".",".",".",".","6","."],["8",".",".",".","6",".",".",".","3"],["4",".",".","8",".","3",".",".","1"],["7",".",".",".","2",".",".",".","6"],[".","6",".",".",".",".","2","8","."],[".",".",".","4","1","9",".",".","5"],[".",".",".",".","8",".",".","7","9"]]
        //[[".",".",".",".","5",".",".","1","."],[".","4",".","3",".",".",".",".","."],[".",".",".",".",".","3",".",".","1"],["8",".",".",".",".",".",".","2","."],[".",".","2",".","7",".",".",".","."],[".","1","5",".",".",".",".",".","."],[".",".",".",".",".","2",".",".","."],[".","2",".","9",".",".",".",".","."],[".",".","4",".",".",".",".",".","."]]


        //char[][] arr = new char[9][];

        //arr[0] = new char[] {'5', '3', '.', '.', '7', '.', '.', '.', '.' };
        //arr[1] = new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' };
        //arr[2] = new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' };
        //arr[3] = new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' };
        //arr[4] = new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' };
        //arr[5] = new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' };
        //arr[6] = new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' };
        //arr[7] = new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' };
        //arr[8] = new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' };

        //bool test = IsValidSudoku(arr);


        //int test = LongestConsecutiveSequence(new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 });
        int test = LongestConsecutiveSequence(new int[] { 1, 2, 0, 1 });

    }

    public static int LongestConsecutiveSequence(int[] nums)
    {
        //  if the array is null or empty return 0
        if (nums.Length == 0 || nums == null)
            return 0;

        //  sort the array so values are all incremental
        Array.Sort(nums);

        //  contains the longest consecutive number
        int longestConsecutive = 0;

        //  placeholder that can be reset to keep checking for other sequences
        int placeHolder = 0;

        for(int i = 0; i < nums.Length-1; i++)
        {
            //  if the current number plus one is equal to the next number in the sequence
            if (nums[i] + 1 == nums[i + 1])
            {
                placeHolder++;
            }
            //  if the next item is the same as the current, skip over it
            else if(nums[i] == nums[i+1])
            {

            }
            //  if the number doesn't continue the sequence, reset the placeholder and set the longest consecutive sequence to it's value before reset.
            else
            {
                if(placeHolder > longestConsecutive)
                    longestConsecutive = placeHolder;
                
                placeHolder = 0;
            }

            //  if the longest consecutive number is less than the placeholder, assign placeholder value to longest consecutive.
            if (placeHolder > longestConsecutive)
                longestConsecutive = placeHolder;
        }

        return longestConsecutive+1;
    }

    public static bool IsValidSudoku(char[][] board)
    {
        //  we're going to use a hash set to see if there are duplicates.
        //  
        //  we'll go through each ROW, and add to the hashset if it doens't exist in the hashset. if it does exist, then we'll return false.
        //  we'll do the same as above but for the COLUMNS.

        HashSet<char> rowHs = new HashSet<char>();
        HashSet<char> colHs = new HashSet<char>();
        Dictionary<Tuple<int,int>, HashSet<char>> gridHs = new Dictionary<Tuple<int,int>, HashSet<char>>();
        //HashSet<char> gridHs = new HashSet<char>();

        //  for each row
        for (int i = 0; i < board.Length; i++)
        {
            //  for each cell
            foreach (char c in board[i])
            {
                //  if the cell isn't empty...
                if (c != '.')
                {
                    //  ... if the row already contains the cell's content...
                    if (rowHs.Contains(c))
                        return false;
                    //  ... else,  add the cell to the hashset.
                    else
                        rowHs.Add(c);
                }
            }

            //  reset the hash set so it's empty for the next row.
            rowHs = new HashSet<char>();
        }

        //  for each column
        for(int i = 0; i < board[0].Length; i++)
        {
            //  for each row
            for(int e = 0; e < board[0].Length; e++)
            {
                char c = board[e][i];

                if (c != '.' && colHs.Contains(c))
                    return false;
                else
                    colHs.Add(c);
            }

            colHs = new HashSet<char>();
        }

        //  check each 3x3 grid
        for(int i = 0; i < board.Length; i++)
        {
            for(int e = 0; e < board.Length; e++)
            {
                //  get the character
                char c = board[i][e];

                //  get it's board coordinates. we essentially section off each square on the board.
                //  by dividing by 3 (it's max possible number board number) we get a value 0-2 which
                //  we can use to group the number hashsets representing each sub board / grid.
                int rowCoords = i / 3;
                int colCoords = e / 3;

                //  create a tuple as coords identifier
                Tuple<int, int> coords = new Tuple<int, int>(rowCoords, colCoords);

                //  if the space isn't empty...
                if(c != '.')
                {
                    //  check if we have the coords in the dict yet.
                    if (gridHs.ContainsKey(coords))
                    {
                        //  if we do, check if the grid contains this value already.
                        if (gridHs[coords].Contains(c))
                            //  if it does, the sudoku is invalid and return false.
                            return false;
                    }

                    //  if we don't have the coords in the dict yet, add them.
                    else
                        gridHs.Add(coords, new HashSet<char>());

                    //  regardless of what happens above add the value to the grid (unless the value was already in the grid, and we'll return false.)
                    gridHs[coords].Add(c);
                }
            }
        }


        return true;
    }

    public static int[] ProductOfArrayExceptSelf2(int[] nums)
    {
        //  set up array that is the same length as the nums array.
        int[] output = new int[nums.Length];

        int[] prefix = new int[nums.Length];
        int[] postfix = new int[nums.Length];

        for(int i = 0; i < nums.Length; i++)
        {
            if (i == 0)
                prefix[i] = nums[i];
            else
                prefix[i] = prefix[i-1] * nums[i];
        }

        for(int i = nums.Length-1; i >= 0; i--)
        { 
            if (i == nums.Length-1)
                postfix[i] = nums[i];
            else
                postfix[i] = postfix[i + 1] * nums[i];
        }

        for(int i = 0; i < nums.Length; i++)
        {
            if (i == 0)
                output[i] = postfix[i + 1];
            else if (i == nums.Length - 1)
                output[i] = prefix[i - 1];
            else
                output[i] = prefix[i - 1] * postfix[i + 1];
        }


        return output;
    }

    public static int[] ProductOfArrayExceptSelf(int[] nums)
    {
        //  For every number n, sum up every number in the array except n and put it in n's place in the new array.

        int[] newNums = new int[nums.Length];

        newNums[0] = 1;

        for (int i = 1; i < nums.Length; i++)
            newNums[i] = newNums[i-1] * nums[i-1];


        int newSum = 1;

        for(int i = nums.Length-1; i >= 0; i--)
        {
            newNums[i] = newNums[i] * newSum;

            newSum *= nums[i];
        }



        return newNums;
    }

    public static int[] TopKFrequent(int[] nums, int k)
    {
        //Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

        var count = new Dictionary<int, int>();

        var freq = new Dictionary<int, List<int>>();

        //  fill freq with index 0 - nums.length
        for(int i = 0; i < nums.Length+1; i++)
            freq.Add(i, new List<int>());


        //  fill dictionary with (key -> number (100), value -> frequency (1))
        foreach (int n in nums)
        {
            if (count.ContainsKey(n))
                count[n] = count[n] + 1;
            else
                count.Add(n, 1);
        }



        foreach(var kvp in count)
            freq[kvp.Value].Add(kvp.Key);

        var result = new List<int>();

        for(int i = freq.Count-1; i >= 0; i--)
        {
            foreach(int n in freq[i])
            {
                result.Add(n);

                if (result.Count == k)
                    return result.ToArray();
            }
        }

        return null;
    }

    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        //  mapping charCount to list of anagrams
        var result = new List<IList<string>>();
        var seen = new Dictionary<string, List<string>>();

        foreach(var anagram in strs)
        {
            var hash = Hash(anagram);

            if (!seen.ContainsKey(hash))
                seen[hash] = new List<string>();

            seen[hash].Add(anagram);
        }

        foreach(var pair in seen)
            result.Add(pair.Value);

        return result;



        //return result.Values;
        return null;


        //Dictionary<Dictionary<char, int>, List<string>> dict = new Dictionary<Dictionary<char, int>, List<string>>();

        ////  lets do the anagrams
        //foreach(string s in strs)
        //{
        //    Dictionary<char, int> hs = new Dictionary<char, int>();

        //    foreach(char c in s)
        //    {
        //        if (hs.ContainsKey(c))
        //            hs[c] = hs[c] + 1;
        //        else
        //            hs.Add(c, 1);
        //    }

        //    if (dict.ContainsKey(hs))
        //    {
        //        List<string> temp = dict[hs];
        //        temp.Add(s);
        //        dict[hs] = temp;
        //    }
        //    else
        //        dict[hs] = new List<string>() { s };
        //}


        //List<List<string>> output = new List<List<string>>();
        //foreach (List<string> ls in dict.Values)
        //    output.Add(ls);


        //return (IList<IList<string>>)output;
    }

    private static string Hash(string input)
    {
        var alphabet = new int[26];

        foreach(var c in input)
            ++alphabet[c - 'a'];

        var sb = new StringBuilder();

        for (int i = 0; i < alphabet.Length; i++)
        {
            if (alphabet[i] > 0)
            {
                sb.Append(alphabet[i]);
                sb.Append((char)('a' + i));
            }
        }

        return sb.ToString();
    }

    public static bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        s = s.ToLower();
        t = t.ToLower();

        Dictionary<char, int> hs = new Dictionary<char, int>();

        foreach (char c in s)
        {
            //  if we have the key already, increment
            if (hs.ContainsKey(c))
                hs[c] = hs[c] + 1;
            //  if we don't, add a new key
            else
                hs.Add(c, 1);
        }

        foreach (char c in t)
        {
            if (hs.ContainsKey(c))
            {
                if (hs[c] - 1 < 0)
                    return false;
                else
                    hs[c] = hs[c] - 1;
            }
            else
                return false;

        }

        return true;
    }

    public static int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();

        for(int i = 0; i < nums.Length; i++)
        {
            int currentNum = nums[i];

            if(dict.ContainsKey(target-currentNum))
            {
                return new int[] { i, dict[target - currentNum] };
            }
            else
            {
                dict[currentNum] = i;
            }
        }

        return null;
    }

    public static bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> hs = new HashSet<int>();

        foreach(int n in nums)
        {
            if (hs.Contains(n))
                return true;

            hs.Add(n);
        }

        return false;
    }

    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        //  create an output linkedlist.
        ListNode dummy = new ListNode(-1);
        ListNode tail = dummy;

        //  loop through both linked lists.

        //  if list1 node value is greater than list2 node value, add list1 node to output and remove list1 node from list1.
        //  do the same for list2 node value.

        while(list1 != null && list2 != null)
        {
            if(list1.val < list2.val)
            {
                tail.next = list1;
                list1 = list1.next;
            }
            else
            {
                tail.next = list2;
                list2 = list2.next;
            }

            tail = tail.next;
        }

        if (list1 != null)
            tail.next = list1;
        if (list2 != null)
            tail.next = list2;



        return dummy.next;
    }

    public static void PrintListNodes(ListNode list)
    {
        while(list != null)
        {
            Console.WriteLine(list.val + ", ");

            list = list.next;
        }
    }

}

public class DictArrEqualityComparer : IEqualityComparer<int[]>
{
    public bool Equals(int[] x, int[] y)
    {
        if (x.Length != y.Length)
            return false;

        if (!x.SequenceEqual(y))
            return false;

        return true;
    }

    public int GetHashCode(int[] obj)
    {
        return base.GetHashCode();
    }
}

public class ListNode
{

    public int val;

    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

}
  