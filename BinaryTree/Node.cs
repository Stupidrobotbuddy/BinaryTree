namespace BinaryTree
{
    internal class Node<T>
    {
        private static uint GlobalId = 1;

        public uint Id { get; }
        public T data;
        public Node<T>? parent;
        public Node<T>? right;
        public Node<T>? left;

        public Node(T _data)
        {
            Id = GlobalId++;
            data = _data;
            parent = null;
            right = null;
            left = null;
        }

        public Node(T _data, uint Id)
        {
            this.Id = Id;
            data = _data;
            parent = null;
            right = null;
            left = null;
        }
    }
}