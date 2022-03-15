using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BlueRocket.LIBRARY.TESTS.LIB.GENERIC
{
    [TestClass()]
    public class xLista_Test
    {
        string input;
        string output;

        xLista Lista = new xLista();

        [TestMethod()]
        public void TST010_FlowCSV_Padrao()
        {

            // arrange
            input = "1234,2345,3,5,78";
            output = "4,4,1,1,2";

            // act & assert
            ActionLista();

        }

        [TestMethod()]
        public void TST020_FlowCSV_ComEspacos()
        {

            // arrange
            input = " 1234 , 2345 , 3 , 5 , 78 ";
            output = "4,4,1,1,2";

            // act & assert
            ActionLista();

        }

        [TestMethod()]
        public void TST030_FlowCSV_Unico()
        {

            // arrange
            input = " 923348 ";
            output = "6";

            // act & assert
            ActionLista();

        }

        [TestMethod()]
        public void TST040_FlowCSV_Vazio()
        {

            // arrange
            input = "";
            output = "";

            // act & assert
            ActionLista();

        }

        [TestMethod()]
        public void TST050_FlowCSV_Espaco()
        {

            // arrange
            input = "   ";
            output = "0";

            // act & assert
            ActionLista();

        }

        [TestMethod()]
        public void TST060_FlowCSV_Nulo()
        {

            // arrange
            input = null;
            output = "";

            // act & assert
            ActionLista();

        }

        [TestMethod()]
        public void TST070_FlowCSV_SeparadorModificado()
        {

            // arrange
            input = " 12,3 $ 456,78 $ 3,23 ";
            output = "4$6$4";

            // act & assert
            ActionLista(prmSeparador: "$");

        }
        
        private void ActionLista() => ActionLista(prmSeparador: ",");
        private void ActionLista(string prmSeparador)
        {

            // assert
            Lista.Parse(input, prmSeparador);

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
        public void TST010_Mask_MascaraPadrao()
        {
            // arrange
            lista = "COD_MATRICULA = ####.##.#####-#"; chave = "COD_MATRICULA";

            input = "198402018831";
            output = "1984.02.01883-1";

            // act & assert
            ActionMask();

        }

        [TestMethod()]
        public void TST020_Mask_MascaraMaiorValor()
        {
            // arrange
            lista = "COD_MATRICULA = ##-#####.##.#####-#"; chave = "COD_MATRICULA";

            input = "198402018831";
            output = "1984.02.01883-1";

            // act & assert
            ActionMask();

        }

        [TestMethod()]
        public void TST030_Mask_MascaraMenorValor()
        {
            // arrange
            lista = "COD_MATRICULA = ##.##.#####-#"; chave = "COD_MATRICULA";

            input = "198402018831";
            output = "84.02.01883-1";

            // act & assert
            ActionMask();

        }
        
        [TestMethod()]
        public void TST040_Mask_MascarasMultiplas()
        {
            // arrange
            lista = "COD_MATRICULA = ####.##.#####-#, CPF = ###.###.###-##, CNPJ = ###.###.###-##"; chave = "CPF";

            input = "14029092845";
            output = "140.290.928-45";

            // act & assert
            ActionMask();

        }

        [TestMethod()]
        public void TST050_Mask_MascaraVazia()
        {
            // arrange
            lista = ""; chave = "CPF";

            input = "14029092845";
            output = "14029092845";

            // act & assert
            ActionMask();

        }

        [TestMethod()]
        public void TST060_Mask_KeyInexistente()
        {
            // arrange
            lista = "COD_MATRICULA = ####.##.#####-#, CPF = ###.###.###-##, CNPJ = ###.###.###-##"; chave = "RG";

            input = "14029092845";
            output = "14029092845";

            // act & assert
            ActionMask();

        }
        private void ActionMask()
        {

            Mask = new xMask(lista);

            // assert
            string result = Mask.TextToString(chave, input);

            // assert
            if (output != result)
                Assert.Fail(string.Format("Expected: <{0}>, Actual: <{1}>, Lista: <{2}>", output, result));

        }

    }
}
