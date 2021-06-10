using System;

namespace LAB_4_ADST
{
    public class Dijkstra<T>
    {
        private MyGraph<T> _graph;

        public Dijkstra(MyGraph<T> graph)
        {
            _graph = graph;
        }

        public void Traverse(int source)
        {
            PrintSolution(Algorithm(source), source);
        }

        private int[] Algorithm(int src)
        {
            int[] distances = new int[_graph.VertexCount];

            bool[] sptSet = new bool[_graph.VertexCount];

            for (int i = 0; i < _graph.VertexCount; i++)
            {
                distances[i] = int.MaxValue;
                sptSet[i] = false;
            }

            distances[src] = 0;

            for (int count = 0; count < _graph.VertexCount - 1; count++)
            {
                int u = MinDistance(distances, sptSet);

                sptSet[u] = true;

                for (int v = 0; v < _graph.VertexCount; v++)
                {
                    if (!sptSet[v] && _graph.Vertices[u].Adjacency[v] != 0
                                   && distances[u] + _graph.Vertices[u].Adjacency[v] < distances[v])
                    {
                        distances[v] = distances[u] + _graph.Vertices[u].Adjacency[v];
                    }
                }

            }

            return distances;
        }

        private int MinDistance(int[] distances, bool[] sptSet)
        {
            int minValue = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < _graph.VertexCount; v++)
            {
                if (sptSet[v] == false && distances[v] <= minValue)
                {
                    minValue = distances[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private void PrintSolution(int[] distances, int source)
        {
            Console.Write($"Vertex     ShortestPath from {0}\n", source);
            for (int i = 0; i < _graph.VertexCount; i++)
            {
                Console.Write(i + " \t\t " + distances[i] + "\n");
            }
        }
    }
}