using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TMRSim
{
    class TMR
    {

        private ALU[] _alu;
        private Voter _voter;
        private Random _rand;

        public TMR()
        {
            _voter = new Voter("VOTER0");
            _alu = new ALU[3];


            _rand = new Random();

            _alu[0] = new ALU("ALU0", _voter.SetInputA,_rand);
            _alu[1] = new ALU("ALU1", _voter.SetInputB, _rand);
            _alu[2] = new ALU("ALU2", _voter.SetInputC, _rand);


        }
        public sbyte GetALU_Result(int index)
        {
            return _alu[index].Result;
        }
        public sbyte GetVoter_Result()
        {
            return _voter.Result;
        }

        public void SimulateOnce(sbyte operandA,sbyte operandB,OPERATION_TYPE operation,bool[] isErr)
        {
            _voter.Start();

            var collection = _alu.Zip(isErr, (a, e) => new { a, e });

            foreach (var item in collection)
            {
                item.a.Start();
                item.a.SetOperandsAndOperation(operandA, operandB, operation, item.e);
            }

            foreach (var item in _alu)
                item.Join();

            _voter.Join();

        }
    }
}
