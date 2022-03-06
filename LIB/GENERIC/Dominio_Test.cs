using System;
using System.Collections.Generic;
using System.Text;
using Dooggy.FACTORY.UNIT;
using Dooggy.Lib.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dooggy.Tests.LIB.GENERIC
{
    [TestClass()]
    public class myDominio_Test : UTC
    {

        [TestMethod()]
        public void TST_GetDominio_010_Padrao()
        {

            input = "[impacto] ALTO,MEDIO,BAIXO";
            output = "impacto: ALTO,MEDIO,BAIXO";

            // act & assert
            ActionGetDominio();

        }

        [TestMethod()]
        public void TST_GetDominio_020_SemKey()
        {

            input = "ALTO,MEDIO,BAIXO";
            output = "ALTO,MEDIO,BAIXO";

            // act & assert
            ActionGetDominio();

        }

        [TestMethod()]
        public void TST_GetDominio_030_SemLista()
        {

            input = "[impacto]";
            output = "impacto";

            // act & assert
            ActionGetDominio();

        }
        [TestMethod()]
        public void TST_GetDominio_040_Espacamentos()
        {

            input = "    [   impacto   ]     ALTO   ,   MEDIO   ,   BAIXO   ";
            output = "impacto: ALTO,MEDIO,BAIXO";

            // act & assert
            ActionGetDominio();

        }
        [TestMethod()]
        public void TST_GetDominio_050_Vazio()
        {

            input = "";
            output = "";

            // act & assert
            ActionGetDominio();

        }
        [TestMethod()]
        public void TST_GetDominio_060_Nulos()
        {

            input = null;
            output = "";

            // act & assert
            ActionGetDominio();

        }
        private void ActionGetDominio()
        {

            // assert
            myDominio dominio = new myDominio(input);

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

            inputList.Add("[ impacto] ALTO, MEDIO, BAIXO");
            inputList.Add("[    tipo] PROGRESSIVO, REGRESSIVO");
            inputList.Add("[analista] ALEXANDRE, LISIA, VITOR");
            inputList.Add("[situacao] PRONTO, EDICAO, ERRO, REFINAR");

            outputList.Add("impacto: ALTO,MEDIO,BAIXO");
            outputList.Add("tipo: PROGRESSIVO,REGRESSIVO");
            outputList.Add("analista: ALEXANDRE,LISIA,VITOR");
            outputList.Add("situacao: PRONTO,EDICAO,ERRO,REFINAR");

            // act & assert
            ActionGetDominios();

        }
        [TestMethod()]
        public void TST_GetDominios_020_TagsRepetidas()
        {

            inputList.Add("[ impacto] ALTO, MEDIO, BAIXO");
            inputList.Add("[    tipo] PROGRESSIVO, REGRESSIVO");
            inputList.Add("[analista] ALEXANDRE, LISIA, VITOR");
            inputList.Add("[    tipo] FACIL, MEDIO, DIFICIL");
            inputList.Add("[situacao] PRONTO, EDICAO, ERRO, REFINAR");

            outputList.Add("impacto: ALTO,MEDIO,BAIXO");
            outputList.Add("tipo: FACIL,MEDIO,DIFICIL");
            outputList.Add("analista: ALEXANDRE,LISIA,VITOR");
            outputList.Add("situacao: PRONTO,EDICAO,ERRO,REFINAR");

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
