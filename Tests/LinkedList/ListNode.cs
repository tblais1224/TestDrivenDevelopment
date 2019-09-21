namespace Tests
{
    public class ListNode<T>
    {
        public ListNode(T value)
        {
            Value = value;
        }

        public ListNode<T> Next { get; set; }
        public T Value { get; set; }
    }
}