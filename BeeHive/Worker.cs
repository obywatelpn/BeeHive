using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHive
{
    class Worker
    {
        private string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked;

        public Worker(string[] jobsICanDo)
        {
            this.jobsICanDo = jobsICanDo;
        }

        public string CurrentJob { get; private set; }

        public int ShiftsLeft { get; private set; }

        public void WorkOneShift()
        {
            shiftsWorked++;
            ShiftsLeft = shiftsToWork - shiftsWorked;
            if (ShiftsLeft==0)
            {
                CurrentJob = "";
            }
        }

        public bool DoThisJob(string task, int numberOfRuns)
        {
            foreach (string job in jobsICanDo)
            {
                if (task==job && String.IsNullOrEmpty(CurrentJob))
                {
                    shiftsToWork = numberOfRuns;
                    CurrentJob = task;
                    shiftsWorked = 0;
                    return true;
                }
            }
            return false;
        }
    }
}
