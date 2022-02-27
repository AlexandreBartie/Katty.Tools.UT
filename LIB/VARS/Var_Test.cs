using Dooggy;
using Dooggy.Lib.Vars;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Dooggy.Tests.LIB.VARS.FORMAT
{
    [TestClass()]
    public class CAT_010_VarsByFormatTextString_Test : xVars_Test
    {

        [TestMethod()]
        public void TST010_FormatTextString_FormatoPadrao()
        {

            input = "ALEXANDRE BARTIE";
            output = "ALEXA";

            // act & assert
            ActionFormatText("X(5)");

        }
        [TestMethod()]
        public void TST020_FormatTextString_SaidaComBrancos()
        {

            input = "ALEXANDRE BARTIE";
            output = "ALEXANDRE ";

            // act & assert
            ActionFormatText("X(10)");

        }
        [TestMethod()]
        public void TST030_FormatTextString_SaidaReduzida()
        {

            input = "ALEX";
            output = "ALEX";

            // act & assert
            ActionFormatText("X(10)");

        }
        [TestMethod()]
        public void TST040_FormatTextString_SaidaInvertida()
        {

            input = "ALEXANDRE BARTIE";
            output = "BARTIE";

            // act & assert
            ActionFormatText("X(-6)");

        }
        [TestMethod()]
        public void TST050_FormatTextString_FormatoCaixaBaixa()
        {

            input = "ALEXANDRE BARTIE";
            output = "AL";

            // act & assert
            ActionFormatText("x(2)");

        }
        [TestMethod()]
        public void TST060_FormatTextString_FormatoZero()
        {

            input = "ALEXANDRE BARTIE";
            output = "";

            // act & assert
            ActionFormatText("x(0)");

        }
        [TestMethod()]
        public void TST070_FormatTextString_FormatoNaoInformado()
        {

            input = "ALEXANDRE BARTIE";
            output = "";

            // act & assert
            ActionFormatText("x()");

        }

        [TestMethod()]
        public void TST080_FormatTextString_DelimitadorNaoEncontrado()
        {

            input = "ALEXANDRE BARTIE";
            output = "";

            // act & assert
            ActionFormatText("X");

        }
        [TestMethod()]
        public void TST090_FormatTextString_FormatoNaoNumerico()
        {

            input = "ALEXANDRE BARTIE";
            output = "";

            // act & assert
            ActionFormatText("X(ff)");

        }
    }

    [TestClass()]
    public class CAT_020_VarsByFormatTextSubstring_Test : xVars_Test
    {

        [TestMethod()]
        public void TST010_FormatTextSubstring_PosicaoMaisTamanho()
        {

            input = "ALEXANDRE BARTIE";
            output = "ANDRE";

            // act & assert
            ActionFormatText("X(5+5)");

        }
        [TestMethod()]
        public void TST020_FormatTextSubstring_PosicaoInicialFinal()
        {

            input = "ALEXANDRE BARTIE";
            output = "EXA";

            // act & assert
            ActionFormatText("X(3*5)");

        }
    }
    [TestClass()]
    public class CAT_030_VarsByFormatTextMask_Test : xVars_Test
    {

        [TestMethod()]
        public void TST010_FormatMask_FormatoPadrao()
        {
            // arrange

            input = "198402018831";
            output = "1984.02.01883-1";

            // act & assert
            ActionFormatMask("####.##.#####-#");

        }

        [TestMethod()]
        public void TST020_Mask_MascaraMaiorValor()
        {
            // arrange

            input = "198402018831";
            output = "1984.02.01883-1";

            // act & assert
            ActionFormatMask("##-#####.##.#####-#");

        }

        [TestMethod()]
        public void TST030_Mask_MascaraMenorValor()
        {
            // arrange
            input = "198402018831";
            output = "84.02.01883-1";

            // act & assert
            ActionFormatMask("##.##.#####-#");

        }
        [TestMethod()]
        public void TST040_Mask_MascaraVazia()
        {
            // arrange
            input = "198402018831";
            output = "198402018831";

            // act & assert
            ActionFormatMask("");

        }
        [TestMethod()]
        public void TST050_Mask_MascaraNula()
        {
            // arrange
            input = "198402018831";
            output = "198402018831";

            // act & assert
            ActionFormatMask(null);

        }
    }
    [TestClass()]
    public class CAT_040_VarsByFormatDate_Test : xVars_Test
    {

        [TestMethod()]
        public void TST010_VarDate_FormatoPadrao()
        {

            input = "DD/MM/AAAA";
            output = "08/05/2022";

            // act & assert
            ActionFormatDate();

        }
        [TestMethod()]
        public void TST020_VarDate_FormatoString()
        {

            input = "DDMMAAAA";
            output = "08052022";

            // act & assert
            ActionFormatDate();

        }

        [TestMethod()]
        public void TST030_VarDate_FormatoStringInvertido()
        {

            input = "AAAAMMDD";
            output = "20220508";

            // act & assert
            ActionFormatDate();

        }

        [TestMethod()]
        public void TST040_VarDate_FormatoVazio()
        {

            input = "";
            output = "08/05/2022 00:00:00";

            // act & assert
            ActionFormatDate();

        }

        [TestMethod()]
        public void TST050_VarDate_FormatoNull()
        {

            input = null;
            output = "08/05/2022 00:00:00";

            // act & assert
            ActionFormatDate();

        }
    }

    [TestClass()]
    public class CAT_050_VarsByFormatDouble_Test : xVars_Test
    {

        [TestMethod()]
        public void TST010_VarDouble_DecimalPadrao()
        {

            input = @"#######.00";
            output = "123.45";

            // act & assert
            ActionFormatDouble(prmNumber: 123.45);

        }

        [TestMethod()]
        public void TST020_VarDouble_NumeroInteiro()
        {

            input = @"#######.00";
            output = "123.00";

            // act & assert
            ActionFormatDouble(prmNumber: 123);

        }

        [TestMethod()]
        public void TST030_VarDouble_NumeroUnicoDecimal()
        {

            input = @"#######.00";
            output = "123.40";

            // act & assert
            ActionFormatDouble(prmNumber: 123.4);

        }

        [TestMethod()]
        public void TST040_VarDouble_NumeroEstouroDecimal()
        {

            input = @"#######.00";
            output = "123.46";

            // act & assert
            ActionFormatDouble(prmNumber: 123.456);

        }

        [TestMethod()]
        public void TST050_VarDouble_NumeroMilhoes()
        {

            input = @"#######.00";
            output = "12143123.45";

            // act & assert
            ActionFormatDouble(prmNumber: 12143123.45);

        }

        [TestMethod()]
        public void TST060_VarDouble_NumeroMilhoesFormatado()
        {

            input = @"#,###,###.00";
            output = "12,143,123.45";

            // act & assert
            ActionFormatDouble(prmNumber: 12143123.45);

        }
        
        [TestMethod()]
        public void TST070_VarDouble_DecimalNegativo()
        {

            input = @"#######.00";
            output = "-123.40";

            // act & assert
            ActionFormatDouble(prmNumber: -123.4);

        }

        [TestMethod()]
        public void TST080_VarDouble_MultiplosFormatos()
        {

            input = @"#######.00;(#######.00)";
            output = "(123.40)";

            // act & assert
            ActionFormatDouble(prmNumber: -123.4);

        }
        [TestMethod()]
        public void TST090_VarDouble_NumeroDecimalFormatoVazio()
        {

            input = "";
            output = "123.4";

            // act & assert
            ActionFormatDouble(prmNumber: 123.4);

        }
        [TestMethod()]
        public void TST100_VarDouble_NumeroInteiroFormatoVazio()
        {

            input = "";
            output = "123";

            // act & assert
            ActionFormatDouble(prmNumber: 123);

        }
        [TestMethod()]
        public void TST110_VarDouble_NumeroNegativoFormatoVazio()
        {

            input = "";
            output = "-123";

            // act & assert
            ActionFormatDouble(prmNumber: -123);

        }
        [TestMethod()]
        public void TST120_VarDouble_NumeroZeroFormatoVazio()
        {

            input = "";
            output = "0";

            // act & assert
            ActionFormatDouble(prmNumber: 0);

        }
        [TestMethod()]
        public void TST130_VarDouble_NumeroDecimalFormatoNull()
        {

            input = null;
            output = "123.45";

            // act & assert
            ActionFormatDouble(prmNumber: 123.45);

        }

    }

    public class xVars_Test
    {

        public DateTime date = new System.DateTime(2022, 05, 08);

        public string input;
        public string output;
        public string result;

        public void ActionFormatText(string prmFormat)
        {

            // assert
            result = myFormat.TextToString(input, prmFormat);

            // assert
            ActionGeneric();

        }
        public void ActionFormatMask(string prmMask)
        {

            // assert
            result = myFormat.TextToString(input, prmMask);

            // assert
            ActionGeneric();

        }
        public void ActionFormatDate()
        {

            // assert
            result = myFormat.DateToString(date, input);

            // assert
            ActionGeneric();

        }
        public void ActionFormatDouble(Double prmNumber) => ActionFormatDouble(prmNumber, prmRegionalizacao: CultureInfo.InvariantCulture);
        public void ActionFormatDouble(Double prmNumber, CultureInfo prmRegionalizacao) => ActionFormatDouble(prmNumber, prmRegionalizacao, prmCSV: false);
        public void ActionFormatDouble(Double prmNumber, CultureInfo prmRegionalizacao, bool prmCSV)
        {

            // assert
            result = myFormat.DoubleToString(prmNumber, input, prmRegionalizacao, prmCSV);

            // assert
            ActionGeneric();

        }
        public void ActionGeneric()
        {

            // assert
            if (output != result)
                Assert.Fail(string.Format("{2} Expected: <{0}> {2}   Actual: <{1}>", output, result, Environment.NewLine));

        }

    }
}
