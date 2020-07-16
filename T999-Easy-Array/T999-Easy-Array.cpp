// T999-Easy-Array.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include <vector>

using namespace std;

class Solution {
public:
    int numRookCaptures(vector<vector<char>>& board) {
        int xdir[] = { 0,1,0,-1 };
        int ydir[] = { 1,0,-1,0 };
        for (auto i = 0; i < 8; i++)
        {
            for (auto j = 0; j < 8; j++)
            {
                if (board[i][j] == 'R')
                {
                    auto res = 0;
                    for (auto dir = 0; dir < 4; dir++)
                    {
                        auto step = 1;
                        while (true)
                        {
                            auto xcur = i + step * xdir[dir];
                            auto ycur = j + step * ydir[dir];
                            if (xcur < 0 || xcur>8 || ycur < 0 || ycur>8 || board[xcur][ycur] == 'B')
                                break;
                            else if(board[xcur][ycur] =='p')
                            {
                                res++;
                                break;
                            }
                            step++;
                        }
                    }
                    return res;
                }
            }
        }
        return 0;
    }
};

int main()
{
    std::cout << "Hello World!\n";
}

