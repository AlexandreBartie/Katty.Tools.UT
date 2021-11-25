using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Diagnostics;
using Dooggy;
using Dooggy.KERNEL;

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

    [TestClass()]
    public class DataViewConnection_Test : DataConnection_Test
    {

         [TestMethod()]
        public void TST010_DataView_ViewUnicoResultado()
        {

            // arrange
            output = "{ 'COD_MATRICULA': '198402018831', 'NOM_RESPONSAVEL_PGTO': 'PAULO LOUREIRO FILHO' }";

            // act
            ConnectDbOracle();

            Pool.AddDataView(prmTag: "Aluno=Padrao", prmSQL: GetComandoSQL());

            // & assert
            VerifyDadosDataView(prmTag: "Aluno=Padrao");

        }

        [TestMethod()]
        public void TST020_DataView_ViewMultiplosResultados()
        {

            // arrange
            output = "{ 'COD_MATRICULA': '198402018831', 'NOM_RESPONSAVEL_PGTO': 'PAULO LOUREIRO FILHO' }";

            // act
            ConnectDbOracle();

            Pool.AddDataView(prmTag: "Aluno=Padrao", prmSQL: GetComandoSQL(prmUnico: false));

            // & assert
            VerifyDadosDataView(prmTag: "Aluno=Padrao");

        }

        [TestMethod()]
        public void TST030_DataView_CamposModificados()
        {

            // arrange
            output = "{ 'MATRICULA': '198402018831', 'RESPONSAVEL': 'PAULO LOUREIRO FILHO', 'CPF': '80554504715' }";

            // act
            ConnectDbOracle();

            Pool.AddDataView(prmTag: "Aluno=Padrao", prmSQL: GetComandoSQL_Alias());

            // & assert
            VerifyDadosDataView(prmTag: "Aluno=Padrao");

        }

        [TestMethod()]
        public void TST040_DataView_MascaraResultados()
        {

            // arrange
            output = "{ 'MATRICULA': '1984.02.01883-1', 'RESPONSAVEL': 'PAULO LOUREIRO FILHO', 'CPF': '805.545.047-15' }";

            // act
            ConnectDbOracle();

            Pool.AddDataView(prmTag: "Aluno=Padrao", prmSQL: GetComandoSQL_Alias(), prmMask: "{ 'matricula': '####.##.#####-#', 'cpf': '###.###.###-##' }");

            // & assert
            VerifyDadosDataView(prmTag: "Aluno=Padrao");

        }

        [TestMethod()]
        public void TST050_DataView_DadoVazio()
        {

            // arrange
            output = "{ 'COD_MATRICULA': '200717000195', 'NOM_RESPONSAVEL_PGTO': 'null' }";

            // act
            ConnectDbOracle();

            Pool.AddDataView(prmTag: "Aluno=Null", prmSQL: GetComandoSQL(prmSituacao: 12));

            // & assert
            VerifyDadosDataView(prmTag: "Aluno=Null");

        }

        [TestMethod()]
        public void TST060_DataView_ResultadoVazio()
        {

            // arrange
            output = "";

            // act
            ConnectDbOracle();

            Pool.AddDataView(prmTag: "Aluno=Nenhum", prmSQL: GetComandoSQL(prmSituacao: 91));

            // & assert
            VerifyDadosDataView(prmTag: "Aluno=Nenhum");

        }

        [TestMethod()]
        public void TST070_DataView_ViewNaoLocalizada()
        {

            // arrange
            output = "";

            // act
            ConnectDbOracle();

            Pool.AddDataView(prmTag: "Aluno=Nenhum", prmSQL: GetComandoSQL(prmSituacao: 91));

            // & assert
            VerifyDadosDataView(prmTag: "Aluno=X");

        }
        
        [TestMethod()]
        public void TST080_DataView_MultiplasViews()
        {

            // arrange
            output = "{ 'COD_MATRICULA': '199901172028', 'NOM_RESPONSAVEL_PGTO': 'PAULA AMORIM GOULART FERREIRA' }";

            // act
            ConnectDbOracle();

            Pool.AddDataView(prmTag: "Aluno=Errado", prmSQL: GetComandoSQL(prmSituacao: 4));
            Pool.AddDataView(prmTag: "Aluno=Novato", prmSQL: GetComandoSQL(prmSituacao: 10));
            Pool.AddDataView(prmTag: "Aluno=Padrao", prmSQL: GetComandoSQL(prmSituacao: 6));

            // & assert
            VerifyDadosDataView(prmTag: "Aluno=Novato");

        }

        private string GetComandoSQL() => GetComandoSQL(prmSituacao: 6);

        private string GetComandoSQL(int prmSituacao) => GetComandoSQL(prmSituacao, prmUnico: false);

        private string GetComandoSQL(bool prmUnico) => GetComandoSQL(prmSituacao: 6,  prmUnico);

        private string GetComandoSQL(int prmSituacao, bool prmUnico) => SQLGenericBuilding(prmSituacao, prmAliasMatricula: "", prmAliasResponsavel: "", prmAliasCPF: "", prmUnico);

        private string GetComandoSQL_Alias() => SQLGenericBuilding(prmSituacao: 6, prmAliasMatricula: "matricula", prmAliasResponsavel: "responsavel", prmAliasCPF: "cpf", prmUnico: true);
        
        private string SQLGenericBuilding(int prmSituacao, string prmAliasMatricula, string prmAliasResponsavel, string prmAliasCPF, bool prmUnico)
        {

            string alias_A = ""; string alias_B = ""; string alias_C = ""; string numero_cpf = "";  string restricao = "";

            if (prmAliasMatricula != "")
            { alias_A = "as " + prmAliasMatricula; }

            if (prmAliasResponsavel != "")
            { alias_B = "as " + prmAliasResponsavel; }

            if (prmAliasCPF != "")
            { alias_C = ", cpf_responsavel_pgto as " + prmAliasCPF; numero_cpf = "and CPF_RESPONSAVEL_PGTO is not NULL"; }

            if (!prmUnico)
            { restricao = "and ROWNUM = 1"; }

            return (String.Format("SELECT cod_matricula {1}, nom_responsavel_pgto {2} {3} FROM sia.aluno_curso WHERE cod_situacao_aluno = '{0}' {4} {5}", prmSituacao, alias_A, alias_B, alias_C, numero_cpf, restricao));

        }
        private void VerifyDadosDataView(string prmTag)
        {

            string actual = Pool.GetView(prmTag);

            // assert
            if (output != actual)
                Assert.Fail(string.Format("Actual: <{0}>, Expected: <{1}>", actual, output));
        }

    }

    [TestClass()]
    public class DataModelConnection_Test : DataConnection_Test
    {

        [TestMethod()]
        public void TST010_DataModel_ModeloUnico()
        {

            // arrange
            output = "{ 'MATRICULA': '198701044478', 'NOME': 'SILVIA DAVID MENDES DOS SANTOS', 'CPF': '32820810659' }, " +
                     "{ 'MATRICULA': '198402018831', 'NOME': 'PAULO LOUREIRO FILHO', 'CPF': '80554504715' }, " +
                     "{ 'MATRICULA': '199202147261', 'NOME': 'LEONARDO DE SOUSA GIRAO BARBOSA', 'CPF': '2585206718' }, " +
                     "{ 'MATRICULA': '200301709508', 'NOME': 'ANDRE LUIS SILVA AREIAS', 'CPF': '9546765724' }";


            // act
            ConnectDbOracle();

            Pool.AddDataModel(prmTag: "Aluno", prmModel: @"{'#ENTIDADES#':'sia.aluno_curso','#ATRIBUTOS#':'cod_matricula as matricula, nom_responsavel_pgto as nome, cpf_responsavel_pgto as cpf '}");

            string regras = "{ '#REGRAS#': 'cod_situacao_aluno = #X# and cpf_responsavel_pgto is not NULL' }";


            Pool.AddDataVariant(prmTag: "=SIT_04", prmRegra: regras.Replace("#X#", "4"));
            Pool.AddDataVariant(prmTag: "=SIT_06", prmRegra: regras.Replace("#X#", "6"));
            Pool.AddDataVariant(prmTag: "=SIT_08", prmRegra: regras.Replace("#X#", "8"));
            Pool.AddDataVariant(prmTag: "=SIT_10", prmRegra: regras.Replace("#X#", "10"));

            // & assert
            VerifyDadosDataModel();

        }
        private void VerifyDadosDataModel()
        {

            string atual = Pool.fluxos();

            // assert
            if (output != atual)
                Assert.Fail(string.Format("Actual: <{0}>, Expected: <{1}>", atual, output));

        }

    }

    public class DataConnection_Test
    {
        public string input;
        public string output;

        public TestTrace Trace;

        public DataBaseOracle db = new DataBaseOracle();

        public DataPoolConnection Pool;

        public void ConnectDbOracle() { ConnectDbOracle(prmSenha: "asdfg"); }

        public void ConnectDbOracle(string prmSenha)
        {

            Trace = new TestTrace();

            db.user = "desenvolvedor_sia";
            db.password = prmSenha;

            db.host = "10.250.1.35";
            db.port = "1521";
            db.service = "branch_1083.prod01.redelocal.oraclevcn.com";

            Pool = new DataPoolConnection(Trace.DataBase);

            Pool.AddDataBase(prmTag: "SIA", prmConexao: db.GetString());

        }

        public string GetYesNo(bool prmOpcao) { if (prmOpcao) return "SIM"; return "NAO"; }


    }


}
