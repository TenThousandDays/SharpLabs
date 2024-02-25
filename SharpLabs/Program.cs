using System.Text.RegularExpressions;

namespace SharpLabs
{
    class Program
    {
        static int getCharCount(string s, char c)
        {
            int count = 0;
            foreach(char ch in s)
            {
                if(ch == c)
                {
                    count++;
                }
            }
            return count;
        }

        static String removeNumbers(string s)
        {
            try
            {
                return Regex.Replace(s, @"\d", "", RegexOptions.None, TimeSpan.FromSeconds(3.0));
            }
            // ReDoS-awared approach
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

        static bool allLettersInString(char[] letters, string s)
        {
            foreach(char c in letters)
            {
                if (!s.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }

        static bool checkRoundBrackets(string s)
        {
            char top;
            Stack<char> st = new Stack<char>();
            foreach(char c in s)
            {
                if(c == '(')
                {
                    st.Push(c);
                }
                else if(c == ')')
                {
                    if(!st.TryPop(out top))
                    {
                        return false;
                    }
                    if(top != '(')
                    {
                        return false;
                    }
                }
            }
            return st.Count == 0;
        }

        static void Main(string[] args)
        {
            string str = "()(())";
            bool res = checkRoundBrackets(str);
            Console.WriteLine($"Result: {res}");
        }
    }
}