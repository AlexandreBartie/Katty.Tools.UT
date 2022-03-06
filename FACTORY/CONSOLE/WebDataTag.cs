using Dooggy.Tests.Factory.lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dooggy.Tests.FACTORY.TAG
{
    [TestClass()]
    public class CAT_010_DataTagByScript_Test : UTC_Dooggy
    {

        public CAT_010_DataTagByScript_Test()
        {

            path_out += @"DataTAG\ByScript\";

        }

        [TestMethod()]
        public void TST010_DataTagByScript_DefinicaoUnica()
        {

            // arrange
            output.Add("[    impacto] ALTO");
            output.Add("[  categoria] NEGOCIO");
            output.Add("[       tipo] REGRESSIVO");
            output.Add("[   analista] ALEXANDRE");
            output.Add("[   situacao] PRONTO");

            // act
            ConnectDbOracle();

            input.Add(">>");
            input.Add(">> TAGS");
            input.Add(">>");
            input.Add();
            input.Add(">tag: ");
            input.Add("   -impacto: ALTO");
            input.Add(" -categoria: NEGOCIO");
            input.Add("      -tipo: REGRESSIVO");
            input.Add("  -analista: ALEXANDRE");
            input.Add("  -situacao: PRONTO");
            input.Add();
            input.Add(">view: Login");
            input.Add("  -name: testLoginAdmValido");
            input.Add("      -output: login,senha,usuarioLogado");
            input.Add("");
            input.Add(">item: Marli");
            input.Add(" -sql:  SELECT cod_usuario, '$date(D+0:DDMMAAAA)' as senha, nom_usuario");
            input.Add("        FROM seg.usuario");
            input.Add("        WHERE cod_usuario = #(UserID)");
            input.Add();
            input.Add(">save[txt]: Login + Aluno");

            Console.Play(prmCode: input.txt);

            // & assert
            AssertTest(prmResult: Console.Script.Tags.txt);

        }

    }
}
