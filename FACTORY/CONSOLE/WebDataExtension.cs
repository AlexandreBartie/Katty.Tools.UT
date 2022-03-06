using Dooggy.Tests.Factory.lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dooggy.Tests.FACTORY.EXTENSION
{
    [TestClass()]
    public class CAT_010_DataExtensionByCalc_Test : DataModelFactory_Test
    {

        public CAT_010_DataExtensionByCalc_Test()
        {

            path_out += @"DataExtension\ByCalc\";

        }

        [TestMethod()]
        public void TST010_DataExtensionByCalc_HOJE_DDMMAAAA()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,05062021,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Variáveis" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">var: UserID = '1016283'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "  -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -output: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, '$date(D+0:DDMMAAAA)' as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = #(UserID)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST020_DataExtensionByCalc_3MesesAntes_MMAAAA()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,032021,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Variáveis" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">var: UserID = '1016283'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "  -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -output: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, '$date(M-3:MMAAAA)' as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = #(UserID)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST030_DataExtensionByCalc_3MesesDepois_MMAA()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,0921,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Variáveis" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">var: UserID = '1016283'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "  -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -output: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, '$date(M+3:MMAA)' as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = #(UserID)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

    }
    [TestClass()]
    public class CAT_020_DataExtensionByFormat_Test : DataModelFactory_Test
    {

        public CAT_020_DataExtensionByFormat_Test()
        {

            path_out += @"DataExtension\ByFormat\";

        }

        [TestMethod()]
        public void TST010_DataExtension_ArquivoTXT_UTF8()
        {

            TesteGeneric_DataEncoding(prmArquivoOUT: "ArquivoTXT_UTF8", prmOptions: "txt.UTF8");

        }

        [TestMethod()]
        public void TST020_DataExtension_ArquivoTXT_UTF7()
        {

            TesteGeneric_DataEncoding(prmArquivoOUT: "ArquivoTXT_UTF7", prmOptions: "txt.UTF7");

        }

        [TestMethod()]
        public void TST030_DataExtension_ArquivoTXT_UTF32()
        {

            TesteGeneric_DataEncoding(prmArquivoOUT: "ArquivoTXT_UTF32", prmOptions: "txt.UTF32");

        }
        [TestMethod()]
        public void TST040_DataExtension_ArquivoTXT_UNICODE()
        {

            TesteGeneric_DataEncoding(prmArquivoOUT: "ArquivoTXT_UNICODE", prmOptions: "txt.UNICODE");

        }

        [TestMethod()]
        public void TST050_DataExtension_ArquivoTXT_ASCII()
        {

            TesteGeneric_DataEncoding(prmArquivoOUT: "ArquivoTXT_ASCII", prmOptions: "txt.ASCII");

        }

        [TestMethod()]
        public void TST060_DataExtension_ArquivoTXT_CodePage_1252()
        {

            TesteGeneric_DataEncoding(prmArquivoOUT: "ArquivoTXT_1252", prmOptions: "txt.1252");

        }

        [TestMethod()]
        public void TST070_DataExtension_ArquivoTXT_CodePage_28591()
        {
            TesteGeneric_DataEncoding(prmArquivoOUT: "ArquivoTXT_ISO-8859-1", prmOptions: "txt.28591");
        }

        [TestMethod()]
        public void TST080_DataExtension_ArquivoTXT_CodePage_AJ21()
        {

            TesteGeneric_DataEncoding(prmArquivoOUT: "ArquivoTXT_ERRO", prmOptions: "txt.AW32");

        }
    }
    [TestClass()]
    public class CAT_040_DataExtensionByFields_Test : DataModelFactory_Test
    {
        public CAT_040_DataExtensionByFields_Test()
        {

            path_out += @"DataExtension\ByFields\";

        }

        [TestMethod()]
        public void TST010_DataExtensionByFields_EntradaPadrao()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,usuario,email" + Environment.NewLine;
            output += ",1016283,MARLI LOPES OGAWA DE FIGUEIREDO,marli.ogawa@yduqs.com.br" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Input" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "     -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "    -input: login" + Environment.NewLine;
            bloco += "   -output: usuario, email" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += "   -enter: login = '1016283'" + Environment.NewLine;
            bloco += "     -sql: SELECT #(login), nom_usuario, txt_email" + Environment.NewLine;
            bloco += "             FROM seg.usuario" + Environment.NewLine;
            bloco += "            WHERE cod_usuario = #(login)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST020_DataExtensionByFields_SaidaPadrao()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,usuario,email,msg" + Environment.NewLine;
            output += ",1016283,MARLI LOPES OGAWA DE FIGUEIREDO,marli.ogawa@yduqs.com.br,Usuário Ativo" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Input" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "     -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "    -input: login" + Environment.NewLine;
            bloco += "   -output: usuario, email, msg" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += "   -check: msg = 'Usuário Ativo'" + Environment.NewLine;
            bloco += "     -sql: SELECT cod_usuario, nom_usuario, txt_email, #(msg)" + Environment.NewLine;
            bloco += "             FROM seg.usuario" + Environment.NewLine;
            bloco += "            WHERE cod_usuario = '1016283'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST030_DataExtensionByFields_EntradaSaidaPadrao()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,usuario,email,msg" + Environment.NewLine;
            output += ",1016283,MARLI LOPES OGAWA DE FIGUEIREDO,marli.ogawa@yduqs.com.br,Usuário Ativo" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Input" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "     -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "    -input: login" + Environment.NewLine;
            bloco += "   -output: usuario, email, msg" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += "   -enter: login='1016283'" + Environment.NewLine;
            bloco += "   -check:   msg= 'Usuário Ativo'" + Environment.NewLine;
            bloco += "     -sql: SELECT #(login), nom_usuario, txt_email, #(msg)" + Environment.NewLine;
            bloco += "             FROM seg.usuario" + Environment.NewLine;
            bloco += "            WHERE cod_usuario = #(login)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST040_DataExtensionByFields_EntradaAlias()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,usuario,email,msg" + Environment.NewLine;
            output += ",1016283,MARLI LOPES OGAWA DE FIGUEIREDO,marli.ogawa@yduqs.com.br,Usuário Ativo" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "     -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "    -input: login" + Environment.NewLine;
            bloco += "   -output: usuario, email, msg" + Environment.NewLine;
            bloco += "    -alias: usuario = nom_usuario, email = txt_email" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += "   -enter: login='1016283'" + Environment.NewLine;
            bloco += "   -check:   msg= 'Usuário Ativo'" + Environment.NewLine;
            bloco += "     -sql: SELECT #(flow)" + Environment.NewLine;
            bloco += "             FROM seg.usuario" + Environment.NewLine;
            bloco += "            WHERE cod_usuario = #(login)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST050_DataExtensionByFields_EntradaFilter()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,usuario,email,msg" + Environment.NewLine;
            output += ",1016283,MARLI LOPES OGAWA DE FIGUEIREDO,marli.ogawa@yduqs.com.br,Usuário Ativo" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "     -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "   -tables: seg.usuario" + Environment.NewLine;
            bloco += "    -input: login" + Environment.NewLine;
            bloco += "   -output: usuario, email, msg" + Environment.NewLine;
            bloco += "    -alias: usuario = nom_usuario, email = txt_email" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += "   -enter: login='1016283'" + Environment.NewLine;
            bloco += "   -check:   msg= 'Usuário Ativo'" + Environment.NewLine;
            bloco += "  -filter: cod_usuario = #(login)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
    }
    [TestClass()]
    public class CAT_050_DataExtensionByFieldsFail_Test : DataModelFactory_Test
    {
        public CAT_050_DataExtensionByFieldsFail_Test()
        {

            path_out += @"DataExtension\ByFieldsFail\";

        }
        [TestMethod()]
        public void TST010_DataExtensionByFieldsFail_DataEnterNotFindInputFields()
        {

            // arrange
            output = "";
            output += "[ DAT] act# -db[SIA] -status: CONECTADO" + Environment.NewLine;
            output += "[ERRO] DataEnter não encontrado em campos INPUT ... -enter: #(login) = '1016283'" + Environment.NewLine;
            output += "[ SET] act# -view[Login] -itens: 1" + Environment.NewLine;
            output += "[ SET] act# Variável modificada ... -var: msg = 'Usuário Ativo'" + Environment.NewLine;
            output += "[ERRO] Variável não encontrada ... -var: login -cmd: SELECT #(login), nom_usuario, txt_email, 'Usuário Ativo' FROM seg.usuario WHERE cod_usuario = #(login)" + Environment.NewLine;
            output += "[ERRO] SQL falhou ... -error: [ORA-00936: expressão não encontrada] -db[SIA] -sql: SELECT , nom_usuario, txt_email, 'Usuário Ativo' FROM seg.usuario WHERE cod_usuario =" + Environment.NewLine;
            output += "[MUTE] act# -save: Silenciado com sucesso. -encoding: utf8" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Input" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "     -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "   -output: login" + Environment.NewLine;
            bloco += "   -output: usuario, email, msg" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += "   -enter: login='1016283'" + Environment.NewLine;
            bloco += "   -check:   msg= 'Usuário Ativo'" + Environment.NewLine;
            bloco += "     -sql: SELECT #(login), nom_usuario, txt_email, #(msg)" + Environment.NewLine;
            bloco += "             FROM seg.usuario" + Environment.NewLine;
            bloco += "            WHERE cod_usuario = #(login)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.Log.txt);

        }

        [TestMethod()]
        public void TST020_DataExtensionByFieldsFail_DataCheckNotFindOutputFields()
        {

            // arrange
            output = "";
            output += "[ DAT] act# -db[SIA] -status: CONECTADO" + Environment.NewLine;
            output += "[ERRO] DataCheck não encontrado em campos OUTPUT... -check: #(msg) = 'Usuário Ativo'" + Environment.NewLine;
            output += "[ SET] act# -view[Login] -itens: 1" + Environment.NewLine;
            output += "[ SET] act# Variável modificada ... -var: login = '1016283'" + Environment.NewLine;
            output += "[ SQL] -db[SIA] -sql: SELECT '1016283', nom_usuario, txt_email, '' FROM seg.usuario WHERE cod_usuario = '1016283'" + Environment.NewLine;
            output += "[MUTE] act# -save: Silenciado com sucesso. -encoding: utf8" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Input" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "     -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "   -input: login" + Environment.NewLine;
            bloco += "   -input: usuario, email, msg" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += "   -enter: login='1016283'" + Environment.NewLine;
            bloco += "   -check:   msg= 'Usuário Ativo'" + Environment.NewLine;
            bloco += "     -sql: SELECT #(login), nom_usuario, txt_email, #(msg)" + Environment.NewLine;
            bloco += "             FROM seg.usuario" + Environment.NewLine;
            bloco += "            WHERE cod_usuario = #(login)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.Log.txt);

        }
    }

    [TestClass()]
    public class CAT_060_DataExtensionByExists_Test : DataModelFactory_Test
    {
        public CAT_060_DataExtensionByExists_Test()
        {

            path_out += @"DataExtension\ByExists\";

        }

        [TestMethod()]
        public void TST010_DataExtensionByExists_EntradaPadrao()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,usuario,email" + Environment.NewLine;
            output += ",1016283,MARLI LOPES OGAWA DE FIGUEIREDO,marli.ogawa@yduqs.com.br" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Input" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "     -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "    -input: login" + Environment.NewLine;
            bloco += "   -output: usuario, email" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += "   -enter: login = '1016283'" + Environment.NewLine;
            bloco += "     -sql: SELECT #(login), nom_usuario, txt_email" + Environment.NewLine;
            bloco += "             FROM seg.usuario" + Environment.NewLine;
            bloco += "            WHERE cod_usuario = #(login)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
    }
}
