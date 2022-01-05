using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dooggy.Lib.Parse;

namespace Dooggy.Tests.LIB.PARSE
{
    [TestClass()]
    public class xJSON_Test
    {

        string input; string inputA; string inputB; string mestreA; string mestreB;
        string output;

        xJSON FluxoJSON;

        [TestMethod()]
        public void TST010_FluxoSimples_Padrao()
        {

            // arrange
            input = @"{ 'Nome': 'Alexandre', 'email': 'alexandre_bartie@hotmail.com' }";
            output =  @"[Nome]: 'Alexandre', [email]: 'alexandre_bartie@hotmail.com'";

            //// act
            FluxoJSON = new xJSON(); FluxoJSON.Add(input);

            // act & assert
            AssertJSON();

        }

        [TestMethod()]
        public void TST020_FluxoSimples_ValoresComAspas()
        {

            // arrange
            input = @"{ 'tag': 'Aluno', 'sql': 'SELECT * from Alunos WHERE situacao = ok' }";
            output =  @"[tag]: 'Aluno', [sql]: 'SELECT * from Alunos WHERE situacao = ok'";

            //// act
            FluxoJSON = new xJSON(); FluxoJSON.Add(input);

            // act & assert
            AssertJSON();

        }

        [TestMethod()]
        public void TST030_FluxoSimples_ValoresComBarraNormal()
        {

            // arrange
            input = @"{ 'path': 'c:\MassaTestes\', 'branch': '1084', 'porta': '1521' }";
            output =  @"[path]: 'c:\MassaTestes\', [branch]: '1084', [porta]: '1521'";

            //// act
            FluxoJSON = new xJSON(); FluxoJSON.Add(input);

            // act & assert
            AssertJSON();

        }

        [TestMethod()]
        public void TST040_FluxoSimples_ValoresComBarraDobrada()
        {

            // arrange
            input = @"{ 'path': 'c:\\MassaTestes\\', 'branch': '1084', 'porta': '1521' }";
            output =  @"[path]: 'c:\MassaTestes\', [branch]: '1084', [porta]: '1521'";

            //// act
            FluxoJSON = new xJSON(); FluxoJSON.Add(input);

            // act & assert
            AssertJSON();

        }
        
        [TestMethod()]
        public void TST050_FluxoSimples_ValoresComBarraInvertida()
        {

            // arrange
            input = @"{ 'path': 'c:/MassaTestes/', 'branch': '1084', 'porta': '1521' }";
            output =  @"[path]: 'c:/MassaTestes/', [branch]: '1084', [porta]: '1521'";

            //// act
            FluxoJSON = new xJSON(); FluxoJSON.Add(input);

            // act & assert
            AssertJSON();

        }


        [TestMethod()]
        public void TST060_FluxoSimples_ErroFormatacao()
        {

            // arrange
            input = @"{'COD_MATRICULA': ####.##.#####-#' }";
            output = @"";

            //// act
            FluxoJSON = new xJSON(); ; FluxoJSON.Add(input);

            // act & assert
            AssertJSON();

        }

        [TestMethod()]
        public void TST070_FluxoMultiplo_Padrao()
        {

            // arrange
            inputA = @"{ 'Nome': 'Alexandre', 'email': 'alexandre_bartie@hotmail.com' }";
            inputB = @"{ 'Nome': 'Bartie', 'email': 'bartie.devops@outlook.com' }";

            output  = "";
            output += @"[ ";
            output += @"{ ""Nome"": ""Alexandre"", ""email"": ""alexandre_bartie@hotmail.com"" }, ";
            output += @"{ ""Nome"": ""Bartie"", ""email"": ""bartie.devops@outlook.com"" }";
            output += @" ]";

            //// act
            FluxoJSON = new xJSON(); FluxoJSON.Add(inputA); FluxoJSON.Add(inputB);

            // act & assert
            AssertJSON(prmMultiplos: true);

        }

        [TestMethod()]
        public void TST080_FluxoMultiplo_FluxoCombinado()
        {

            // arrange
            inputA = @"{ 'Nome': 'Alexandre', 'email': 'alexandre_bartie@hotmail.com' }";
            inputB = @"{ 'Nome': 'Bartie', 'email': 'bartie.devops@outlook.com' }";

            mestreA = @"{ 'Nome': 'Renato' }";
            mestreB = @"{ 'Nome': 'José' }";

            output = @"[ { ""Nome"": ""Renato"", ""email"": ""alexandre_bartie@hotmail.com"" }, { ""Nome"": ""José"", ""email"": ""bartie.devops@outlook.com"" } ]";

            //// act
            FluxoJSON = new xJSON(); FluxoJSON.Add(inputA,mestreA); FluxoJSON.Add(inputB, mestreB);

            // act & assert
            AssertJSON(prmMultiplos: true);

        }

        [TestMethod()]
        public void TST090_FluxoMultiplo_FluxoCombinadoExtendido()
        {

            // arrange
            inputA = @"{ 'Nome': 'Alexandre', 'email': 'alexandre_bartie@hotmail.com' }";
            inputB = @"{ 'Nome': 'Bartie', 'email': 'bartie.devops@outlook.com' }";

            mestreA = @"{ 'Nome': 'Renato', 'sobrenome': 'Andrade' }";
            mestreB = @"{ 'Nome': 'José', 'sobrenome': 'da Silva' }";

            output = @"[ { ""Nome"": ""Renato"", ""email"": ""alexandre_bartie@hotmail.com"", ""sobrenome"": ""Andrade"" }, { ""Nome"": ""José"", ""email"": ""bartie.devops@outlook.com"", ""sobrenome"": ""da Silva"" } ]";

            //// act
            FluxoJSON = new xJSON(); FluxoJSON.Add(inputA, mestreA); FluxoJSON.Add(inputB, mestreB);

            // act & assert
            AssertJSON(prmMultiplos: true);

        }

        private void AssertJSON() => AssertJSON(prmMultiplos: false);

        private void AssertJSON(bool prmMultiplos)
        {

            FluxoJSON.Save();

            string result;

            if (prmMultiplos)
                result = FluxoJSON.fluxo;
            else
                result = FluxoJSON.tuplas;

            // assert
            if (output != result)
                Assert.Fail(string.Format("Expected: <{0}>, Actual: <{1}>", output, result));

        }
    }

}
