using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMRSim
{
    static class Utils
    {
        public static string SbyteToBinaryString(sbyte number, int length)
        {
            string output = Convert.ToString(number, 2).PadLeft(8, '0');

            if (output.Length > length)
            {
                return output.Substring(output.Length - length, length);
            }

            return output;
        }
        public static OPERATION_TYPE StringOperationToEnum(string operation)
        {
            //foreach(var item in Enum.GetNames(typeof(OPERATION_TYPE)))
            //{
            //    if(item.Equals(operation))

            //}

            return (OPERATION_TYPE)Enum.Parse(typeof(OPERATION_TYPE), operation);
        }

        public static bool CheckOperandRange(int operand)
        {
            if (operand < -128 || operand > 127)
                return false;
            else
                return true;
        }

        public static FileStream CreateFileStream()
        {
            FileStream fs = new FileStream("log.txt", FileMode.Append);
            return fs;
        }

        public static void WriteLog(string logText)
        {
            FileStream fs = CreateFileStream();

            using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
            {
                writer.WriteLine(DateTime.Now + ": " + logText);
            }
        }

    }


}
