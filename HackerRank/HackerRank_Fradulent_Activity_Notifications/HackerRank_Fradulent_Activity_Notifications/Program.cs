using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace HackerRank_Fradulent_Activity_Notifications
{
    class Program
    {
        static int activityNotifications(int[] expenditure, int d)
        {
            int l = expenditure.Length;
            int[] arr_cnt_exp = new int[201];
            int ans = 0;

            for (int j = 0; j < d; j++)
            {
            
                arr_cnt_exp[expenditure[j]]++;

            }


            float median = 0;
            for (int i = d; i < l; i++)
            {
                
                median = FindMedian(arr_cnt_exp, d);
             

                if (expenditure[i] >= median * 2)
                {
                 

                    ans++;
                }
 
                arr_cnt_exp[expenditure[i - d]]--;
                arr_cnt_exp[expenditure[i]]++;
       
            }
            return ans;

        }
        static float FindMedian(int[] arr_cnt_exp, int d)
        {
            int sum = 0;
            int median_low = 0;
            int median_high = 0;
            for (int i = 0; i < arr_cnt_exp.Length; i++)
            {

                if (sum <= (d / 2))
                {
                    median_low = (sum == d / 2) ? median_high : i;
                    sum += arr_cnt_exp[i];
                    median_high = i;
                }
                else
                {
                    if (d % 2 != 0)
                    {
                        return median_high;
                    }
                    else
                    {
                        return (float)(median_high + median_low) / 2;

                    }
                }

            }
            return 0;
        }

        static void Main(string[] args)
        {
           // int[] expenditure = { 10, 20, 30, 40, 50 };
            int n = 200000;
            int d = 10000;
            int[] expenditure = new int[n];
            //LinkedList<int> ll_test = new LinkedList<int>();
            //ll_test.AddLast(5);
            //ll_test.AddLast(7);
            //ll_test.AddLast(4);
            //ll_test.AddLast(3);
            //ll_test.AddLast(7);
            //LinkedListSort(ll_test);

            //LinkedListNode<int> node = ll_test.First;
            //while(node != null)
            //{
            //    Console.WriteLine(node.Value);
            //    node = node.Next;
            //}
            //int d = 3;


            string path = @"C:\Users\joshu\Desktop\HackerRank_Fradulent";
            string[] lines = File.ReadAllLines(path);
            int index = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] s_nums = lines[i].Split(' ');
                foreach (var s in s_nums)
                {
                    expenditure[index] = Convert.ToInt16(s);
                    index++;
                }
            }
            Stopwatch stpwat = new Stopwatch();
            stpwat.Start();
            //foreach(var v in expenditure)
            //{
            //    Console.WriteLine(v);
            //}
            int ans = activityNotifications(expenditure, d);
            Console.WriteLine("elpased milliseconds is {0}", stpwat.ElapsedMilliseconds);
            Console.WriteLine("ans is {0}", ans);

            Console.ReadKey();
        }
    }

}