using System;
using System.Collections.Generic;
using System.Text;
using Dooggy.Lib.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dooggy.Tests.LIB.VARS
{
       
    [TestClass()]
    public class xStrings_Test
    {

        string mask;
        
        string input;
        string output;
        string result;

        [TestMethod()]
        public void TST_GetFirst_010_Padrao()
        {

            input = "Alexandre Bartie";
            output = "A";

            // act & assert
            ActionGetFirst();

        }

        [TestMethod()]
        public void TST_GetFirst_020_TextoCaracterUnico()
        {

            input = "X";
            output = "X";

            // act & assert
            ActionGetFirst();

        }

        [TestMethod()]
        public void TST_GetFirst_030_TextoComBrancos()
        {

            input = " X ";
            output = " ";

            // act & assert
            ActionGetFirst();

        }

        [TestMethod()]
        public void TST_GetFirst_040_TextoVazio()
        {

            input = "";
            output = "";

            // act & assert
            ActionGetFirst();

        }

        [TestMethod()]
        public void TST_GetFirst_050_TextoNulo()
        {

            input = null;
            output = "";

            // act & assert
            ActionGetFirst();

        }

        [TestMethod()]
        public void TST_GetLast_010_Padrao()
        {

            input = "Alexandre Bartie";
            output = "e";

            // act & assert
            ActionGetLast();

        }

        [TestMethod()]
        public void TST_GetLast_020_TextoCaracterUnico()
        {

            input = "X";
            output = "X";

            // act & assert
            ActionGetLast();

        }

        [TestMethod()]
        public void TST_GetLast_030_TextoComBrancos()
        {

            input = " X ";
            output = " ";

            // act & assert
            ActionGetLast();

        }

        [TestMethod()]
        public void TST_GetLast_040_TextoVazio()
        {

            input = "";
            output = "";

            // act & assert
            ActionGetLast();

        }

        [TestMethod()]
        public void TST_GetLast_050_TextoNulo()
        {

            input = null;
            output = "";

            // act & assert
            ActionGetLast();

        }

        [TestMethod()]
        public void TST_GetFirstExt_010_Padrao()
        {

            input = "Alexandre Bloco Bartie";
            output = "Alexan";

            // act & assert
            ActionGetFirstExt();

        }

        [TestMethod()]
        public void TST_GetFirstExt_020_TextoCaracterUnico()
        {

            input = "X";
            output = "X";

            // act & assert
            ActionGetFirstExt();

        }

        [TestMethod()]
        public void TST_GetFirstExt_030_TextoTamanhoCurto()
        {

            input = "abcde";
            output = "abcde";

            // act & assert
            ActionGetFirstExt();

        }

        [TestMethod()]
        public void TST_GetFirstExt_040_TextoTamanhoExato()
        {

            input = "abcdef";
            output = "abcdef";

            // act & assert
            ActionGetFirstExt();

        }

        [TestMethod()]
        public void TST_GetFirstExt_050_TextoTamanhoLongo()
        {

            input = "abcdefg";
            output = "abcdef";

            // act & assert
            ActionGetFirstExt();

        }
        
        [TestMethod()]
        public void TST_GetFirstExt_060_TextoComBrancos()
        {

            input = " X ";
            output = " X ";

            // act & assert
            ActionGetFirstExt();

        }
        [TestMethod()]
        public void TST_GetFirstExt_070_TextoVazio()
        {

            input = "";
            output = "";

            // act & assert
            ActionGetFirstExt();

        }
        [TestMethod()]
        public void TST_GetFirstExt_080_TextoNulo()
        {

            input = null;
            output = "";

            // act & assert
            ActionGetFirstExt();

        }

        [TestMethod()]
        public void TST_GetFirstExt_090_TamanhoZero()
        {

            input = "abcdefg";
            output = "";

            // act & assert
            ActionGetFirstExt(prmTamanho: 0);

        }

        [TestMethod()]
        public void TST_GetFirstExt_100_TamanhoNegativo()
        {

            input = "abcdefg";
            output = "";

            // act & assert
            ActionGetFirstExt(prmTamanho: -1);

        }
        [TestMethod()]
        public void TST_GetFirstExt_110_Delimitador()
        {

            input = "abc|defg";
            output = "abc";

            // act & assert
            ActionGetFirstExt(prmDelimitador: "|");

        }
        [TestMethod()]
        public void TST_GetFirstExt_120_DelimitadorPrimeiroCaracter()
        {

            input = "|abcdefg";
            output = "";

            // act & assert
            ActionGetFirstExt(prmDelimitador: "|");

        }
        [TestMethod()]
        public void TST_GetFirstExt_130_DelimitadorUltimoCaracter()
        {

            input = "abcdefg|";
            output = "abcdefg";

            // act & assert
            ActionGetFirstExt(prmDelimitador: "|");

        }
        [TestMethod()]
        public void TST_GetFirstExt_140_DelimitadorNaoEncontrado()
        {

            input = "abcdefg";
            output = "abcdefg";

            // act & assert
            ActionGetFirstExt(prmDelimitador: "|");

        }
        [TestMethod()]
        public void TST_GetLastExt_010_Padrao()
        {

            input = "Alexandre Bloco Bartie";
            output = "Bartie";

            // act & assert
            ActionGetLastExt();

        }

        [TestMethod()]
        public void TST_GetLastExt_020_TextoCaracterUnico()
        {

            input = "X";
            output = "X";

            // act & assert
            ActionGetLastExt();

        }

        [TestMethod()]
        public void TST_GetLastExt_030_TextoTamanhoCurto()
        {

            input = "abcde";
            output = "abcde";

            // act & assert
            ActionGetLastExt();

        }

        [TestMethod()]
        public void TST_GetLastExt_040_TextoTamanhoExato()
        {

            input = "abcdef";
            output = "abcdef";

            // act & assert
            ActionGetLastExt();

        }

        [TestMethod()]
        public void TST_GetLastExt_050_TextoTamanhoLongo()
        {

            input = "abcdefg";
            output = "bcdefg";

            // act & assert
            ActionGetLastExt();

        }

        [TestMethod()]
        public void TST_GetLastExt_060_TextoComBrancos()
        {

            input = " X ";
            output = " X ";

            // act & assert
            ActionGetLastExt();

        }

        [TestMethod()]
        public void TST_GetLastExt_070_TextoVazio()
        {

            input = "";
            output = "";

            // act & assert
            ActionGetLastExt();

        }

        [TestMethod()]
        public void TST_GetLastExt_080_TextoNulo()
        {

            input = null;
            output = "";

            // act & assert
            ActionGetLastExt();

        }

        [TestMethod()]
        public void TST_GetLastExt_090_TamanhoZero()
        {

            input = "abcdefg";
            output = "";

            // act & assert
            ActionGetLastExt(prmTamanho: 0);

        }

        [TestMethod()]
        public void TST_GetLastExt_100_TamanhoNegativo()
        {

            input = "abcdefg";
            output = "bcdefg";

            // act & assert
            ActionGetLastExt(prmTamanho: -1);

        }
        
        [TestMethod()]
        public void TST_GetLastExt_110_Delimitador()
        {

            input = "abc|defg";
            output = "defg";

            // act & assert
            ActionGetLastExt(prmDelimitador: "|");

        }
        [TestMethod()]
        public void TST_GetLastExt_120_DelimitadorPrimeiroCaracter()
        {

            input = "|abcdefg";
            output = "abcdefg";

            // act & assert
            ActionGetLastExt(prmDelimitador: "|");

        }
        [TestMethod()]
        public void TST_GetLastExt_130_DelimitadorUltimoCaracter()
        {

            input = "abcdefg|";
            output = "";

            // act & assert
            ActionGetLastExt(prmDelimitador: "|");

        }
        [TestMethod()]
        public void TST_GetLastExt_140_DelimitadorNaoEncontrado()
        {

            input = "abcdefg";
            output = "";

            // act & assert
            ActionGetLastExt(prmDelimitador: "|");

        }

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

        [TestMethod()]
        public void TST_GetNoBlank_010_Padrao()
        {

            input = "Alexandre Bartie";
            output = "AlexandreBartie";

            // act & assert
            ActionGetNoBlank();

        }

        [TestMethod()]
        public void TST_GetNoBlank_020_MultiplosEspacos()
        {

            input = " Alexandre Bartie ";
            output = "AlexandreBartie";

            // act & assert
            ActionGetNoBlank();

        }

        [TestMethod()]
        public void TST_GetNoBlank_030_EspacosDobrados()
        {

            input = "  Alexandre  Bartie  ";
            output = "AlexandreBartie";

            // act & assert
            ActionGetNoBlank();

        }
        
        [TestMethod()]
        public void TST_GetNoBlank_040_Vazio()
        {

            input = "";
            output = "";

            // act & assert
            ActionGetNoBlank();

        }
        [TestMethod()]
        public void TST_GetNoBlank_050_Null()
        {

            input = null;
            output = "";

            // act & assert
            ActionGetNoBlank();

        }

        private void ActionGetFirst()
        {

            // assert
            result = xString.GetFirst(input);

            // assert
            ActionGeneric();

        }
        private void ActionGetFirstExt() => ActionGetFirstExt(prmTamanho: 6);
        private void ActionGetFirstExt(int prmTamanho)
        {

            // assert
            result = xString.GetFirst(input, prmTamanho);

            // assert
            ActionGeneric();

        }
        private void ActionGetFirstExt(string prmDelimitador)
        {

            // assert
            result = xString.GetFirst(input, prmDelimitador);

            // assert
            ActionGeneric();

        }
        private void ActionGetLast()
        {

            // assert
            result = xString.GetLast(input);

            // assert
            ActionGeneric();

        }
        private void ActionGetLastExt() => ActionGetLastExt(prmTamanho: 6);
        private void ActionGetLastExt(int prmTamanho)
        {

            // assert
            result = xString.GetLast(input, prmTamanho);

            // assert
            ActionGeneric();

        }
        private void ActionGetLastExt(string prmDelimitador)
        {

            // assert
            result = xString.GetLast(input, prmDelimitador);

            // assert
            ActionGeneric();

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

        private void ActionGetNoBlank()
        {

            // assert
            result = xString.GetNoBlank(input);

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