﻿
class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World!");
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
}