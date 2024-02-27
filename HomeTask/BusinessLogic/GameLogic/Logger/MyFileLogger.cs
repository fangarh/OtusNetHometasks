using BusinessContracts.Logger;

namespace GameLogic.Logger
{
    public class MyFileLogger:IMyFileLogger
    {
        public MyFileLogger(string fileName)
        {
            FileName = fileName;
        }

        public void Log(string message)
        {
            if (!File.Exists(FileName))
            {
                File.Create(FileName);
            }

            File.AppendAllText(FileName, $"{DateTime.Now}:{message}");
        }

        public List<string> GetSavedLogs()
        {
            if (File.Exists(FileName))
                return File.ReadAllLines(FileName).ToList();

            return new List<string>();
        }

        public string FileName { get; set; }
    }
}
