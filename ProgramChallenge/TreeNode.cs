namespace ProgramChallenge
{
    public class TreeNode
    {
        private TreeNode _parent;
        private TreeNode _rightChild;
        private TreeNode _leftChild;
        
        public TreeNode(TreeNode parent, string data) : base(data)
        {
            _parent = parent;
        }
        
        public TreeNode(TreeNode parent, int data) : base(data)
        {
            _parent = parent;
        }
        
        public TreeNode(TreeNode parent, char data) : base(data)
        {
            _parent = parent;
        }

        public void SetRightChild(TreeNode rightChild)
        {
            _rightChild = rightChild;
        }

        public void SetLeftChild(TreeNode leftChild)
        {
            _leftChild = leftChild;
        }

        public TreeNode GetRightChild()
        {
            return _rightChild;
        }

        public TreeNode GetLeftChild()
        {
            return _leftChild;
        }
    }
}