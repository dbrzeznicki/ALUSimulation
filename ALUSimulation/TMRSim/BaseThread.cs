using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TMRSim
{
    abstract class BaseThread
    {
        private Thread _thread;
        protected string _name;

        protected BaseThread()
        {
            _thread = new Thread(new ThreadStart(this.RunThread));
        }

        public void Start() => _thread.Start();
        public void Join() => _thread.Join();
        public bool IsAlive => _thread.IsAlive;
        public void Abort() => _thread.Abort();

     
        public abstract void RunThread();
    }
}
