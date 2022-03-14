using BlueRocket.CORE.Tests.Factory.lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueRocket.CORE.Tests.FACTORY.FUNCTION
{
    [TestClass()]
    public class CAT_010_DataFunctionByRandom_Test : UTC_BlueRocketCORE
    {

        public CAT_010_DataFunctionByRandom_Test()
        {

            SetSubPathOUT(@"DataFunction\ByRandom\");

        }

        [TestMethod()]
        public void TST010_DataFunctionByRandom_FormatacaoSemPrefixo()
        {

            // arrange

            output("testLoginAdmValido,login,senha,usuarioLogado");
            output(",1016283,9084713,MARLI LOPES OGAWA DE FIGUEIREDO");
            output("");

            input(">>");
            input(">> Variáveis");
            input(">>");
            input();
            input(">loc: UserID = '1016283'");
            input();
            input(">view: Login");
            input("  -name: testLoginAdmValido");
            input("      -output: login,senha,usuarioLogado");
            input();
            input(">item: Marli");
            input(" -sql:  SELECT cod_usuario, '$random(6)' as senha, nom_usuario");
            input("        FROM seg.usuario");
            input("        WHERE cod_usuario = #(UserID)");
            input();
            input(">save[txt]");

            // act
            Play(prmCode: inputTXT);

            // & assert
            AssertTest(prmResult: Console.Result.data);

        }

        [TestMethod()]
        public void TST020_DataFunctionByRandom_FormatacaoComPrefixo()
        {

            // arrange

            input(">>");
            input(">> Variáveis");
            input(">>");
            input();
            input(">loc: UserID = '1016283'");
            input();
            input(">view: Login");
            input("  -name: testLoginAdmValido");
            input("      -output: id,conta,usuario");
            input();
            input(">item: Marli");
            input(" -sql:  SELECT cod_usuario, '$random(CC: [10])' as senha, nom_usuario");
            input("        FROM seg.usuario");
            input("        WHERE cod_usuario = #(UserID)");
            input();
            input(">save[txt]");

            output("testLoginAdmValido,id,conta,usuario");
            output(",1016283,CC: 9084713018,MARLI LOPES OGAWA DE FIGUEIREDO");
            output("");

            // act
            Play(prmCode: inputTXT);

            // & assert
            AssertTest(prmResult: Console.Result.data);

        }

    }
}
