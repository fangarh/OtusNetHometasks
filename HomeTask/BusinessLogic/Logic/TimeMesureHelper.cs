using System.Diagnostics;

namespace Logic
{
    public class TimeMeasureHelper
    {
        public static TimeSpan Measure(Action measureAction)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            measureAction?.Invoke();
            watch.Stop();

            return watch.Elapsed;
        }
    }
}
