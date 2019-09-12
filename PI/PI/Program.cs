using System;

namespace PI
{
    class Program
    {
        static int[] cache = new int[10002];

        static void Main(string[] args)
        {
            for (int i = 0; i < cache.Length; i++)
                cache[i] = -1;
            var aa = memorize("12341234", 0);
            Console.WriteLine(aa);
        }

        static int getDifficulty(string s, int startIndex, int endIndex)
        {

            string target = s.Substring(startIndex, endIndex - startIndex + 1);
            bool areAllSameInt = true;

            foreach(char c in target)
            {
                if (c != target[0])
                {
                    areAllSameInt = false;
                    break;
                }
            }

            if (areAllSameInt) return 1;

            bool isIntervalOne = true;
            for(int i = 0; i < target.Length; i++)
            {
                if (i+2 < target.Length 
                    && ((target[0] - target[1]) != 1 && (target[0] - target[1]) != -1) 
                    && ((target[0] - target[1]) != (target[i] - target[i+1])))
                {
                    isIntervalOne = false;
                    break;
                }
            }

            if (isIntervalOne) return 2;

            bool isAreternate = true;
            for (int i = 0; i < target.Length; i++)
            {
                if (target[i] != target[i%2])
                {
                    isAreternate = false;
                    break;
                }
            }

            if (isAreternate) return 4;

            bool isProgressive = true;
            for (int i = 0; i < target.Length; i++)
            {
                if (i + 2 < target.Length
                    && ((target[0] - target[1]) != (target[i] - target[i + 1])))
                {
                    isProgressive = false;
                    break;
                }
            }

            if (isProgressive) return 5;

            return 10;
        }
        static int memorize(string s, int begin)
        {
            if (begin == s.Length) return 0;

            int ret = cache[begin];
            if (ret != -1) return ret;

            ret = 987654321;

            for(int i = 3; i <= 5; i++)
            {
                if (begin + i <= s.Length)
                    ret = ret < memorize(s, begin + i) + getDifficulty(s, begin, begin + i - 1) ? ret : memorize(s, begin + i) + getDifficulty(s, begin, begin + i - 1);
            }

            return ret;
        }
    }
}
