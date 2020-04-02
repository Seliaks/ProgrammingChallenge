namespace ProgramChallenge
{
    public class List
    {
        private ListItem _head;
        private int _length = 0;

        public void Deconstruct(out int length)
        {
            length = _length;
        }

        public List()
        {
            
        }
        
        public List(ListItem head)
        {
            _head = head;
        }
        
        
    }
}