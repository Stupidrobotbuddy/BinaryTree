namespace BinaryTree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Tree BST = new();
            BST.replace(1, null);
            BST.Insert(4, BST.root);

            Console.WriteLine(BST.search(1, BST.root));
            Console.ReadLine();

            BST.Delete(0, BST.root);

            Console.WriteLine(BST.ExistsId(0, BST.root));
            Console.ReadLine();
        }
    }
}