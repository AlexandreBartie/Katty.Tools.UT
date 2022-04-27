using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Katty.UTC.LIB.PARSE.MASK
{
    [TestClass()]
    public class myMask_Test : UTControl
    {
        string lista; string chave;

        private myMasks Masks;

        [TestMethod()]
        public void TST010_Mask_MascaraPadrao()
        {
            // arrange
            lista = "COD_MATRICULA: ####.##.#####-#"; chave = "COD_MATRICULA";

            input("198402018831");
            output("1984.02.01883-1");

            // act & assert
            ActionMask();

        }

        [TestMethod()]
        public void TST020_Mask_MascaraSemEspacos()
        {
            // arrange
            lista = "PHONE: ##-###-###-###"; chave = "PHONE";

            input( "11959056700");
            output("11-959-056-700");

            // act & assert
            ActionMask();

        }


        [TestMethod()]
        public void TST030_Mask_MascaraMaiorValor()
        {
            // arrange
            lista = "COD_MATRICULA: ##-#####.##.#####-#"; chave = "COD_MATRICULA";

            input("198402018831");
            output("1984.02.01883-1");

            // act & assert
            ActionMask();

        }

        [TestMethod()]
        public void TST040_Mask_MascaraMenorValor()
        {
            // arrange
            lista = "COD_MATRICULA: ##.##.#####-#"; chave = "COD_MATRICULA";

            input("198402018831");
            output("84.02.01883-1");

            // act & assert
            ActionMask();

        }

        [TestMethod()]
        public void TST050_Mask_MascarasMultiplas()
        {
            // arrange
            lista = "COD_MATRICULA: ####.##.#####-#, CPF: ###.###.###-##, CNPJ: ###.###.###-##"; chave = "CPF";

            input("14029092845");
            output("140.290.928-45");

            // act & assert
            ActionMask();

        }

        [TestMethod()]
        public void TST060_Mask_MascaraVazia()
        {
            // arrange
            lista = ""; chave = "CPF";

            input("14029092845");
            output( "14029092845");

            // act & assert
            ActionMask();

        }

        [TestMethod()]
        public void TST070_Mask_KeyInexistente()
        {
            // arrange
            lista = "COD_MATRICULA: ####.##.#####-#, CPF: ###.###.###-##, CNPJ: ###.###.###-##"; chave = "RG";

            input("14029092845");
            output("14029092845");

            // act & assert
            ActionMask();

        }
        private void ActionMask()
        {

            Masks = new myMasks(lista);

            AssertTest(prmResult: Masks.TextToString(chave, GetRaw()));

        }

    }
}
