using Dooggy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dooggy.Tests.LIB.GENERIC
{
    [TestClass()]
    public class xLista_Test
    {
        string input;
        string output;

        xLista Lista = new xLista();

        [TestMethod()]
        public void TST010_FluxoCSV_Padrao()
        {

            // arrange
            input = "1234,2345,3,5,78";
            output = "4,4,1,1,2";

            // act & assert
            ActionLista();

        }

        private void ActionLista()
        {

            // assert
            Lista.Parse(input, prmSeparador: ",");

            string result = Lista.log;

            // assert
            if (output != result)
                Assert.Fail(string.Format("Expected: <{0}>, Actual: <{1}>, Lista: <{2}>", output, result, input));

        }
    }

}
