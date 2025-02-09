using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            Console.WriteLine($"Stack Overflow: Cannot push {value}, {Name} stack is full.");
            return;
        }
        data[++top] = value;
        Console.WriteLine($"Pushed {value} to {Name}.");
    }

    public void _Push(int value)
    {
        if (top >= Size - 1)
        {
            Console.WriteLine($"Stack Overflow: Cannot push {value}, {Name} stack is full.");
            return;
        }
        data[++top] = value;
        
    }

    public int Pop()
    {
        if (top < 0)
        {
            Console.WriteLine($"Stack Underflow: Cannot pop, {Name} stack is empty.");
            return -1;
        }
        return data[top--];
    }

    // Read-only indexer
    public int this[int index]
    {
        get { return data[index]; }
    }

    public void PrintStack()
    {
        if (top < 0)
        {
            Console.WriteLine($"{Name} stack is empty.");
            return;
        }
        Console.Write($"\n {Name} :");
        for (int i = top; i >= 0; i--)
        {
            Console.Write(" " + data[i] + " ");
        }
        Console.WriteLine("\n ");
    }

    // Combine two stacks into one
    public static Stack operator + (Stack s1, Stack s2)
    {
        Stack s3 = new Stack(s1.Size + s2.Size, "S3");
        Console.WriteLine("\nCombine S1 & S2 into S3 :");
        for (int i = 0; i <= s1.top; i++)
        {
            s3._Push(s1.data[i]);
        }

        for (int i = 0; i <= s2.top; i++)
        {
            s3._Push(s2.data[i]);
        }

        return s3;
    }


    // Convert Stack to Array -Imlicit Conversion
    public static implicit operator int[](Stack stack)
    {
        int[] array = new int[stack.top + 1];
        for (int i = 0; i <= stack.top; i++)
        {
            array[i] = stack.data[i];
        }
        return array;
    }


    // Convert Array to Stack -Explicit Conversion
    public static explicit operator Stack(int[] array)
    {
        Stack newStack = new Stack(array.Length, "ConvertedStack");
        foreach (int value in array)
        {
            newStack._Push(value);
        }
        return newStack;
    }
}

class Program
{
    static void Main()
    {
        // Stack S1
        Stack S1 = new Stack(2, "S1");
        S1.Push(1);
        S1.Push(2);

        // Stack S2
        Stack S2 = new Stack(3, "S2");
        S2.Push(3);
        S2.Push(4);
        S2.Push(5);

        // Combine S1 and S2 into S3
        Stack S3 = S1 + S2;
        S3.PrintStack();


        Console.WriteLine("\n............... S4 ...........\n");
        // Stack S4
        Stack S4 = new Stack(3, "S4");
        S4.Push(10);
        S4.Push(20);
        S4.Push(30);

        // Access element using the indexer
        Console.WriteLine($"\nElement at index 1 in S4: {S4[1]}");

        Console.WriteLine("\n...............Convert S4 to Array...........\n");

        // Convert Stack to Array -Imlicit Conversion
        int[] arrayFromStack = S4;
        Console.Write("\n S4 converted to array: ");
        Console.WriteLine($"[{string.Join(", ", arrayFromStack)}]");

        Console.WriteLine("\n...............Convert Array to S5...........\n");

        // Convert Array to Stack -Explicit Conversion

        Stack S5 = (Stack)arrayFromStack;
        S5.PrintStack();
    }
}
