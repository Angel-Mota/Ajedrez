using System;

class Program
{
    static char[,] board = new char[8, 8];

    static void Main()
    {
        InitializeBoard();
        PrintBoard();

        while (true)
        {
            Console.WriteLine("Ingrese la posición actual y la posición a la que desea moverse (por ejemplo, a2 a4): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
            {
                break;
            }

            if (IsValidMove(input))
            {
                MakeMove(input);
                PrintBoard();
            }
            else
            {
                Console.WriteLine("Movimiento no válido. Inténtelo de nuevo.");
            }
        }
    }

    static void InitializeBoard()
    {
        // Inicializar el tablero con peones
        for (int i = 0; i < 8; i++)
        {
            board[1, i] = 'P'; // Peones blancos
            board[6, i] = 'p'; // Peones negros
        }
    }

    static void PrintBoard()
    {
        Console.Clear();
        Console.WriteLine("    a   b   c   d   e   f   g   h");
        Console.WriteLine("  +-------------------------------+");

        for (int i = 0; i < 8; i++)
        {
            Console.Write(8 - i + " |");
            for (int j = 0; j < 8; j++)
            {
                Console.Write(board[i, j] != 0 ? " " + board[i, j] + " |" : "   |");
            }
            Console.WriteLine("\n  +-------------------------------+");
        }
    }

    // Reemplaza la función IsValidMove con esta versión modificada
    // Reemplaza la función IsValidMove con esta versión modificada
    static bool IsValidMove(string move)
    {
        if (move.Length != 5)
        {
            return false;
        }

        int fromFile = move[0] - 'a';
        int fromRank = '8' - move[1];
        int toFile = move[3] - 'a';
        int toRank = '8' - move[4];

        if (fromFile < 0 || fromFile > 7 || fromRank < 0 || fromRank > 7 ||
            toFile < 0 || toFile > 7 || toRank < 0 || toRank > 7)
        {
            return false;
        }

        // Validar que la pieza seleccionada sea un peón
        if (char.ToLower(board[fromRank, fromFile]) != 'p')
        {
            return false;
        }

        // Validar que el movimiento sea válido para un peón
        if (fromFile != toFile || Math.Abs(toRank - fromRank) > 2)
        {
            return false;
        }

        // Validar el primer movimiento especial de dos casillas
        if (fromRank == 6 && Math.Abs(toRank - fromRank) == 2)
        {
            // Asegurarse de que no haya ninguna pieza en la casilla intermedia
            if (board[fromRank - 1, fromFile] != 0)
            {
                return false;
            }
        }
        else if (Math.Abs(toRank - fromRank) > 1) // Después del primer movimiento, solo se permite mover una casilla
        {
            return false;
        }

        // Validar que el peón no se mueva hacia atrás
        if (toRank >= fromRank)
        {
            return false;
        }

        // Validar que el peón no salte sobre otras piezas
        if (board[toRank, toFile] != 0)
        {
            return false;
        }

        return true;
    }



    static void MakeMove(string move)
    {
        int fromFile = move[0] - 'a';
        int fromRank = '8' - move[1];
        int toFile = move[3] - 'a';
        int toRank = '8' - move[4];

        board[toRank, toFile] = board[fromRank, fromFile];
        board[fromRank, fromFile] = (char)0;
    }
}