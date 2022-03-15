using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Diagnostics;

namespace BlueRocket.LIBRARY.TESTS.DATA.CONNECTION
{
    [TestClass()]
    public class DataBaseConnection_Test : DataConnection_Test
    {

        [TestMethod()]
        public void TST010_DataBase_ConexaoOracleOK()
        {

            // arrange
            output = "SIM";

            // act
            ConnectDbOracle();

            // & assert
            VerifyDataBase();

        }

        [TestMethod()]
        public void TST020_DataBase_ConexaoOracleFail()
        {

            // arrange
            output = "NAO";

            // act
            ConnectDbOracle(prmSenha: "123456");

            // & assert
            VerifyDataBase();

        }

        private void VerifyDataBase()
        {

            // assert
            string result = GetYesNo(prmOpcao: Connect.IsDbOK);

            // assert
            if (output != result)
                Assert.Fail(string.Format("Expected: <{0}>, Actual: <{1}>", output, result));

        }

    }

    public class DataConnection_Test
    {
        public string input;
        public string output;

        private TraceLog Trace = new TraceLog();

        public DataConnect Connect;

        private DataBaseOracle Oracle => Connect.Assist.Oracle;

        public DataConnection_Test()
        {
            Connect = new DataConnect(Trace);
        }

        public void ConnectDbOracle() { ConnectDbOracle(prmSenha: "asdfg"); }

        public void ConnectDbOracle(string prmSenha)
        {

            Oracle.user = "desenvolvedor_sia";
            Oracle.password = prmSenha;

            Oracle.host = "10.250.1.35";
            Oracle.service = "branch_1083.prod01.redelocal.oraclevcn.com";


            Connect.AddDataBase(prmTag: "SIA", prmConexao: Oracle.GetString());

        }

        public string GetYesNo(bool prmOpcao) { if (prmOpcao) return "SIM"; return "NAO"; }

    }


}
