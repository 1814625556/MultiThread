using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadTask
{
    public class SharedState
    {
        public int State { get; set; }
    }

    public class Job
    {
        public SharedState _sharedState;

        public Job(SharedState sharedState)
        {
            _sharedState = sharedState;
        }

        public void DoTheJob()
        {
            for (int i = 0; i < 50000; i++)
            {
                lock (_sharedState)
                {
                    _sharedState.State += 1;
                }
            }
        }
    }

}
