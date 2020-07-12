using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HackerRank_HackerRank_Radio_Transmitters
{
    class Program
    {
        static int hackerlandRadioTransmitters(int[] x, int k)
        {
            int ans = 0;
            int range = k;
            int[] arr_location_occupancy = new int[100001];
            int _no_of_homes = x.Length;
            for (int i = 0; i < _no_of_homes; i++)
            {
                arr_location_occupancy[x[i]]++;
            }

            int _left_most_loc = 1;
            while (_no_of_homes > 0)
            {
                while (arr_location_occupancy[_left_most_loc] == 0)
                {
                    _left_most_loc++;
                }

                int _optimal_starting_loc = _left_most_loc + range;
                if(_optimal_starting_loc > 100000)
                {
                    _optimal_starting_loc = 100000;
                }
                while (arr_location_occupancy[_optimal_starting_loc] == 0)
                {
                    _optimal_starting_loc--;
                }

                _no_of_homes -= arr_location_occupancy[_optimal_starting_loc];
                for (int i = 1; i <= k; i++)
                {
                    if (_no_of_homes > 0)
                    {
                        if(_optimal_starting_loc + i <=100000)
                        _no_of_homes -= arr_location_occupancy[_optimal_starting_loc + i];
                        if (_optimal_starting_loc - i >= _left_most_loc)
                            _no_of_homes -= arr_location_occupancy[_optimal_starting_loc - i];
                    }
                    else
                    break;
                }

                _left_most_loc = _optimal_starting_loc + range + 1;
                ans++;
            }

            return ans;
        }
        static void Main(string[] args)
        {
            string path = @"C:\Users\joshu\Desktop\HackerRank_TestCase";
            int[] x = new int[24481];
            int index = 0;
            string[] lines = File.ReadAllLines(path);
            
            foreach(string line in lines)
            {
                string[] s_nums = line.Split(' ').ToArray();
                foreach (var s in s_nums)
                {
                    x[index] = Convert.ToInt32(s);
                    index++;
                }
            }
            //int[] x = { 7, 2, 4, 6, 5, 9, 12, 11 };
            int k = 51;
            int ans = hackerlandRadioTransmitters(x, k);
            Console.WriteLine("ans is {0}", ans);
            Console.ReadKey();
        }
    }
}
