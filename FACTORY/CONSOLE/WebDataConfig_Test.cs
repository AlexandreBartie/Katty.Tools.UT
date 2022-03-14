using BlueRocket.CORE.Lib.Files;
using BlueRocket.CORE.Lib.Vars;
using BlueRocket.CORE.Tests.Factory.lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueRocket.CORE.Tests.FACTORY.CONFIG
{

    [TestClass()]
    public class CAT_010_DataConfig_Test : DataConfig_Test
    {

        [TestMethod()]
        public void TST010_DataConfig_ArquivoConfigOK()
        {

            // arrange

            input = @"C:\MassaTestes\TestQA.cfg";

            output = ArgOutput.GetOutputTimeOut(prmTimeOutDB: "5", prmTimeOutSQL: "15");

            // act
            Console.Setup(prmArquivoCFG: input);

             // & assert
            VerifyExpectedData();

        }

        [TestMethod()]
        public void TST020_DataConfig_ConteudoConfigOK()
        {
            // arrange

            input = ArgInput.GetInput();

            output = ArgOutput.GetOutput();

            // act
            Console.Config.Parse(prmBloco: input);

            // & assert
            VerifyExpectedData();

        }

        [TestMethod()]
        public void TST030_DataConfig_ConteudoMultiplasBases()
        {

            // arrange

            input = ArgInput.GetInputSecondDB(prmSecondDB: true);

            output = ArgOutput.GetOutputDBase(prmStatusDB: "CONECTADO", prmSecondDB: true);

            // act
            //ConnectDbOracle();

            Console.Config.Parse(prmBloco: input);

            // & assert
            VerifyExpectedData();

        }

        [TestMethod()]
        public void TST040_DataConfig_ConteudoDBInexistente()
        {
            input = ArgInput.GetInputServiceDB(prmServiceDB: "HOMOLOGACAO");

            // arrange
            output = ArgOutput.GetOutputDBase(prmStatusDB: "ERRO", prmSecondDB: false);

            // act

            Console.Config.Parse(prmBloco: input);

            // & assert
            VerifyExpectedData();

        }

        [TestMethod()]
        public void TST050_DataConfig_ConteudoDataFixa()
        {

            sintaxeToday = "D=14|M=12|A=2020";
            formatDate = "AAAAMMDD";

            input = ArgInput.GetInputCSV(prmSintaxeToday: sintaxeToday, prmFormatDate: formatDate);

            // arrange
            output = ArgOutput.GetOutputCSV(sintaxeToday, prmFormatDate: formatDate, prmFormatToday: "20201214");

            // act
            Console.Config.Parse(prmBloco: input);

            // & assert
            VerifyExpectedData();

        }
        
        [TestMethod()]
        public void TST060_DataConfig_ConteudoEspacamentos()
        {
            input = ArgInput.GetInput();

            // arrange
            output = ArgOutput.GetOutput();

            // act
            Console.Config.Parse(prmBloco: input);

            // & assert
            VerifyExpectedData();

        }
    }

    public class DataConfig_Test : DataBasicFactory_Test
    {

        public Diretorio dir;

        public DateTime date;

        public string sintaxeToday;

        public string formatDate;

        public DataConfig_InputTest ArgInput;

        public DataConfig_OutputTest ArgOutput;

        public DataConfig_Test()
        {
            ArgInput = new DataConfig_InputTest(this);

            ArgOutput = new DataConfig_OutputTest(this);
        }

        public void VerifyExpectedData()
        {

            if (Console.DoConnect())


            base.VerifyExpectedData(prmData: Console.Config.status());
        }

    }

    public class DataConfig_InputTest
    {
        
        private DataConfig_Test DataConfig;

        public bool secondDB;
        public string serviceDB;

        public string sintaxeToday;

        public string formatRegion;
        public string formatDate;

        public string SetupCommand_Line1;
        public string SetupCommand_Line2;

        public string timeout_DB;
        public string timeout_SQL; 

        public DataConfig_InputTest(DataConfig_Test prmDataConfig)
        {
            DataConfig = prmDataConfig;
        }
        private void Reset()
        {

            secondDB = false;
            serviceDB = "INTEGRATION";

            sintaxeToday = "D+0";

            formatRegion = "pt-BR";
            formatDate = "DD/MM/AAAA";

            timeout_DB = "30";
            timeout_SQL = "20";

        }
        private string GetDefault()
        {
            string input = "";

            input += GetInputDBase();
            input += GetInputConnect();
            input += GetInputCSV();
            input += GetInputPath();

            return input;
        }
        public string GetInput()
        {
            Reset(); return GetDefault();
        }
        public string GetInputSecondDB(bool prmSecondDB)
        {
            Reset(); secondDB = prmSecondDB; return GetDefault();
        }
        public string GetInputServiceDB(string prmServiceDB)
        {
            Reset(); serviceDB = prmServiceDB; return GetDefault();
        }
        public string GetInputCSV(string prmSintaxeToday, string prmFormatDate)
        {
            Reset(); sintaxeToday = prmSintaxeToday; formatDate = prmFormatDate; return GetDefault();
        }

        private string GetInputDBase()
        {
            string texto = "";

            string conexao = "-db[{0}]: {{ 'host': '10.250.1.35', 'port': '1521', 'service': '{1}.Prod01.redelocal.oraclevcn.com', 'user': 'desenvolvedor_sia', 'password': 'asdfg' }}";

            texto = ">dbase:" + Environment.NewLine;
            texto += ", " + String.Format(conexao, "SIA", serviceDB) + Environment.NewLine;

            if (secondDB)
                texto += String.Format(conexao, "TCA", serviceDB) + Environment.NewLine;

            return texto;
        }
        private string GetInputConnect()
        {
   
            string texto = "";

            texto += @">connect: " + Environment.NewLine;
            texto += @"  -setup: Alter Session set NLS_DATE_FORMAT = 'dd/mm/yy'" + Environment.NewLine;
            texto += @"  -setup: Alter Session set NLS_NUMERIC_CHARACTERS = ',.' " + Environment.NewLine;
            texto += @"  -timeoutDB : 05" + Environment.NewLine;
            texto += @"  -timeoutSQL: 15" + Environment.NewLine;

            return texto;
        }
        public string GetInputPath()
        {
            string texto = "";

            texto += @">path: " + Environment.NewLine;
            texto += @"-cfg: C:\MassaTestes\POC\CLI\CFG\" + Environment.NewLine;
            texto += @"-ini: C:\MassaTestes\POC\CLI\INI\" + Environment.NewLine;
            texto += @"-out: C:\MassaTestes\POC\CLI\OUT\" + Environment.NewLine;
            texto += @"-log: C:\MassaTestes\POC\CLI\LOG\" + Environment.NewLine;

            return texto;
        }

        private string GetInputCSV()
        {

            string texto = "";

            texto += @">csv: " + Environment.NewLine;
            texto += @"-region: " + formatRegion + Environment.NewLine;
            texto += @"-today: " + sintaxeToday + Environment.NewLine;
            texto += @"-save: txt.1252.csv" + Environment.NewLine;

            if (formatDate != "")
                texto += @"-date: " + formatDate + Environment.NewLine;

            return texto;
        }


    }

    public class DataConfig_OutputTest
    {

        private DataConfig_Test DataConfig;

        public bool secondDB;
        public string statusDB;

        public string sintaxeToday;

        public string formatRegion;
        public string formatToday;
        public string formatDate;

        public string timeout_DB;
        public string timeout_SQL;

        public DataConfig_OutputTest(DataConfig_Test prmDataConfig)
        {
            DataConfig = prmDataConfig;
        }

        private void Reset()
        {

            secondDB = false;
            statusDB = "CONECTADO";

            sintaxeToday = "D+0";

            formatRegion = "pt-BR";
            formatToday = "";
            formatDate = "DD/MM/AAAA";

            timeout_DB = "5";
            timeout_SQL = "15";

        }
        private string GetDefault() => GetDefault(prmConnectedDB: true);
        private string GetDefault(bool prmConnectedDB)
        {
            string output = "";

            output += GetOutputDBase();

            if (prmConnectedDB)
            {
                output += GetOutputConnect();
                output += GetOutputCSV();
                output += GetOutputPath();
            }

            output += GetOutputTest();

            return output;
        }
        public string GetOutput()
        {
            Reset(); return GetDefault();
        }
        public string GetOutputDBase(string prmStatusDB, bool prmSecondDB)
        {
            Reset(); statusDB = prmStatusDB; secondDB = prmSecondDB; return GetDefault(prmConnectedDB: (prmStatusDB !=  "ERRO"));
        }
        public string GetOutputRegion(string prmRegion)
        {
            Reset(); formatRegion = prmRegion; return GetDefault();
        }
        public string GetOutputCSV(string prmSintaxeToday, string prmFormatDate, string prmFormatToday)
        {
            Reset(); sintaxeToday = prmSintaxeToday;  formatToday = prmFormatToday; formatDate = prmFormatDate; return GetDefault();
        }
        public string GetOutputTimeOut(string prmTimeOutDB, string prmTimeOutSQL)
        {
            Reset(); timeout_DB = prmTimeOutDB; timeout_SQL = prmTimeOutSQL; return GetDefault();
        }

        private string GetOutputDBase()
        {
            string texto = "";

            texto += @">dbase: ";
            texto += @"-db[SIA]: " + statusDB;

            if (secondDB)
                texto += @", -db[TCA]: " + statusDB;

            return texto;
        }

        private string GetOutputConnect()
        {

            string mask = @" | >connect: -setup: {0}, -timeoutDB: {1}, -timeoutSQL: {2}";

            string setup = "";
            setup += "Alter Session set NLS_DATE_FORMAT = 'dd/mm/yy'";
            setup += " | ";
            setup += "Alter Session set NLS_NUMERIC_CHARACTERS = ',.'";

            return string.Format(mask, setup, timeout_DB, timeout_SQL);

        }
        private string GetOutputCSV()
        {

            string mask = @" | >csv: -region: {0}, -today: {1}, -date: {2}, -save: txt.1252.csv";

            return string.Format(mask, formatRegion, sintaxeToday, formatDate);
        }

        private string GetOutputPath()
        {
            string texto = "";

            texto += @" | ";
            texto += @">path: ";
            texto += @"-cfg: 'C:\MassaTestes\POC\CLI\CFG\', ";
            texto += @"-ini: 'C:\MassaTestes\POC\CLI\INI\', ";
            texto += @"-out: 'C:\MassaTestes\POC\CLI\OUT\', ";
            texto += @"-log: 'C:\MassaTestes\POC\CLI\LOG\'";

            return texto;
        }
        private string GetOutputTest()
        {

            string txt_formatDate;

            if (formatToday == "")
                txt_formatDate = myFormat.DateToString(myDate.Calc(sintaxeToday), formatDate);
            else
                txt_formatDate = formatToday;

            string texto = "";

            texto += @" | ";
            texto += @">test: ";
            texto += @"-date: " + txt_formatDate + ", ";
            texto += @"-double: ""1234,5""";
            return texto;
        }
        internal string GetPath(string prmPath) => @"C:\MassaTestes\POC\TesteUT\" + prmPath;

    }
}
