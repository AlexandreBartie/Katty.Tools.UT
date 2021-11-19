using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace Dooggy.Tests
{
    [TestClass()]
    public class xParseCSV_Test
    {
        string entrada;
        string esperado;
        string saida;

        [TestMethod()]
        public void ParseCSV_TST01_Padrao()
        {

            // arrange
            entrada = "1234,2345,3,5,78";
            esperado = "4,4,1,1,2";

            // act
            saida = ActionParseCSV(entrada);

            // assert
            Assert.AreEqual(esperado, saida); 

        }

        [TestMethod()]
        public void ParseCSV_TST02_ItemUnico()
        {
            // arrange
            entrada = "82";
            esperado = "2";

            // act
            saida = ActionParseCSV(entrada);

            // assert
            Assert.AreEqual(esperado, saida);
        }

        [TestMethod()]
        public void ParseCSV_TST03_ItemVazio()
        {
            // arrange
            entrada = "1234,,3,5,78";
            esperado = "4,0,1,1,2";


            // act
            saida = ActionParseCSV(entrada);

            // assert
            Assert.AreEqual(esperado, saida);
        }

        [TestMethod()]
        public void ParseCSV_TST04_ListaVazia()
        {
            // arrange
            entrada = "";
            esperado = "";

            // act
            saida = ActionParseCSV(entrada);

            // assert
            Assert.AreEqual(esperado, saida);
        }

        [TestMethod()]
        public void ParseCSV_TST05_ItemComma()
        {
            // arrange

            entrada = @"Alexandre,Bartie,604,Beverlyblvd,alexandre.bartie@hotmail.com";
            esperado = "9,6,15,28";

            // act
            saida = ActionParseCSV(entrada);

            // assert
            Assert.AreEqual(esperado, saida);
        }
        private string ActionParseCSV(string prmLista)
        {

            xParseCSV lista = new xParseCSV(prmLista);

            string separador = "";

            string resultado = "";

            foreach (string item in lista)
            {

                resultado += separador + item.Length.ToString();

                separador = ",";

            }

            return (resultado);

        }

    }
}