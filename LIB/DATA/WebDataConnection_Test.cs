using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Diagnostics;

namespace Katty.UTC.LIB.DATA
{
    [TestClass()]
    public class DataBaseConnection_Test : DataBase_UTC
    {

        [TestMethod()]
        public void TST010_DataBase_ConexaoOracleOK()
        {

            // arrange
            output("Yes");

            // & assert
            VerifyDataBase();

        }

        [TestMethod()]
        public void TST020_DataBase_ConexaoOracleFail()
        {

            // arrange
            output("No");

            // & assert
            VerifyDataBase(prmSenha: "abcedf");

        }

    }

    [TestClass()]
    public class DataCursorByLog_Test : DataBase_UTC
    {

        [TestMethod()]
        public void TST010_DataCursorByLog_SQLExecutado()
        {

            // arrange
            inputText("SELECT cod_usuario, '1234as' as senha, 'Leonardo' as nom_usuario");
            inputText(" FROM seg.usuario");
            inputText(" WHERE cod_usuario = '11959056700'");

            output("[ SQL] -db[SIA] -sql: " + GetInput());

            // & assert
            VerifyDataCursorByLog();

        }

        [TestMethod()]
        public void TST020_DataCursorByLog_SQLNoResults()
        {

            inputText("SELECT cod_usuario, '1234as' as senha, 'Leonardo' as nom_usuario");
            inputText("  FROM seg.usuario");
            inputText("  WHERE cod_usuario = '1'");

            outputText("[ERRO] >>>> [ZERO Results] -db[SIA] -sql: ");
            outputText(GetInput());

            // & assert
            VerifyDataCursorByLog();

        }
        [TestMethod()]
        public void TST030_DataCursorByLog_SQLFail()
        {

            // arrange
            inputText("SELECT cod_ususario, '1234as' as senha, 'Leonardo' as nom_usuario");
            inputText("  FROM seg.usuario");
            inputText(" WHERE cod_usuario = '11959056700'");

            outputText(@"[ERRO] >>>> [ORA-00904: ""COD_USUSARIO"": identificador inválido] ");
            outputText(@"SQL falhou ... -db[SIA] -sql: ");
            outputText(GetInput());

            // & assert
            VerifyDataCursorByLog();

        }
    }

    [TestClass()]
    public class DataCursorByMask_Test : DataBase_UTC
    {

        [TestMethod()]
        public void TST010_DataCursorByMask_SQLMaskTXT()
        {

            // arrange
            inputText("SELECT cod_usuario, '1234as' as senha, 'Leonardo' as nome");
            inputText(" FROM seg.usuario");
            inputText(" WHERE cod_usuario = '11959056700'");

            output("11-959-056-700,1234as,Leo");

            // & assert
            VerifyDataCursorByMask(prmMask: @"cod_usuario: ##-###-###-###, nome: X(3)");

        }

        [TestMethod()]
        public void TST020_DataCursorByMask_SQLMaskDate()
        {

            // arrange
            inputText("SELECT dt_vencimento, dt_baixa, dt_geracao ");
            inputText(" FROM SIA.carne");
            inputText(" WHERE num_seq_carne = '29600296'");


            output("2004-mai-07,20040625,12-04-2004");

            // & assert
            VerifyDataCursorByMask(prmMask: @"dt_vencimento: AAAA-MMM-DD, dt_baixa: AAAAMMDD, dt_geracao: DD-MM-AAAA");

        }

        [TestMethod()]
        public void TST030_DataCursorByMask_SQLMaskNumeric()
        {

            // arrange
            inputText("SELECT num_seq_carne, val_a_pagar, val_desconto, val_multa, val_pago ");
            inputText(" FROM SIA.carne");
            inputText(" WHERE num_seq_carne = '53869974'");

            output("53869974,407.31,0.00,8.15,0.00");

            // & assert
            VerifyDataCursorByMask(prmMask: @"val_a_pagar: #0.00, val_desconto: #0.00, val_multa: #0.00, val_pago: #0.00");

        }

        [TestMethod()]
        public void TST040_DataCursorByMask_SQLMaskAlias()
        {

            // arrange
            inputText("SELECT cod_usuario as usuario, '1234as' as senha, 'Leonardo' as nome");
            inputText(" FROM seg.usuario");
            inputText(" WHERE cod_usuario = '11959056700'");

            output("11-959-056-700,1234as,Leo");

            // & assert
            VerifyDataCursorByMask(prmMask: @"usuario[cod_usuario: ##-###-###-###], nome: X(3)");

        }
        [TestMethod()]
        public void TST050_DataCursorByMask_SQLMaskAliasOculto()
        {

            // arrange
            inputText("SELECT cod_usuario as usuario, '1234as' as senha, 'Leonardo' as nome");
            inputText(" FROM seg.usuario");
            inputText(" WHERE cod_usuario = '11959056700'");

            output("11-959-056-700,1234as,Leo");

            // & assert
            VerifyDataCursorByMask(prmMask: @"usuario[:##-###-###-###], nome: X(3)");

        }

    }


    public class DataBase_UTC : UTControl
    {

        private TraceLog Trace = new TraceLog();

        public DataConnect Connect;

        public DataBase Base => Connect.DataBaseCorrente;

        private DataBaseOracle Oracle => Connect.Assist.Oracle;

        public DataBase_UTC()
        {
            Connect = new DataConnect(Trace);
        }

        public void VerifyDataBase() => VerifyDataBase(prmSenha: "asdfg");
        public void VerifyDataBase(string prmSenha)
        {

            ConnectDbOracle(prmSenha);

            AssertTest(prmResult: myBool.GetYesNo(prmOpcao: Connect.IsDbOK));

        }

        public void VerifyDataCursorByLog()
        {

            ConnectDbOracle(prmSenha: "asdfg");

            DataCursor cursor = Base.GetCursor(prmSQL: GetInput(), prmMask: "");

            AssertTest(prmResult: cursor.Log.txt);
        }

        public void VerifyDataCursorByMask(string prmMask)
        {

            ConnectDbOracle(prmSenha: "asdfg");

             DataCursor cursor = Base.GetCursor(prmSQL: GetInput(), prmMask);

            AssertTest(prmResult: cursor.csv());
        }

        private void ConnectDbOracle() => ConnectDbOracle(prmSenha: "asdfg");
        private void ConnectDbOracle(string prmSenha)
        {

            Oracle.user = "desenvolvedor_sia";
            Oracle.password = prmSenha;

            Oracle.host = "10.250.1.35";
            Oracle.port = "1521";
            Oracle.service = "INTEGRATION.prod01.redelocal.oraclevcn.com";

            Connect.AddDataBase(prmTag: "SIA", prmConexao: Oracle.GetString());

            Base.Setup();

        }

    }


}
