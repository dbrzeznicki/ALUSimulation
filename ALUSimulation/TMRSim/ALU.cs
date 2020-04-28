using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TMRSim
{
    enum OPERATION_TYPE
    {
        NONE,
        ADD,
        SUB,
        XOR,
        OR,
        AND
    }

    class ALU : BaseThread
    {
        public sbyte Result { get; private set; }

        private sbyte _operandA, _operandB;
        private OPERATION_TYPE _operation;
        private Action<sbyte> _actVoter;
        private ManualResetEvent _resetEvent;
        private bool _isError = false;
        private Random _rand;
        static readonly object _object = new object();


        public ALU(string name,Action<sbyte> actVoter,Random rand) : base()
        {
            this._name = name;

            _rand = rand;

            _resetEvent = new ManualResetEvent(false);
            _actVoter = actVoter;
            Reset();
        }
        public void Reset()
        {
            _operandA = _operandB = 0;
            _operation = OPERATION_TYPE.NONE;
            _resetEvent.Reset();
        }

        public void SetOperandsAndOperation(sbyte a,sbyte b,OPERATION_TYPE operation,bool isError = false)
        {
            lock (_object)
            {
                _operandA = a;
                _operandB = b;
                _operation = operation;
                _resetEvent.Set();
                _isError = isError;
            }
        }

        public sbyte Calculate()
        {
            sbyte result = DoOperation(_operandA, _operandB, _operation);

            return Result = (!_isError) ? result : (sbyte)(_rand.Next(-127,126));
        }
        public sbyte DoOperation(sbyte a, sbyte b, OPERATION_TYPE op)
        {
            switch (op)
            {
                case OPERATION_TYPE.ADD: return Add(a, b);
                case OPERATION_TYPE.SUB: return Sub(a, b);
                case OPERATION_TYPE.OR: return Or(a, b);
                case OPERATION_TYPE.AND: return And(a, b);
                case OPERATION_TYPE.XOR: return Xor(a, b);
            }

            return 0;
        }
        private sbyte Add(sbyte a, sbyte b)
        {
            return (sbyte)(a + b);
        }
        private sbyte Sub(sbyte a, sbyte b)
        {
            return (sbyte)(a - b);
        }
        private sbyte Or(sbyte a, sbyte b)
        {
            return (sbyte)(a | b);
        }
        private sbyte And(sbyte a, sbyte b)
        {
            return (sbyte)(a & b);
        }
        private sbyte Xor(sbyte a, sbyte b)
        {
            return (sbyte)(a ^ b);
        }

        public override void RunThread()
        {

                _resetEvent.WaitOne();



                _actVoter.Invoke(Calculate());

                Reset();

        }
    }
}
