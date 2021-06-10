namespace LAB_4_ADST
{
    public class Vertex<T>
    {
        public T Value { get; set; }
        public int[] Adjacency { get; set; }

        public Vertex(T value, int[] adjacency)
        {
            Value = value;
            Adjacency = adjacency;
        }
    }
}