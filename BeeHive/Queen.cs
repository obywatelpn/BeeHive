using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHive
{
    class Queen:Bee
    {
        private readonly Worker[] _workers;
        private int _shiftNumber = 0;

        public Queen(Worker[] workers, int beeWeight):base(beeWeight)
        {
            this._workers = workers;
        }

        public float GetHoneyConsumption()
        {
            var beesAtWork = 0;
            var beesShiftsLeft = 0;
            var beeWorkerWithMostShiftsLeftHoneyConsumption = 0f;
            foreach (var beeWorker in _workers)
            {
                beesAtWork = beeWorker.CurrentJob != "" ? beesAtWork++ : beesAtWork;
                if (beeWorker.ShiftsLeft > beesShiftsLeft)
                {
                    beesShiftsLeft = beeWorker.ShiftsLeft;
                    beeWorkerWithMostShiftsLeftHoneyConsumption= beeWorker.GetHoneyConsumption(beesShiftsLeft);
                }
            }

            var additionalHoneyUnits = beesAtWork <= 2 ? 20 : 30;

            return beeWorkerWithMostShiftsLeftHoneyConsumption + additionalHoneyUnits;
            
        }
        public bool AssignWork(string task, int numberOfRuns)
        {
            return _workers.Any(worker => worker.DoThisJob(task, numberOfRuns) == true);
        }

        public string WorkTheNextShift()
        {
            _shiftNumber++;
            var overallHoneyConsumption = 0f;
            var beesShiftsLeft = 0;
            for (int j = 0; j < _workers.Length; j++)
            {
                overallHoneyConsumption += _workers[j].GetHoneyConsumption(_workers[j].ShiftsLeft);
                if (_workers[j].ShiftsLeft > beesShiftsLeft)
                {
                    beesShiftsLeft = _workers[j].ShiftsLeft;
                }
            }
            overallHoneyConsumption += this.GetHoneyConsumption();

            string report = "Raport zmiany numer " + _shiftNumber.ToString() + "\r\n";
            for (int i = 0; i < _workers.Length; i++)
            {
                _workers[i].WorkOneShift();
                if (String.IsNullOrEmpty(_workers[i].CurrentJob))
                {
                    report += $"Robotnica numer {i + 1} nie pracuje \r\n";
                }
                else
                {
                    report += "Robotnica numer " + (i + 1) + " robi \"" + _workers[i].CurrentJob +
                       "\" jeszcze przez " + _workers[i].ShiftsLeft + " zmiany\r\n";
                }
            }
            report += $"Całkowite spożycie miodu: {overallHoneyConsumption} jednostek \r\n";
            return report;
        }
    }
}
