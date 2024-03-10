using System.Xml.Linq;

namespace BinaryTree
{
    internal class Tree
    {
        public Node<int>? root;
        

        public void replace(int value, Node<int> _node)
        {
            if (root == null)
            {
                root = new Node<int>(value, 0);
            }
            else
            {
                _node.data = value;
            }
        }

        public void Insert(int value, Node<int> _node)
        {
            HelperMethods<int> helper = new();

            helper.insertion(value, _node);
        }

        public void Insert(Node<int> NodeToBeInserted, Node<int> StartingPoint)
        {
            HelperMethods<int> helper = new();

            helper.insertion(NodeToBeInserted, StartingPoint);
        }

        public int search(uint IdToSearch, Node<int> node)
        {
            HelperMethods<int> helper = new HelperMethods<int>();
            if (node is null || !ExistsId(IdToSearch, root))
            {
                return -1;
            }

            return helper._Search(IdToSearch, node, this).data;

            
        }

        public Node<int> searchNode(uint IdToSearch, Node<int> node)
        {
            HelperMethods<int> helper = new HelperMethods<int>();
            if (node == null || !ExistsId(IdToSearch, root))
            {
                return null;
            }

            return helper._Search(IdToSearch, node, this);
        }

        public bool ExistsId(uint IdToSearch, Node<int> node)
        {
            if (node is null)
            {
                return false;
            }

            if (node.Id == IdToSearch)
            {
                return true;
            }
            else if (node.right is not null)
            {
                return ExistsId(IdToSearch, node.right);
            }

            return ExistsId(IdToSearch, node.left);
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
        internal Node<T> _Search(uint Id, Node<T> node, Tree tree)
        {
            if (node is null || !tree.ExistsId(Id, tree.root))
            {
                return null;
            }

            if (Id == node.Id)
            {
                return node;
            }

            Node<T> result = _Search(Id, node.left, tree);
            if (result is not null)
            {
                return result;
            }

            return _Search(Id, node.right, tree);
        }

        internal void insertion(int value, Node<int> _node)
        {
            if (value < _node.data)
            {
                if (_node.left is null)
                {
                    _node.left = new Node<int>(value);
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