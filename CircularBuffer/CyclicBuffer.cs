namespace CircularBuffer;

// internal class Node<T>
// {
//     internal required T Value;
//     public Node<T>? Next;
//
//     public Node(T value)
//     {
//         this.Value = value;
//     }
//
// }

public class CyclicBufferContainer<T>
{
    private int Size { get; set; }

    // Obs: it is not an absolute value
    private int CurrIteration { get; set; } = 0; // why get and set ?

    private T[] Buffer { get; set; }

    private int Head = 0;

    private int Tail = 0;

    public CyclicBufferContainer(int size)
    {
        Console.WriteLine("Initializing circular buffer");

        this.Size = size;
        this.Buffer = new T[Size];
    }

    public void Enqueue(T value)
    {
        var idx = Head % Size;
        
        Buffer[idx] = value;
        Head++;
    }

    public T? Dequeue()
    {
        if (IsEmpty())
            return default(T); // what is the default of T in some possible cases
        
        var idx = Tail % Size;
        
        Tail++;
        return Buffer[idx];

    }

    // It means that it could be full aswell 
    private bool IsEmpty() => Head == Tail;
    
}