// T912-Middle-QuickSort.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include <vector>
using namespace std;
class Solution {
public:
    //O(n)，计数排序
    //vector<int> sortArray(vector<int>& nums) {
    //    int arr[100000] = { 0 };
    //    auto n = nums.size();
    //    for (auto i = 0; i < n; i++)
    //        arr[nums[i] + 50000] += 1;

    //    vector<int>res;
    //    for (auto i = 0; i < 100000; i++)
    //    {
    //        if(arr[i] != 0)
    //            res.insert(res.end(), arr[i], i - 50000);
    //    }
    //    return res;
    //}

    static void swap(vector<int>& nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

    static void qsort(vector<int>& nums, int i, int j)
    {
        if (i >= j)
            return;
        auto target = nums[i];
        auto min = i;
        for (auto cur = i + 1; cur <= j; cur++)
        {
            if (nums[cur] < target)
            {
                min++;
                swap(nums, min, cur);
            }
        }
        swap(nums, min, i);
        qsort(nums, i, min - 1);
        qsort(nums, min + 1, j);
    } 

    static vector<int> sortArray(vector<int>& nums)
    {
        qsort(nums, 0, nums.size() - 1);
        return nums;
    }
};
int main()
{
    vector<int> input = { 5,2,0,-1,2,88,-343 };
    vector<int> res = Solution::sortArray(input);
}

// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
// 调试程序: F5 或调试 >“开始调试”菜单

// 入门使用技巧: 
//   1. 使用解决方案资源管理器窗口添加/管理文件
//   2. 使用团队资源管理器窗口连接到源代码管理
//   3. 使用输出窗口查看生成输出和其他消息
//   4. 使用错误列表窗口查看错误
//   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
//   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件
