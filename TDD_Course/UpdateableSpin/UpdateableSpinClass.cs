using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TDD_Course
{
    public class UpdateableSpin
    {
        private readonly object lockObj = new object();
        private bool shouldWait = true;
        private long executionStartingTime;

        public bool Wait(TimeSpan timeout, int spinDuration = 0)
        {
            UpdateTimeout();

            while (true)
            {
                lock (lockObj)
                {
                    if (!shouldWait)
                    {
                        return true;
                    }
                    if (DateTime.UtcNow.Ticks - executionStartingTime > timeout.Ticks)
                    {
                        return false;
                    }
                }
                Thread.Sleep(spinDuration);
            }


            return false;
        }

        public void Set()
        {
            lock (lockObj)
            {
                shouldWait = false;
            }
        }

        public void UpdateTimeout()
        {
            lock (lockObj)
            {
                executionStartingTime = DateTime.UtcNow.Ticks;
            }
        }
    }
}
