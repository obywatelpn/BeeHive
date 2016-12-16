using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHive
{
    class Bee
    {
        private int _beeWeight;
        public Bee(int beeWeight) {
            this._beeWeight = beeWeight;
        }
        public virtual int ShiftsLeft { get { return 0; }}
        public float GetHoneyConsumption(int shiftsLeft) {
            float weightRate = this._beeWeight > 150 ? 1.35f : 1f;
            return shiftsLeft == 0 ? 7.5f * weightRate : (shiftsLeft + 9f) * weightRate;
        }
    }
}
