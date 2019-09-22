using System;

namespace RMAutoFramework.Base
{
    public class Base
    {
        public readonly ParallelConfig parallelConfig;

        public Base(ParallelConfig parallelConfig)
        {
            this.parallelConfig = parallelConfig;
        }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            return (TPage)Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }
    }
}
