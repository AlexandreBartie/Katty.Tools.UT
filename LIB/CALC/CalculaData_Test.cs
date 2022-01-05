using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dooggy.Tests.LIB.VARS
{

    [TestClass()]
    public class DynamicDateByCalc_Test : DynamicDate_Test
    {

        [TestMethod()]
        public void TST_DynamicDateByCalc_010_Hoje()
        {

            input = "D=0";
            output = "05/06/2021";

            // act & assert
            ActionDynamicDateByCalc();

        }

        [TestMethod()]
        public void TST_DynamicDateByCalc_020_DiaFixo()
        {

            input = "D=15";
            output = "15/06/2021";

            // act & assert
            ActionDynamicDateByCalc();

        }

        [TestMethod()]
        public void TST_DynamicDateByCalc_030_DiaMais()
        {

            input = "D+1";
            output = "06/06/2021";

            // act & assert
            ActionDynamicDateByCalc();

        }

        [TestMethod()]
        public void TST_DynamicDateByCalc_040_DiaMenos()
        {

            input = "D-1";
            output = "04/06/2021";

            // act & assert
            ActionDynamicDateByCalc();

        }

        [TestMethod()]
        public void TST_DynamicDateByCalc_050_DiaMaisViraMes()
        {

            input = "D+28";
            output = "03/07/2021";

            // act & assert
            ActionDynamicDateByCalc();

        }
        [TestMethod()]
        public void TST_DynamicDateByCalc_060_DiaMenosViraMes()
        {

            input = "D-10";
            output = "26/05/2021";

            // act & assert
            ActionDynamicDateByCalc();

        }
        [TestMethod()]
        public void TST_DynamicDateByCalc_070_DiaFixoEstouro()
        {

            input = "D=31";
            output = "30/06/2021";

            // act & assert
            ActionDynamicDateByCalc();

        }
        [TestMethod()]
        public void TST_DynamicDateByCalc_100_MesFixo()
        {

            input = "M=2";
            output = "05/02/2021";

            // act & assert
            ActionDynamicDateByCalc();

        }

        [TestMethod()]
        public void TST_DynamicDateByCalc_110_MesMais()
        {

            input = "M+1";
            output = "05/07/2021";

            // act & assert
            ActionDynamicDateByCalc();

        }

        [TestMethod()]
        public void TST_DynamicDateByCalc_120_MesMenos()
        {

            input = "M-1";
            output = "05/05/2021";

            // act & assert
            ActionDynamicDateByCalc();

        }

        [TestMethod()]
        public void TST_DynamicDateByCalc_130_MesMaisViraAno()
        {

            input = "M+7";
            output = "05/01/2022";

            // act & assert
            ActionDynamicDateByCalc();

        }

        [TestMethod()]
        public void TST_DynamicDateByCalc_140_MesMenosViraAno()
        {

            input = "M-6";
            output = "05/12/2020";

            // act & assert
            ActionDynamicDateByCalc();

        }


        [TestMethod()]
        public void TST_DynamicDateByCalc_150_MesEstouro()
        {

            input = "M=13";
            output = "05/12/2021";

            // act & assert
            ActionDynamicDateByCalc();

        }

        [TestMethod()]
        public void TST_DynamicDateByCalc_200_AnoFixo()
        {

            input = "A=2024";
            output = "05/06/2024";

            // act & assert
            ActionDynamicDateByCalc();

        }

        [TestMethod()]
        public void TST_DynamicDateByCalc_210_AnoMais()
        {

            input = "A+1";
            output = "05/06/2022";

            // act & assert
            ActionDynamicDateByCalc();

        }

        [TestMethod()]
        public void TST_DynamicDateByCalc_220_AnoMenos()
        {

            input = "A-1";
            output = "05/06/2020";

            // act & assert
            ActionDynamicDateByCalc();

        }
        [TestMethod()]
        public void TST_DynamicDateByCalc_230_AnoEstouro()
        {

            input = "A=4500";
            output = "05/06/2500";

            // act & assert
            ActionDynamicDateByCalc();

        }

    }

    [TestClass()]
    public class DynamicDateByView_Test : DynamicDate_Test
    {

        [TestMethod()]
        public void TST_DynamicDateByView_010_FormatacaoPadrao()
        {

            input = "D+1|M=3|A-20";
            output = "06/03/2001";

            // act & assert
            ActionDynamicDateByView();

        }

        [TestMethod()]
        public void TST_DynamicDateByView_020_UltimoDiaMesAnterior()
        {

            input = "D=1|D-1";
            output = "31/05/2021";

            // act & assert
            ActionDynamicDateByView();

        }

        [TestMethod()]
        public void TST_DynamicDateByView_030_UltimoDiaMesPosterior()
        {

            input = "D=1|D-1|M+2";
            output = "31/07/2021";

            // act & assert
            ActionDynamicDateByView();

        }

        [TestMethod()]
        public void TST_DynamicDateByView_040_UltimoDiaMesFevereiroAnoCorrente()
        {

            input = "D=31|M=2";
            output = "28/02/2021";

            // act & assert
            ActionDynamicDateByView();

        }

        [TestMethod()]
        public void TST_DynamicDateByView_050_UltimoDiaMesFevereiroAnoSeguinte()
        {

            input = "D=31|M=2|A+1";
            output = "28/02/2022";

            // act & assert
            ActionDynamicDateByView();

        }

        [TestMethod()]
        public void TST_DynamicDateByView_060_UltimoDiaMesFevereiroAnoBissexto()
        {

            input = "D=31|M=2|A=2024";
            output = "29/02/2024";

            // act & assert
            ActionDynamicDateByView();

        }

        [TestMethod()]
        public void TST_DynamicDateByView_070_PenultimoDiaProximoMes()
        {

            input = "D=1|D-2|M+2";
            output = "30/07/2021";

            // act & assert
            ActionDynamicDateByView();

        }

        [TestMethod()]
        public void TST_DynamicDateByView_080_3MesesAntes()
        {

            input = "M-3:MMAAAA";
            output = "032021";

            // act & assert
            ActionDynamicDateByView();

        }

        [TestMethod()]
        public void TST_DynamicDateByView_090_3MesesDepois()
        {

            input = "M+3:MMAAAA";
            output = "092021";

            // act & assert
            ActionDynamicDateByView();

        }

        [TestMethod()]
        public void TST_DynamicDateByView_100_CaixaBaixa()
        {

            input = "d=31|m=2|a=2024:aaaammdd";
            output = "20240229";

            // act & assert
            ActionDynamicDateByView();

        }

        [TestMethod()]
        public void TST_DynamicDateByView_110_EspacosEmBranco()
        {

            input = "   d  =  31  |  m  =  2  |  a  =  2024  : aaaa mm dd ";
            output = " 2024 02 29 ";

            // act & assert
            ActionDynamicDateByView();

        }

    }

    public class DynamicDate_Test
    {


        public DateTime ancora = new DateTime(2021, 6, 5);

        public string input;
        public string output;
        public string result;


        public void ActionDynamicDateByCalc()
        {

            DynamicDate Data = new DynamicDate(ancora);

            // assert
            result = Data.Calc(prmSintaxe: input).ToString("dd/MM/yyyy");

            // assert
            ActionGeneric();

        }

        public void ActionDynamicDateByView()
        {

            DynamicDate Data = new DynamicDate(ancora);

            // assert
            result = Data.View(prmSintaxe: input);

            // assert
            ActionGeneric();

        }

        public void ActionGeneric()
        {

            // assert
            if (output != result)
                Assert.Fail(string.Format("Expected: <{0}>, Actual: <{1}>", output, result));

        }

    }

}

