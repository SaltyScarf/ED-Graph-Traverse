using System;

namespace LAB_4_ADST
{
    public class MyEdge : IComparable<MyEdge> 
    {
        public int Source;
        public int Destination;
        public int Weight;

        public MyEdge(int src, int dest, int weight)
        {
            Source = src;
            Destination = dest;
            Weight = weight;
        }
        
        public int CompareTo(MyEdge compareEdge)
        {
            return this.Weight - compareEdge.Weight;
        }
    }
}