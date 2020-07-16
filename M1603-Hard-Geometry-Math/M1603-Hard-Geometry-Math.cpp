// M1603-Hard-Geometry-Math.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include <algorithm>
#include <vector>
using namespace std;

//已知点(a,b)在(x1,y1)~(x2,y2)所在直线上，判断是否在线段范围内
bool IsInside(int x1, int y1, int x2, int y2, int a, int b)
{   
    return (std::min(x1, x2) <= a && a <= std::max(x1, x2)) &&
        (std::min(y1, y2) <= b && b <= std::max(y1, y2));
}

void UpdateNode(vector<double>& node, double x, double y)
{
    if (node.size() == 0 || x < node[0] || (x == node[0] && y < node[1]))
    {
        node = { x,y };
    }
}

vector<double> intersection(vector<int>& start1, vector<int>& end1, vector<int>& start2, vector<int>& end2) {
    //x=x1+t1*(x2-x1)
    //y=y1+t1*(y2-y1)
    //0<=t<=1，表示线段
    int x1 = start1[0];
    int y1 = start1[1];
    int x2 = end1[0];
    int y2 = end1[1];
    int x3 = start2[0];
    int y3 = start2[1];
    int x4 = end2[0];
    int y4 = end2[1];
    
    vector<double>node;
    if ((y4 - y3) * (x2 - x1) == (y2 - y1) * (x4 - x3)) // 斜率一致
    {
        if ((y2 - y1) * (x3 - x1) == (y3 - y1) * (x2 - x1)) // (x3,y3)在直线上，即截距一致
        {
            //结果一定是4个端点之一
            if (IsInside(x1, y1, x2, y2, x3, y3))
                UpdateNode(node, x3, y3);
            if (IsInside(x1, y1, x2, y2, x4, y4))
                UpdateNode(node, x4, y4);
            if (IsInside(x3, y3, x4, y4, x1, y1))
                UpdateNode(node, x1, y1);
            if (IsInside(x3, y3, x4, y4, x2, y2))
                UpdateNode(node, x2, y2);
        }
    }
    else
    {
        double t1 = (double)(x3 * (y4 - y3) + y1 * (x4 - x3) - y3 * (x4 - x3) - x1 * (y4 - y3)) / ((x2 - x1) * (y4 - y3) - (x4 - x3) * (y2 - y1));
        double t2 = (double)(x1 * (y2 - y1) + y3 * (x2 - x1) - y1 * (x2 - x1) - x3 * (y2 - y1)) / ((x4 - x3) * (y2 - y1) - (x2 - x1) * (y4 - y3));
        // 判断 t1 和 t2 是否均在 [0, 1] 之间
        if (t1 >= 0.0 && t1 <= 1.0 && t2 >= 0.0 && t2 <= 1.0) 
            node = { x1 + t1 * (x2 - x1), y1 + t1 * (y2 - y1) };
    }
    return node;
}
int main()
{
    std::cout << "Hello World!\n";
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
