using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMRSim
{
    static class Utils
    {
        public static string SbyteToBinaryString(sbyte number,int length)
        {
            string output = Convert.ToString(number, 2).PadLeft(8, '0');

            if (output.Length > length)
            {
                return output.Substring(output.Length - length,length);
            }

            return output;
        }
        public static OPERATION_TYPE StringOperationToEnum(string operation)
        {
            //foreach(var item in Enum.GetNames(typeof(OPERATION_TYPE)))
            //{
            //    if(item.Equals(operation))

            //}

            return (OPERATION_TYPE)Enum.Parse(typeof(OPERATION_TYPE),operation);
        }
    }


}
