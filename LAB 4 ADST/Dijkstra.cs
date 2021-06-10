using System;
using System.Collections.Generic;

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
            int[] lastHop;
            PrintSolution(Algorithm(source, out lastHop), source, lastHop);
        }

        private int[] Algorithm(int src, out int[] lastHop)
        {
            int[] distances = new int[_graph.VertexCount];

            bool[] included = new bool[_graph.VertexCount];

            int[] tempHop = new int[_graph.VertexCount];

            for (int i = 0; i < _graph.VertexCount; i++)
            {
                distances[i] = int.MaxValue;
                included[i] = false;
            }

            distances[src] = 0;

            for (int count = 0; count < _graph.VertexCount - 1; count++)
            {
                int shortestDistInd = MinDistance(distances, included);

                included[shortestDistInd] = true;

                for (int v = 0; v < _graph.VertexCount; v++)
                {
                    if (!included[v] && _graph.Vertices[shortestDistInd].Adjacency[v] != 0
                                   && distances[shortestDistInd] + _graph.Vertices[shortestDistInd].Adjacency[v] < distances[v])
                    {
                        distances[v] = distances[shortestDistInd] + _graph.Vertices[shortestDistInd].Adjacency[v];
                        tempHop[v] = shortestDistInd;
                    }
                }

            }

            lastHop = tempHop;

            return distances;
        }

        private int MinDistance(int[] distances, bool[] included)
        {
            int minValue = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < _graph.VertexCount; v++)
            {
                if (included[v] == false && distances[v] <= minValue)
                {
                    minValue = distances[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private int GetSourceNextHop(List<int> path)
        {
            return path[1];
        }

        private List<int> GetPathFromSource(int[] lastHop, int source, int destination)
        {
            List<int> path = new List<int>();

            int currentVertex = destination;
            
            path.Add(currentVertex);

            if (currentVertex == source)
            {
                path.Add(source);
                return path;
            }

            while (currentVertex != source)
            {
                path.Add(lastHop[currentVertex]);
                currentVertex = lastHop[currentVertex];
            }

            path.Reverse();

            return path;
        }

        private void PrintSolution(int[] distances, int source, int[] lastHop)
        {
            Console.WriteLine("Source: " + source + "\n");
            Console.Write($"Vertex     ShortestPath     Next Hop\n");
            
            for (int i = 0; i < _graph.VertexCount; i++)
            {
                int nextHope = GetSourceNextHop(GetPathFromSource(lastHop, source, i));
                Console.Write(i + " \t\t " + distances[i] + " \t\t " + nextHope + "\n");
            }
        }
    }
}