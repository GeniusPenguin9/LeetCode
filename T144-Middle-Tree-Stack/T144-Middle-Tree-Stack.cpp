// T144-Middle-Tree-Stack.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
using namespace std;
#include <vector>

struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode(int x) : val(x), left(NULL), right(NULL) {}

};

class Solution {
public:
    //顺序遍历，order:1-前序；2-中序；3-后序
    vector<int> orderTraversal(TreeNode* root, int order) {
        vector<int> res;
        AddNode(res, root, order);
        return res;
    }
    void AddNode(vector<int>& vec, TreeNode* node, int order)
    {
        if (node == NULL)
            return;
        if (order == 1)
        {
            vec.push_back(node->val);
            AddNode(vec, node->left, 1);
            AddNode(vec, node->right, 1);
        }
        else if (order == 2)
        {
            AddNode(vec, node->left, 2);
            vec.push_back(node->val);
            AddNode(vec, node->right, 2);
        }
        else if (order == 3)
        { 
            AddNode(vec, node->left, 3);
            AddNode(vec, node->right, 3);
            vec.push_back(node->val);
        }
    }
};
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
