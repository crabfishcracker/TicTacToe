int[,] board = new int[3, 3];
int player = 0;

RenderGameBoard();
MainLoop();

void MainLoop()
{
    while (true)
    {
        player++;
        if (player > 2)
        {
            player = 1;
        }
        PlayerInput(player);

        RenderGameBoard();

        if (CheckWinning() || BoardIsFull())
        {
            if (PlayAgain())
            {
                InitGame();
            }
            else
            {
                break;
            }
        }
    }
}

void InitGame()
{
    player = 0;
    board = new int[3, 3];
    RenderGameBoard();
}

bool PlayAgain()
{
    Console.WriteLine("Do you want to play again? (Y/N)");
    string? userAnswer = Console.ReadLine();
    if (userAnswer != null && userAnswer.ToLower() == "y")
    {
        return true;
    }
    else
    {
        return false;
    }
}

bool CheckWinning()
{
    bool IsWinning = false;
    int winner = 0;

    if (board[0, 0] > 0 && board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2])
    {
        IsWinning = true;
        winner = board[0, 0];
    }
    else if (board[1, 0] > 0 && board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2])
    {
        IsWinning = true;
        winner = board[1, 0];
    }
    else if (board[2, 0] > 0 && board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2])
    {
        IsWinning = true;
        winner = board[2, 0];
    }

    else if (board[0, 0] > 0 && board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0])
    {
        IsWinning = true;
        winner = board[0, 0];
    }
    else if (board[0, 1] > 0 && board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1])
    {
        IsWinning = true;
        winner = board[0, 1];
    }
    else if (board[0, 2] > 0 && board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2])
    {
        IsWinning = true;
        winner = board[0, 2];
    }

    else if (board[0, 0] > 0 && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
    {
        IsWinning = true;
        winner = board[0, 0];
    }
    else if (board[0, 2] > 0 && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
    {
        IsWinning = true;
        winner = board[0, 2];
    }

    if (IsWinning)
    {
        Console.WriteLine($"Player {winner} WINS!!");
        Console.WriteLine();
    }
    return IsWinning;
}

bool BoardIsFull()
{
    for (int y = 0; y < 3; y++)
    {
        for (int x = 0; x < 3; x++)
        {
            if (board[x, y] == 0)
            {
                return false;
            }
        }
    }
    return true;
}

void RenderGameBoard()
{
    Console.Clear();
    Console.WriteLine("  Let's play");
    Console.WriteLine("  [ TIC TAC TOE ]");
    Console.WriteLine();
    Console.WriteLine("   | 1 | 2 | 3 | <-(X)");
    Console.WriteLine(" ---------------");

    for (int y = 0; y < 3; y++)
    {
        Console.Write($" {y + 1} |");
        for (int x = 0; x < 3; x++)
        {
            if (x == 2)
            {
                if (board[x, y] == 0)
                {
                    Console.WriteLine($"   |");
                }
                else
                {
                    Console.WriteLine($" {board[x, y]} |");
                }
                Console.WriteLine(" ---------------");
            }
            else
            {
                if (board[x, y] == 0)
                {
                    Console.Write($"   |");
                }
                else
                {
                    Console.Write($" {board[x, y]} |");
                }
            }
        }
    }

    Console.WriteLine("(Y)");
    Console.WriteLine();
}

void PlayerInput(int player)
{
    while (true)
    {
        Console.WriteLine($"Player {player}'s move.");

        string? input = String.Empty;
        int posX = 0;
        while (true)
        {
            Console.WriteLine("Enter position X (column): ");
            input = Console.ReadLine();
            bool inputIsOk = false;
            if (input != null)
            {
                inputIsOk = int.TryParse(input, out posX);
                if (!inputIsOk)
                    continue;
            }

            if (posX < 1)
                posX = 1;
            else if (posX > 3)
                posX = 3;

            break;
        }

        int posY = 0;
        while (true)
        {
            Console.WriteLine("Enter position Y (row): ");
            input = Console.ReadLine();
            bool inputIsOk = false;
            if (input != null)
            {
                inputIsOk = int.TryParse(input, out posY);
                if (!inputIsOk)
                    continue;
            }

            if (posY < 1)
                posY = 1;
            else if (posY > 3)
                posY = 3;

            break;
        }

        bool IsEmptySlot = false;
        IsEmptySlot = board[posX - 1, posY - 1] == 0;
        if (IsEmptySlot)
        {
            board[posX - 1, posY - 1] = player;
            break;
        }
        else
            Console.WriteLine("Illegal move, try again!");
    }
}
