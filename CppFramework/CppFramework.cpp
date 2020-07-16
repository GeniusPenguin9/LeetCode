// CppFramework.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//
using namespace std;
#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
#include <unordered_map>
#include <utility>
#include <bitset>

/* *********************************************************** Tree *********************************************************** */
 struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode(int x) : val(x), left(NULL), right(NULL) {}  
};
 /* 
 *****************************************
    顺序遍历 = > vecter<treenode.val>
 ***************************************** 
 */
 //A-2:顺序遍历的辅助函数
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

 //A-1:顺序遍历，order:1-前序；2-中序；3-后序
 vector<int> orderTraversal(TreeNode* root, int order) {
     vector<int> res;
     AddNode(res, root, order);
     return res;
 }

 //B-1:获取树的最小深度
 int minDepth(TreeNode* root) {
     int res = 0;
     vector<TreeNode*> cur;
     if (root != NULL)
     {
         res++;
         cur.push_back(root);
     }
     while (cur.size() > 0)
     {
         res++;
         vector<TreeNode*> next;
         for (int i = 0; i < cur.size(); i++)
         {
             if (cur[i]->left == NULL && cur[i]->right == NULL)
                 return res;
             else
             {
                 if (cur[i]->left != NULL)
                     next.push_back(cur[i]->left);
                 if (cur[i]->right != NULL)
                     next.push_back(cur[i]->right);
             }
         }
         cur = next;
     }

     return res;
 }

 /* *********************************************************** pair as map's key *********************************************************** */
 struct pair_hash
 {
     template <class T1, class T2>
     std::size_t operator()(const std::pair<T1, T2>& pair)const
     {
         return std::hash<T1>()(pair.first) ^ std::hash<T2>()(pair.second);
     }
 };


int main()
{
    /* ************************* 一维vector的初始化 ************************* */
    // Create an empty vector 
    vector<int> vect1;

    // Create a vector of size 3 with all values as 10. 
    vector<int> vect2(3, 10);

    // CPP program to initialize a vector like an array. 
    vector<int> vect3{ 10, 20, 30 };

    // CPP program to initialize a vector from an array. 
    int arr[] = { 10, 20, 30 };
    int n = sizeof(arr) / sizeof(arr[0]);
    vector<int> vect4(arr, arr + n);

    // CPP program to initialize a vector from another vector. 
    vector<int> vect5(vect4.begin(), vect4.end());

    /* ************************* vector的常用函数 ************************* */
    std::sort(vect5.begin(), vect5.end());
    
    //erases all the elements from the third element to the fifth element.
    //begin() + 2 => vect[2] => 3rd element
    //[a,b)
    vect5.erase(vect5.begin() + 2, vect5.begin() + 5);  

    //搜索范围内全部val=20的元素并删除，返回Iterator that store the position of last element 
    //!!注意，此时(vect5.pend(),vect5.end()]还是可以访问到，还是原来的数据=。= 
    //!!.size()还是remove前的长度=。=
    std::vector<int>::iterator pend;
    pend = std::remove(vect5.begin(), vect5.end(), 20);

    //连接2个vector
    vect5.insert(vect5.end(), vect3.begin(), vect3.end());

    /* ************************* 二维vector的初始化 ************************* */
    // row * col, all default val = 3
    #define row 2
    #define col 3
    vector<vector<int>> vect_matrix1(row, vector<int>(col, 3));
    
    
    /* ************************* unordered_map的初始化、查找 ************************* */
    unordered_map<int, int>map;
    map.insert({ 3,30 });
    map.insert({ 1,10 });
    for (auto it = map.find(3); it != map.end(); it++)
        cout << "key:" << it->first << '\t' << "value:" << it->second << '\n';

    /* ************************* 使用pair作为map的key ************************* */
    unordered_map<pair<string,string>, int, pair_hash> umap_strstr = { {{"AA","BB"},100 },
                                                {{"CC","DD"},300 } };
    for (auto const& entry : umap_strstr)
    {
        auto key_pair = entry.first;
        //cout << "key:" << key_pair.first << ',' << key_pair.second << '\t' << "value:" << entry.second << '\n';
    }

    unordered_map<pair<char,int>, int, pair_hash> umap_chrint = { {{'A',10},100 },
                                                {{'B',3},300 } };
    for (auto const& entry : umap_chrint)
    {
        auto key_pair = entry.first;
        //cout << "key:" << key_pair.first << ',' << key_pair.second << '\t' << "value:" << entry.second << '\n';
    }
    auto it = umap_chrint.find({ 'A',10 });
    //if (it != umap_chrint.end())
    //    cout << "find it:" <<it->second << '\n';
    
    /* ************************* 二进制 ************************* */
    bitset<32> bs(15);//u32 => 0000 0000 0000 1111

}

