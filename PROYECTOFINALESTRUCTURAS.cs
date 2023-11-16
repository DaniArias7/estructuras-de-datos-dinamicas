//PROYECTO FINAL
// DANIEL ALZATE

using System;
using System.Collections.Generic;

public class BinaryTree
{
    public int Value { get; set; }
    public BinaryTree Parent { get; set; }
    public BinaryTree Left { get; set; }
    public BinaryTree Right { get; set; }

    public BinaryTree(int value, BinaryTree parent = null, BinaryTree left = null, BinaryTree right = null)
    {
        Value = value;
        Parent = parent;
        Left = left;
        Right = right;
    }
}

public class TreeOrder
{
    public static void InOrder(BinaryTree root, Action<BinaryTree> callback)
    {
        if (root == null)
        {
            throw new ArgumentNullException(nameof(root), "El árbol no puede ser nulo.");
        }

        if (callback == null)
        {
            throw new ArgumentNullException(nameof(callback), "La función de devolución de llamada no puede ser nula.");
        }

        Stack<BinaryTree> stack = new Stack<BinaryTree>();
        BinaryTree currentNode = root;

        while (currentNode != null || stack.Count > 0)
        {
            while (currentNode != null)
            {
                stack.Push(currentNode);
                currentNode = currentNode.Left;
            }

            currentNode = stack.Pop();
            callback(currentNode);
            currentNode = currentNode.Right;
        }
    }
}

class Program
{
    static void Main()
    {
        // Ejemplo de uso
        BinaryTree root = new BinaryTree(1);
        root.Left = new BinaryTree(2, root);
        root.Right = new BinaryTree(3, root);
        root.Left.Left = new BinaryTree(4, root.Left);
        root.Left.Left.Right = new BinaryTree(9, root.Left.Left);
        root.Right.Left = new BinaryTree(6, root.Right);
        root.Right.Right = new BinaryTree(7, root.Right);

        // Definir la función de devolución de llamada
        Action<BinaryTree> callback = (node) => Console.WriteLine($"callback({node.Value})");

        // Realizar el recorrido in-order 
        try
        {
            TreeOrder.InOrder(root, callback);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se produjo una excepción: {ex.Message}");
        }
    }
}
