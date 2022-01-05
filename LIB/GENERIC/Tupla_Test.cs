using System;
using System.Collections.Generic;
using System.Text;
using Dooggy.Lib.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dooggy.Tests.LIB.GENERIC
{
    [TestClass()]
    public class xTupla_Test
    {

        xTupla tupla;

        string input;
        string output;
        string result;

        [TestMethod()]
        public void TST_GetTupla_010_Padrao()
        {

            input = "alex=1234";
            output = "alex: '1234'";

            // act & assert
            ActionGetTupla();

        }

        [TestMethod()]
        public void TST_GetTupla_020_ComEspacos()
        {

            input = "alex = 1234";
            output = "alex: '1234'";

            // act & assert
            ActionGetTupla();

        }

        [TestMethod()]
        public void TST_GetTupla_030_SemValor()
        {

            input = "alex";
            output = "alex: ''";

            // act & assert
            ActionGetTupla();

        }

        [TestMethod()]
        public void TST_GetTupla_040_SemParametro()
        {

            input = "=1234";
            output = ": '1234'";

            // act & assert
            ActionGetTupla();

        }

        [TestMethod()]
        public void TST_GetTupla_050_Vazio()
        {

            input = "";
            output = "";

            // act & assert
            ActionGetTupla();

        }

        [TestMethod()]
        public void TST_GetTupla_060_Espaco()
        {

            input = "  ";
            output = "";

            // act & assert
            ActionGetTupla();

        }
        
        [TestMethod()]
        public void TST_GetTupla_070_Nulo()
        {

            input = null;
            output = "";

            // act & assert
            ActionGetTupla();

        }

        [TestMethod()]
        public void TST_GetTupla_080_SeparadorDefinido()
        {

            input = "alex $ 1234";
            output = "alex: '1234'";

            // act & assert
            ActionGetTupla(prmSeparador: "$");

        }
        [TestMethod()]
        public void TST_GetTupla_090_SeparadorDuplo()
        {

            input = "alex $$ 1234";
            output = "alex: '1234'";

            // act & assert
            ActionGetTupla(prmSeparador: "$$");

        }
        [TestMethod()]
        public void TST_GetTupla_100_ComDelimitador()
        {

            input = "alex = 1234 [Aluno Novato]";
            output = "alex: '1234' <Aluno Novato>";

            // act & assert
            ActionGetTupla();

        }
        [TestMethod()]
        public void TST_GetTupla_110_ComDelimitadorNoMeio()
        {

            input = "alex =[   Aluno Novato   ] 1234 ";
            output = "alex: '1234' <Aluno Novato>";

            // act & assert
            ActionGetTupla();

        }
        [TestMethod()]
        public void TST_GetTupla_120_ComDelimitadorNoInicio()
        {

            input = "[   Aluno Novato   ] alex =1234 ";
            output = "alex: '1234' <Aluno Novato>";

            // act & assert
            ActionGetTupla();

        }
        [TestMethod()]
        public void TST_GetTupla_130_ComDelimitadorComEspacos()
        {

            input = "alex = 1234 [   Aluno Novato   ]";
            output = "alex: '1234' <Aluno Novato>";

            // act & assert
            ActionGetTupla();

        }
        
        [TestMethod()]
        public void TST_GetTupla_140_SemValorComDelimitador()
        {

            input = "alex [   Aluno Novato   ]";
            output = "alex: '' <Aluno Novato>";

            // act & assert
            ActionGetTupla();

        }
        [TestMethod()]
        public void TST_GetTupla_150_SemTagComDelimitador()
        {

            input = " = 1234 [   Aluno Novato   ]";
            output = ": '1234' <Aluno Novato>";

            // act & assert
            ActionGetTupla();

        }
        [TestMethod()]
        public void TST_GetTupla_160_SemTagSemValorComDelimitador()
        {

            input = "  [   Aluno Novato   ]";
            output = "<Aluno Novato>";

            // act & assert
            ActionGetTupla();

        }
        private void ActionGetTupla() => ActionGetTupla(prmSeparador: "=");
        private void ActionGetTupla(string prmSeparador)
        {

            // assert
            tupla = new xTupla(input, prmSeparador);

            result = tupla.memo;

            // assert
            ActionGeneric();

        }

        private void ActionGeneric()
        {

            // assert
            if (output != result)
                Assert.Fail(string.Format("Expected: <{0}>, Actual: <{1}>", output, result));

        }
    }

    [TestClass()]
    public class xTuplas_Test
    {

        xTuplas lista;

        string input;
        string output;
        string result;

        [TestMethod()]
        public void TST_GetTuplas_010_Padrao()
        {

            input = "alex=1234,gomes=2321,jorge=9841";
            output = "alex: '1234', gomes: '2321', jorge: '9841'";

            // act & assert
            ActionGetTupla();

        }

        [TestMethod()]
        public void TST_GetTuplas_020_ComEspacos()
        {

            input = "  alex  =  1234  ,  gomes  =  2321  ,  jorge  =  9841  ";
            output = "alex: '1234', gomes: '2321', jorge: '9841'";

            // act & assert
            ActionGetTupla();

        }
        [TestMethod()]
        public void TST_GetTuplas_030_ComDelimitadores()
        {

            input = "  alex  =  1234 [zzz]  ,  gomes  =  2321 [bbb] ,  jorge  =  9841 [jjjjj] ";
            output = "alex: '1234' <zzz>, gomes: '2321' <bbb>, jorge: '9841' <jjjjj>";

            // act & assert
            ActionGetTupla();

        }
        [TestMethod()]
        public void TST_GetTuplas_040_SemValoresSeparadorModificado()
        {

            input = "Login[testLoginAdmValido,login,senha,usuarioLogado] + Aluno[test01_ValidarInformacoesDoAluno,matricula,getNomeAluno]";
            output = "Login: '' <testLoginAdmValido,login,senha,usuarioLogado>, Aluno: '' <test01_ValidarInformacoesDoAluno,matricula,getNomeAluno>";

            // act & assert
            ActionGetTupla(prmSeparador: "+");

        }

        private void ActionGetTupla() => ActionGetTupla(prmSeparador: ",");
        private void ActionGetTupla(string prmSeparador)
        {

            // assert
            lista = new xTuplas(input, prmSeparador);

            result = lista.memo;

            // assert
            ActionGeneric();

        }

        private void ActionGeneric()
        {

            // assert
            if (output != result)
                Assert.Fail(string.Format("Expected: <{0}>, Actual: <{1}>", output, result));

        }
    }
}
