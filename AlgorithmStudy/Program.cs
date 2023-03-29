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
            CompletionMarathon(a, b);

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

            for(int i =0; i<participant.Length; i++)
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

            foreach(var v in dic)
            {
                //since both string[] elements are added into dictionary whoever complete the marathon will have value 2
                //thefore filtered 
                if (v.Value <= 1)
                {

                Console.WriteLine($"{v.Key } : {v.Value}");
                }
            }

        }

    }

}
