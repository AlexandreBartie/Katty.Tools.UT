using BlueRocket.CORE.FACTORY.UNIT;
using BlueRocket.CORE.Lib.Parse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueRocket.CORE.Tests.LIB.PARSE
{
    [TestClass()]
    public class TUPLA_Test : UTC
    {

        myTuplas Tuplas;

        [TestMethod()]
        public void TST010_Tupla_UnicoPar()
        {

            // arrange
            input(@"Nome=Alexandre Bartie");

            output(@"Nome: 'Alexandre Bartie'");

            //// act
            Tuplas = new myTuplas(inputTXT);

            // act & assert
            AssertTUPLA();

        }

        [TestMethod()]
        public void TST020_Tupla_VariosPares()
        {

            // arrange
            input(@"Nome=Alexandre Bartie, nascimento=05/06/1971, email=alexandre_bartie@hotmail.com");

            output(@"Nome: 'Alexandre Bartie', nascimento: '05/06/1971', email: 'alexandre_bartie@hotmail.com'");

            //// act
            Tuplas = new myTuplas(inputTXT);

            // act & assert
            AssertTUPLA();

        }
        [TestMethod()]
        public void TST030_Tupla_EntradaVazia()
        {

            // arrange
            input(@"");

            output(@"");

            //// act
            Tuplas = new myTuplas(inputTXT);

            // act & assert
            AssertTUPLA();

        }
        [TestMethod()]
        public void TST040_Tupla_EntradaNull()
        {

            // arrange
            input(null);

            output("");

            //// act
            Tuplas = new myTuplas(inputTXT);

            // act & assert
            AssertTUPLA();

        }

        [TestMethod()]
        public void TST050_Tupla_ListaNomes()
        {

            // arrange
            input(@"Nome, nascimento, email");

            output(@"Nome: '', nascimento: '', email: ''");

            //// act
            Tuplas = new myTuplas(inputTXT);

            // act & assert
            AssertTUPLA();

        }
        [TestMethod()]
        public void TST060_Tupla_ListaNomes()
        {

            // arrange
            input(@"Nome, nascimento, email");

            output(@"Nome: '', nascimento: '', email: ''");

            //// act
            Tuplas = new myTuplas();

            Tuplas.Parse("Nome"); Tuplas.Parse("nascimento"); Tuplas.Parse("email");

            // act & assert
            AssertTUPLA();

        }
        [TestMethod()]
        public void TST070_Tupla_VariasTuplas()
        {

            // arrange
            input(@"Nome, nascimento, email");

            output(@"Nome: 'Alexandre Bartie', nascimento: '05/06/1971', email: 'alexandre_bartie@hotmail.com'");

            //// act
            Tuplas = new myTuplas();

            Tuplas.Parse("Nome=Alexandre Bartie"); Tuplas.Parse("nascimento=05/06/1971"); Tuplas.Parse("email=alexandre_bartie@hotmail.com");

            // act & assert
            AssertTUPLA();

        }
        [TestMethod()]
        public void TST080_Tupla_AtualizarParcialmente()
        {

            // arrange
            input(@"Nome, nascimento, email");

            output(@"Nome: 'Renato Andrade', nascimento: '', email: 'renato.andrade@gmail.com'");

            //// act
            Tuplas = new myTuplas(inputTXT);

            Tuplas.Parse("Nome=Renato Andrade, email=renato.andrade@gmail.com");

            // act & assert
            AssertTUPLA();

        }
        [TestMethod()]
        public void TST090_Tupla_AtualizarPosicionalmenteValores()
        {

            // arrange
            input(@"Nome, nascimento, email");

            output(@"Nome: 'Renato Andrade', nascimento: '', email: 'renato.andrade@gmail.com'");

            //// act
            Tuplas = new myTuplas(inputTXT);

            Tuplas.SetValues("Renato Andrade, , renato.andrade@gmail.com");

            // act & assert
            AssertTUPLA();

        }
        private void AssertTUPLA() => AssertTUPLA(prmMultiplos: false);

        private void AssertTUPLA(bool prmMultiplos)
        {
            AssertTest(prmResult: Tuplas.log);
        }
    }

}
