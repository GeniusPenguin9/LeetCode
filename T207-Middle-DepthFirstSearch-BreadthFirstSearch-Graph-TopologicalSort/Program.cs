using System;
using System.Collections.Generic;
using System.Linq;

namespace T207_Middle_DepthFirstSearch_BreadthFirstSearch_Graph_TopologicalSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = CanFinish(2, new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } });
            var res1 = CanFinish(2, new int[][] { new int[] { 1, 0 } });
        }

        // 参考题解优化
        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            int[] inDegree = new int[numCourses];   //用于记录每个节点的入度，即当前有多少条边指向该节点
            Dictionary<int, List<int>> outVertex = new Dictionary<int, List<int>>();    //用于记录以每个点为顶端，指向的节点List，即从key指向item in list
            for(var i = 0; i < numCourses; i++)
            {
                outVertex.Add(i, new List<int>());
            }

            //[to, from]
            foreach(var i in prerequisites)
            {
                inDegree[i[0]]++;
                outVertex[i[1]].Add(i[0]);
            }

            Queue<int> queue = new Queue<int>();
            for(var i = 0; i < numCourses; i++)
            {
                if (inDegree[i] == 0)
                    queue.Enqueue(i);
            }

            var delectcount = 0;
            while(queue.Count() > 0)
            {
                var from = queue.Dequeue();
                delectcount++;
                foreach (var to in outVertex[from])
                {
                    inDegree[to]--;
                    if (inDegree[to] == 0)
                        queue.Enqueue(to);
                }
            }
            return delectcount == numCourses;
        }

        /* 下记写法问题：遍历LIST耗时较长，造成整体算例超时；
        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            List<Edge> listEdges = new List<Edge>();
            foreach (var edge in prerequisites)
                listEdges.Add(new Edge(edge[1], edge[0]));

            var listElement = Enumerable.Range(0, numCourses).ToList();
            int delectnum = 0;
            while(delectnum != numCourses)
            {
                var judgecount = 0;
                var targetcount = listElement.Count();
                foreach(var i in listElement)
                {
                    judgecount++;
                    if (listEdges.Count(item => item.endVertex == i) == 0)
                    {
                        listEdges.RemoveAll(item => item.startVertex == i);
                        listElement.Remove(i);
                        delectnum++;
                        break;
                    }
                    if (judgecount == targetcount)
                        return false;
                }  
            }
            return true;
        }
        class Edge
        {
            public int startVertex;
            public int endVertex;
            public Edge(int startVertex, int endVertex)
            {
                this.startVertex = startVertex;
                this.endVertex = endVertex;
            }
        }
        */
    }
}
