using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank_Lilys_Homework
{
    class Program
    {
        static int asc_ans = 0;
        static int dsc_ans = 0;
        static int lilysHomework(int[] arr)
        {
            int[] arr_rev = new int[arr.Length];
            int[] sort_arr = new int[arr.Length];
            int lim = (arr.Length % 2 == 0) ? (arr.Length / 2 - 1) : arr.Length / 2;

            for (int i = 0; i <= lim; i++)
            {
                arr_rev[i] = arr[arr.Length - 1 - i];
                arr_rev[arr.Length - 1 - i] = arr[i];
            }
            for (int i = 0; i < arr.Length; i++)
            {
                sort_arr[i] = arr[i];
            }

            AscMergeSort(sort_arr);
            asc_ans = FindSwaps(arr,sort_arr);
            dsc_ans = FindSwaps(arr_rev,sort_arr);

            return Math.Min(asc_ans, dsc_ans);
        }

        static int FindNoOfSwaps(int[] arr, int[] cop_arr, Dictionary<int, int> dic_pos)
        {
            int cnt_swaps = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != cop_arr[i])
                {
                    cnt_swaps++;
                    dic_pos.TryGetValue(cop_arr[i], out int pos1);
                    dic_pos[arr[i]] = pos1;
                    arr[pos1] = arr[i];
                }
            }
            return cnt_swaps;
        }

        static void AscMergeSort(int[] arr)
        {
            int len = arr.Length;
            if (len > 1)
            {
                int mid = len / 2;
                int l_len = mid;
                int r_len = len - mid;
                int[] l_arr = new int[l_len];
                int[] r_arr = new int[r_len];

                for (int i = 0; i < l_len; i++)
                {
                    l_arr[i] = arr[i];
                }

                for (int i = 0; i < r_len; i++)
                {
                    r_arr[i] = arr[mid + i];
                }

                AscMergeSort(l_arr);
                AscMergeSort(r_arr);
                int l_index = 0;
                int r_index = 0;
                for (int i = 0; i < len; i++)
                {
                    if (l_index < l_len && r_index < r_len)
                    {
                        if (r_arr[r_index] < l_arr[l_index])
                        {



                            arr[i] = r_arr[r_index];
                            r_index++;

                        }
                        else
                        {

                            arr[i] = l_arr[l_index];
                            l_index++;

                        }
                    }
                    else
                    {

                        if (l_index < l_len)
                        {

                            arr[i] = l_arr[l_index];
                            l_index++;
                        }
                        else if (r_index < r_len)
                        {
                            arr[i] = r_arr[r_index];
                            r_index++;
                        }
                    }
                }


            }
        }

        static int FindSwaps(int[] arr, int[] sort_array)
        {
            Dictionary<int, int> dic_pos = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                dic_pos.Add(arr[i], i);
            }
            return FindNoOfSwaps(arr, sort_array, dic_pos);

        }


        static void Main(string[] args)
        {
            int[] arr = { 3, 4, 2, 5, 1 };
            
            int ans = lilysHomework(arr);
            Console.WriteLine("ans is {0}", ans);
            Console.ReadKey();
        }
    }
}
