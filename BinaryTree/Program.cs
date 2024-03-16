namespace BinaryTree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Tree BST = new();
            BST.Insert(4);

            Console.WriteLine(BST.search(1));
            Console.ReadLine();

            BST.Insert(5);
            BST.Insert(5);

            Console.WriteLine(BST.FindLevel(BST.root));
            Console.ReadLine();
        }
    }
}