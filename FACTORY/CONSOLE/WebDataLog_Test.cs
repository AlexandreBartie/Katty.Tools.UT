using Dooggy.Tests.Factory.lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dooggy.Tests.FACTORY.LOG
{
    [TestClass()]
    public class CAT_010_DataLogByMain_Test : DataModelFactory_Test
    {
        public CAT_010_DataLogByMain_Test()
        {

            path_out += @"DataLog\ByMain\";

        }

        [TestMethod()]
        public void TST010_DataLogByMain_ArquivoPadrao()
        {

            // arrange
            output = "";
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
        public void TST020_DataLogByMain_ArquivoMascaramento()
        {

            // arrange
            output = "";
            output += @"[ DAT] act# -db[SIA] -status: CONECTADO" + Environment.NewLine;
            output += @"[ SET] act# -view[MascaramentoAluno] -itens: 3" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '10'" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '4'" + Environment.NewLine;
            output += @"[SAVE] act# -save: Salvo com sucesso. -encoding: utf8 -file: ArqAtendimentoAoAluno-Mascaramento.txt" + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno-Mascaramento");

            // & assert
            VerifyExpectedData(prmData: Console.Result.Log.txt);

        }

        [TestMethod()]
        public void TST030_DataLogByMain_ArquivoMultiplos()
        {

            // arrange
            output = "";
            output += @"[ DAT] act# -db[SIA] -status: CONECTADO" + Environment.NewLine;
            output += @"[ SET] act# -view[LoginADM] -itens: 1" + Environment.NewLine;
            output += @"[ SET] act# -view[MultiplosAlunos] -itens: 3" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_usuario, '1234as' as senha, nom_usuario FROM seg.usuario WHERE cod_usuario = '1016283'" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '10'" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '4'" + Environment.NewLine;
            output += @"[SAVE] act# -save: Salvo com sucesso. -encoding: utf8 -file: ArqAtendimentoAoAluno-Multiplos.txt" + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno-Multiplos");

            // & assert
            VerifyExpectedData(prmData: Console.Result.Log.txt);

        }

        [TestMethod()]
        public void TST040_DataLogByMain_ArquivoNoTAGs()
        {

            // arrange
            output = "";
            output += @"[ DAT] act# -db[SIA] -status: CONECTADO" + Environment.NewLine;
            output += @"[ SET] act# -view[Teste] -itens: 3" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '10'" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '4'" + Environment.NewLine;
            output += @"[SAVE] act# -save: Salvo com sucesso. -encoding: utf8 -file: ArqAtendimentoAoAluno-NoTAGs.txt" + Environment.NewLine;


            // act
            ConnectDbOracle();

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno-NoTAGs");

            // & assert
            VerifyExpectedData(prmData: Console.Result.Log.txt);

        }

        [TestMethod()]
        public void TST050_DataLogByMain_ArquivosIsolamento()
        {

            // arrange
            output = "";
            output += @"[ DAT] act# -db[SIA] -status: CONECTADO" + Environment.NewLine;
            output += @"[ SET] act# -view[Teste] -itens: 3" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '10'" + Environment.NewLine;
            output += @"[ SQL] -db[SIA] -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '4'" + Environment.NewLine;
            output += @"[SAVE] act# -save: Salvo com sucesso. -encoding: utf8 -file: ArqAtendimentoAoAluno-NoTAGs.txt" + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno-NoTAGs");

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno-NoTAGs");

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno-NoTAGs");

            // & assert
            VerifyExpectedData(prmData: Console.Result.Log.txt);

        }

        [TestMethod()]
        public void TST060_DataLogByMain_DBDesconetadoVariosRegistros()
        {

            // arrange
            output = "";
            output += @"[ERRO] Conexão bloqueada ... -error: [APENAS para testes unitários] -db[SIA] -string: Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(Host = 10.250.1.35)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = INTEGRATION.prod01.redelocal.oraclevcn.com)));User ID=desenvolvedor_sia;Password=asdfg;Connection Timeout=30" + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.SetDBStatus(prmBloqueado: true);

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno-NoTAGs");

            Console.SetDBStatus(prmBloqueado: false);

            // & assert
            VerifyExpectedData(prmData: Console.Result.Log.txt);

        }

        [TestMethod()]
        public void TST070_DataLogByMain_DBDesconetadoVariosArquivos()
        {

            // arrange
            output = "";
            output += @"[ERRO] Conexão bloqueada ... -error: [APENAS para testes unitários] -db[SIA] -string: Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(Host = 10.250.1.35)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = INTEGRATION.prod01.redelocal.oraclevcn.com)));User ID=desenvolvedor_sia;Password=asdfg;Connection Timeout=30" + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.SetDBStatus(prmBloqueado: true);

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno");

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno");

            Console.Import(prmArquivoINI: "ArqAtendimentoAoAluno");

            Console.SetDBStatus(prmBloqueado: false);

            // & assert
            VerifyExpectedData(prmData: Console.Result.Log.txt);

        }

    }

    [TestClass()]
    public class CAT_020_DataLogByErr_Test : DataModelFactory_Test
    {
        public CAT_020_DataLogByErr_Test()
        {

            path_out += @"DataLog\ByErr\";

        }
        [TestMethod()]
        public void TST010_DataLogByErr_VariavelNotFound()
        {

            // arrange
            output = "";
            output += "[ERRO] Variável não encontrada ... -var: UserxID -cmd: SELECT cod_usuario, '#(UserxID)' as senha, nom_usuario FROM seg.usuario WHERE cod_usuario = '1016283'" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
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
            VerifyExpectedData(prmData: Console.Result.Err.txt);

        }

        [TestMethod()]
        public void TST020_DataLogByErr_SQLFalhou()
        {

            // arrange
            output = "";
            output += "[ERRO] SQL falhou ... -error: [ORA-01722: número inválido] -db[SIA] -sql: SELECT cod_usuario, '1234as' as senha, nom_usuario FROM seg.usuario WHERE cod_usuario = 2" + Environment.NewLine;


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
            VerifyExpectedData(prmData: Console.Result.Err.txt);

        }

        [TestMethod()]
        public void TST030_DataLogByErr_SQLZeroItens()
        {

            // arrange
            output = "";
            output += "[ERRO] -db: sql isnt found ..." + Environment.NewLine;

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
            VerifyExpectedData(prmData: Console.Result.Err.txt);

        }
        [TestMethod()]
        public void TST040_DataLogByErr_SQLNoCommand()
        {

            output = "";
            output += "[ERRO] -db: sql isnt found ..." + Environment.NewLine;

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
            VerifyExpectedData(prmData: Console.Result.Err.txt);

        }
    }

    [TestClass()]
    public class CAT_030_DataLogBySQL_Test : DataModelFactory_Test
    {
        public CAT_030_DataLogBySQL_Test()
        {

            path_out += @"DataLog\BySQL\";

        }
        [TestMethod()]
        public void TST010_DataLogBySQL_ViewUnica()
        {

            // arrange
            output = "";
            output += "[ SQL] -db[SIA] -sql: SELECT cod_matricula, nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '4'" + Environment.NewLine;
            output += "[ SQL] -db[SIA] -sql: SELECT cod_matricula, nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            output += "[ SQL] -db[SIA] -sql: SELECT cod_matricula, nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '10'" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula, nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula, nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula, nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = '10'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save: Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.SQL.txt);

        }
        [TestMethod()]
        public void TST020_DataLogBySQL_ViewMultiplas()
        {

            // arrange
            output = "";
            output += "[ SQL] -db[SIA] -sql: SELECT cod_usuario, '1234as' as senha, nom_usuario FROM seg.usuario WHERE cod_usuario = '1016283'" + Environment.NewLine;
            output += "[ SQL] -db[SIA] -sql: SELECT cod_matricula, nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '4'" + Environment.NewLine;
            output += "[ SQL] -db[SIA] -sql: SELECT cod_matricula, nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            output += "[ SQL] -db[SIA] -sql: SELECT cod_matricula, nom_responsavel_pgto, cpf_responsavel_pgto FROM sia.aluno_curso WHERE cod_situacao_aluno = '10'" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela LOGIN" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "  -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -output: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, '1234as' as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = '1016283'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela ALUNO" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -name: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,getNomeAluno" + Environment.NewLine;
            bloco += "        -mask: cod_matricula = ####.##.#####-#, cpf_responsavel_pgto = ###.###.###-##" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula, nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula, nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula, nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = '10'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.SQL.txt);

        }
    }
}