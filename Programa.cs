using System;

class Programa
{
    static void Main(string[] args)
    {
        var network = new Network(9);

        network.Connect(1, 2);
        network.Connect(6, 2);
        network.Connect(2, 4);
        network.Connect(5, 8);

        Console.WriteLine($"1 e 6 estão conectados? {network.IsConnected(1, 6)}");
        Console.WriteLine($"6 e 4 estão conectados? {network.IsConnected(6, 4)}");
        Console.WriteLine($"7 e 4 estão conectados? {network.IsConnected(7, 4)}");
        Console.WriteLine($"5 e 6 estão conectados? {network.IsConnected(5, 6)}");

        Console.WriteLine("\n NÍVEL DE CONEXÃO--------------------\n");

        Console.WriteLine($"Nível entre 1 e 6: {network.LevelConnection(1, 6)}");
        Console.WriteLine($"Nível entre 1 e 2: {network.LevelConnection(1, 2)}");
        Console.WriteLine($"Nível entre 6 e 4: {network.LevelConnection(6, 4)}");
        Console.WriteLine($"Nível entre 5 e 8: {network.LevelConnection(5, 8)}");
        Console.WriteLine($"Nível entre 7 e 4: {network.LevelConnection(7, 4)}");
    }
}