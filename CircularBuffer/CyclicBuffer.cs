using System.Text;

namespace CircularBuffer;

public class CyclicBufferContainer<T> 
{
    private int Size { get; set; }
    private T[] Buffer { get; set; }

    private int Head = 0; // Write

    private int Tail = 0; // Read

    public CyclicBufferContainer(int size)
    {
        Console.WriteLine("Initializing circular buffer");

        this.Size = size;
        this.Buffer = new T[Size];
    }

    public int Enqueue(T value)
    {
        if (IsFull()) return 0;

        if (Head == Size - 1)
        {
            Head = 0;
        }
        else
        {
            Head++;
        }
        
        Buffer[Head] = value;
        Head++;

        return 1;
    }
    public T? Dequeue()
    {
        if (IsEmpty())
            return default(T); // what is the default of T in some possible cases
        
        Tail++;
        return Buffer[Tail];
    }
    private bool IsEmpty() => Head == Tail;
    private bool IsFull() => Head - 1 == Tail || (Head == Size - 1 && Tail == 0);
    public override string ToString()
    {
        var builder = new StringBuilder(Size);

        foreach (var elem in Buffer)
            builder.Append(elem);

        
        return builder.ToString();
    }
    
}