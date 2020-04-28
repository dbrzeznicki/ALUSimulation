using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TMRSim
{
    class Voter : BaseThread
    {
        public sbyte Result { get; private set; }

        private sbyte _inputA,_inputB,_inputC;
        static readonly object _object = new object();
        ManualResetEvent _resetEvent;
        private int _nInputs;
        private bool _isInputA, _isInputB, _isInputC;

        public Voter(string name)
        {
            this._name = name;

            _resetEvent = new ManualResetEvent(false);

            Reset();


        }
        ~Voter()
        {
            _resetEvent.Dispose();
        }
        public void Reset()
        {
            _inputA = _inputB = _inputC =  0;
            _nInputs = 0;
            _isInputA = _isInputB = _isInputC = false;
            _resetEvent.Reset();
        }
        public void SetInputA(sbyte input)
        {
            lock (_object)
            {
                _inputA = input;

                _isInputA = true;
                Test();
            }

        }
        public void SetInputB(sbyte input)
        {
            lock (_object)
            {
                _inputB = input;

                _isInputB = true;

                Test();

            }


        }
        public void Test()
        {
            if (_isInputA && _isInputB && _isInputC )
            {
                _resetEvent.Set();
            }

        }
        public void SetInputC(sbyte input)
        {
            lock (_object)
            {
                _inputC = input;
                _isInputC = true;
                Test();
            }

        }


        private sbyte GetResult()
        {
            return (sbyte)((_inputA & _inputB) | (_inputC & _inputA) | ( _inputB & _inputC));
        }

        public override void RunThread()
        {

                _resetEvent.WaitOne();



                Result = GetResult();


                Reset();

        }
    }
}
