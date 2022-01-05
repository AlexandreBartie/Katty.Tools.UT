using System;
using System.Collections.Generic;
using System.Text;
using Dooggy.Tests.Factory.lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dooggy.Tests.FACTORY.DATA
{
    [TestClass()]
    public class CAT30_DataOutputCSV_Test : DataModelFactory_Test
    {

        [TestMethod()]
        public void TST010_DataOutputCSV_RegistroUnico()
        {

            // arrange
            output = "199202147261,LEONARDO DE SOUSA GIRAO BARBOSA,2585206718" + Environment.NewLine;

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFluxo(prmTag: "=SIT_08", prmSQL: GetComandoSQL_Aluno(prmSituacao: 8));

            // & assert
            VerifyExpectedData(prmData: Dados.csv("Aluno"));

        }

        [TestMethod()]
        public void TST020_DataOutputCSV_RegistrosMultiplos()
        {

            // arrange
            output = "";
            output += "198701044478,SILVIA DAVID MENDES DOS SANTOS,32820810659" + Environment.NewLine;
            output += "198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;
            output += "199202147261,LEONARDO DE SOUSA GIRAO BARBOSA,2585206718" + Environment.NewLine;
            output += "200301709508,ANDRE LUIS SILVA AREIAS,9546765724" + Environment.NewLine;

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno");

            Dados.AddDataFluxo(prmTag: "=SIT_04", prmSQL: GetComandoSQL_Aluno(prmSituacao: 4));
            Dados.AddDataFluxo(prmTag: "=SIT_06", prmSQL: GetComandoSQL_Aluno(prmSituacao: 6));
            Dados.AddDataFluxo(prmTag: "=SIT_08", prmSQL: GetComandoSQL_Aluno(prmSituacao: 8));
            Dados.AddDataFluxo(prmTag: "=SIT_10", prmSQL: GetComandoSQL_Aluno(prmSituacao: 10));


            // & assert
            VerifyExpectedData(prmData: Dados.csv("Aluno"));

        }

        [TestMethod()]
        public void TST030_DataOutputCSV_FluxosMultiplosMascaradosComCamposNulos()
        {

            // arrange
            output = "";
            output += "1987.01.04447-8,SILVIA DAVID MENDES DOS SANTOS,328.208.106-59" + Environment.NewLine;
            output += "1987.01.04763-9,PATRICIA TRAVASSOS SEABRA LEBRE," + Environment.NewLine;
            output += "1980.02.00576-7,JOSE CLAUDIO V DE OLIVEIRA," + Environment.NewLine;
            output += "2003.01.70950-8,ANDRE LUIS SILVA AREIAS,95.467.657-24" + Environment.NewLine;

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno", prmMask: GetMaskAluno());

            Dados.AddDataFluxo(prmTag: "=SIT_04", prmSQL: GetComandoSQL_Aluno(prmSituacao: 4));
            Dados.AddDataFluxo(prmTag: "=SIT_06", prmSQL: GetComandoSQL_Aluno(prmSituacao: 6, prmCPF: false));
            Dados.AddDataFluxo(prmTag: "=SIT_08", prmSQL: GetComandoSQL_Aluno(prmSituacao: 8, prmCPF: false));
            Dados.AddDataFluxo(prmTag: "=SIT_10", prmSQL: GetComandoSQL_Aluno(prmSituacao: 10));


            // & assert
            VerifyExpectedData(prmData: Dados.csv("Aluno"));

        }

        [TestMethod()]
        public void TST040_DataOutputCSV_FluxosMultiplosMascaradosComFluxoNulo()
        {

            // arrange
             output += "1987.01.04447-8,SILVIA DAVID MENDES DOS SANTOS,328.208.106-59" + Environment.NewLine;
            output += Environment.NewLine;
            output += "1980.02.00576-7,JOSE CLAUDIO V DE OLIVEIRA," + Environment.NewLine;
            output += "2003.01.70950-8,ANDRE LUIS SILVA AREIAS,95.467.657-24" + Environment.NewLine;

            // act
            ConnectDbOracle();
            
            Dados.AddDataView(prmTag: "Aluno", prmMask: GetMaskAluno());

            Dados.AddDataFluxo(prmTag: "=SIT_04", prmSQL: GetComandoSQL_Aluno(prmSituacao: 4));
            Dados.AddDataFluxo(prmTag: "=SIT_99", prmSQL: GetComandoSQL_Aluno(prmSituacao: 99, prmCPF: false));
            Dados.AddDataFluxo(prmTag: "=SIT_08", prmSQL: GetComandoSQL_Aluno(prmSituacao: 8, prmCPF: false));
            Dados.AddDataFluxo(prmTag: "=SIT_10", prmSQL: GetComandoSQL_Aluno(prmSituacao: 10));

            // & assert
            VerifyExpectedData(prmData: Dados.csv(prmTags: "Aluno"));

        }

        [TestMethod()]
        public void TST050_DataOutputCSV_FluxosTodosNulos()
        {

            // arrange
            output = "";
            output += Environment.NewLine;
            output += Environment.NewLine;
            output += Environment.NewLine;
            output += Environment.NewLine;

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: "Aluno", prmMask: GetMaskAluno());

            Dados.AddDataFluxo(prmTag: "=SIT_95", prmSQL: GetComandoSQL_Aluno(prmSituacao: 95));
            Dados.AddDataFluxo(prmTag: "=SIT_96", prmSQL: GetComandoSQL_Aluno(prmSituacao: 96, prmCPF: false));
            Dados.AddDataFluxo(prmTag: "=SIT_97", prmSQL: GetComandoSQL_Aluno(prmSituacao: 97, prmCPF: false));
            Dados.AddDataFluxo(prmTag: "=SIT_98", prmSQL: GetComandoSQL_Aluno(prmSituacao: 98));

            // & assert
            VerifyExpectedData(prmData: Dados.csv(prmTags: "Aluno"));

        }

        [TestMethod()]
        public void TST060_DataOutputCSV_FluxosMultiplosArquivos()
        {

            // arrange
            output = "";
            output += "1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;
            output += "1987.01.04447-8,SILVIA DAVID MENDES DOS SANTOS,328.208.106-59" + Environment.NewLine;
            output += "1987.01.04763-9,PATRICIA TRAVASSOS SEABRA LEBRE," + Environment.NewLine;
            output += "1980.02.00576-7,JOSE CLAUDIO V DE OLIVEIRA," + Environment.NewLine;
            output += "2003.01.70950-8,ANDRE LUIS SILVA AREIAS,95.467.657-24" + Environment.NewLine;

            // act
            ConnectDbOracle();

            // Tag:Login

            Dados.AddDataView(prmTag: "Login");

            Dados.AddDataFluxo(prmTag: "=Marli", prmSQL: GetComandoSQL_Login(prmUsuario: 1016283));

            // Tag:Aluno
            Dados.AddDataView(prmTag: "Aluno", prmMask: GetMaskAluno());

            Dados.AddDataFluxo(prmTag: "=SIT_04", prmSQL: GetComandoSQL_Aluno(prmSituacao: 4));
            Dados.AddDataFluxo(prmTag: "=SIT_06", prmSQL: GetComandoSQL_Aluno(prmSituacao: 6, prmCPF: false));
            Dados.AddDataFluxo(prmTag: "=SIT_08", prmSQL: GetComandoSQL_Aluno(prmSituacao: 8, prmCPF: false));
            Dados.AddDataFluxo(prmTag: "=SIT_10", prmSQL: GetComandoSQL_Aluno(prmSituacao: 10));

            // & assert
            VerifyExpectedData(prmData: Dados.csv(prmTags: "Login + Aluno"));

        }

    }

    [TestClass()]
    public class CAT31_DataOutputTXT_Test : DataModelFactory_Test
    {

        [TestMethod()]
        public void TST010_DataOutputTXT_FluxosMultiplosCabecalhoMascaradosComNulos()
        {

            // arrange
            output = "ListaResponsaveis,Matricula,NomeResponsavel,CPF" + Environment.NewLine;
            output += ",1987.01.04447-8,SILVIA DAVID MENDES DOS SANTOS,328.208.106-59" + Environment.NewLine;
            output += Environment.NewLine;
            output += ",1980.02.00576-7,JOSE CLAUDIO V DE OLIVEIRA," + Environment.NewLine;
            output += ",2003.01.70950-8,ANDRE LUIS SILVA AREIAS,95.467.657-24" + Environment.NewLine;

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: GetTagCabecalho(prmTag: "Aluno"), prmMask: GetMaskAluno());

            Dados.AddDataFluxo(prmTag: "=SIT_04", prmSQL: GetComandoSQL_Aluno(prmSituacao: 4));
            Dados.AddDataFluxo(prmTag: "=SIT_99", prmSQL: GetComandoSQL_Aluno(prmSituacao: 99, prmCPF: false));
            Dados.AddDataFluxo(prmTag: "=SIT_08", prmSQL: GetComandoSQL_Aluno(prmSituacao: 8, prmCPF: false));
            Dados.AddDataFluxo(prmTag: "=SIT_10", prmSQL: GetComandoSQL_Aluno(prmSituacao: 10));

            // & assert
            VerifyExpectedData(prmData: Dados.txt(prmTags: "Aluno"));

        }

        [TestMethod()]
        public void TST020_DataOutputTXT_FluxosTodosNulos()
        {

            // arrange
            output = "ListaResponsaveis,Matricula,NomeResponsavel,CPF" + Environment.NewLine;
            output += Environment.NewLine;
            output += Environment.NewLine;
            output += Environment.NewLine;
            output += Environment.NewLine;

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: GetTagCabecalho(prmTag: "Aluno"), prmMask: GetMaskAluno());


            Dados.AddDataFluxo(prmTag: "=SIT_95", prmSQL: GetComandoSQL_Aluno(prmSituacao: 95));
            Dados.AddDataFluxo(prmTag: "=SIT_96", prmSQL: GetComandoSQL_Aluno(prmSituacao: 96, prmCPF: false));
            Dados.AddDataFluxo(prmTag: "=SIT_97", prmSQL: GetComandoSQL_Aluno(prmSituacao: 97, prmCPF: false));
            Dados.AddDataFluxo(prmTag: "=SIT_98", prmSQL: GetComandoSQL_Aluno(prmSituacao: 98));

            // & assert
            VerifyExpectedData(prmData: Dados.txt(prmTags: "Aluno"));

        }


    }
}
