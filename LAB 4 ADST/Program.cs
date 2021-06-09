using System;

namespace LAB_4_ADST
{
    class Program
    {
        static void Main()
        {
            int[, ] ex = new int[, ] 
            { 
                { 0, 8, 2, 5, 0, 0, 0, 0 },
                { 8, 0, 0, 2, 0, 13, 0, 0 },
                { 2, 0, 0, 2, 5, 0, 0, 0 },
                { 5, 2, 2, 0, 1, 6, 3, 0 },
                { 0, 0, 5, 1, 0, 0, 1, 0 },
                { 0, 13, 0, 6, 0, 0, 2, 3 },
                { 0, 0, 0, 3, 1, 2, 0, 6 },
                { 0, 0, 0, 0, 0, 3, 6, 0 },
            };
            
            MyGraph graph = new MyGraph(ex);

            Dijkstra alg = new Dijkstra(graph);
            
            alg.Traverse(0);
        }
    }
}