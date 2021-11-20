using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Windows.Forms;

namespace Dooggy.Tests
{
    [TestClass()]
    public class xParseCSV_Test
    {
        string input;
        string output;

        [TestMethod()]
        public void TST010_FluxoCSV_Padrao()
        {

            // arrange
            input = "1234,2345,3,5,78";
            output = "4,4,1,1,2";

            // act & assert
            ActionParseCSV();

        }

        [TestMethod()]
        public void TST020_FluxoCSV_Vazio()
        {
            // arrange
            input = "";
            output = "";

            // act & assert
            ActionParseCSV();
        }

        [TestMethod()]
        public void TST030_FluxoCSV_ItemUnico()
        {
            // arrange
            input = "82";
            output = "2";

            // act & assert
            ActionParseCSV();
        }

        [TestMethod()]
        public void TST040_FluxoCSV_ItemVazio()
        {
            // arrange
            input = "1234,,3,5,78";
            output = "4,0,1,1,2";

            // act & assert
            ActionParseCSV();
        }

        [TestMethod()]
        public void TST050_FluxoCSV_MultiplosVazios()
        {
            // arrange
            input = " , , , , ";
            output = "0,0,0,0,0";

            // act & assert
            ActionParseCSV();
        }
        [TestMethod()]
        public void TST060_FluxoCSV_IgnorarEspacos()
        {
            // arrange
            input = @"   Alexandre   ,    Bartie     , 376.52  ,   alexandre.bartie@hotmail.com   ";
            output = "9,6,6,28";

            // act & assert
            ActionParseCSV();
        }

        [TestMethod()]
        public void TST070_FluxoCSV_IgnorarDelimitadores()
        {
            // arrange
            input = @"Alexandre,Bartie,  3|76.5|2 , alexandre.bartie@hotmail.com";
            output = "9,6,8,28";

            // act & assert
            ActionParseCSV();
        }

        [TestMethod()]
        public void TST080_FluxoCSV_Delimitado_ItemNormal()
        {
            // arrange
            input = @"Alexandre,Bartie,  |376.52|  ,alexandre.bartie@hotmail.com";
            output = "9,6,8,28";

            // act & assert
            ActionParseCSV();
        }


        [TestMethod()]
        public void TST090_FluxoCSV_Delimitado_ItemNormalComEspacos()
        {
            // arrange
            input = @"Alexandre,Bartie,  | 376.52 |  ,alexandre.bartie@hotmail.com";
            output = "9,6,10,28";

            // act & assert
            ActionParseCSV();
        }
        
        [TestMethod()]
        public void TST100_FluxoCSV_Delimitado_ItemEspacos()
        {
            // arrange
            input = @"Alexandre,Bartie,  |     |  ,alexandre.bartie@hotmail.com";
            output = "9,6,7,28";

            // act & assert
            ActionParseCSV();
        }
       
        [TestMethod()]
        public void TST110_FluxoCSV_DelimitadoComVirgula_Padrao()
        {
            // arrange
            input = @"Alexandre,Bartie,  | 376,52 |  ,alexandre.bartie@hotmail.com";
            output = "9,6,10,28";

            // act & assert
            ActionParseCSV();
        }

        [TestMethod()]
        public void TST120_FluxoCSV_DelimitadoComVirgula_MultiplasVirgulas()
        {
            // arrange
            input = @"Alexandre,Bartie,  |,1,,376,52,,78,999,,3,|  ,alexandre.bartie@hotmail.com";
            output = "9,6,24,28";

            // act & assert
            ActionParseCSV();
        }

        [TestMethod()]
        public void TST130_FluxoCSV_DelimitadoComVirgula_MultiplasVirgulas_ComEspacamentos()
        {
            // arrange
            input = @"Alexandre,Bartie,  |  , 1 , , 376 , 52 ,, 78 , 999 , , 3   |  ,alexandre.bartie@hotmail.com";
            output = "9,6,41,28";

            // act & assert
            ActionParseCSV();
        }

        [TestMethod()]
        public void TST140_FluxoCSV_DelimitadoComVirgula_ExtraDelimitador()
        {
            // arrange
            input = @"Alexandre,Bartie,  | 37|6,52 |  ,alexandre.bartie@hotmail.com";
            output = "9,6,11,28";

            // act & assert
            ActionParseCSV();
        }

        [TestMethod()]
        public void TST150_FluxoCSV_DelimitadoComVirgula_ExtraDoubleSTART()
        {
            // arrange
            input = @"Alexandre,Bartie,  | 37|6,|52 |  ,alexandre.bartie@hotmail.com";
            output = "9,6,12,28";

            // act & assert
            ActionParseCSV();
        }
        
        [TestMethod()]
        public void TST160_FluxoCSV_DelimitadoComVirgula_DelimitadorNoSTART()
        {
            // arrange
            input = @"Alexandre,Bartie,  3|76,52 |  ,alexandre.bartie@hotmail.com";
            output = "9,6,4,4,28";

            // act & assert
            ActionParseCSV();
        }

        [TestMethod()]
        public void TST170_FluxoCSV_DelimitadoComVirgula_DelimitadorNoEND()
        {
            // arrange
            input = @"Alexandre,Bartie, | 3|76,5|2  ,alexandre.bartie@hotmail.com";
            output = "9,6,6,3,28";

            // act & assert
            ActionParseCSV();
        }

        [TestMethod()]
        public void TST180_FluxoCSV_DelimitadoComVirgula_DelimitadorEND()
        {
            // arrange
            input = @"Alexandre,Bartie, | 376|,52 |";
            output = "9,6,6,4";

            // act & assert
            ActionParseCSV();
        }
        [TestMethod()]
        public void TST190_FluxoCSV_DelimitadoComVirgula_DelimitadorENDFake()
        {
            // arrange
            input = @"Alexandre,Bartie, | 376,|52 |";
            output = "9,6,11";

            // act & assert
            ActionParseCSV();
        }
        private void ActionParseCSV()
        {

            // assert
            xParseCSV list = new xParseCSV(input);

            // build "result" to compare with "output"
            string result = list.log;

            // assert
            if (output != result)
                Assert.Fail(string.Format("Expected: <{0}>, Actual: <{1}>, Memo: <{2}>", output, result, list.memo()));

        }

    }
}