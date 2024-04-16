using TextGame;
using TextGame.Exceptions;

var gameProcess = new GameProcess();
gameProcess.StartGame();

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Введите команду:");
    var command = Console.ReadLine();

    try
    {
        if (command.ToLower() == "endGame".ToLower())
        {
            gameProcess.EndGame();
            break;
        }
        else if (command.ToLower() == "initGame".ToLower())
        {
            gameProcess.RestartGame();
            Console.WriteLine("Игра начата сначала");
        }
        else
        {
            Console.WriteLine(gameProcess.ExecuteAction(command));
        }
    }
    catch (GameProcessException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch 
    {
        Console.WriteLine("Ошибка при выполнении действия");
    }
}

gameProcess.EndGame();
Console.WriteLine("Игра завершена");