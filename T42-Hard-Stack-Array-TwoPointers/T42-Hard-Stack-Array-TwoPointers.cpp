// T42-Hard-Stack-Array-TwoPointers.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
    static int trap(vector<int>& height) {
        auto n = height.size();
        if (n == 0)
            return 0;
        vector<int> h = vector<int>(n, 0);
        auto min = height[0];
        for (int i = 0; i < n; i++)
        {
            min = std::max(min, height[i]);
            h[i] = min;
        }
        min = height[n - 1];
        for (int i = n - 1; i >= 0; i--)
        {
            min = std::max(min, height[i]);
            h[i] = std::min(h[i], min);
        }

        auto res = 0;
        for (int i = 0; i < n; i++)
            res += (h[i] - height[i]);
        return res;
    }
};

int main()
{
    vector<int> input = { 0,1,0,2,1,0,1,3,2,1,2,1 };
    auto res6 = Solution::trap(input);
}


