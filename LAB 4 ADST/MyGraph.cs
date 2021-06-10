using System;
using System.Drawing;

namespace LAB_4_ADST
{
    public class MyGraph<T>
    {
        public Vertex<T>[] Vertices;
        private int _vertexCount;

        public int VertexCount
        {
            get => _vertexCount;
        }

        public MyGraph(int[,] matrix, T[] values)
        {
            _vertexCount = values.GetLength(0);
            Vertices = new Vertex<T>[_vertexCount];
            
            for (int i = 0; i < VertexCount; i++)
            {
                int[] row = new int[VertexCount];
                
                for (int j = 0; j < VertexCount; j++)
                {
                    row[j] = matrix[i, j];
                }

                Vertices[i] = new Vertex<T>(values[i], row);
            }
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < VertexCount; i++)
            {
                for (int j = 0; j < VertexCount; j++)
                {
                     Console.Write(Vertices[i].Adjacency[j] + " ");
                }
                
                Console.WriteLine();
            }
        }
    }
}