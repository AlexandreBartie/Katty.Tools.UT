using System;
using System.Collections.Generic;
using System.Text;
using Dooggy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dooggy.Tests.LIB.GENERIC
{
    [TestClass()]
    public class xStrings_Test
    {

        string mask;
        
        string input;
        string output;
        string result;

        [TestMethod()]
        public void TST_GetMask_010_MascaraPadrao()
        {

            mask = "####.##.#####-#";

            input = "198402018831";
            output = "1984.02.01883-1";

            // act & assert
            ActionGetMask();

        }

        [TestMethod()]
        public void TST_GetMask_020_MascaraMaiorValor()
        {

            mask = "###.####.##.#####-#";

            input = "198402018831";
            output = "1984.02.01883-1";

            // act & assert
            ActionGetMask();

        }

        [TestMethod()]
        public void TST_GetMask_030_MascaraMenorValor()
        {

            mask = "##.#####-#";

            input = "198402018831";
            output = "02.01883-1";

            // act & assert
            ActionGetMask();

        }

        [TestMethod()]
        public void TST_GetMask_040_MascaraEntreAspas()
        {

            mask = @"""####.##.#####-#""";

            input = "198402018831";
            output = @"""1984.02.01883-1""";

            // act & assert
            ActionGetMask();

        }

        [TestMethod()]
        public void TST_GetMask_050_MascaraComPrefixo()
        {

            mask = "CPF: ###.####.##.#####-#";

            input = "198402018831";
            output = "CPF: 1984.02.01883-1";

            // act & assert
            ActionGetMask();

        }

        [TestMethod()]
        public void TST_GetReverse_010_Padrao()
        {

            input = "Alexandre Bartie";
            output = "eitraB erdnaxelA";

            // act & assert
            ActionGetReverse();

        }

        [TestMethod()]
        public void TST_GetReverse_020_Vazio()
        {

            input = "";
            output = "";

            // act & assert
            ActionGetReverse();

        }
        [TestMethod()]
        public void TST_GetReverse_030_Null()
        {

            input = null;
            output = "";

            // act & assert
            ActionGetReverse();

        }
        private void ActionGetMask()
        {

            // assert
            result = xString.GetMask(input, mask);

            // assert
            ActionGeneric();

        }

        private void ActionGetReverse()
        {

            // assert
            result = xString.GetReverse(input);

            // assert
            ActionGeneric();

        }

        private void ActionGeneric()
        {

            // assert
            if (output != result)
                Assert.Fail(string.Format("Expected: <{0}>, Actual: <{1}>", output, result));

        }
    }

}