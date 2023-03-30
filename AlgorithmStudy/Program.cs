using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmStudy
{
    class Program
    {

        static void Main(string[] args)
        {
            //Reversewords testing

            //string test = "the sky is blue";
            //ReverseWords(test);

            // KthLargestElement testing
            int[] arr = { 1, 4, 66, 5, 22, 41, 3 };
            // 2nd larest num
            //   int k = 5;
            // KthLargestElement(arr, k);

            //Repeat string match 
            string[] a = { "leo", "john", "eden", "mike" };
            string[] b = { "leo", "john", "eden" };
            //CompletionMarathon(a, b);

            // find num in array
            string[] test = { "911", "9113412321", "381209" };
            string[] test2 = { "123", "456", "789" };
            string[] test3 = { "12", "123", "1235", "567", "88" };
            bool flag = NumberExists(test3);
            Console.WriteLine(flag);

            //Find Every Prime num in string
            string test4 = "17";
            int primeNumsInStr = FindEveryPrimeNumInString(test4);

            //   Console.WriteLine($"Total Prime nums : {primeNumsInStr}");
        

            Console.ReadLine();
        }

        /// <summary>
        /// ReverseWords => It is a method that will reverse string 
        /// </summary>
        /// <param name="s"> string that will be reversed</param>
        public static void ReverseWords(string s)
        {
            //copy the string from the parameter
            string beforeReverse = s;
            string[] strArr = beforeReverse.Split(' ');

            for (int i = 0; i < strArr.Length; i++)
            {
                for (int j = i + 1; j < strArr.Length; j++)
                {
                    string temp = strArr[i];
                    strArr[i] = strArr[j];
                    strArr[j] = temp;
                }
            }
            foreach (string result in strArr)
            {

                Console.Write(result + " ");

            }

        }


        public static void KthLargestElement(int[] arr, int kth)
        {
            //1.sort the array largest to smallest
            //2. copy array 
            int[] test = arr;
            int result = 0;

            for (int i = 0; i < test.Length; i++)
            {
                for (int j = i + 1; j < test.Length; j++)
                {
                    if (test[i] < test[j])
                    {
                        int temp = test[i];
                        test[i] = test[j];
                        test[j] = temp;
                    }
                }

            }
            // find kth largest in arr
            for (int i = 0; i < test.Length; i++)
            {
                result = test[kth];
            }
            Console.WriteLine(result);


            // or We can also consider to use Queue
            // using queue it will order largest to smallest
            // then find i that mathes with kth position

            Queue<int> queue = new Queue<int>(arr);

            for (int i = 0; i < queue.Count; i++)
            {
                if (i == kth)
                    Console.WriteLine(queue.ElementAt(i - 1));
            }


        }
        /// <summary>
        /// participants joined marathon and whoever not complete the marathon then make them as output
        /// </summary>
        /// <param name="participant"> Every particpants for the marathon</param>
        /// <param name="complete">people who complete the marathon </param>
        public static void CompletionMarathon(string[] participant, string[] complete)
        {

            // using dictionry and add them into dic for participant and complete
            Dictionary<string, int> dic = new Dictionary<string, int>();

            for (int i = 0; i < participant.Length; i++)
            {
                if (!dic.ContainsKey(participant[i]))
                    dic.Add(participant[i], 1);
                else
                    dic[participant[i]]++;

            }
            for (int i = 0; i < complete.Length; i++)
            {
                if (!dic.ContainsKey(complete[i]))
                    dic.Add(complete[i], 1);
                else
                    dic[complete[i]]++;

            }

            foreach (var v in dic)
            {
                //since both string[] elements are added into dictionary whoever complete the marathon will have value 2
                //thefore filtered 
                if (v.Value <= 1)
                {

                    Console.WriteLine($"{v.Key } : {v.Value}");
                }
            }

        }


        public static bool NumberExists(string[] arr)
        {
            //copy the arr for in case any error occurs
            string[] copyArr = arr;
            //first num in arr
            string test = copyArr[0];
            //last num in arr
            string lastNum = copyArr[copyArr.Length - 1];
            for (int i = 0; i < copyArr.Length - 1; i++)
            {

                if (copyArr[i + 1].Contains(test) || lastNum.Contains(test))
                    return false;
            }
            return true;
        }
        public static int FindEveryPrimeNumInString(string s)
        {

            if (s.Length < 1)
                return 0;



            int num = Convert.ToInt32(s);

            var dic = new Dictionary<int, int>();
            int value = 0;
            while (num > 0)
            {
                if (!dic.ContainsKey(num))
                    dic.Add(num, 1);
                else
                    dic[num]++;

                value = num % 10;
                if (!dic.ContainsKey(value))
                    dic.Add(value, 1);
                else
                    dic[value]++;

                num /= 10;


            }
            //reverse 
            int reverse = ReverseStr(s);
            int reverseValue = 0;

            while (reverse > 0)
            {
                if (!dic.ContainsKey(reverse))
                    dic.Add(reverse, 1);
                else
                    dic[reverse]++;

                reverseValue = reverse % 10;
                if (!dic.ContainsKey(reverseValue))
                    dic.Add(reverseValue, 1);
                else
                    dic[reverseValue]++;

                reverse /= 10;


            }
            int count = 0;
            foreach (var d in dic)
            {
                if (IsPrime(d.Key))
                {
                    Console.WriteLine($"{ d.Key}");
                    count++;
                }

            }


            //17
            return count;


        }
        /// <summary>
        /// reverse string and return int value
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ReverseStr(string s)
        {
            string reversed = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                reversed += s[i];

            }
            return Convert.ToInt32(reversed);

        }
        public static bool IsPrime(int val)
        {
            if (val <= 2)
                return false;
            for (int i = 2; i < Math.Sqrt(val); i++)
            {
                //1234567891011
                if (val % i == 0)
                    return false;
            }
            return true;
        }

   


      
    }


    }


