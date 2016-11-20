using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHive
{
    class Queen
    {
        private readonly Worker[] _workers;
        private int _shiftNumber = 0;

        public Queen(Worker[] workers)
        {
            this._workers = workers;
        }

        public bool AssignWork(string task, int numberOfRuns)
        {
            return _workers.Any(worker => worker.DoThisJob(task, numberOfRuns) == true);
        }
        
        public string WorkTheNextShift()
        {
            string report = "";
            _shiftNumber++;
            report = "Raport zmiany numer " + _shiftNumber.ToString()+ "\n\n";
            for (int i = 0; i < _workers.Length; i++)
            {
                _workers[i].WorkOneShift();
                if (String.IsNullOrEmpty(_workers[i].CurrentJob))
                {
                    report += "Robotnica numer" + (i+1) + " nie pracuje \n";
                }
                report += "Robotnica numer" + (i+1) + " robi \"" + _workers[i].CurrentJob +
                          "\" jeszcze przez " + _workers[i].ShiftsLeft + " zmiany\n";

            }

            return report;
        }
    }
}
