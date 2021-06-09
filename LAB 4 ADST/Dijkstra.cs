using System;

namespace LAB_4_ADST
{
    public class Dijkstra
    {
        private MyGraph _graph;

        public Dijkstra(MyGraph graph)
        {
            _graph = graph;
        }

        public void Traverse(int source)
        {
            Algorithm(source);
        }

        private void Algorithm(int src)
        {
            int[] dist = new int[_graph.VertexCount];

            bool[] sptSet = new bool[_graph.VertexCount];

            for (int i = 0; i < _graph.VertexCount; i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            dist[src] = 0;

            for (int count = 0; count < _graph.VertexCount - 1; count++)
            {
                int u = MinDistance(dist, sptSet);

                sptSet[u] = true;

                for (int v = 0; v < _graph.VertexCount; v++)
                {
                    if (!sptSet[v] && _graph.Matrix[u, v] != 0
                                   && dist[u] != int.MaxValue && dist[u] + _graph.Matrix[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + _graph.Matrix[u, v];
                    }
                }

            }
        }

        private int MinDistance(int[] dist, bool[] sptSet)
        {
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < _graph.VertexCount; v++)
            {
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }
            }

            return min_index;
        }

        private void PrintSolution(int[] dist, int n)
        {
            Console.Write("Vertex     ShortestPath "
                          + "from Source\n");
            for (int i = 0; i < _graph.VertexCount; i++)
            {
                Console.Write(i + " \t\t " + dist[i] + "\n");
            }
        }
    }
}