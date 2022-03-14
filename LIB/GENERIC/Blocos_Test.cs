using System;
using System.Collections.Generic;
using System.Text;
using BlueRocket.CORE;
using BlueRocket.CORE.Lib.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlueRocket.CORE.Tests.LIB.GENERIC
{
    [TestClass()]
    public class xBloco_Test
    {

        string input;
        string output;
        string result;

        [TestMethod()]
        public void TST_GetBloco_020_Inexistente()
        {

            input = "Alexandre << *1234* >> Bartie";
            output = "";

            // act & assert
            ActionGetBloco();

        }

        [TestMethod()]
        public void TST_GetBloco_030_Espaco()
        {

            input = "Alexandre <<* *>> Bartie";
            output = " ";

            // act & assert
            ActionGetBloco();

        }

        [TestMethod()]
        public void TST_GetBloco_040_Vazio()
        {

            input = "Alexandre <<**>> Bartie";
            output = "";

            // act & assert
            ActionGetBloco();

        }

        [TestMethod()]
        public void TST_GetBloco_050_TextoVazio()
        {

            input = "";
            output = "";

            // act & assert
            ActionGetBloco();

        }

        [TestMethod()]
        public void TST_GetBloco_060_Null()
        {

            input = null;
            output = "";

            // act & assert
            ActionGetBloco();

        }

        [TestMethod()]
        public void TST_GetBloco_070_DelimitadorUnico()
        {

            input = "Alexandre ##D+0## Bartie";
            output = "D+0";

            // act & assert
            ActionGetBloco(prmDelimitador: "##", prmPreserve: false);

        }

        [TestMethod()]
        public void TST_GetBloco_080_DelimitadorPreservado()
        {

            input = "Alexandre ##D+0## Bartie";
            output = "##D+0##";

            // act & assert
            ActionGetBloco(prmDelimitador: "##", prmPreserve: true);

        }

        [TestMethod()]
        public void TST_GetBloco_090_DelimitadoresSobrepostosCompleto()
        {

            input = "Alexandre <<***>> Bartie";
            output = "*";

            // act & assert
            ActionGetBloco();

        }

        [TestMethod()]
        public void TST_GetBloco_100_DelimitadoresSobrepostosIncompleto()
        {

            input = "Alexandre <<*>> Bartie";
            output = "";

            // act & assert
            ActionGetBloco();

        }

        [TestMethod()]
        public void TST_GetBloco_110_DelimitadoresSobrepostosCompletoPreservado()
        {

            input = "Alexandre <<***>> Bartie";
            output = "<<***>>";

            // act & assert
            ActionGetBloco(prmPreserve: true);

        }

        [TestMethod()]
        public void TST_GetBloco_120_DelimitadoresSobrepostosIncompletoPreservado()
        {

            input = "Alexandre <<*>> Bartie";
            output = "<<**>>";

            // act & assert
            ActionGetBloco(prmPreserve: true);

        }

        [TestMethod()]
        public void TST_GetBloco_130_DelimitadorNaoEncontrado()
        {

            input = "Alexandre ##D+0## Bartie";
            output = "";

            // act & assert
            ActionGetBloco(prmDelimitador: "|");

        }

        [TestMethod()]
        public void TST_GetBloco_140_DelimitadorFinalNaoEncontrado()
        {

            input = "Alexandre [D+0[ Bartie";
            output = "";

            // act & assert
            ActionGetBloco(prmDelimitadorInicial: "[", prmDelimitadorFinal: "]");

        }

        [TestMethod()]
        public void TST_GetBlocoRemove_010_DelimitadorRemovido()
        {

            input = "Alexandre #D+10# Bartie";
            output = "Alexandre  Bartie";

            // act & assert
            ActionGetBlocoRemove(prmDelimitador: "#");

        }

        [TestMethod()]
        public void TST_GetBlocoRemove_020_DelimitadorRemovidoTrim()
        {

            input = "Alexandre #D+10# Bartie";
            output = "Alexandre Bartie";

            // act & assert
            ActionGetBlocoRemove(prmDelimitador: "#", prmTRIM: true);

        }

        [TestMethod()]
        public void TST_GetBlocoRemove_030_DelimitadorUnidoRemovido()
        {

            input = "Alexandre ##D+0## Bartie";
            output = "Alexandre  Bartie";

            // act & assert
            ActionGetBlocoRemove(prmDelimitador: "##");

        }

        [TestMethod()]
        public void TST_GetBlocoAntes_010_Padrao()
        {

            input = "Alexandre #D+0# Bartie";
            output = "Alexandre ";

            // act & assert
            ActionGetBlocoAntes(prmBloco: "#D+0#");

        }

        [TestMethod()]
        public void TST_GetBlocoAntes_020_PosicaoInicio()
        {

            input = "#D+0# Alexandre Bartie";
            output = "";

            // act & assert
            ActionGetBlocoAntes(prmBloco: "#D+0#");

        }

        [TestMethod()]
        public void TST_GetBlocoAntes_030_PosicaoInicioTRIM()
        {

            input = "#D+0# Alexandre Bartie";
            output = "";

            // act & assert
            ActionGetBlocoAntes(prmBloco: "#D+0#", prmTRIM: true);

        }

        [TestMethod()]
        public void TST_GetBlocoAntes_040_PosicaoFinal()
        {

            input = "Alexandre Bartie #D+0#";
            output = "Alexandre Bartie ";

            // act & assert
            ActionGetBlocoAntes(prmBloco: "#D+0#");

        }

        [TestMethod()]
        public void TST_GetBlocoAntes_050_PosicaoFinalTRIM()
        {

            input = "Alexandre Bartie #D+0#";
            output = "Alexandre Bartie";

            // act & assert
            ActionGetBlocoAntes(prmBloco: "#D+0#", prmTRIM: true);

        }

        [TestMethod()]
        public void TST_GetBlocoAntes_060_Vazio()
        {

            input = "";
            output = "";

            // act & assert
            ActionGetBlocoAntes(prmBloco: "#D+0#");

        }

        [TestMethod()]
        public void TST_GetBlocoAntes_070_Null()
        {

            input = null;
            output = "";

            // act & assert
            ActionGetBlocoAntes(prmBloco: "#D+0#");

        }

        [TestMethod()]
        public void TST_GetBlocoAntes_080_BlocoNull()
        {

            input = "Alexandre Bartie";
            output = "Alexandre Bartie";

            // act & assert
            ActionGetBlocoAntes(prmBloco: null);

        }

        [TestMethod()]
        public void TST_GetBlocoAntes_090_BlocoVazio()
        {

            input = "Alexandre Bartie";
            output = "Alexandre Bartie";

            // act & assert
            ActionGetBlocoAntes(prmBloco: "");

        }

        [TestMethod()]
        public void TST_GetBlocoAntes_100_BlocoNaoEncontrado()
        {

            input = "Alexandre Bartie";
            output = "Alexandre Bartie";

            // act & assert
            ActionGetBlocoAntes(prmBloco: "#");

        }

        [TestMethod()]
        public void TST_GetBlocoDepois_010_Padrao()
        {

            input = "Alexandre #D+0# Bartie";
            output = " Bartie";

            // act & assert
            ActionGetBlocoDepois(prmBloco: "#D+0#");

        }

        [TestMethod()]
        public void TST_GetBlocoDepois_020_PosicaoInicio()
        {

            input = "#D+0# Alexandre Bartie";
            output = " Alexandre Bartie";

            // act & assert
            ActionGetBlocoDepois(prmBloco: "#D+0#");

        }

        [TestMethod()]
        public void TST_GetBlocoDepois_030_PosicaoInicioTRIM()
        {

            input = "#D+0# Alexandre Bartie";
            output = "Alexandre Bartie";

            // act & assert
            ActionGetBlocoDepois(prmBloco: "#D+0#", prmTRIM: true);

        }

        [TestMethod()]
        public void TST_GetBlocoDepois_040_PosicaoFinal()
        {

            input = "Alexandre Bartie #D+0#";
            output = "";

            // act & assert
            ActionGetBlocoDepois(prmBloco: "#D+0#");

        }

        [TestMethod()]
        public void TST_GetBlocoDepois_050_PosicaoFinalTRIM()
        {

            input = "Alexandre Bartie #D+0#";
            output = "";

            // act & assert
            ActionGetBlocoDepois(prmBloco: "#D+0#", prmTRIM: true);

        }

        [TestMethod()]
        public void TST_GetBlocoDepois_060_Vazio()
        {

            input = "";
            output = "";

            // act & assert
            ActionGetBlocoDepois(prmBloco: "#D+0#");

        }

        [TestMethod()]
        public void TST_GetBlocoDepois_070_Null()
        {

            input = null;
            output = "";

            // act & assert
            ActionGetBlocoDepois(prmBloco: "#D+0#");

        }

        [TestMethod()]
        public void TST_GetBlocoDepois_080_BlocoNull()
        {

            input = "Alexandre Bartie";
            output = "";

            // act & assert
            ActionGetBlocoDepois(prmBloco: null);

        }

        [TestMethod()]
        public void TST_GetBlocoDepois_090_BlocoVazio()
        {

            input = "Alexandre Bartie";
            output = "";

            // act & assert
            ActionGetBlocoDepois(prmBloco: "");

        }

        [TestMethod()]
        public void TST_GetBlocoDepois_100_BlocoNaoEncontrado()
        {

            input = "Alexandre Bartie";
            output = "";

            // act & assert
            ActionGetBlocoDepois(prmBloco: "#");

        }

        [TestMethod()]
        public void TST_GetTroca_010_Padrao()
        {

            input = "Alexandre ##D+0## Bartie";
            output = "Alexandre 'D+0' Bartie";

            // act & assert
            ActionGetBlocoTroca(prmDelimitadorVelho: "##", prmDelimitadorNovo: "'");

        }
        [TestMethod()]
        public void TST_GetTroca_020_Multiplos()
        {

            input = "##um## Alexandre ##D+0## Bartie ##zero##";
            output = "'um' Alexandre 'D+0' Bartie 'zero'";

            // act & assert
            ActionGetBlocoTroca(prmDelimitadorVelho: "##", prmDelimitadorNovo: "'");

        }

        private void ActionGetBloco() => ActionGetBloco(prmPreserve: false);
        private void ActionGetBloco(bool prmPreserve) => ActionGetBloco(prmDelimitadorInicial: "<<*", prmDelimitadorFinal: "*>>", prmPreserve);
        private void ActionGetBloco(string prmDelimitador) => ActionGetBloco(prmDelimitador, prmPreserve: false);
        private void ActionGetBloco(string prmDelimitador, bool prmPreserve) => ActionGetBloco(prmDelimitador, prmDelimitador, prmPreserve);
        private void ActionGetBloco(string prmDelimitadorInicial, string prmDelimitadorFinal) => ActionGetBloco(prmDelimitadorInicial, prmDelimitadorFinal, prmPreserve: false);
        private void ActionGetBloco(string prmDelimitadorInicial, string prmDelimitadorFinal, bool prmPreserve)
        {

            // assert
            result = Bloco.GetBloco(input, prmDelimitadorInicial, prmDelimitadorFinal, prmPreserve);

            // assert
            ActionGeneric();

        }

        private void ActionGetBlocoRemove() => ActionGetBlocoRemove(prmDelimitadorInicial: "<<*", prmDelimitadorFinal: "*>>");
        private void ActionGetBlocoRemove(string prmDelimitador) => ActionGetBlocoRemove(prmDelimitador, prmTRIM: false);
        private void ActionGetBlocoRemove(string prmDelimitador, bool prmTRIM) => ActionGetBlocoRemove(prmDelimitador, prmDelimitador, prmTRIM);

        private void ActionGetBlocoRemove(string prmDelimitadorInicial, string prmDelimitadorFinal) => ActionGetBlocoRemove(prmDelimitadorInicial, prmDelimitadorFinal, prmTRIM: false);
        private void ActionGetBlocoRemove(string prmDelimitadorInicial, string prmDelimitadorFinal, bool prmTRIM)
        {

            // assert
            result = Bloco.GetBlocoRemove(input, prmDelimitadorInicial, prmDelimitadorFinal, prmTRIM);

            // assert
            ActionGeneric();

        }

        private void ActionGetBlocoAntes(string prmBloco) => ActionGetBlocoAntes(prmBloco, prmTRIM: false);
        private void ActionGetBlocoAntes(string prmBloco, bool prmTRIM)
        {

            // assert
            result = Bloco.GetBlocoAntes(input, prmBloco, prmTRIM);

            // assert
            ActionGeneric();

        }

        private void ActionGetBlocoDepois(string prmBloco) => ActionGetBlocoDepois(prmBloco, prmTRIM: false);
        private void ActionGetBlocoDepois(string prmBloco, bool prmTRIM)
        {

            // assert
            result = Bloco.GetBlocoDepois(input, prmBloco, prmTRIM);

            // assert
            ActionGeneric();

        }

        private void ActionGetBlocoTroca(string prmDelimitadorVelho, string prmDelimitadorNovo) => ActionGetBlocoTroca(prmDelimitadorVelho, prmDelimitadorVelho, prmDelimitadorNovo);
        private void ActionGetBlocoTroca(string prmDelimitadorInicial, string prmDelimitadorFinal, string prmDelimitadorNovo)
        {

            // assert
            result = Bloco.GetBlocoTroca(input, prmDelimitadorInicial, prmDelimitadorFinal, prmDelimitadorNovo);

            // assert
            ActionGeneric();

        }
        private void ActionGeneric()
        {

            // assert
            if (output != result)
                Assert.Fail(string.Format("Expected: {0}, Actual: {1}", output, result));

        }
    }



    [TestClass()]
    public class xPrefixo_Test
    {

        string input;
        string output;
        string result;


        [TestMethod()]
        public void TST_GetPrefixo_010_Padrao()
        {

            input = ">Alex: Bartie";
            output = "Alex";

            // act & assert
            ActionGetPrefixo();

        }

        [TestMethod()]
        public void TST_GetPrefixo_020_SemPrefixo()
        {

            input = "Alex: Bartie";
            output = "";

            // act & assert
            ActionGetPrefixo();

        }

        [TestMethod()]
        public void TST_GetPrefixo_030_SemDelimitador()
        {

            input = ">Alex Bartie";
            output = "Alex Bartie";

            // act & assert
            ActionGetPrefixo();

        }
        [TestMethod()]
        public void TST_GetPrefixo_040_Preservado()
        {

            input = ">Alex: Bartie";
            output = ">Alex:";

            // act & assert
            ActionGetPrefixo(prmPreserve: true);

        }

        [TestMethod()]
        public void TST_GetPrefixo_050_ParametrosBrancos()
        {

            input = ">Alex   :   ";
            output = "Alex";

            // act & assert
            ActionGetPrefixo();

        }

        [TestMethod()]
        public void TST_GetPrefixo_050_ApenasBrancos()
        {

            input = ">  :  ";
            output = "";

            // act & assert
            ActionGetPrefixo();

        }

        [TestMethod()]
        public void TST_GetPrefixo_060_Vazio()
        {

            input = "";
            output = "";

            // act & assert
            ActionGetPrefixo();

        }

        [TestMethod()]
        public void TST_GetPrefixo_070_Null()
        {

            input = null;
            output = "";

            // act & assert
            ActionGetPrefixo();

        }

        private void ActionGetPrefixo() => ActionGetPrefixo(prmPreserve: false);
        private void ActionGetPrefixo(bool prmPreserve) => ActionGetPrefixo(prmSinal: ">", prmDelimitador: ":", prmPreserve);
        private void ActionGetPrefixo(string prmSinal, string prmDelimitador, bool prmPreserve)
        {

            // assert
            result = Prefixo.GetPrefixo(input, prmSinal, prmDelimitador, prmPreserve);

            // assert
            ActionGeneric();

        }

        private void ActionGeneric()
        {

            // assert
            if (output != result)
                Assert.Fail(string.Format("Expected: {0}, Actual: {1}", output, result));

        }

    }
}