using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Katty.UTC.UNIT
{

    [TestClass()]
    public class UTControl_Test : UTControl
    {

        [TestMethod()]
        public void TST010_UTControlByLine_EntradaUnicaLinha()
        {

            inputText("Linha 1");
            inputText("Linha 2");
            inputText("Linha 3");

            output("Linha 1Linha 2Linha 3");
            output();

            // act & assert
            AssertTest(prmResult: GetInput());

        }

        [TestMethod()]
        public void TST020_UTControlByLine_EntradaMultiplasLinhas()
        {

            input("Linha 1");
            input("Linha 2");
            input("linha 3");

            output("Linha 1");
            output("Linha 2");
            output("linha 3");
            output();

            // act & assert
            AssertTest(prmResult: GetInput());

        }

    }
}
