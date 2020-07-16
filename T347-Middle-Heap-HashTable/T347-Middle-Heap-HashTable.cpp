// T347-Middle-Heap-HashTable.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//
using namespace std;
#include <iostream>
#include <vector>
#include <unordered_map>
#include <algorithm>

vector<int> topKFrequent(vector<int>& nums, int k) {
    unordered_map<int, int>numCount;
    vector<vector<int>>countNum = { vector<int>{} };//第0个保持为空
    int n = nums.size();
    for (int i = 0; i < n; i++)
    {
        if (numCount.find(nums[i]) != numCount.end())
        {
            int count = numCount[nums[i]];
            numCount[nums[i]]++;
            
            auto it = countNum[count].find(nums[i]);
            if (countNum.size() == count+1)
                countNum.push_back(vector<int>{nums[i]});
            else
                countNum[count+1].push_back(nums[i]);
        }
        else
        {
            numCount.insert({ nums[i],1 });
            if (countNum.size() == 2)
                countNum.push_back(vector<int>{nums[i]});
            else
                countNum.push_back(vector<int>{nums[i]});
        }
    }

    vector<int>res;
    for (auto it = countNum.end(); it >= countNum.begin(); it--)
    {
        if (k == 0)
            break;
        res.insert(res.end(), it->begin(), it->end());
        k -= it->size();
    }
    return res;
}

int main()
{
    //vector<int>a = { 1,1,1,2,2,3 };


    //auto res1 = topKFrequent(a, 2);

    
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
