
using System.Diagnostics;
using System.Text;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0,
        ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

class Program
{
    static void Main()
    {

    }

    public static string LongestCommonPrefix(string[] strs)
    {
        bool flag = false;
        StringBuilder res = new StringBuilder();
        int minLen = strs.Min(str => str.Length);
        for (int i = 0; i < minLen; i++)
        {
            res.Append(strs[0][i]);
            foreach (string str in strs)
            {
                if (!str.StartsWith(res.ToString()))
                {
                    flag = true;
                    break;
                }
                
            }

            if(flag)
            {
                res.Remove(res.Length - 1, 1);
                break;
            }
        }
        return res.ToString();
    }
    
    public static int RomanToInt(string s)
    {
        int result = 0;
        Dictionary<char, int> dict = new Dictionary<char, int>();
        dict.Add('I', 1);
        dict.Add('V', 5);
        dict.Add('X', 10);
        dict.Add('L', 50);
        dict.Add('C', 100);
        dict.Add('D', 500);
        dict.Add('M', 1000);
        for (int i = 0; i < s.Length; i++)
        {
            switch (s[i])
            {
                case 'I':
                    if (i < s.Length - 1 && (s[i + 1] == 'V' || s[i + 1] == 'X'))
                    {
                        result += dict[s[i++ + 1]] - 1;
                    }
                    else
                    {
                        result += dict[s[i]];
                    }
                    break;
                case 'X':
                    if (i < s.Length - 1 && (s[i + 1] == 'L' || s[i + 1] == 'C'))
                    {
                        result += dict[s[i++ + 1]] - 10;
                    }
                    else
                    {
                        result += dict[s[i]];
                    }
                    break;
                case 'C':
                    if (i < s.Length - 1 && (s[i + 1] == 'D' || s[i + 1] == 'M'))
                    {
                        result += dict[s[i++ + 1]] - 100;
                    }
                    else
                    {
                        result += dict[s[i]];
                    }
                    break;
                default:
                    result += dict[s[i]];
                    break;
            }
        }   
        return result;
    }

    public static bool IsValid(string s)
    {
        var stack = new Stack<char>();
        for (var i = 0; i < s.Length; i++)
            if (s[i] == '(' || s[i] == '{' || s[i] == '[')
            {
                stack.Push(s[i]);
            }
            else
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                var popped = stack.Pop();
                switch (popped)
                {
                    case '[':
                        if (s[i] != ']') return false;

                        break;
                    case '{':
                        if (s[i] != '}') return false;

                        break;
                    case '(':
                        if (s[i] != ')') return false;

                        break;
                }
            }

        if (stack.Count == 0)
            return true;
        return false;
    }
    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode result = null;
        ListNode head = new ListNode();
        result = head;
        while (list1 != null || list2 != null)
        {
            if (list1 == null)
            {
                head.next = new ListNode(list2.val, null);
                head = head.next;
                list2 = list2.next;
                continue;
            }

            if (list2 == null)
            {
                head.next = new ListNode(list1.val, null);
                head = head.next;
                list1 = list1.next;
                continue;
            }

            if (list1.val < list2.val)
            {
                head.next = new ListNode(list1.val, null);
                head = head.next;
                list1 = list1.next;
            }
            else
            {
                head.next = new ListNode(list2.val, null);
                head = head.next;
                list2 = list2.next;
            }
        }
        result = result.next;
        return result;
    }
    
}