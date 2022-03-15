using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlueRocket.LIBRARY.TESTS.LIB.GENERIC
{
    [TestClass()]
    public class myDominio_Test : UTC
    {

        [TestMethod()]
        public void TST_GetDominio_010_Padrao()
        {

            input("[impacto] ALTO,MEDIO,BAIXO");
            output("impacto: ALTO,MEDIO,BAIXO");

            // act & assert
            ActionGetDominio();

        }

        [TestMethod()]
        public void TST_GetDominio_020_SemKey()
        {

            input("ALTO,MEDIO,BAIXO");
            output("ALTO,MEDIO,BAIXO");

            // act & assert
            ActionGetDominio();

        }

        [TestMethod()]
        public void TST_GetDominio_030_SemLista()
        {

            input("[impacto]");
            output("impacto");

            // act & assert
            ActionGetDominio();

        }
        [TestMethod()]
        public void TST_GetDominio_040_Espacamentos()
        {

            input("    [   impacto   ]     ALTO   ,   MEDIO   ,   BAIXO   ");
            output("impacto: ALTO,MEDIO,BAIXO");

            // act & assert
            ActionGetDominio();

        }
        [TestMethod()]
        public void TST_GetDominio_050_Vazio()
        {

            input("");
            output("");

            // act & assert
            ActionGetDominio();

        }
        [TestMethod()]
        public void TST_GetDominio_060_Nulos()
        {

            input(null);
            output("");

            // act & assert
            ActionGetDominio();

        }
        private void ActionGetDominio()
        {

            // assert
            myDominio dominio = new myDominio(inputTXT);

            // assert
            AssertTest(prmResult: dominio.log);

        }
    }

    [TestClass()]
    public class myDominios_Test : UTC
    {

        [TestMethod()]
        public void TST_GetDominios_010_Padrao()
        {

            input("[ impacto] ALTO, MEDIO, BAIXO");
            input("[    tipo] PROGRESSIVO, REGRESSIVO");
            input("[analista] ALEXANDRE, LISIA, VITOR");
            input("[situacao] PRONTO, EDICAO, ERRO, REFINAR");

            output("impacto: ALTO,MEDIO,BAIXO");
            output("tipo: PROGRESSIVO,REGRESSIVO");
            output("analista: ALEXANDRE,LISIA,VITOR");
            output("situacao: PRONTO,EDICAO,ERRO,REFINAR");
            output();

            // act & assert
            ActionGetDominios();

        }
        [TestMethod()]
        public void TST_GetDominios_020_TagsRepetidas()
        {

            input("[ impacto] ALTO, MEDIO, BAIXO");
            input("[    tipo] PROGRESSIVO, REGRESSIVO");
            input("[analista] ALEXANDRE, LISIA, VITOR");
            input("[    tipo] FACIL, MEDIO, DIFICIL");
            input("[situacao] PRONTO, EDICAO, ERRO, REFINAR");

            output("impacto: ALTO,MEDIO,BAIXO");
            output("tipo: FACIL,MEDIO,DIFICIL");
            output("analista: ALEXANDRE,LISIA,VITOR");
            output("situacao: PRONTO,EDICAO,ERRO,REFINAR");

            // act & assert
            ActionGetDominios();

        }
        
        private void ActionGetDominios()
        {

            // assert
            myDominios dominios = new myDominios();

            dominios.AddItens(inputList);

            // assert
            AssertTest(prmResult: dominios.log);

        }

    }

}
