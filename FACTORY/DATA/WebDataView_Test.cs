using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlueRocket.CORE.Factory.Data;
using BlueRocket.CORE.Factory;
using BlueRocket.CORE.Tests.Factory.lib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace BlueRocket.CORE.Tests.DATA.VIEW
{

    [TestClass()]
    public class CAT_010_DataViewByConsultas_Test : DataView_Test
    {

        [TestMethod()]
        public void TST010_DataViewByConsultas_ConsultaUnica()
        {

            // arrange
            output = "{ 'COD_MATRICULA': '199202134879', 'NOM_RESPONSAVEL_PGTO': 'RENATA P WERNECK DE FREITAS' }";

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFlow(prmTag: "Padrao", prmSQL: GetComandoSQL());

            // & assert
            VerifyDadosDataView();

        }

        [TestMethod()]
        public void TST020_DataViewByConsultas_ConsultasMultiplas()
        {

            // arrange
            output = "{ 'COD_MATRICULA': '199202134879', 'NOM_RESPONSAVEL_PGTO': 'RENATA P WERNECK DE FREITAS' }";

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFlow(prmTag: "Padrao", prmSQL: GetComandoSQL(prmUnico: false));

            // & assert
            VerifyDadosDataView();

        }

        [TestMethod()]
        public void TST030_DataViewByConsultas_ConsultasCamposAlias()
        {

            // arrange
            output = "{ 'MATRICULA': '198402018831', 'RESPONSAVEL': 'PAULO LOUREIRO FILHO', 'CPF': '80554504715' }";

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFlow(prmTag: "=Padrao", prmSQL: GetComandoSQL_Alias());

            // & assert
            VerifyDadosDataView();

        }

        [TestMethod()]
        public void TST040_DataViewByConsultas_ConsultaCamposNulos()
        {

            // arrange
            output = "{ 'COD_MATRICULA': '200918033112' }";

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFlow(prmTag: "=Null", prmSQL: GetComandoSQL(prmSituacao: 12));

            // & assert
            VerifyDadosDataView();

        }

        [TestMethod()]
        public void TST050_DataViewByConsultas_ConsultaRetornoNulo()
        {

            // arrange
            output = "{ }";

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFlow(prmTag: "=Nenhum", prmSQL: GetComandoSQL(prmSituacao: 91));

            // & assert
            VerifyDadosDataView();

        }

        [TestMethod()]
        public void TST060_DataViewByConsultas_ConsultaNaoEncontrada()
        {

            // arrange
            output = "";

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFlow(prmTag: "Errado", prmSQL: GetComandoSQL(prmSituacao: 4));
            Dados.AddDataFlow(prmTag: "Novato", prmSQL: GetComandoSQL(prmSituacao: 10));
            Dados.AddDataFlow(prmTag: "Padrao", prmSQL: GetComandoSQL(prmSituacao: 6));

            // & assert
            VerifyDadosDataView("Login");

        }

        [TestMethod()]
        public void TST070_DataViewByConsultas_ConsultaNaoEncontrada_MenosCaracteres()
        {

            // arrange
            output = "";

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFlow(prmTag: "Errado", prmSQL: GetComandoSQL(prmSituacao: 4));
            Dados.AddDataFlow(prmTag: "Novato", prmSQL: GetComandoSQL(prmSituacao: 10));
            Dados.AddDataFlow(prmTag: "Padrao", prmSQL: GetComandoSQL(prmSituacao: 6));

            // & assert
            VerifyDadosDataView("Alun");

        }

        [TestMethod()]
        public void TST080_DataViewByConsultas_ConsultaNaoEncontrada_MaisCaracteres()
        {

            // arrange
            output = "";

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFlow(prmTag: "Errado", prmSQL: GetComandoSQL(prmSituacao: 4));
            Dados.AddDataFlow(prmTag: "Novato", prmSQL: GetComandoSQL(prmSituacao: 10));
            Dados.AddDataFlow(prmTag: "Padrao", prmSQL: GetComandoSQL(prmSituacao: 6));

            // & assert
            VerifyDadosDataView("Alunos");

        }

    }

    [TestClass()]
    public class CAT_020_DataViewByTipos_Test : DataView_Test
    {

        [TestMethod()]
        public void TST010_DataViewByTipos_MascaraStrings()
        {

            // arrange
            output = "";
            output += "ID 1984.02.01883-1,PAULO LOUREIRO FILHO,CPF 805.545.047-15" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -name: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,NomeAluno,Responsavel" + Environment.NewLine;
            bloco += "       -mask: cod_matricula = ID ####.##.#####-#, cpf_responsavel_pgto = CPF ###.###.###-##" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "   -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[csv]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyDadosDataView(prmTipo: eTipoFileFormat.csv);

        }

        [TestMethod()]
        public void TST020_DataViewByTipos_MascaraDatas()
        {

            // arrange
            output = "";
            output += "1997-07-05" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -name: test01_ConsultarDebitoPorNossoNumero" + Environment.NewLine;
            bloco += "      -output: nVencimento[VENCIMENTO:AAAA-MM-DD]" + Environment.NewLine;
            bloco += "        -mask: VENCIMENTO = AAAA-MM-DD" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "   -sql: select ac.DT_VENCIMENTO as VENCIMENTO" + Environment.NewLine;
            bloco += "         from SIA.carne ac" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[csv]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyDadosDataView(prmTipo: eTipoFileFormat.csv);

        }

    }

    [TestClass()]
    public class CAT_030_DataViewByFormatos_Test : DataView_Test
    {

        [TestMethod()]
        public void TST010_DataViewByFormatos_MultiplosArquivosJSON()
        {

            // arrange
            output = "";
            output += "{ 'LOGIN': '1016283', 'SENHA': '1234as', 'USUARIOLOGADO': 'MARLI LOPES OGAWA DE FIGUEIREDO' }, ";
            output += "{ 'MATRICULA': '198701044478', 'RESPONSAVEL': 'SILVIA DAVID MENDES DOS SANTOS', 'CPF': '32820810659' }, ";
            output += "{ 'MATRICULA': '199901172028', 'RESPONSAVEL': 'PAULA AMORIM GOULART FERREIRA' }, ";
            output += "{ 'MATRICULA': '198402018831', 'RESPONSAVEL': 'PAULO LOUREIRO FILHO', 'CPF': '80554504715' }";


            // act
            ConnectDbOracle();

            // Tag:Login

            Dados.AddDataView(prmTag: "Login");

            Dados.AddDataFlow(prmTag: "Marli", prmSQL: GetComandoSQL_Login(prmUsuario: 1016283));

            // Tag:Aluno

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFlow(prmTag: "Errado", prmSQL: GetComandoSQL_Aluno(prmSituacao: 4));
            Dados.AddDataFlow(prmTag: "Novato", prmSQL: GetComandoSQL_Aluno(prmSituacao: 10, prmCPF: false));
            Dados.AddDataFlow(prmTag: "Padrao", prmSQL: GetComandoSQL_Aluno(prmSituacao: 6));

            // & assert
            VerifyDadosDataView(prmTags: "Login + Aluno");

        }
       
        [TestMethod()]
        public void TST020_DataViewByFormatos_MultiplosArquivosCSV()
        {

            // arrange
            output = "";
            output += "1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;
            output += "198701044478,SILVIA DAVID MENDES DOS SANTOS,32820810659" + Environment.NewLine;
            output += "199901172028,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;
            output += "198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;

            // act
            ConnectDbOracle();

            // Tag:Login

            Dados.AddDataView(prmTag: "Login");

            Dados.AddDataFlow(prmTag: "Marli", prmSQL: GetComandoSQL_Login(prmUsuario: 1016283));

            // Tag:Aluno

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFlow(prmTag: "Errado", prmSQL: GetComandoSQL_Aluno(prmSituacao: 4));
            Dados.AddDataFlow(prmTag: "Novato", prmSQL: GetComandoSQL_Aluno(prmSituacao: 10, prmCPF: false));
            Dados.AddDataFlow(prmTag: "Padrao", prmSQL: GetComandoSQL_Aluno(prmSituacao: 6));

            //Console.s

            // & assert
            VerifyDadosDataView(prmTags: "Login + Aluno", prmTipo: eTipoFileFormat.csv);

        }

        [TestMethod()]
        public void TST030_DataViewByFormatos_MultiplosArquivosTXT()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",198701044478,SILVIA DAVID MENDES DOS SANTOS,32820810659" + Environment.NewLine;
            output += ",199901172028,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;
            output += ",198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;


            // act
            ConnectDbOracle();

            // Tag:Login

            Dados.AddDataView(prmTag: "Login|testLoginAdmValido|login,senha,usuarioLogado");

            Dados.AddDataFlow(prmTag: "Marli", prmSQL: GetComandoSQL_Login(prmUsuario: 1016283));

            // Tag:Aluno

            Dados.AddDataView(prmTag: "Aluno|test01_ValidarInformacoesDoAluno|matricula,getNomeAluno");

            Dados.AddDataFlow(prmTag: "Errado", prmSQL: GetComandoSQL_Aluno(prmSituacao: 4));
            Dados.AddDataFlow(prmTag: "Novato", prmSQL: GetComandoSQL_Aluno(prmSituacao: 10, prmCPF: false));
            Dados.AddDataFlow(prmTag: "Padrao", prmSQL: GetComandoSQL_Aluno(prmSituacao: 6));

            // & assert
            VerifyDadosDataView(prmTags: "Login + Aluno", prmTipo: eTipoFileFormat.txt);

        }

        [TestMethod()]
        public void TST040_DataViewByFormatos_MultiplosArquivosTXTcomMascaramento()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",1987.01.04447-8,SILVIA DAVID MENDES DOS SANTOS,328.208.106-59" + Environment.NewLine;
            output += ",1999.01.17202-8,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;
            output += ",1984.02.01883-1,PAULO LOUREIRO FILHO,805.545.047-15" + Environment.NewLine;


            // act
            ConnectDbOracle();

            // Tag:Login

            Dados.AddDataView(prmTag: "Login|testLoginAdmValido|login,senha,usuarioLogado");

            Dados.AddDataFlow(prmTag: "Marli", prmSQL: GetComandoSQL_Login(prmUsuario: 1016283));

            // Tag:Aluno

            Dados.AddDataView(prmTag: "Aluno|test01_ValidarInformacoesDoAluno|matricula,getNomeAluno", prmMask: GetMaskAluno());

            Dados.AddDataFlow(prmTag: "Errado", prmSQL: GetComandoSQL_Aluno(prmSituacao: 4));
            Dados.AddDataFlow(prmTag: "Novato", prmSQL: GetComandoSQL_Aluno(prmSituacao: 10, prmCPF: false));
            Dados.AddDataFlow(prmTag: "Padrao", prmSQL: GetComandoSQL_Aluno(prmSituacao: 6));

            // & assert
            VerifyDadosDataView(prmTags: "Login + Aluno", prmTipo: eTipoFileFormat.txt);

        }

    }

    public class DataView_Test : DataModelFactory_Test
    {
        public void VerifyDadosDataView(eTipoFileFormat prmTipo) => VerifyDadosDataView(prmTags: Dados.View.tag, prmTipo);
        public void VerifyDadosDataView() => VerifyDadosDataView(prmTags: Dados.View.tag);
        public void VerifyDadosDataView(string prmTags) => VerifyDadosDataView(prmTags, prmTipo: eTipoFileFormat.json);
        public void VerifyDadosDataView(string prmTags, eTipoFileFormat prmTipo)
        {
            
            string atual = Dados.output(prmTags, prmTipo);

            // assert
            VerifyExpectedData(prmData: atual);

        }

    }
}
