

namespace RMAutoFramework.Base
{
    public class DriverContext
    {
        public readonly ParallelConfig parallelConfig;

        public DriverContext(ParallelConfig parallelConfig)
        {
            this.parallelConfig = parallelConfig;
        }

        public void GoToUrl(string url)
        {
            parallelConfig.Driver.Url = url;
        }

        public static Browser Browser { get; set; }
    }
}
