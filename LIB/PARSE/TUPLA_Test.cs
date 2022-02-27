using Dooggy.FACTORY.UNIT;
using Dooggy.Lib.Parse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dooggy.Tests.LIB.PARSE.TUPLA
{
    [TestClass()]
    public class TUPLA_Test : UTC
    {

        myTuplas Tuplas;

        [TestMethod()]
        public void TST010_TuplaByNew_UnicaTupla()
        {

            // arrange
            input = @"Nome=Alexandre Bartie";

            output = @"Nome: 'Alexandre Bartie'";

            //// act
            Tuplas = new myTuplas(input);

            // act & assert
            AssertTUPLA();

        }

        [TestMethod()]
        public void TST020_TuplaByNew_VariasTuplas()
        {

            // arrange
            input = @"Nome=Alexandre Bartie, nascimento=05/06/1971, email=alexandre_bartie@hotmail.com";

            output = @"Nome: 'Alexandre Bartie', nascimento: '05/06/1971', email: 'alexandre_bartie@hotmail.com'";

            //// act
            Tuplas = new myTuplas(input);

            // act & assert
            AssertTUPLA();

        }
        [TestMethod()]
        public void TST030_TuplaByNew_EntradaVazia()
        {

            // arrange
            input = @"";

            output = @"";

            //// act
            Tuplas = new myTuplas(input);

            // act & assert
            AssertTUPLA();

        }
        [TestMethod()]
        public void TST040_TuplaByNew_EntradaNull()
        {

            // arrange
            input = null;

            output = @"";

            //// act
            Tuplas = new myTuplas(input);

            // act & assert
            AssertTUPLA();

        }

        [TestMethod()]
        public void TST050_TuplaByNew_ListaNomes()
        {

            // arrange
            input = @"Nome, nascimento, email";

            output = @"Nome: '', nascimento: '', email: ''";

            //// act
            Tuplas = new myTuplas(input);

            // act & assert
            AssertTUPLA();

        }
        [TestMethod()]
        public void TST060_TuplaByParse_ListaNomes()
        {

            // arrange
            input = @"Nome, nascimento, email";

            output = @"Nome: '', nascimento: '', email: ''";

            //// act
            Tuplas = new myTuplas();

            Tuplas.Parse("Nome"); Tuplas.Parse("nascimento"); Tuplas.Parse("email");

            // act & assert
            AssertTUPLA();

        }
        [TestMethod()]
        public void TST070_TuplaByParse_VariasTuplas()
        {

            // arrange
            input = @"Nome, nascimento, email";

            output = @"Nome: 'Alexandre Bartie', nascimento: '05/06/1971', email: 'alexandre_bartie@hotmail.com'";

            //// act
            Tuplas = new myTuplas();

            Tuplas.Parse("Nome=Alexandre Bartie"); Tuplas.Parse("nascimento=05/06/1971"); Tuplas.Parse("email=alexandre_bartie@hotmail.com");

            // act & assert
            AssertTUPLA();

        }
        [TestMethod()]
        public void TST080_TuplaByParse_AtualizarParcialmenteTuplas()
        {

            // arrange
            input = @"Nome, nascimento, email";

            output = @"Nome: 'Renato Andrade', nascimento: '', email: 'renato.andrade@gmail.com'";

            //// act
            Tuplas = new myTuplas(input);

            Tuplas.Parse("Nome=Renato Andrade, email=renato.andrade@gmail.com");

            // act & assert
            AssertTUPLA();

        }
        [TestMethod()]
        public void TST090_TuplaByParse_AtualizarPosicionalmenteValores()
        {

            // arrange
            input = @"Nome, nascimento, email";

            output = @"Nome: 'Renato Andrade', nascimento: '', email: 'renato.andrade@gmail.com'";

            //// act
            Tuplas = new myTuplas(input);

            Tuplas.SetValues("Renato Andrade, , renato.andrade@gmail.com");

            // act & assert
            AssertTUPLA();

        }
        private void AssertTUPLA() => AssertTUPLA(prmMultiplos: false);

        private void AssertTUPLA(bool prmMultiplos)
        {

            //Tupla.Save();

            string result;

            //if (prmMultiplos)
                result = Tuplas.key;
            //else
            //result = ""; //;Tupla.tuplas;

        }
        public override void AssertTest()
        {
            // assert
            if (IsFail())
                Assert.Fail(error);
        }
    }

}
