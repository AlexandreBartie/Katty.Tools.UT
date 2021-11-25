using Dooggy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    [TestClass()]
    public class xMask_Test
    {
        string lista; string chave;
        string input; 
        string output;

        private xMask Mask;

        [TestMethod()]
        public void TST010_Mask_MascaraUnica()
        {
            // arrange
            lista = "{ 'COD_MATRICULA': '####.##.#####-#' }"; chave = "COD_MATRICULA";

            input = "198402018831";
            output = "1984.02.01883-1";

            // act & assert
            ActionMask();

        }

        [TestMethod()]
        public void TST020_Mask_MascarasMultiplas()
        {
            // arrange
            lista = "{ 'COD_MATRICULA': '####.##.#####-#', 'CPF': '###.###.###-##', 'CNPJ': '###.###.###-##' }"; chave = "CPF";

            input = "14029092845";
            output = "140.290.928-45";

            // act & assert
            ActionMask();

        }

        [TestMethod()]
        public void TST030_Mask_MascaraVazia()
        {
            // arrange
            lista = "{  }"; chave = "CPF";

            input = "14029092845";
            output = "14029092845";

            // act & assert
            ActionMask();

        }

        [TestMethod()]
        public void TST040_Mask_KeyInexistente()
        {
            // arrange
            lista = "{ 'COD_MATRICULA': '####.##.#####-#', 'CPF': '###.###.###-##', 'CNPJ': '###.###.###-##' }"; chave = "RG";

            input = "14029092845";
            output = "14029092845";

            // act & assert
            ActionMask();

        }
        private void ActionMask()
        {

            Mask = new xMask(lista);

            // assert
            string result = Mask.GetValor(input, chave);

            // assert
            if (output != result)
                Assert.Fail(string.Format("Expected: <{0}>, Actual: <{1}>, Lista: <{2}>", output, result));

        }

    }
}
