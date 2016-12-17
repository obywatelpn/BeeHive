using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHive
{
    class Worker:Bee
    {
        private string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked;

        public Worker(string[] jobsICanDo, int beeWeight):base(beeWeight)
        {
            this.jobsICanDo = jobsICanDo;
        }

        public string CurrentJob { get; private set; }
        

        public override int ShiftsLeft
        {
            get { return shiftsToWork - shiftsWorked; }
        }

        public bool WorkOneShift()
        {
            if (string.IsNullOrEmpty(CurrentJob))
            {
                return false;
            }
            shiftsWorked++;
            if (shiftsWorked > shiftsToWork)
            {
                shiftsWorked = 0;
                shiftsToWork = 0;
                CurrentJob = "";
                return true;
            }
            else
                return false;
        }

        public bool DoThisJob(string task, int numberOfRuns)
        {
            if (!String.IsNullOrEmpty(CurrentJob))
            {
                return false;
            }

            foreach (string job in jobsICanDo)
            {
                if (task==job)
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
