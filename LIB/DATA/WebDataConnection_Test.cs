using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Diagnostics;
using Dooggy;
using Dooggy.Lib.Data;
using Dooggy.Factory.Data;
using Dooggy.Factory;

namespace Dooggy.Tests.LIB.DATA
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
            output = "SIM";

            // act
            ConnectDbOracle(prmSenha: "123456");

            // & assert
            VerifyDataBase();

        }

        private void VerifyDataBase()
        {

            // assert
            string result = GetYesNo(prmOpcao: Pool.IsON());

            // assert
            if (output != result)
                Assert.Fail(string.Format("Expected: <{0}>, Actual: <{1}>", output, result));

        }

    }

    public class DataConnection_Test
    {
        public string input;
        public string output;

         public TestDataPool Pool;

        public void ConnectDbOracle() { ConnectDbOracle(prmSenha: "asdfg"); }

        public void ConnectDbOracle(string prmSenha)
        {

            Pool = new TestDataPool();

            Pool.Connect.Oracle.user = "desenvolvedor_sia";
            Pool.Connect.Oracle.password = prmSenha;

            Pool.Connect.Oracle.host = "10.250.1.35";
            Pool.Connect.Oracle.port = "1521";
            Pool.Connect.Oracle.service = "branch_1083.prod01.redelocal.oraclevcn.com";


            Pool.Connect.Oracle.Add(prmTag: "SIA");

        }

        public string GetYesNo(bool prmOpcao) { if (prmOpcao) return "SIM"; return "NAO"; }

    }


}
