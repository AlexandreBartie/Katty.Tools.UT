using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dooggy.Factory.Data;
using Dooggy.Factory;
using Dooggy.Tests.Factory.lib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace Dooggy.Tests.FACTORY.VIEW
{

    [TestClass()]
    public class CAT10_DataView_Test : DataFactory_Test
    {

        [TestMethod()]
        public void TST010_DataView_ViewUnicoResultado()
        {

            // arrange
            output = "{ 'COD_MATRICULA': '198402018831', 'NOM_RESPONSAVEL_PGTO': 'PAULO LOUREIRO FILHO' }";

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFluxo(prmTag: "Padrao", prmSQL: GetComandoSQL());

            // & assert
            VerifyDadosDataView();

        }

        [TestMethod()]
        public void TST020_DataView_ViewMultiplosResultados()
        {

            // arrange
            output = "{ 'COD_MATRICULA': '198402018831', 'NOM_RESPONSAVEL_PGTO': 'PAULO LOUREIRO FILHO' }";

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFluxo(prmTag: "Padrao", prmSQL: GetComandoSQL(prmUnico: false));

            // & assert
            VerifyDadosDataView();

        }

        [TestMethod()]
        public void TST030_DataView_CamposModificados()
        {

            // arrange
            output = "{ 'MATRICULA': '198402018831', 'RESPONSAVEL': 'PAULO LOUREIRO FILHO', 'CPF': '80554504715' }";

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFluxo(prmTag: "=Padrao", prmSQL: GetComandoSQL_Alias());

            // & assert
            VerifyDadosDataView();

        }

        [TestMethod()]
        public void TST040_DataView_MascaraResultados()
        {

            // arrange
            output = "{ 'MATRICULA': '1984.02.01883-1', 'RESPONSAVEL': 'PAULO LOUREIRO FILHO', 'CPF': '805.545.047-15' }";

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFluxo(prmTag: "=Padrao", prmSQL: GetComandoSQL_Alias(), prmMask: GetMaskAluno());

            // & assert
            VerifyDadosDataView();

        }

        [TestMethod()]
        public void TST050_DataView_DadoVazio()
        {

            // arrange
            output = "{ 'COD_MATRICULA': '200717000195' }";

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFluxo(prmTag: "=Null", prmSQL: GetComandoSQL(prmSituacao: 12));

            // & assert
            VerifyDadosDataView();

        }

        [TestMethod()]
        public void TST060_DataView_ResultadoVazio()
        {

            // arrange
            output = "{ }";

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFluxo(prmTag: "=Nenhum", prmSQL: GetComandoSQL(prmSituacao: 91));

            // & assert
            VerifyDadosDataView();

        }

        [TestMethod()]
        public void TST070_DataView_ViewNaoEncontrada()
        {

            // arrange
            output = "";

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFluxo(prmTag: "Errado", prmSQL: GetComandoSQL(prmSituacao: 4));
            Dados.AddDataFluxo(prmTag: "Novato", prmSQL: GetComandoSQL(prmSituacao: 10));
            Dados.AddDataFluxo(prmTag: "Padrao", prmSQL: GetComandoSQL(prmSituacao: 6));

            // & assert
            VerifyDadosDataView("Login");

        }

        [TestMethod()]
        public void TST080_DataView_ViewNaoExata_MenosCaracteres()
        {

            // arrange
            output = "";

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFluxo(prmTag: "Errado", prmSQL: GetComandoSQL(prmSituacao: 4));
            Dados.AddDataFluxo(prmTag: "Novato", prmSQL: GetComandoSQL(prmSituacao: 10));
            Dados.AddDataFluxo(prmTag: "Padrao", prmSQL: GetComandoSQL(prmSituacao: 6));

            // & assert
            VerifyDadosDataView("Alun");

        }

        [TestMethod()]
        public void TST090_DataView_ViewNaoExata_MaisCaracteres()
        {

            // arrange
            output = "";

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFluxo(prmTag: "Errado", prmSQL: GetComandoSQL(prmSituacao: 4));
            Dados.AddDataFluxo(prmTag: "Novato", prmSQL: GetComandoSQL(prmSituacao: 10));
            Dados.AddDataFluxo(prmTag: "Padrao", prmSQL: GetComandoSQL(prmSituacao: 6));

            // & assert
            VerifyDadosDataView("Alunos");

        }
        
        [TestMethod()]
        public void TST100_DataView_MultiplosArquivosJSON()
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

            Dados.AddDataFluxo(prmTag: "Marli", prmSQL: GetComandoSQL_Login(prmUsuario: 1016283));

            // Tag:Aluno

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFluxo(prmTag: "Errado", prmSQL: GetComandoSQL_Aluno(prmSituacao: 4));
            Dados.AddDataFluxo(prmTag: "Novato", prmSQL: GetComandoSQL_Aluno(prmSituacao: 10, prmCPF: false));
            Dados.AddDataFluxo(prmTag: "Padrao", prmSQL: GetComandoSQL_Aluno(prmSituacao: 6));

            // & assert
            VerifyDadosDataView(prmTags: "Login + Aluno");

        }
       
        [TestMethod()]
        public void TST110_DataView_MultiplosArquivosCSV()
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

            Dados.AddDataFluxo(prmTag: "Marli", prmSQL: GetComandoSQL_Login(prmUsuario: 1016283));

            // Tag:Aluno

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFluxo(prmTag: "Errado", prmSQL: GetComandoSQL_Aluno(prmSituacao: 4));
            Dados.AddDataFluxo(prmTag: "Novato", prmSQL: GetComandoSQL_Aluno(prmSituacao: 10, prmCPF: false));
            Dados.AddDataFluxo(prmTag: "Padrao", prmSQL: GetComandoSQL_Aluno(prmSituacao: 6));

            // & assert
            VerifyDadosDataView(prmTags: "Login + Aluno", prmTipo: eTipoFileFormat.csv);

        }

        [TestMethod()]
        public void TST120_DataView_MultiplosArquivosTXT()
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

            Dados.AddDataFluxo(prmTag: "Marli", prmSQL: GetComandoSQL_Login(prmUsuario: 1016283));

            // Tag:Aluno

            Dados.AddDataView(prmTag: "Aluno|test01_ValidarInformacoesDoAluno|matricula,getNomeAluno");

            Dados.AddDataFluxo(prmTag: "Errado", prmSQL: GetComandoSQL_Aluno(prmSituacao: 4));
            Dados.AddDataFluxo(prmTag: "Novato", prmSQL: GetComandoSQL_Aluno(prmSituacao: 10, prmCPF: false));
            Dados.AddDataFluxo(prmTag: "Padrao", prmSQL: GetComandoSQL_Aluno(prmSituacao: 6));

            // & assert
            VerifyDadosDataView(prmTags: "Login + Aluno", prmTipo: eTipoFileFormat.txt);

        }

        [TestMethod()]
        public void TST130_DataView_MultiplosArquivosTXTcomMascaramento()
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

            Dados.AddDataFluxo(prmTag: "Marli", prmSQL: GetComandoSQL_Login(prmUsuario: 1016283));

            // Tag:Aluno

            Dados.AddDataView(prmTag: "Aluno|test01_ValidarInformacoesDoAluno|matricula,getNomeAluno", prmMask: GetMaskAluno());

            Dados.AddDataFluxo(prmTag: "Errado", prmSQL: GetComandoSQL_Aluno(prmSituacao: 4));
            Dados.AddDataFluxo(prmTag: "Novato", prmSQL: GetComandoSQL_Aluno(prmSituacao: 10, prmCPF: false));
            Dados.AddDataFluxo(prmTag: "Padrao", prmSQL: GetComandoSQL_Aluno(prmSituacao: 6));

            // & assert
            VerifyDadosDataView(prmTags: "Login + Aluno", prmTipo: eTipoFileFormat.txt);

        }

        private void VerifyDadosDataView() => VerifyDadosDataView(prmTags: Dados.View.tag);
        private void VerifyDadosDataView(string prmTags) => VerifyDadosDataView(prmTags, prmTipo: eTipoFileFormat.json);
        private void VerifyDadosDataView(string prmTags, eTipoFileFormat prmTipo)
        {

            string atual = Dados.GetOutput(prmTags, prmTipo);

            // assert
            VerifyExpectedData(prmData: atual);

        }

    }

}
