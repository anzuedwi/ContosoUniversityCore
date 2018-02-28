using ContosoUniversityCore.Test.Utility.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ContosoUniversityCore.Test.Utility.Extensions
{
    public static class NumberHelper
    {
        /// <summary>
        /// Add Two Integers
        /// </summary>
        /// <param name="operandOne">First Operand</param>
        /// <param name="operations">Operations performed on Integer</param>
        /// <param name="operandTwo">Second Operand</param>
        /// <returns></returns>
        public static int PerformOperation(this int operandOne, Operations operations, int operandTwo)
        {
            DataTable dataTable = new DataTable();
            string operation = operations.GetDisplayName();

            //Display name not found
            if(operation == null)
            {
                return 0;
            }

            string computedResult = dataTable.Compute($"{operandOne}{operation}{operandTwo}", string.Empty).ToString();
            return Int16.Parse(computedResult);
        }
    }
}
