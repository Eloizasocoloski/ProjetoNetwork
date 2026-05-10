using System;
using System.Collections.Generic;

public class Network
{

    private Dictionary<int, List<int>> connections;
    private int size;

    public Network() { }

    public Network(int size)
    {
        if (size <= 0)
            throw new ArgumentException("O tamanho deve ser positivo.");

        this.size = size;
        connections = new Dictionary<int, List<int>>();
        for (int i = 0; i < size; i++)
            connections[i] = new List<int>();
    }

    public void Connect(int num1, int num2)
    {
        Validate(num1);
        Validate(num2);

        if (num1 == num2)
            throw new InvalidOperationException("Não é possível conectar um número a ele mesmo.");

        if (connections[num1].Contains(num2))
            throw new InvalidOperationException("A conexão já existe.");

        connections[num1].Add(num2);
        connections[num2].Add(num1);
    }

    public void Disconnect(int num1, int num2)
    {
        Validate(num1);
        Validate(num2);

        if (num1 == num2)
            throw new InvalidOperationException("Não é possível desconectar um número de ele mesmo.");

        if (!connections[num1].Contains(num2))
            throw new InvalidOperationException("A conexão não existe.");

        connections[num1].Remove(num2);
        connections[num2].Remove(num1);
    }

    public int LevelConnection(int a, int b)
    {
        Validate(a);
        Validate(b);

        bool[] visited = new bool[size];
        return SearchLevel(a, b, visited, 0);
    }

    private int SearchLevel(int current, int target, bool[] visited, int level)
    {
        if (current == target)
            return level;

        visited[current] = true;

        foreach (int neighbor in connections[current])
        {
            if (!visited[neighbor])
            {
                int result = SearchLevel(neighbor, target, visited, level + 1);
                if (result != -1)
                    return result;
            }
        }
        return -1;
    }

    public void Validate(int num)
    {
        if (num < 0 || num >= size)
            throw new ArgumentException("Elemento inválido");
    }
}