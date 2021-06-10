using System;

namespace LAB_4_ADST
{
    public class Kruskal<T>
    {
        private MyGraph<T> _graph;
        private int[] _parent;

        public Kruskal(MyGraph<T> graph)
        {
            _graph = graph;
            _parent = new int[graph.VertexCount];
        }

        public void FindMST()
        {
            PrintSolution(Algorithm());
        }
    
        private int FindSet(int i)
        {
            while (_parent[i] != i)
            {
                i = _parent[i];
            }
            
            return i;
        }
        
        private void UniteEdge(int i, int j)
        {
            int a = FindSet(i);
            int b = FindSet(j);
            _parent[a] = b;
        }

        private int Algorithm()
        {
            int mincost = 0;

            for (int i = 0; i < _graph.VertexCount; i++)
            {
                _parent[i] = i;
            }

            int edgeCount = 0;
            while (edgeCount < _graph.VertexCount - 1)
            {
                int min = int.MaxValue;
                int a = -1;
                int b = -1;
                
                for (int i = 0; i < _graph.VertexCount; i++)
                {
                    for (int j = 0; j < _graph.VertexCount; j++)
                    {
                        if (FindSet(i) != FindSet(j) && _graph.Vertices[i].Adjacency[j] < min && _graph.Vertices[i].Adjacency[j] != 0)
                        {
                            min = _graph.Vertices[i].Adjacency[j];
                            a = i;
                            b = j;
                        }
                    }
                }

                UniteEdge(a, b);
                
                PrintEdge(edgeCount++, a, b, min);
                
                mincost += min;
            }

            return mincost;
        }

        private void PrintEdge(int edgeNumber, int edgeStart, int edgeEnd, int cost)
        {
            Console.Write("Edge {0}:({1}, {2}) cost:{3} \n", edgeNumber, edgeStart, edgeEnd, cost);
        }

        private void PrintSolution(int mincost)
        {
            Console.WriteLine("The minimal cost of MST is: {0}", mincost);
        }
    }
}