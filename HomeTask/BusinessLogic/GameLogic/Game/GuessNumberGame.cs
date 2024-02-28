using BusinessContracts.Game;
using BusinessContracts.Helpers;
using BusinessContracts.Logger;
using GameLogic.Helpers;
using GameLogic.Logger;

namespace GameLogic.Game
{
    public class GuessNumberGame:IGuessNumberGame
    {
        private readonly IGuessChecker _checker;
        private readonly IRandomNumberGenerator _randomizer;
        private readonly IMyLogger _logger;

        public int WinCount { get; private set; }
        public int LooseCount { get; private set; }

        public GuessNumberGame(IGuessChecker checker = null, IRandomNumberGenerator randomizer = null, IMyLogger logger = null)
        {
            _logger = logger ?? new MyMemoryLogger();
            _checker = checker ?? new GuessChecker(_logger);
            _randomizer = randomizer ?? new ExtRandomNumberGenerator(500);
        }

        public void Play(int tryCount, int roundCount = 1)
        {
            WinCount = LooseCount = 0;
            for (int i = 0; i < roundCount; i++)
            {
                int number = _randomizer.RandomNumber;
                _checker.Initialize(number);
                Console.WriteLine($"Раунд №{i} начался. Для выхода введите '\\q' или '\\в'");
                Console.WriteLine($"Побед: {WinCount}  Поражений: {LooseCount} - {number}");

                switch (PlayRound(tryCount))
                {
                    case RoundResult.Win:
                        _logger.Log("User win!");
                        WinCount++;
                        Console.Clear();
                        continue;
                    case RoundResult.Loose:
                        _logger.Log("User loose!");
                        LooseCount++;
                        Console.Clear();
                        break;
                    case RoundResult.Exit:
                        _logger.Log("User pressed exit!");
                        return;
                        
                }
            }
        }

        private RoundResult PlayRound(int tryCount)
        {
            for (int j = 0; j < tryCount; j++)
            {
                Console.WriteLine($"Попытка {j}.");

                if (ReadNumberFromConsole(out var choice) == RoundResult.Exit)
                    return RoundResult.Exit;

                if (CheckChoice(choice) == RoundResult.Win) 
                    return RoundResult.Win;
            }

            return RoundResult.Loose;
        }

        private RoundResult CheckChoice(int choice)
        {
            switch (_checker.TryGuess(choice))
            {
                case GuessResult.Equals:
                    Console.WriteLine("Вы выиграли! <Нажмите любую кнопку>");
                    Console.ReadKey();
                    return RoundResult.Win;
                case GuessResult.Less:
                    Console.WriteLine("Загаданное число больше");
                    break;
                case GuessResult.More:
                    Console.WriteLine("Загаданное число меньше");
                    break;
                case GuessResult.Unknown:
                    _logger.Log("Guess check error");
                    Console.WriteLine("Ошибка при проверке");
                    break;
            }

            return RoundResult.Play;
        }

        private RoundResult ReadNumberFromConsole(out int number)
        {
            bool reading = true;
            number = -1;
            
            while (reading)
            {
                Console.WriteLine("Введите число");
                var inStr = Console.ReadLine() ?? "";

                if (!Int32.TryParse(inStr, out number))
                {
                    if (inStr.Equals("\\q", StringComparison.InvariantCultureIgnoreCase)
                        || inStr.Equals("\\в", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Console.WriteLine("Выход из игры");
                        return RoundResult.Exit;
                    }
                    Console.WriteLine("Ошибка ввода.");
                    

                    continue;
                }

                reading = false;
            }

            return RoundResult.Play;
        }
    }
}
