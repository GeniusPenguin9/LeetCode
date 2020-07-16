// T887-Hard-Math-BinarySearch-DP.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//
#include <vector>
#include <iostream>
#include <algorithm>
#include <unordered_map>
using namespace std;

unordered_map<pair<int, int>, int> map;//<egg num, floor num>, steps
class Solution {
public:
    static int superEggDrop(int k, int n) {
        if (k == 0)
            return 0;
        if (k == 1)
            return n;

        vector<vector<int>>dp(k + 1, vector<int>(n + 1));
        for (int egg = 2; egg <= k; egg++)
        {
            for (int floor = 1; floor <= n; floor++)
            {
                int broke = 0;
                auto egg_broke = map.find(pair<int,int>(egg - 1, floor - 1));
                if (egg_broke != map.end())
                    broke = egg_broke->second;
                else
                    broke = superEggDrop(k - 1, n - 1);

                int unbroke = 0;
                auto egg_unbroke = map.find(pair<int, int>(egg, n - floor));
                if (egg_unbroke != map.end())
                    unbroke = egg_unbroke->second;
                else
                    unbroke = superEggDrop(k, n - floor);

                dp[egg][floor] = std::max(broke, unbroke) + 1;
            }
        }
        
        map[pair<int, int>(n, k)] = dp[n][k];
        return dp[n][k];
    }
};
int main()
{
    int res2 = Solution::superEggDrop(1, 2);
    int res3 = Solution::superEggDrop(2, 6);
    int res4 = Solution::superEggDrop(3, 14);
}


