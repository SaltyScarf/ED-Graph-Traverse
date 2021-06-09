using System;
using System.Drawing;

namespace LAB_4_ADST
{
    public class MyGraph
    {
        public int[,] Matrix;
        private int _vertexCount;

        public int VertexCount
        {
            get => _vertexCount;
        }

        public MyGraph(int vertexCount)
        {
            Matrix = new int[vertexCount, vertexCount];
            _vertexCount = vertexCount;
        }

        public MyGraph(int[,] matrix)
        {
            Matrix = matrix;
            _vertexCount = matrix.GetLength(0);
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < VertexCount; i++)
            {
                for (int j = 0; j < VertexCount; j++)
                {
                     Console.Write(Matrix[i,j] + " ");
                }
                
                Console.WriteLine();
            }
        }
    }
}