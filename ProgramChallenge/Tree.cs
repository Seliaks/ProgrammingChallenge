namespace ProgramChallenge
{
    public class Tree
    {
        private TreeNode _head;

        public Tree(TreeNode head)
        {
            _head = head;
        }

        public Tree()
        {
        }

        public void AddNode(TreeNode newNode)
        {
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                TreeNode current = _head;
                if (newNode.GetData() > current.GetData())
                {
                    
                }
            }
        }
    }
}