namespace BusinessContracts.Logger;

public interface IMyFileLogger : IMyLogger, IMyAccessibleLogger
{
    public string FileName { get; set; }
}