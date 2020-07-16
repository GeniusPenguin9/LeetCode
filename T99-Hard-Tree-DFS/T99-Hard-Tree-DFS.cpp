// T99-Hard-Tree-DFS.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include <vector>
using namespace std;
struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode(int x) : val(x), left(NULL), right(NULL) {}

};

class Solution {
public:
    void recoverTree(TreeNode* root) {
        auto vec = orderTraversal(root, 2);
        TreeNode min = TreeNode(INT32_MIN);
        TreeNode max = TreeNode(INT32_MAX);
        vec.insert(vec.begin(), {min});
        vec.push_back(max);
        int n = vec.size();
        auto first = -1;
        auto seconde = -1;
        for (int i = 1; i < n-1; i++)
        {
            if (vec[i].val<vec[i - 1].val || vec[i].val>vec[i + 1].val)
            {
                if (first == -1)
                    first = i;
                else
                {
                    seconde = i;
                    break;
                }
            }
        }
        auto tmp = vec[first].val;
        vec[first].val = vec[seconde].val;
        vec[seconde].val = tmp;
        return;
    }
    //A-2:顺序遍历的辅助函数
    void AddNode(vector<TreeNode>& vec, TreeNode* node, int order)
    {
        if (node == NULL)
            return;
        if (order == 1)
        {
            vec.push_back(*node);
            AddNode(vec, node->left, 1);
            AddNode(vec, node->right, 1);
        }
        else if (order == 2)
        {
            AddNode(vec, node->left, 2);
            vec.push_back(*node);
            AddNode(vec, node->right, 2);
        }
        else if (order == 3)
        {
            AddNode(vec, node->left, 3);
            AddNode(vec, node->right, 3);
            vec.push_back(*node);
        }
    }

    //A-1:顺序遍历，order:1-前序；2-中序；3-后序
    vector<TreeNode> orderTraversal(TreeNode* root, int order) {
        vector<TreeNode> res;
        AddNode(res, root, order);
        return res;
    }
};
int main()
{
    std::cout << "Hello World!\n";
}

