using BlueRocket.CORE.Tests.Factory.lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueRocket.CORE.Tests.DATA.TYPES
{
    [TestClass()]
    public class CAT_010_DataTypesByNumeric_Test : DataModelFactory_Test
    {

        public CAT_010_DataTypesByNumeric_Test()
        {

            path_out += @"DataType\ByNumeric\";

        }

        [TestMethod()]
        public void TST010_DataTypesByNumeric_ValorPadrao()
        {

            // arrange
            output = "";
            output += "ValidarCarne,Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            output += ",29600296,493.19,44.84,8.97,464.36" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view:" + Environment.NewLine;
            bloco += "  -name: ValidarCarne" + Environment.NewLine;
            bloco += "      -output: Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += " -sql: SELECT num_seq_carne, val_a_pagar, val_desconto, val_multa, val_pago" + Environment.NewLine;
            bloco += "         FROM sia.carne" + Environment.NewLine;
            bloco += "        WHERE num_seq_carne = '29600296'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST020_DataTypesByNumeric_ValorZero()
        {

            // arrange
            output = "";
            output += "ValidarCarne,Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            output += ",53869974,407.31,0,8.15,0" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view:" + Environment.NewLine;
            bloco += "  -name: ValidarCarne" + Environment.NewLine;
            bloco += "      -output: Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += " -sql: SELECT num_seq_carne, val_a_pagar, val_desconto, val_multa, val_pago" + Environment.NewLine;
            bloco += "         FROM sia.carne" + Environment.NewLine;
            bloco += "        WHERE num_seq_carne = '53869974'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
        [TestMethod()]
        public void TST030_DataTypesByNumeric_ValorNull()
        {

            // arrange
            output = "";
            output += "ValidarCarne,Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            output += ",53791924,356.94,,7.93," + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view:" + Environment.NewLine;
            bloco += "  -name: ValidarCarne" + Environment.NewLine;
            bloco += "      -output: Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += " -sql: SELECT num_seq_carne, val_a_pagar, val_desconto, val_multa, val_pago" + Environment.NewLine;
            bloco += "         FROM sia.carne" + Environment.NewLine;
            bloco += "        WHERE num_seq_carne = '53791924'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST040_DataTypesByNumeric_ValorFormatado()
        {

            // arrange
            output = "";
            output += "ValidarCarne,Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            output += ",29600296,493.19,44.84,8.97,464.36" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view:" + Environment.NewLine;
            bloco += "  -name: ValidarCarne" + Environment.NewLine;
            bloco += "      -output: Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            bloco += "       -mask: val_a_pagar = #0.00, val_desconto = #0.00, val_multa = #0.00, val_pago = #0.00" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += " -sql: SELECT num_seq_carne, val_a_pagar, val_desconto, val_multa, val_pago" + Environment.NewLine;
            bloco += "         FROM sia.carne" + Environment.NewLine;
            bloco += "        WHERE num_seq_carne = '29600296'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST050_DataTypesByNumeric_ValorZeroFormatado()
        {

            // arrange
            output = "";
            output += "ValidarCarne,Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            output += ",53869974,407.31,0.00,8.15,0.00" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view:" + Environment.NewLine;
            bloco += "  -name: ValidarCarne" + Environment.NewLine;
            bloco += "      -output: Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            bloco += "       -mask: val_a_pagar = #0.00, val_desconto = #0.00, val_multa = #0.00, val_pago = #0.00" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += " -sql: SELECT num_seq_carne, val_a_pagar, val_desconto, val_multa, val_pago" + Environment.NewLine;
            bloco += "         FROM sia.carne" + Environment.NewLine;
            bloco += "        WHERE num_seq_carne = '53869974'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST060_DataTypesByNumeric_ValorNullFormatado()
        {

            // arrange
            output = "";
            output += "ValidarCarne,Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            output += ",4649064,168.05,,,168.05" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view:" + Environment.NewLine;
            bloco += "  -name: ValidarCarne" + Environment.NewLine;
            bloco += "      -output: Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            bloco += "       -mask: val_a_pagar = #0.00, val_desconto = #0.00, val_multa = #0.00, val_pago = #0.00" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += " -sql: SELECT num_seq_carne, val_a_pagar, val_desconto, val_multa, val_pago" + Environment.NewLine;
            bloco += "         FROM sia.carne" + Environment.NewLine;
            bloco += "        WHERE num_seq_carne = '4649064'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST070_DataTypesByNumeric_ValorCSV_Culture_enUS()
        {

            // arrange
            output = "";
            output += "ValidarCarne,Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            output += ",53869974,407.31,0.00,8.15,0.00" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view:" + Environment.NewLine;
            bloco += "  -name: ValidarCarne" + Environment.NewLine;
            bloco += "      -output: Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            bloco += "       -mask: val_a_pagar = #0.00, val_desconto = #0.00, val_multa = #0.00, val_pago = #0.00" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += " -sql: SELECT num_seq_carne, val_a_pagar, val_desconto, val_multa, val_pago" + Environment.NewLine;
            bloco += "         FROM sia.carne" + Environment.NewLine;
            bloco += "        WHERE num_seq_carne = '53869974'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Config.CSV.SetRegion("en-US");

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

            Console.Config.CSV.SetRegion();

        }

        [TestMethod()]
        public void TST080_DataTypesByNumeric_ValorCSV_Culture_ptBR()
        {

            // arrange
            output = "";
            output += "ValidarCarne,Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            output += @",53869974,""407,31"",""0"",""8,15"",""0""" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view:" + Environment.NewLine;
            bloco += "  -name: ValidarCarne" + Environment.NewLine;
            bloco += "      -output: Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += " -sql: SELECT num_seq_carne, val_a_pagar, val_desconto, val_multa, val_pago" + Environment.NewLine;
            bloco += "         FROM sia.carne" + Environment.NewLine;
            bloco += "        WHERE num_seq_carne = '53869974'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Config.CSV.SetRegion("pt-BR");

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

            Console.Config.CSV.SetRegion();

        }

        [TestMethod()]
        public void TST090_DataTypesByNumeric_ValorCSVFormatado_Culture_enUS()
        {

            // arrange
            output = "";
            output += "ValidarCarne,Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            output += ",53869974,407.31,0.00,8.15,0.00" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view:" + Environment.NewLine;
            bloco += "  -name: ValidarCarne" + Environment.NewLine;
            bloco += "      -output: Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            bloco += "       -mask: val_a_pagar = #0.00, val_desconto = #0.00, val_multa = #0.00, val_pago = #0.00" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += " -sql: SELECT num_seq_carne, val_a_pagar, val_desconto, val_multa, val_pago" + Environment.NewLine;
            bloco += "         FROM sia.carne" + Environment.NewLine;
            bloco += "        WHERE num_seq_carne = '53869974'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Config.CSV.SetRegion("en-US");

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

            Console.Config.CSV.SetRegion();

        }

        [TestMethod()]
        public void TST100_DataTypesByNumeric_ValorCSVFormatado_Culture_ptBR()
        {

            // arrange
            output = "";
            output += "ValidarCarne,Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            output += @",53869974,""407,31"",""0,00"",""8,15"",""0,00""" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view:" + Environment.NewLine;
            bloco += "  -name: ValidarCarne" + Environment.NewLine;
            bloco += "      -output: Carne,aPagar,Desconto,Multa,Pago" + Environment.NewLine;
            bloco += "       -mask: val_a_pagar = #0.00, val_desconto = #0.00, val_multa = #0.00, val_pago = #0.00" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += " -sql: SELECT num_seq_carne, val_a_pagar, val_desconto, val_multa, val_pago" + Environment.NewLine;
            bloco += "         FROM sia.carne" + Environment.NewLine;
            bloco += "        WHERE num_seq_carne = '53869974'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Config.CSV.SetRegion("pt-BR");

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

            Console.Config.CSV.SetRegion();

        }
    }
    [TestClass()]
    public class CAT_020_DataTypesByDate_Test : DataModelFactory_Test
    {

        public CAT_020_DataTypesByDate_Test()
        {

            path_out += @"DataType\ByDate\";

        }
        [TestMethod()]
        public void TST010_DataConsoleByTipo_DataPadrao()
        {

            // arrange
            output = "";
            output += "ValidarCarne,Carne,aPagar,Desconto,Multa,Pago,Baixa,Geracao" + Environment.NewLine;
            output += ",29600296,493.19,44.84,8.97,464.36,25/06/2004,12/04/2004" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view:" + Environment.NewLine;
            bloco += "  -name: ValidarCarne" + Environment.NewLine;
            bloco += "      -output: Carne,aPagar,Desconto,Multa,Pago,Baixa,Geracao" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += " -sql: SELECT num_seq_carne, val_a_pagar, val_desconto, val_multa, val_pago, dt_baixa, dt_geracao" + Environment.NewLine;
            bloco += "         FROM sia.carne" + Environment.NewLine;
            bloco += "        WHERE num_seq_carne = '29600296'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST020_DataConsoleByTipo_DataFormatado()
        {

            // arrange
            output = "";
            output += "ValidarCarne,Carne,aPagar,Desconto,Multa,Pago,Baixa,Geracao" + Environment.NewLine;
            output += ",29600296,493.19,44.84,8.97,464.36,2004jun25,abr:12-2004" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view:" + Environment.NewLine;
            bloco += "  -name: ValidarCarne" + Environment.NewLine;
            bloco += "      -output: Carne,aPagar,Desconto,Multa,Pago,Baixa,Geracao" + Environment.NewLine;
            bloco += "       -mask: dt_baixa = AAAAMMMDD, dt_geracao = MMM:DD-AAAA" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += " -sql: SELECT num_seq_carne, val_a_pagar, val_desconto, val_multa, val_pago, dt_baixa, dt_geracao" + Environment.NewLine;
            bloco += "         FROM sia.carne" + Environment.NewLine;
            bloco += "        WHERE num_seq_carne = '29600296'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
        [TestMethod()]
        public void TST030_DataConsoleByTipo_DataNull()
        {

            // arrange
            output = "";
            output += "ValidarCarne,Carne,aPagar,Desconto,Multa,Pago,Baixa,Geracao" + Environment.NewLine;
            output += ",60481429,481.8,,9.64,,,08/09/2006" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view:" + Environment.NewLine;
            bloco += "  -name: ValidarCarne" + Environment.NewLine;
            bloco += "      -output: Carne,aPagar,Desconto,Multa,Pago,Baixa,Geracao" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += " -sql: SELECT num_seq_carne, val_a_pagar, val_desconto, val_multa, val_pago, dt_baixa, dt_geracao" + Environment.NewLine;
            bloco += "         FROM sia.carne" + Environment.NewLine;
            bloco += "        WHERE num_seq_carne = '60481429'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST040_DataConsoleByTipo_DataNullFormatado()
        {

            // arrange
            output = "";
            output += "ValidarCarne,Carne,aPagar,Desconto,Multa,Pago,Baixa,Geracao" + Environment.NewLine;
            output += ",60481429,481.8,,9.64,,,2006set08" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view:" + Environment.NewLine;
            bloco += "  -name: ValidarCarne" + Environment.NewLine;
            bloco += "      -output: Carne,aPagar,Desconto,Multa,Pago,Baixa,Geracao" + Environment.NewLine;
            bloco += "       -mask: dt_baixa = AAAAMMMDD, dt_geracao = AAAAMMMDD" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += " -sql: SELECT num_seq_carne, val_a_pagar, val_desconto, val_multa, val_pago, dt_baixa, dt_geracao" + Environment.NewLine;
            bloco += "         FROM sia.carne" + Environment.NewLine;
            bloco += "        WHERE num_seq_carne = '60481429'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
    }


}
