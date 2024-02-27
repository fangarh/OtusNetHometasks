using BusinessContracts.Logger;

namespace GameLogic.Logger
{
    public class MyMemoryLogger:IMyMemoryLogger
    {
        private readonly List<string> _logStrings;
        public MyMemoryLogger()
        {
            _logStrings = new List<string>();
        }

        public void Log(string message)
        {
            _logStrings.Add($"{DateTime.Now}: {message}");
        }

        public List<string> GetSavedLogs()
        {
            return _logStrings;
        }
    }
}
