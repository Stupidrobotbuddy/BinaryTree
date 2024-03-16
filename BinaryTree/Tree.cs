using System.Xml.Linq;

namespace BinaryTree
{
    internal class Tree
    {
        internal Node<int>? root;
        internal Dictionary<uint, Node<int>> NodeList = new Dictionary<uint, Node<int>>();
        

        public void replace(int value, uint Id)
        {
            if (!ExistsId(Id))
            {
                return;
            }

            NodeList[Id].data = value;
        }

        public void Insert(int value)
        {
            HelperMethods<int> helper = new();
            if (root == null)
            {
                root = new Node<int>(value);
                NodeList.Add(root.Id, root);
                return;
            }

            helper.insertion(value, root);
        }

        public void Insert(Node<int> NodeToBeInserted, Node<int> StartingPoint)
        {
            HelperMethods<int> helper = new();
            if (root == null)
            {
                root = NodeToBeInserted;
                return;
            }

            helper.insertion(NodeToBeInserted, StartingPoint);
        }

        public int search(uint IdToSearch)
        {
            return NodeList[IdToSearch].data;
        }

        public Node<int> searchNode(uint IdToSearch, Node<int> node)
        {
            return NodeList[IdToSearch];
        }

        public bool ExistsId(uint IdToSearch)
        {
            return NodeList.ContainsKey(IdToSearch);
        }

        //Solution from: https://www.baeldung.com/cs/binary-tree-height#:~:text=The%20height%20of%20a%20binary%20tree%20is%20the%20height%20of,the%20depth%20of%20the%20tree.
        public int FindHeight(Node<int> root) 
        {
            if (root == null)
            {
                return 0;
            }

            int LeftHeight = FindHeight(root.left);
            int RightHeight = FindHeight(root.right);
            return Math.Max(LeftHeight, RightHeight) + 1;
        }

        public int FindSize(Node<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            int LeftSize = FindSize(root.left);
            int RightSize = FindSize(root.right);
            return 1 + LeftSize + RightSize;
        }

        public int FindLevel(Node<int> root)
        {
            if (root == null){
                return 0;
            }
            if (root.right == null && root.left == null)
            {
                return 0;
            }
            int LeftRoot = FindLevel(root.left);
            int RightRoot = FindLevel(root.right);
            return Math.Max(LeftRoot, RightRoot) + 1;

        }
    }

    internal class HelperMethods<T>
    {

        internal void insertion(int value, Node<int> _node)
        {
            if (value < _node.data)
            {
                if (_node.left is null)
                {
                    _node.left = new Node<int>(value);
                    Tree.NodeList.Add(_node.left.Id, _node.left);
                    _node.left.parent = _node;
                }
                else
                {
                    insertion(value, _node.left);
                }
            }
            else if (value > _node.data)
            {
                if (_node.right is null)
                {
                    _node.right = new Node<int>(value);
                    Tree.NodeList.Add(_node.right.Id, _node.right);
                    _node.right.parent = _node;
                }
                else
                {
                    insertion(value, _node.right);
                }
            }
        }

        internal void insertion(Node<int> NodeToBeInserted, Node<int> _node)
        {
            if (_node is null) { return; }

            if (NodeToBeInserted.data < _node.data)
            {
                if (_node.left is null)
                {
                    _node.left = NodeToBeInserted;
                    Tree.NodeList.Add(_node.left.Id, _node.left);
                    NodeToBeInserted.parent = _node;
                }
                else
                {
                    insertion(NodeToBeInserted, _node.left);
                }
            }

            else if (NodeToBeInserted.data > _node.data)
            {
                if (_node.right is null)
                {
                    _node.right = NodeToBeInserted;
                    Tree.NodeList.Add(_node.right.Id, _node.right);
                    NodeToBeInserted.parent = _node;
                }
                else
                {
                    insertion(NodeToBeInserted, _node.right);
                }
            }
        }
    }
}