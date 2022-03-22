using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dooggy.LIBRARY.UTC.LIB.PARSE
{
    [TestClass()]
    public class JSON_Test
    {

        string input; string inputA; string inputB; string mestreA; string mestreB;
        string output;

        myJSON FlowJSON;

        [TestMethod()]
        public void TST010_FlowSimples_Padrao()
        {

            // arrange
            input = @"{ 'Nome': 'Alexandre', 'email': 'alexandre_bartie@hotmail.com' }";
            output = @"[Nome]: 'Alexandre', [email]: 'alexandre_bartie@hotmail.com'";

            //// act
            FlowJSON = new myJSON();

            FlowJSON.Add(input);

            // act & assert
            AssertJSON();

        }

        [TestMethod()]
        public void TST020_FlowSimples_ValoresComAspas()
        {

            // arrange
            input = @"{ 'tag': 'Aluno', 'sql': 'SELECT * from Alunos WHERE situacao = ok' }";
            output = @"[tag]: 'Aluno', [sql]: 'SELECT * from Alunos WHERE situacao = ok'";

            //// act
            FlowJSON = new myJSON(); FlowJSON.Add(input);

            // act & assert
            AssertJSON();

        }

        [TestMethod()]
        public void TST030_FlowSimples_ValoresComBarraNormal()
        {

            // arrange
            input = @"{ 'path': 'c:\\MassaTestes\\', 'branch': '1084', 'porta': '1521' }";
            output = @"[path]: 'c:\MassaTestes\', [branch]: '1084', [porta]: '1521'";

            //// act
            FlowJSON = new myJSON(); FlowJSON.Add(input);

            // act & assert
            AssertJSON();

        }

        [TestMethod()]
        public void TST040_FlowSimples_ValoresComBarraDobrada()
        {

            // arrange
            input = @"{ 'path': 'c:\\MassaTestes\\', 'branch': '1084', 'porta': '1521' }";
            output = @"[path]: 'c:\MassaTestes\', [branch]: '1084', [porta]: '1521'";

            //// act
            FlowJSON = new myJSON(); FlowJSON.Add(input);

            // act & assert
            AssertJSON();

        }

        [TestMethod()]
        public void TST050_FlowSimples_ValoresComBarraInvertida()
        {

            // arrange
            input = @"{ 'path': 'c:/MassaTestes/', 'branch': '1084', 'porta': '1521' }";
            output = @"[path]: 'c:/MassaTestes/', [branch]: '1084', [porta]: '1521'";

            //// act
            FlowJSON = new myJSON(); FlowJSON.Add(input);

            // act & assert
            AssertJSON();

        }


        [TestMethod()]
        public void TST060_FlowSimples_ErroFormatacao()
        {

            // arrange
            input = @"{'COD_MATRICULA': ####.##.#####-#' }";
            output = @"";

            //// act
            FlowJSON = new myJSON(); ; FlowJSON.Add(input);

            // act & assert
            AssertJSON();

        }

        [TestMethod()]
        public void TST070_FlowMultiplo_Padrao()
        {

            // arrange
            inputA = @"{ 'Nome': 'Alexandre', 'email': 'alexandre_bartie@hotmail.com' }";
            inputB = @"{ 'Nome': 'Bartie', 'email': 'bartie.devops@outlook.com' }";

            output = "";
            output += @"[ ";
            output += @"{ ""Nome"": ""Alexandre"", ""email"": ""alexandre_bartie@hotmail.com"" }, ";
            output += @"{ ""Nome"": ""Bartie"", ""email"": ""bartie.devops@outlook.com"" }";
            output += @" ]";

            //// act
            FlowJSON = new myJSON(); FlowJSON.Add(inputA); FlowJSON.Add(inputB);

            // act & assert
            AssertJSON(prmMultiplos: true);

        }

        [TestMethod()]
        public void TST080_FlowMultiplo_FlowCombinado()
        {

            // arrange
            inputA = @"{ 'Nome': 'Alexandre', 'email': 'alexandre_bartie@hotmail.com' }";
            inputB = @"{ 'Nome': 'Bartie', 'email': 'bartie.devops@outlook.com' }";

            mestreA = @"{ 'Nome': 'Renato' }";
            mestreB = @"{ 'Nome': 'José' }";

            output = @"[ { ""Nome"": ""Renato"", ""email"": ""alexandre_bartie@hotmail.com"" }, { ""Nome"": ""José"", ""email"": ""bartie.devops@outlook.com"" } ]";

            //// act
            FlowJSON = new myJSON(); FlowJSON.Add(inputA, mestreA); FlowJSON.Add(inputB, mestreB);

            // act & assert
            AssertJSON(prmMultiplos: true);

        }

        [TestMethod()]
        public void TST090_FlowMultiplo_FlowCombinadoExtendido()
        {

            // arrange
            inputA = @"{ 'Nome': 'Alexandre', 'email': 'alexandre_bartie@hotmail.com' }";
            inputB = @"{ 'Nome': 'Bartie', 'email': 'bartie.devops@outlook.com' }";

            mestreA = @"{ 'Nome': 'Renato', 'sobrenome': 'Andrade' }";
            mestreB = @"{ 'Nome': 'José', 'sobrenome': 'da Silva' }";

            output = @"[ { ""Nome"": ""Renato"", ""email"": ""alexandre_bartie@hotmail.com"", ""sobrenome"": ""Andrade"" }, { ""Nome"": ""José"", ""email"": ""bartie.devops@outlook.com"", ""sobrenome"": ""da Silva"" } ]";

            //// act
            FlowJSON = new myJSON(); FlowJSON.Add(inputA, mestreA); FlowJSON.Add(inputB, mestreB);

            // act & assert
            AssertJSON(prmMultiplos: true);

        }

        private void AssertJSON() => AssertJSON(prmMultiplos: false);

        private void AssertJSON(bool prmMultiplos)
        {

            FlowJSON.Save();

            string result;

            if (prmMultiplos)
                result = FlowJSON.Flow;
            else
                result = FlowJSON.tuplas;

            // assert
            if (output != result)
                Assert.Fail(string.Format("Expected: <{0}>, Actual: <{1}>", output, result));

        }
    }

}
