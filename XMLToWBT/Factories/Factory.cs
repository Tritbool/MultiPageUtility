using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToWBT.Factories
{
    public  class Factory<T>
    {
        private static Factory<T> _instance;
        static readonly object instanceLock = new object();

        protected Factory() { }

        public static Factory<T> getInstance()
        {
            if (_instance == null)
            {
                lock (instanceLock)
                {
                    if (_instance == null)
                        _instance = new Factory<T>();
                }
            }

            return _instance;
        }

    }
}
