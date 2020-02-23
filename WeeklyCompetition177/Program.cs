using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WeeklyCompetition177
{
    class Program
    {
        static void Main(string[] args)
        {
            //var res1 = DaysBetweenDates("2019-06-29", "2019-06-30");
            //var res15 = DaysBetweenDates( "2019-12-31", "2020-01-15");
            //var res3_3 = ClosestDivisors(8);
            //var res5_25 = ClosestDivisors(123);
            //var res40_25 = ClosestDivisors(999);
            //var res1_2 = ClosestDivisors(1);

            var res981 = LargestMultipleOfThree(new int[] { 8, 1, 9 });
            var res8760=LargestMultipleOfThree(new int[] { 8, 6, 7, 1, 0 });
            var res_em = LargestMultipleOfThree(new int[] { 1 });
            var res0= LargestMultipleOfThree(new int[] { 0, 0, 0, 0, 0, 0 });
            var res_em2 = LargestMultipleOfThree(new int[] { 5,8 });
        }

        public static int[] ClosestDivisors(int num)
        {
            var s1 = (int)Math.Sqrt(num + 1);
            var s2 = (int)Math.Sqrt(num + 2);
            if (s1 * s1 == (num + 1))
                return new int[] { s1, s1 };
            else
            {
                if (s2 * s2 == (num + 2))
                    return new int[] { s2, s2 };

                else
                {
                    var s1_temp = new int[2] { -1, -1 };
                    var s2_temp = new int[2] { -1, -1 };
                    for (var i = s1;i>=1;i--)
                    {
                        if((num+1)%i==0)
                        {
                            s1_temp[0] = i;
                            s1_temp[1] = (num+1) / i;
                            break;
                        }
                    }
                    for (var i = s2 ; i >= 1; i--)
                    {
                        if ((num+2) % i == 0)
                        {
                            s2_temp[0] = i;
                            s2_temp[1] = (num+2) / i;
                            break;
                        }
                    }
                    if (s1_temp[0] == -1 && s2_temp[0] != -1)
                        return s2_temp;
                    else if (s1_temp[0] != -1 && s2_temp[0] == -1)
                        return s1_temp;
                    else if (s1_temp[0] == -1 && s2_temp[0] == -1)
                        return new int[] { };
                    else
                    {
                        if (s1_temp[1] - s1_temp[0] <= s2_temp[1] - s2_temp[0])
                            return s1_temp;
                        else
                            return s2_temp;
                    }
                }
            }
        }
        
        public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
        {
            var inarray = Enumerable.Repeat(0,n).ToArray();
            for(var i = 0; i < n; i++)
            {
                if (leftChild[i] != -1)
                    inarray[leftChild[i]]++;
                if (rightChild[i] != -1)
                    inarray[rightChild[i]]++;
            }
            return inarray.Count(i => i == 0) == 1 && inarray.Count(i => i > 1) == 0;
        }


        public static int DaysBetweenDates(string date1, string date2)
        {
            var d1 = DateTime.Parse(date1);
            var d2 = DateTime.Parse(date2);
            return Math.Abs((int)(d1-d2).TotalDays);

        }

        public static  string LargestMultipleOfThree(int[] digits)
        {
            var summod = digits.Sum() %3;
            var ordered = digits.OrderByDescending(i => i).ToList();

            if (summod != 0)
            {
                var ordered_mod = ordered.Select(i => i % 3).ToList();
                
                if(ordered_mod.Contains(summod))
                {
                    ordered.RemoveAt(ordered_mod.LastIndexOf(summod));
                }
                else
                {
                    if(summod == 1)//2+2
                    {
                        if (ordered_mod.Contains(2))
                        { 
                            ordered.RemoveAt(ordered_mod.LastIndexOf(2)); 
                            ordered_mod.RemoveAt(ordered_mod.LastIndexOf(2));
                        }
                        else
                            return "";

                        if (ordered_mod.Contains(2))
                        {
                            ordered.RemoveAt(ordered_mod.LastIndexOf(2));
                            ordered_mod.RemoveAt(ordered_mod.LastIndexOf(2));
                        }
                        else
                            return "";

                    }
                    else if (summod == 2)//1+1
                    {
                        if (ordered_mod.Contains(1))
                        {
                            ordered.RemoveAt(ordered_mod.LastIndexOf(1));
                            ordered_mod.RemoveAt(ordered_mod.LastIndexOf(1));
                        }
                        else
                            return "";

                        if (ordered_mod.Contains(1))
                        {
                            ordered.RemoveAt(ordered_mod.LastIndexOf(1));
                            ordered_mod.RemoveAt(ordered_mod.LastIndexOf(1));
                        }
                        else
                            return "";

                    }
                }

            }
            if (ordered.Count == 0)
                return "";
            else if (ordered[0] == 0)
                return "0";
            else
                return string.Join("", ordered);
        }
    }
}
