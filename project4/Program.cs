using System;

class Stack
{
    private int[] data;
    private int top;
    public int Size { get; private set; }
    public string Name { get; set; }

    public Stack(int size, string name)
    {
        Size = size;
        Name = name;
        data = new int[size];
        top = -1;
    }

    public void Push(int value)
    {
        if (top >= Size - 1)
        {
            Console.WriteLine($"Stack Overflow: Cannot push {value}, {Name}  is full.");
            return;
        }
        data[++top] = value;
        Console.WriteLine($"Pushed {value} to {Name} ");
    }

    public int Pop()
    {
        if (top < 0)
        {
            Console.WriteLine($"Stack Underflow: Cannot pop, {Name}  is empty.");
            return -1;
        }
        return data[top--];
    }

    // Read-only indexer
    public int this[int index]
    {
        get{ return data[index]; }
    }

    public void PrintStack()
    {
        if (top < 0)
        {
            Console.WriteLine($"{Name}  is empty.");
            return;
        }
        Console.Write($"\n{Name} : ");
        for (int i = top; i >= 0; i--)
        {
            Console.Write(" "+data[i] + " ");
        }
        Console.WriteLine();
    }


    public static Stack operator +(Stack s1, Stack s2)
    {
        Stack s3 = new Stack(s1.Size + s2.Size, "S3");


        for (int i = 0; i <= s1.top; i++)
        {
            s3.Push(s1.data[i]);
        }


        for (int i = 0; i <= s2.top; i++)
        {
            s3.Push(s2.data[i]);
        }

        return s3;
    }

    // Implicit conversion from Stack to int[]
    public static implicit operator int[](Stack stack)
    {
        int[] array = new int[stack.top + 1];
        for (int i = 0; i <= stack.top; i++)
        {
            array[i] = stack.data[i];
        }
        return array;
    }

    // Explicit conversion from int[] to Stack
    public static explicit operator Stack(int[] array)
    {
        Stack newStack = new Stack(array.Length, "ConvertedStack ");
        foreach (int value in array)
        {
            newStack.Push(value);
        }
        return newStack;
    }
}

class Program
{
    static void Main()
    {
        Stack S4 = new Stack(3, "S1");

        S4.Push(10);
        S4.Push(20);
        S4.Push(30);

        
        Console.WriteLine($"\n Element at index 1 in S1: {S4[1]}");

        // Convert Stack to Array - Implicit Conversion

        int[] arrayFromStack = S4;
        Console.Write("\nStack converted to array:  ");

        foreach (var value in arrayFromStack)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine("\n");

        // Convert Array to Stack - Explicit Conversion

        int[] newArray = { 5, 15, 25, 35 };
        Stack S5 = (Stack)newArray;
        S5.PrintStack();
    }
}











//Console.WriteLine(string.Join(", ", arrayFromStack));
