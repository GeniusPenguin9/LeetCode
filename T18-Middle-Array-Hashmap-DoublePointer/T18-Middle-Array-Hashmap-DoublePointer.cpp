// T18-Middle-Array-Hashmap-DoublePointer.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include <vector>
#include <unordered_map>
#include <unordered_set>
#include <map>
#include <algorithm>
using namespace std;

class Solution {
public:
    vector<int> twoSum(vector<int>& nums, int target) {
        unordered_map<int,int> umap;
        for (int i = 0; i < nums.size(); i++)
        {
            if (umap.find(target - nums[i]) == umap.end())
                umap.insert({nums[i], i});
            else
                return vector<int>{umap[target-nums[i]], i};
        }
        return vector<int>{};
    }

    vector<vector<int>> threeSum(vector<int>& nums) {
        std::sort(nums.begin(), nums.end());
        vector<vector<int>>res;
        int n = nums.size();
        for (int i = 0; i < n - 2; i++)
        {
            if (nums[i] > 0) //nums[i]是三数之中最小的一个
                break;
            
            if (i > 0 && nums[i] == nums[i - 1])
                continue;
            
            int j = i + 1;
            int k = n - 1;
            while (j < k)
            {
                if (nums[i] * nums[n - 1] > 0)
                    break;
                if (nums[i] + nums[j] + nums[k] == 0)
                {
                    res.push_back({ nums[i],nums[k],nums[j] });
                    while (k > j)
                    {
                        k--;
                        if (nums[k] != nums[k + 1])
                            break;
                    }
                }
                else if (nums[i] + nums[j] + nums[k] > 0)
                {
                    while (k > j)
                    {
                        k--;
                        if (nums[k] != nums[k + 1])
                            break;
                    }
                }
                else 
                {
                    while (k > j)
                    {
                        j++;
                        if (nums[j] != nums[j - 1])
                            break;
                    }
                }
            }

        }
        return res;
    }

    //vector<vector<int>> fourSum(vector<int>& nums, int target) {
    //    unordered_map<int, int> dicCount;
    //    unordered_map<int, vector<pair<int,int>>> dicPair;
    //    int n = nums.size();
    //    for (int i = 0; i < n; i++)
    //    {
    //        if (dicCount.find(nums[i]) == dicCount.end())
    //            dicCount[nums[i]] = 1;
    //        else
    //            dicCount[nums[i]]++;

    //        for (int j = i + 1; j < n; j++)
    //        {
    //            int sum = nums[i] + nums[j];
    //            if (dicPair.find(sum) == dicPair.end())
    //                dicPair[sum] = vector<pair<int, int>>{ pair<int,int>{nums[i],nums[j]} };
    //            else
    //                dicPair[sum].push_back(pair<int, int>{nums[i], nums[j]});
    //        }
    //    }

    //    hash_set<vector<int>> res;
    //    res.

    //}
    //vector<int> Combine(unordered_map<int, int> dicCount, pair<int, int> a, pair<int, int>b)
    //{
    //    vector<int> res;
    //    res.push_back(a.first);
    //    res.push_back(a.second);
    //    res.push_back(b.first);
    //    res.push_back(b.second);
    //    std::sort(res.begin(),res.end());

    //    unordered_map<int, int> resCount;
    //    for(int i = 0; i < 4; i++)
    //    {
    //        if (resCount.find(res[i]) == resCount.end())
    //            resCount[res[i]] = 1;
    //        else
    //            resCount[res[i]]++;
    //    }
    //    for (auto kv: resCount)
    //    {
    //        if (resCount[kv.first] > dicCount[kv.first])
    //            return {};
    //    }
    //    return res;
    //}
};

int main()
{

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
