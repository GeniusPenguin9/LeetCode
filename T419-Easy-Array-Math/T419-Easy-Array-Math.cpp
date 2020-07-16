// T419-Easy-Array-Math.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include <vector>
#include <unordered_map>

using namespace std;

class Solution {
public:
    bool hasGroupsSizeX(vector<int>& deck) {       
        size_t n = deck.size();
        if (n <= 1)
            return false;

        unordered_map<size_t, int> umap;
        for (size_t i = 0; i < n; i++)
        {
            unordered_map<size_t, int>::iterator it = umap.find(i);
            if (it == umap.end())
                umap.insert(std::pair<size_t, int>(i, 1));
            else
                it->second += 1;
        }
        unordered_map<size_t, int>::iterator it = umap.begin();
        auto gcd = it->second;
        it++;
        for (; it != umap.end(); ++it) {
            printf("gcd=%d, it-f=%d,it-s=%d\r\n", gcd, it->first, it->second);
            gcd = GCD(gcd, it->second);
            printf("new gcd=%d\r\n", gcd);
            if (gcd == 1)
                return false;
        }
        return true;
    }

    int GCD(int a, int b)
    {
        if (a == b)
            return a;
        auto min = a < b ? a : b;
        auto max = a > b ? a : b;
        while (min!=0)
        {
            auto t = max % min;
            max = min;
            min = t;
        }
        return 1;
    }
};

int main()
{
    std::cout << "Hello World!\n";

}


