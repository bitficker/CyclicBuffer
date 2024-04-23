namespace CircularBuffer;

public class CyclicBufferContainer<T>
{
    private int Size { get; set; }
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
    
    private bool IsEmpty() => Head == Tail;
    
}