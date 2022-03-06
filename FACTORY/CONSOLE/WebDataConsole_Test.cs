using System;
using System.Collections.Generic;
using System.Text;
using Dooggy.Tests.Factory.lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dooggy.Tests.FACTORY.CONSOLE
{
    [TestClass()]
    public class CAT_010_DataConsoleBySaveDefault_Test : DataModelFactory_Test
    {

        public CAT_010_DataConsoleBySaveDefault_Test()
        {

            path_out += @"DataConsole\BySaveDefault\";

        }
        [TestMethod()]
        public void TST010_DataSave_ArquivoOUT_FormatoDefault()
        {

            SetFormatSave(prmFormatDefault: "");

            TesteGeneric_DataEncoding(prmArquivoOUT: "ArquivoOUT_FormatoDefault", prmCSV: true);

        }
        [TestMethod()]
        public void TST020_DataSave_ArquivoOUT_FormatoTXT()
        {

            SetFormatSave(prmFormatDefault: "txt");

            TesteGeneric_DataEncoding(prmArquivoOUT: "ArquivoOUT_FormatoTXT");

        }

        [TestMethod()]
        public void TST030_DataSave_ArquivoOUT_FormatoCSV_Encoding1252()
        {

            SetFormatSave(prmFormatDefault: ".1252");

            TesteGeneric_DataEncoding(prmArquivoOUT: "ArquivoOUT_FormatoCSV_Encoding1252", prmCSV: true);

        }

        [TestMethod()]
        public void TST040_DataSave_ArquivoOUT_FormatoTXT_Encoding1252()
        {

            SetFormatSave(prmFormatDefault: "txt.1252");

            TesteGeneric_DataEncoding(prmArquivoOUT: "ArquivoOUT_FormatoTXT_Encoding1252");

        }
        [TestMethod()]
        public void TST050_DataSave_ArquivoOUT_FormatoCSV_Encoding1252_XPTO()
        {

            SetFormatSave(prmFormatDefault: ".1252.xpto");

            TesteGeneric_DataEncoding(prmArquivoOUT: "ArquivoOUT_FormatoCSV_Encoding1252_XPTO", prmCSV: true);

        }

        [TestMethod()]
        public void TST060_DataSave_ArquivoOUT_FormatoTXT_Encoding1252_XPTO()
        {

            SetFormatSave(prmFormatDefault: "txt.1252.xpto");

            TesteGeneric_DataEncoding(prmArquivoOUT: "ArquivoOUT_FormatoTXT_Encoding1252_XPTO");

        }
        [TestMethod()]
        public void TST070_DataSave_ArquivoOUT_FormatoCSV_EncodingUFT8_XPTO()
        {

            SetFormatSave(prmFormatDefault: "..xpto");

            TesteGeneric_DataEncoding(prmArquivoOUT: "ArquivoOUT_FormatoCSV_EncodingUFT8_XPTO", prmCSV: true);

        }

        [TestMethod()]
        public void TST080_DataSave_ArquivoOUT_FormatoTXT_EncodingUFT8_XPTO()
        {

            SetFormatSave(prmFormatDefault: "txt..xpto");

            TesteGeneric_DataEncoding(prmArquivoOUT: "ArquivoOUT_FormatoTXT_EncodingUFT8_XPTO");

        }
    }
    [TestClass()]
    public class CAT_020_DataConsoleByTrace_Test : DataModelFactory_Test
    {

        public CAT_020_DataConsoleByTrace_Test()
        {

            path_out += @"DataConsole\ByTrace\";

        }

        [TestMethod()]
        public void TST010_DataConsoleByTrace_RegistroUnico()
        {

            // arrange
            output = "";
            output += "[ DAT] act# -db[SIA] -status: CONECTADO" + Environment.NewLine;
            output += "[ SET] act# -view[Aluno] -itens: 1" + Environment.NewLine;
            output += "[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            output += "[MUTE] act# -save: Silenciado com sucesso. -encoding: utf8" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "        FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "        WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save: Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.Log.txt);

        }

        [TestMethod()]
        public void TST020_DataConsoleByTrace_VariavelNaoEncontrada()
        {

            // arrange
            output = "";
            output += "[ DAT] act# -db[SIA] -status: CONECTADO" + Environment.NewLine;
            output += "[ SET] act# -view[Login] -itens: 1" + Environment.NewLine;
            output += "[ERRO] Variável não encontrada ... -var: UserxID -cmd: SELECT cod_usuario, '#(UserxID)' as senha, nom_usuario FROM seg.usuario WHERE cod_usuario = '1016283'" + Environment.NewLine;
            output += "[ SQL] -db[SIA] -sql: SELECT cod_usuario, '' as senha, nom_usuario FROM seg.usuario WHERE cod_usuario = '1016283'" + Environment.NewLine;
            output += "[MUTE] act# -save: Silenciado com sucesso. -encoding: utf8" + Environment.NewLine;
            
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
            bloco += " -sql:  SELECT cod_usuario, '#(UserxID)' as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = '1016283'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.Log.txt);

        }

        [TestMethod()]
        public void TST030_DataConsoleByTrace_SQLFalhou()
        {

            // arrange
            output = "";
            output += "[ DAT] act# -db[SIA] -status: CONECTADO" + Environment.NewLine;
            output += "[ SET] act# -view[Login] -itens: 1" + Environment.NewLine;
            output += "[ERRO] SQL falhou ... -error: [ORA-01722: número inválido] -db[SIA] -sql: SELECT cod_usuario, '1234as' as senha, nom_usuario FROM seg.usuario WHERE cod_usuario = 2" + Environment.NewLine;
            output += "[MUTE] act# -save: Silenciado com sucesso. -encoding: utf8" + Environment.NewLine;

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
            bloco += " -sql:  SELECT cod_usuario, '1234as' as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = 2" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.Log.txt);

        }

        [TestMethod()]
        public void TST040_DataConsoleByTrace_SQLZeroItens()
        {

            // arrange
            output = "";
            output += "[ DAT] act# -db[SIA] -status: CONECTADO" + Environment.NewLine;
            output += "[ SET] act# -view[Aluno] -itens: 3" + Environment.NewLine;
            output += "[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = 06" + Environment.NewLine;
            output += "[ERRO] >>>> [ZERO Results] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = 99" + Environment.NewLine;
            output += "[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = 08" + Environment.NewLine;
            output += "[MUTE] act# -save: Silenciado com sucesso. -encoding: utf8" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela ALUNO" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -name: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,getNomeAluno" + Environment.NewLine;
            bloco += "       -mask: cod_matricula = ####.##.#####-#, cpf_responsavel_pgto = ###.###.###-##" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = 06" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = 99" + Environment.NewLine; bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = 08" + Environment.NewLine; bloco += Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.Log.txt);

        }

        [TestMethod()]
        public void TST050_DataConsoleByTrace_SQLNoCommand()
        {

            // arrange
            output = "";
            output += "[ DAT] act# -db[SIA] -status: CONECTADO" + Environment.NewLine;
            output += "[ SET] act# -view[Aluno] -itens: 3" + Environment.NewLine;
            output += "[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = 06" + Environment.NewLine;
            output += "[ERRO] -db: sql isnt found ..." + Environment.NewLine;
            output += "[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = 08" + Environment.NewLine;
            output += "[MUTE] act# -save: Silenciado com sucesso. -encoding: utf8" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela ALUNO" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -name: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,getNomeAluno" + Environment.NewLine;
            bloco += "       -mask: cod_matricula = ####.##.#####-#, cpf_responsavel_pgto = ###.###.###-##" + Environment.NewLine; bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = 06" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += ">item:" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = 08" + Environment.NewLine; bloco += Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.Log.txt);

        }

        [TestMethod()]
        public void TST060_DataConsoleByTrace_ImportArquivoINI()
        {

            // arrange
            output = @"";
            output += @"[ DAT] act# -db[SIA] -status: CONECTADO" + Environment.NewLine;
            output += @"[ SET] act# -view[AtendimentoAluno] -itens: 3" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '10'" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '4'" + Environment.NewLine;
            output += @"[SAVE] act# -save: Salvo com sucesso. -encoding: utf8 -file: ArqAtendimentoAoAluno.txt" + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno");

            // & assert
            VerifyExpectedData(prmData: Console.Result.Log.txt);

        }

        [TestMethod()]
        public void TST070_DataConsoleByTrace_ArquivosIsolamento()
        {

            // arrange
            output = @"";
            output += @"[ DAT] act# -db[SIA] -status: CONECTADO" + Environment.NewLine + output;
            output += @"[ SET] act# -view[Teste] -itens: 3" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '10'" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '4'" + Environment.NewLine;
            output += @"[SAVE] act# -save: Salvo com sucesso. -encoding: utf8 -file: ArqAtendimentoAoAluno-NoTAGs.txt" + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno");

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno-NoTAGs");

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno");

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno-NoTAGs");

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno-NoTAGs");

            // & assert
            VerifyExpectedData(prmData: Console.Result.Log.txt);

        }

    }
    [TestClass()]
    public class CAT_030_DataConsoleByLoad_Test : DataModelFactory_Test
    {

        public CAT_030_DataConsoleByLoad_Test()
        {

            path_out += @"DataConsole\ByLoad\";

        }

        [TestMethod()]
        public void TST010_DataConsoleByLoad_ArquivoIdentificado()
        {

            // arrange
            output = "";
            output += ">view: AtendimentoAluno" + Environment.NewLine;
            output += "     -name: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            output += "   -output: matricula,getNomeAluno,cpf" + Environment.NewLine;
            output += Environment.NewLine;
            output += ">item: padrao" + Environment.NewLine;
            output += "   -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            output += "         FROM sia.aluno_curso" + Environment.NewLine;
            output += "         WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            output += Environment.NewLine;
            output += ">item: novato" + Environment.NewLine;
            output += "   -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            output += "         FROM sia.aluno_curso" + Environment.NewLine;
            output += "         WHERE cod_situacao_aluno = '10'" + Environment.NewLine;
            output += Environment.NewLine;
            output += ">item: errado" + Environment.NewLine;
            output += "   -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            output += "         FROM sia.aluno_curso" + Environment.NewLine;
            output += "         WHERE cod_situacao_aluno = '4'" + Environment.NewLine;
            output += Environment.NewLine;
            output += ">save[txt]:" + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.Load();

            Console.SetScript(prmKey: "ArqAtendimentoAoAluno");

            // & assert
            VerifyExpectedData(prmData: Console.code_result + Console.data_result);

        }

        [TestMethod()]
        public void TST030_DataConsoleByLoad_ArquivoInexistente()
        {

            // arrange
            output = "";

            // act
            ConnectDbOracle();

            Console.Load();

            Console.SetScript(prmKey: "ArqXAtendimentoXAluno");

            // & assert
            VerifyExpectedData(prmData: Console.code_result + Console.data_result);

        }
    }
    [TestClass()]
    public class CAT_040_DataConsoleByImport_Test : DataModelFactory_Test
    {

        public CAT_040_DataConsoleByImport_Test()
        {

            path_out += @"DataConsole\ByImport\";

        }

        [TestMethod()]
        public void TST010_DataConsoleByImport_ArquivoPadrao()
        {

            // arrange
            output = "";
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno,cpf" + Environment.NewLine;
            output += ",198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;
            output += ",199901172028,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;
            output += ",198101000798,OSWALDO REBELLO," + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno");

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST020_DataConsoleByImport_ArquivoMascaramento()
        {

            // arrange
            output = "";
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",1984.02.01883-1,PAULO LOUREIRO FILHO,805.545.047-15" + Environment.NewLine;
            output += ",1999.01.17202-8,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;
            output += ",1981.01.00079-8,OSWALDO REBELLO," + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno-Mascaramento");

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST030_DataConsoleByImport_ArquivoMultiplos()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",1984.02.01883-1,PAULO LOUREIRO FILHO,805.545.047-15" + Environment.NewLine;
            output += ",1999.01.17202-8,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;
            output += ",1981.01.00079-8,OSWALDO REBELLO," + Environment.NewLine;
            // act
            ConnectDbOracle();

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno-Multiplos");

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST040_DataConsoleByImport_ArquivoNoTAGs()
        {

            // arrange
            output = "";
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;
            output += ",199901172028,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;
            output += ",198101000798,OSWALDO REBELLO," + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno-NoTAGs");

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST050_DataConsoleByImport_ArquivosIsolamento()
        {

            // arrange
            output = "";
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;
            output += ",199901172028,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;
            output += ",198101000798,OSWALDO REBELLO," + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno");

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno-NoTAGs");

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno");

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno-NoTAGs");

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

    }
    [TestClass()]
    public class CAT_050_DataConsoleByReal_Test : DataModelFactory_Test
    {
        public CAT_050_DataConsoleByReal_Test()
        {

            path_out += @"DataConsole\ByReal\";

        }

        [TestMethod()]
        public void TST010_DataConsoleByReal_ArqConsultaLancarDebito()
        {

            // arrange
            output = "";
            output += "test_01 ValidarInformacoesDoAlunoPesquisarDebito,matricula,getNomAluno" + Environment.NewLine;
            output += ",2009.01.25014-1,LEONARDO BORGES DE OLIVEIRA QUINTANEIRO" + Environment.NewLine;
            output += "test02_PesquisarLancamentoDeDebito,dtInicio,dtFim,getNomAluno,getNomCurso,getNomCampus" + Environment.NewLine;
            output += ",122020,122021,LEONARDO BORGES DE OLIVEIRA QUINTANEIRO,ENGENHARIA DE PRODUÇÃO ,NITERÓI" + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.Import(prmArquivoINI: "xArqConsultaLancarDebito");

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST020_DataConsoleByReal_ArqConsultaDisciplina()
        {

            // arrange
            output = "";
            output += "test01_PesquisarDisciplinaPorDisciplina,nomDisciplina,nCodigoDisciplina,nInstituicao" + Environment.NewLine;
            output += ",FISIOFARMACOLOGIA,CIS0756,UNIVERSIDADE ESTÁCIO DE SÁ" + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.Import(prmArquivoINI: "xArqConsultaDisciplina");

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST030_DataConsoleByReal_ArqConsultaCurso()
        {

            // arrange
            output = "";
            output += "test01_PesquisarCursosPorSigla,nSigla,nCodigoCurso,nomCurso,nTipoCurso" + Environment.NewLine;
            output += ",SGL,0,CURSO MIGRACAO,GRADUAÇÃO" + Environment.NewLine;
            output += "test02_PesquisarPorTipoDeCurso,nCurso,nTipoCurso,nomCurso,nSigla,nCodigoCurso" + Environment.NewLine;
            output += ",EDUCAÇÃO,MESTRADO,MESTRADO EM GESTÃO AMBIENTAL,MGA,2155" + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.Import(prmArquivoINI: "xArqConsultaCurso");

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

    }
    [TestClass()]
    public class CAT_060_DataConsoleBySetup_Test : DataModelFactory_Test
    {
        public CAT_060_DataConsoleBySetup_Test()
        {

            path_out += @"DataConsole\BySetup\";


        }

        [TestMethod()]
        public void TST010_DataConsoleBySetup_CarregarArquivoCFG()
        {

            // arrange
            output = "";
            output += "ArqAtendimentoAoAluno-Mascaramento" + Environment.NewLine;
            output += "ArqAtendimentoAoAluno-Multiplos" + Environment.NewLine;
            output += "ArqAtendimentoAoAluno-NoTAGs" + Environment.NewLine;
            output += "ArqAtendimentoAoAluno-RawData" + Environment.NewLine;
            output += "ArqAtendimentoAoAluno" + Environment.NewLine;
            output += "ArqConsultaDebitoNossoNumero" + Environment.NewLine;
            output += "xArqConsultaBolsaPadrao" + Environment.NewLine;
            output += "xArqConsultaCurso" + Environment.NewLine;
            output += "xArqConsultaDisciplina" + Environment.NewLine;
            output += "xArqConsultaLancarDebito" + Environment.NewLine;
            output += "xArqRepescagem" + Environment.NewLine;
            output += "xArqSQLsemFIM" + Environment.NewLine;

            // act

            string arquivo = path_cfg + @"teste-unitario.cfg";

            Console.Setup(prmArquivoCFG: arquivo);

            // & assert
            VerifyExpectedData(prmData: Console.Scripts.GetLista());

        }

        [TestMethod()]
        public void TST010_DataConsoleBySetup_ProcessarArquivoCFG()
        {

            // arrange
            output = "";
            output += "ArqAtendimentoAoAluno-Mascaramento" + Environment.NewLine;
            output += "ArqAtendimentoAoAluno-Multiplos" + Environment.NewLine;
            output += "ArqAtendimentoAoAluno-NoTAGs" + Environment.NewLine;
            output += "ArqAtendimentoAoAluno-RawData" + Environment.NewLine;
            output += "ArqAtendimentoAoAluno" + Environment.NewLine;
            output += "ArqConsultaDebitoNossoNumero" + Environment.NewLine;
            output += "xArqConsultaBolsaPadrao" + Environment.NewLine;
            output += "xArqConsultaCurso" + Environment.NewLine;
            output += "xArqConsultaDisciplina" + Environment.NewLine;
            output += "xArqConsultaLancarDebito" + Environment.NewLine;
            output += "xArqRepescagem" + Environment.NewLine;
            output += "xArqSQLsemFIM" + Environment.NewLine;

            // act

            string arquivo = path_cfg + @"teste-unitario.cfg";

            Console.EXE(prmArquivoCFG: arquivo);

            // & assert
            VerifyExpectedData(prmData: Console.Scripts.GetLista());

        }

    }
}
