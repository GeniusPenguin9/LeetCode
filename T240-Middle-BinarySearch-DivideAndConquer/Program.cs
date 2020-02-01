using System;

namespace T240_Middle_BinarySearch_DivideAndConquer
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = SearchMatrix(new int[,] { { 1, 4, 7, 11, 15 }, { 2, 5, 8, 12, 19 }, { 3, 6, 9, 16, 22 }, { 10, 13, 14, 17, 24 }, { 18, 21, 23, 26, 30 } }, 5);
            var res2 = SearchMatrix(new int[,] { { -5 } }, -5);
            var res3 = SearchMatrix(new int[,] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 25 } }, 19);
        }
        public static bool SearchMatrix(int[,] matrix, int target)
        {
            // start our "pointer" in the bottom-left
            int row = matrix.GetLength(0) - 1;
            int col = 0;

            while (row >= 0 && col < matrix.GetLength(1))
            {
                if (matrix[row,col] > target)
                {
                    row--;
                }
                else if (matrix[row,col] < target)
                {
                    col++;
                }
                else
                { // found it
                    return true;
                }
            }

            return false;
        }


        /* 递归
        public static int p_target;
        public static int[,] p_matrix;
        public static bool SearchMatrix(int[,] matrix, int target)
        {
            p_target = target;
            p_matrix = matrix;
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return false;

            return IsContains(0, matrix.GetLength(1) - 1, 0, matrix.GetLength(0) - 1);
        }

        public static bool IsContains(int left, int right, int top, int bottom)
        {
            if (p_target < p_matrix[top, left] || p_target > p_matrix[bottom, right])
                return false;

            if (right - left <= 1 && bottom - top <= 1)
                return p_matrix[top, left] == p_target ||
                        p_matrix[top, right] == p_target ||
                         p_matrix[bottom, left] == p_target ||
                          p_matrix[bottom, right] == p_target;
            else
            {
                var vertical_mid = (right - left + 1) / 2 + left;
                var horizontal_mid = (bottom - top + 1) / 2 + top;
                var res = false;
                if (p_matrix[horizontal_mid, vertical_mid] == p_target)
                    return true;
                else if (p_matrix[horizontal_mid, vertical_mid] > p_target)
                    res = IsContains(left, vertical_mid, top, horizontal_mid);
                else
                    res = IsContains(Math.Min(vertical_mid + 1, right), right, Math.Min(horizontal_mid + 1, bottom), bottom);


                if (res == false)
                    res = IsContains(left, vertical_mid, Math.Min(horizontal_mid + 1, bottom), bottom);
                if (res == false)
                    res = IsContains(Math.Min(vertical_mid + 1, right), right, top, horizontal_mid);
                return res;
            }
        }
        */

    }
}
