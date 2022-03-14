using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using BlueRocket.CORE.Factory.Data;
using BlueRocket.CORE.Tests.Factory.lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlueRocket.CORE.Tests.DATA.SAVE
{
    [TestClass()]
    public class CAT10_DataSaveTXT_Test : DataSave_Test
    {

        public CAT10_DataSaveTXT_Test()
        {

            SetTipo(prmTipo: eTipoFileFormat.txt);

        }

        [TestMethod()]
        public void TST010_DataSave_RegistroUnico()
        {

            // arrange
            output = "";
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",199202147261,LEONARDO DE SOUSA GIRAO BARBOSA,2585206718" + Environment.NewLine;

            base.DataSave_RegistroUnico();

        }

        [TestMethod()]
        public void TST020_DataSave_RegistrosMultiplos()
        {

            // arrange
            output = "";
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",198701044478,SILVIA DAVID MENDES DOS SANTOS,32820810659" + Environment.NewLine;
            output += ",198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;
            output += ",199202147261,LEONARDO DE SOUSA GIRAO BARBOSA,2585206718" + Environment.NewLine;
            output += ",200301709508,ANDRE LUIS SILVA AREIAS,9546765724" + Environment.NewLine;

            base.DataSave_RegistrosMultiplos();

        }

        [TestMethod()]
        public void TST030_DataSave_ArquivosMultiplos()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",198701044478,SILVIA DAVID MENDES DOS SANTOS,32820810659" + Environment.NewLine;
            output += ",198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;
            output += ",199202147261,LEONARDO DE SOUSA GIRAO BARBOSA,2585206718" + Environment.NewLine;
            output += ",200301709508,ANDRE LUIS SILVA AREIAS,9546765724" + Environment.NewLine;

            base.DataSave_ArquivosMultiplos();

        }


    }

    [TestClass()]
    public class CAT20_DataSaveCSV_Test : DataSave_Test
    {

        public CAT20_DataSaveCSV_Test()
        {

            SetTipo(prmTipo: eTipoFileFormat.csv);

        }

        [TestMethod()]
        public void TST010_DataSave_RegistroUnico()
        {

            // arrange
            output = "199202147261,LEONARDO DE SOUSA GIRAO BARBOSA,2585206718" + Environment.NewLine;

            base.DataSave_RegistroUnico();

        }

        [TestMethod()]
        public void TST020_DataSave_RegistrosMultiplos()
        {

            // arrange
            output = "";
            output += "198701044478,SILVIA DAVID MENDES DOS SANTOS,32820810659" + Environment.NewLine;
            output += "198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;
            output += "199202147261,LEONARDO DE SOUSA GIRAO BARBOSA,2585206718" + Environment.NewLine;
            output += "200301709508,ANDRE LUIS SILVA AREIAS,9546765724" + Environment.NewLine;

            base.DataSave_RegistrosMultiplos();

        }

        [TestMethod()]
        public void TST030_DataSave_ArquivosMultiplos()
        {

            // arrange
            output = "";
            output += "1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;
            output += "198701044478,SILVIA DAVID MENDES DOS SANTOS,32820810659" + Environment.NewLine;
            output += "198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;
            output += "199202147261,LEONARDO DE SOUSA GIRAO BARBOSA,2585206718" + Environment.NewLine;
            output += "200301709508,ANDRE LUIS SILVA AREIAS,9546765724" + Environment.NewLine;

            base.DataSave_ArquivosMultiplos();

        }

    }

    [TestClass()]
    public class CAT30_DataSaveJSON_Test : DataSave_Test
    {

        public CAT30_DataSaveJSON_Test()
        {

            SetTipo(prmTipo: eTipoFileFormat.json);

        }

        [TestMethod()]
        public void TST010_DataSave_RegistroUnico()
        {

            // arrange
            output = "";
            output += "{ 'MATRICULA': '199202147261', 'RESPONSAVEL': 'LEONARDO DE SOUSA GIRAO BARBOSA', 'CPF': '2585206718' }";
            output += Environment.NewLine;

            base.DataSave_RegistroUnico();

        }

        [TestMethod()]
        public void TST020_DataSave_RegistrosMultiplos()
        {

            // arrange
            output = "";
            output += "{ 'MATRICULA': '198701044478', 'RESPONSAVEL': 'SILVIA DAVID MENDES DOS SANTOS', 'CPF': '32820810659' }, "; 
            output += "{ 'MATRICULA': '198402018831', 'RESPONSAVEL': 'PAULO LOUREIRO FILHO', 'CPF': '80554504715' }, ";
            output += "{ 'MATRICULA': '199202147261', 'RESPONSAVEL': 'LEONARDO DE SOUSA GIRAO BARBOSA', 'CPF': '2585206718' }, ";
            output += "{ 'MATRICULA': '200301709508', 'RESPONSAVEL': 'ANDRE LUIS SILVA AREIAS', 'CPF': '9546765724' }";
            output += Environment.NewLine;

            base.DataSave_RegistrosMultiplos();

        }

        [TestMethod()]
        public void TST030_DataSave_ArquivosMultiplos()
        {

            // arrange
            output = "";
            output += "{ 'LOGIN': '1016283', 'SENHA': '1234as', 'USUARIOLOGADO': 'MARLI LOPES OGAWA DE FIGUEIREDO' }, ";
            output += "{ 'MATRICULA': '198701044478', 'RESPONSAVEL': 'SILVIA DAVID MENDES DOS SANTOS', 'CPF': '32820810659' }, ";
            output += "{ 'MATRICULA': '198402018831', 'RESPONSAVEL': 'PAULO LOUREIRO FILHO', 'CPF': '80554504715' }, ";
            output += "{ 'MATRICULA': '199202147261', 'RESPONSAVEL': 'LEONARDO DE SOUSA GIRAO BARBOSA', 'CPF': '2585206718' }, ";
            output += "{ 'MATRICULA': '200301709508', 'RESPONSAVEL': 'ANDRE LUIS SILVA AREIAS', 'CPF': '9546765724' }" + Environment.NewLine;

            base.DataSave_ArquivosMultiplos();

        }
    }

    public class DataSave_Test : DataModelFactory_Test
    {

        private eTipoFileFormat tipo;

        public void SetTipo(eTipoFileFormat prmTipo)
        {

            tipo = prmTipo;

        }

        internal void DataSave_RegistroUnico()
        {

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: GetTagAluno());

            Dados.AddDataFlow(prmTag: "=SIT_08", prmSQL: GetComandoSQL_Aluno(prmSituacao: 8));

            // & assert
            VerifyDadosyDataSave(prmTags: "Aluno", prmMetodo: MethodBase.GetCurrentMethod());

        }

        internal void DataSave_RegistrosMultiplos()
        {

            // act
            ConnectDbOracle();

            Dados.AddDataView(prmTag: GetTagAluno());

            Dados.AddDataFlow(prmTag: "=SIT_04", prmSQL: GetComandoSQL_Aluno(prmSituacao: 4));
            Dados.AddDataFlow(prmTag: "=SIT_06", prmSQL: GetComandoSQL_Aluno(prmSituacao: 6));
            Dados.AddDataFlow(prmTag: "=SIT_08", prmSQL: GetComandoSQL_Aluno(prmSituacao: 8));
            Dados.AddDataFlow(prmTag: "=SIT_10", prmSQL: GetComandoSQL_Aluno(prmSituacao: 10));

            // & assert
            VerifyDadosyDataSave(prmTags: "Aluno", prmMetodo: MethodBase.GetCurrentMethod());

        }

        internal void DataSave_ArquivosMultiplos()
        {

            // act
            ConnectDbOracle();

            // Tag:Login

            Dados.AddDataView(prmTag: GetTagLogin());

            Dados.AddDataFlow(prmTag: "=Marli", prmSQL: GetComandoSQL_Login(prmUsuario: 1016283));

            // Tag:Aluno

            Dados.AddDataView(prmTag: GetTagAluno());

            Dados.AddDataFlow(prmTag: "=SIT_04", prmSQL: GetComandoSQL_Aluno(prmSituacao: 4));
            Dados.AddDataFlow(prmTag: "=SIT_06", prmSQL: GetComandoSQL_Aluno(prmSituacao: 6));
            Dados.AddDataFlow(prmTag: "=SIT_08", prmSQL: GetComandoSQL_Aluno(prmSituacao: 8));
            Dados.AddDataFlow(prmTag: "=SIT_10", prmSQL: GetComandoSQL_Aluno(prmSituacao: 10));

            // & assert
            VerifyDadosyDataSave(prmTags: "Login + Aluno" , prmMetodo: MethodBase.GetCurrentMethod());

        }

        private string GetTagLogin()
        {

            string retorno = "Login";
            
            if (tipo == eTipoFileFormat.txt)
                retorno +=  "|testLoginAdmValido|login,senha,usuarioLogado";

            return retorno;

        }
        private string GetTagAluno()
        {

            string retorno = "Aluno";

            if (tipo == eTipoFileFormat.txt)
                retorno += "|test01_ValidarInformacoesDoAluno|matricula,getNomeAluno";

            return retorno;

        }


        private void VerifyDadosyDataSave(string prmTags, MethodBase prmMetodo)
        {

            string atual = ""; string nome; string path; string data; string extensao;

            nome = prmMetodo.Name;

            path = Console.Path.GetPathFullOUT(tipo);

            data = Dados.output(prmTags, tipo);

            extensao = Console.Path.GetExtensao(tipo);

            if (Dados.FileINI.Save(nome, path, data, extensao))
                atual = Dados.FileINI.Open(nome, path, extensao);

            // assert
            VerifyExpectedData(prmData: atual);

        }

    }

}
