namespace DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Last { get; set; }

        private DoublyLinkedListNode<T> Current { get; set; }

        public DoublyLinkedList()
        {
            Head = Last = Current = null;
        }

        public void Add(T data)
        {
            DoublyLinkedListNode<T> node = new DoublyLinkedListNode<T>(data);

            if (Head == null)
            {
                Head = node;
                Current = Head;
            }
            else
            {
                Last.Next = node;
                node.Previous = Last;
            }
            Last = node;
        }

        public void MoveForward()
        {
            Current =
                Current.Next == null
                ?
                Current
                :
                Current.Next
                ;
        }

        public void MoveBackward()
        {
            Current =
                Current.Previous == null
                ?
                Current
                :
                Current.Previous
                ;
        }

        public T GetCurrent()
        {
            return
                Current == null
                ?
                default(T)
                :
                Current.Data
                ;
        }

        public T GetNext()
        {
            return
                Current.Next == null
                ?
                default(T)
                :
                Current.Next.Data
                ;
        }

        public T GetPrevious()
        {
            return
                Current.Previous == null
                ?
                default(T)
                :
                Current.Previous.Data
                ;
        }

    }
}
