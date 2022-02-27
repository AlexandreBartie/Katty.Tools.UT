using Dooggy.Tests.Factory.lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dooggy.Tests.FACTORY.TAG
{
    [TestClass()]
    public class CAT_010_DataTagByScript_Test : DataModelFactory_Test
    {

        public CAT_010_DataTagByScript_Test()
        {

            path_out += @"DataTAG\ByScript\";

        }

        [TestMethod()]
        public void TST010_DataTagByScript_DefinicaoUnica()
        {

            // arrange
            output = "";
            output += "[    impacto] ALTO" + Environment.NewLine;
            output += "[  categoria] NEGOCIO" + Environment.NewLine;
            output += "[       tipo] REGRESSIVO" + Environment.NewLine;
            output += "[   analista] ALEXANDRE" + Environment.NewLine;
            output += "[   situacao] PRONTO" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> TAGS" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            output += ">tags: " + Environment.NewLine;
            output += "   -impacto: ALTO" + Environment.NewLine;
            output += " -categoria: NEGOCIO" + Environment.NewLine;
            output += "      -tipo: REGRESSIVO" + Environment.NewLine;
            output += "  -analista: ALEXANDRE" + Environment.NewLine;
            output += "  -situacao: PRONTO" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "  -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -output: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, '$date(D+0:DDMMAAAA)' as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = #(UserID)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Script.key);

        }

    }
}
