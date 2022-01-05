using System;
using System.Collections.Generic;
using System.Text;
using Dooggy.Factory.Console;
using Dooggy.Tests.Factory.lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dooggy.Tests.FACTORY.CONSOLE
{

    [TestClass()]
    public class CAT_10_DataConsoleByView_Test : DataModelFactory_Test
    {

        public CAT_10_DataConsoleByView_Test()
        {

            path_out += @"DataConsole\ByView\";

            Console.Setup(path_ini, path_out);

        }

        [TestMethod()]
        public void TST010_DataConsoleByView_RegistroUnico()
        {

            // arrange
            output = "";
            output += "198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;

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
            bloco += ">csv: Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

        [TestMethod()]
        public void TST020_DataConsoleByView_ComNotacoes()
        {

            // arrange
            output = "";
            output += "198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Manter o arquivo tabulado para facilitar a leitura" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql: SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "       FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "       WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">csv: Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

        [TestMethod()]
        public void TST030_DataConsoleByView_RegistrosMultiplos()
        {

            // arrange
            output = "";
            output += "198101000798,OSWALDO REBELLO," + Environment.NewLine;
            output += "198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;
            output += "199901172028,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = '10'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">csv: Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

        [TestMethod()]
        public void TST040_DataConsoleByView_MascaramentoFormatacao()
        {

            // arrange
            output = "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",1981.01.00079-8,OSWALDO REBELLO," + Environment.NewLine;
            output += ",1984.02.01883-1,PAULO LOUREIRO FILHO,805.545.047-15" + Environment.NewLine;
            output += ",1999.01.17202-8,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -descricao: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -saida: matricula,getNomeAluno" + Environment.NewLine;
            bloco += "       -mask: { 'cod_matricula': '####.##.#####-#', 'cpf_responsavel_pgto': '###.###.###-##' }" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = '10'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">txt: Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }
        [TestMethod()]
        public void TST060_DataConsoleByView_MultiplosArquivos()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",1981.01.00079-8,OSWALDO REBELLO," + Environment.NewLine;
            output += ",1984.02.01883-1,PAULO LOUREIRO FILHO,805.545.047-15" + Environment.NewLine;
            output += ",1999.01.17202-8,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela LOGIN" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "  -descricao: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -saida: login,senha,usuarioLogado" + Environment.NewLine;
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
            bloco += "  -descricao: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -saida: matricula,getNomeAluno" + Environment.NewLine;
            bloco += "       -mask: { 'cod_matricula': '####.##.#####-#', 'cpf_responsavel_pgto': '###.###.###-##' }" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = '10'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">txt: Login + Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

        [TestMethod()]
        public void TST070_DataConsoleByView_ExecucaoConsecutiva()
        {

            // arrange
            output = "";
            output += "198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">csv: Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }
    }

    [TestClass()]
    public class CAT_20_DataConsoleByModel_Test : DataModelFactory_Test
    {

        public CAT_20_DataConsoleByModel_Test()
        {

            path_out += @"DataConsole\ByModel\";

            Console.Setup(path_ini, path_out);

        }

        [TestMethod()]
        public void TST010_DataConsoleByModel_RegistroUnico()
        {

            // arrange
            output = "";
            output += "198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -tabelas: sia.aluno_curso" + Environment.NewLine;
            bloco += "   -campos: cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "   -filtro: cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">csv: Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }


        [TestMethod()]
        public void TST020_DataConsoleByModel_ComNotacoes()
        {

            // arrange
            output = "";
            output += "198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Manter o arquivo tabulado para facilitar a leitura" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -tabelas: sia.aluno_curso" + Environment.NewLine;
            bloco += "   -campos: cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "   -filtro: cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">csv: Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }
        [TestMethod()]
        public void TST030_DataConsoleByModel_RegistrosMultiplos()
        {

            // arrange
            output = "";
            output += "198101000798,OSWALDO REBELLO," + Environment.NewLine;
            output += "198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;
            output += "199901172028,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -tabelas: sia.aluno_curso" + Environment.NewLine;
            bloco += "   -campos: cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "     -filtro:  cod_situacao_aluno = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += "     -filtro:  cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += "     -filtro:  cod_situacao_aluno = '10'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">csv: Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }
        [TestMethod()]
        public void TST040_DataConsoleByModel_MascaramentoFormatacao()
        {

            // arrange
            output = "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",1981.01.00079-8,OSWALDO REBELLO," + Environment.NewLine;
            output += ",1984.02.01883-1,PAULO LOUREIRO FILHO,805.545.047-15" + Environment.NewLine;
            output += ",1999.01.17202-8,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -descricao: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -saida: matricula,getNomeAluno" + Environment.NewLine;
            bloco += "    -tabelas: sia.aluno_curso" + Environment.NewLine;
            bloco += "     -campos: cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "       -mask: { 'cod_matricula': '####.##.#####-#', 'cpf_responsavel_pgto': '###.###.###-##' }" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "     -filtro:  cod_situacao_aluno = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += "     -filtro:  cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += "     -filtro:  cod_situacao_aluno = '10'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">txt: Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

        [TestMethod()]
        public void TST050_DataConsoleByModel_MultiplasTabelas()
        {

            // arrange
            output = "";
            output += "ReconhecimentoPorInstituicao,nInstituicao,nCampusResultado,nomCurso,nAto" + Environment.NewLine;
            output += ",CENTRO UNIVERSITÁRIO IBMEC,BARRA I - IBMEC,CURSO MIGRACAO,Autorização" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: AtosRegulatorios" + Environment.NewLine;
            bloco += "  -descricao: ReconhecimentoPorInstituicao" + Environment.NewLine;
            bloco += "      -saida: nInstituicao,nCampusResultado,nomCurso,nAto" + Environment.NewLine;
            bloco += "    -tabelas: sia.aluno_curso ab, sia.aluno ac, sia.curso ad, sia.campus ae, sia.LIVRO_REGISTRO_DIPLOMA af, sia.instituicao_ensino ag" + Environment.NewLine;
            bloco += "     -campos: ag.NOM_INSTITUICAO AS INSTITUICAO, ae.NOM_CAMPUS AS CAMPUS, ad.NOM_CURSO AS CURSO, SUBSTR(af.TXT_PORT_DOU_AUTORIZACAO, 1, 11) AS ATO" + Environment.NewLine;
            bloco += "   -relacoes: ad.COD_CURSO = ab.COD_CURSO_ATUAL and ae.COD_CAMPUS = ab.COD_CAMPUS_ATUAL and ag.cod_instituicao = ae.cod_instituicao" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "     -filtro: af.CPF_ALUNO = ac.CPF_ALUNO" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">txt: AtosRegulatorios" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }
        [TestMethod()]
        public void TST060_DataConsoleByModel_MultiplosArquivos()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",1981.01.00079-8,OSWALDO REBELLO," + Environment.NewLine;
            output += ",1984.02.01883-1,PAULO LOUREIRO FILHO,805.545.047-15" + Environment.NewLine;
            output += ",1999.01.17202-8,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela LOGIN" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "  -descricao: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -saida: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += "    -tabelas: seg.usuario" + Environment.NewLine;
            bloco += "     -campos: cod_usuario, '1234as' as senha, nom_usuario" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += "     -filtro:  cod_usuario = '1016283'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela ALUNO" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -descricao: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -saida: matricula,getNomeAluno" + Environment.NewLine;
            bloco += "    -tabelas: sia.aluno_curso" + Environment.NewLine;
            bloco += "     -campos: cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "       -mask: { 'cod_matricula': '####.##.#####-#', 'cpf_responsavel_pgto': '###.###.###-##' }" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "     -filtro:  cod_situacao_aluno = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += "     -filtro:  cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += "     -filtro:  cod_situacao_aluno = '10'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">txt: Login + Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

        [TestMethod()]
        public void TST070_DataConsoleByModel_ExecucaoConsecutiva()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",1981.01.00079-8,OSWALDO REBELLO," + Environment.NewLine;
            output += ",1984.02.01883-1,PAULO LOUREIRO FILHO,805.545.047-15" + Environment.NewLine;
            output += ",1999.01.17202-8,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela LOGIN" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "  -descricao: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -saida: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += "    -tabelas: seg.usuario" + Environment.NewLine;
            bloco += "     -campos: cod_usuario, '1234as' as senha, nom_usuario" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += "     -filtro:  cod_usuario = '1016283'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela ALUNO" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -descricao: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -saida: matricula,getNomeAluno" + Environment.NewLine;
            bloco += "    -tabelas: sia.aluno_curso" + Environment.NewLine;
            bloco += "     -campos: cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "       -mask: { 'cod_matricula': '####.##.#####-#', 'cpf_responsavel_pgto': '###.###.###-##' }" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "     -filtro:  cod_situacao_aluno = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += "     -filtro:  cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += "     -filtro:  cod_situacao_aluno = '10'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">txt: Login + Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }


    }
    [TestClass()]
    public class CAT_30_DataConsoleByVariable_Test : DataModelFactory_Test
    {

        public CAT_30_DataConsoleByVariable_Test()
        {

            path_out += @"DataConsole\ByVariable\";

            Console.Setup(path_ini, path_out);

        }

        [TestMethod()]
        public void TST010_DataConsoleByVariable_VariavelSimples()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;

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
            bloco += "  -descricao: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -saida: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, '1234as' as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = $(UserID)$" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">txt: Login + Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

        [TestMethod()]
        public void TST020_DataConsoleByVariable_VariavelValorVazio()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Variáveis" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">var: UserID = '1016283'" + Environment.NewLine;
            bloco += ">var: UserPass = ''" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "  -descricao: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -saida: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, $(UserPass)$ as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = $(UserID)$" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">txt: Login + Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

        [TestMethod()]
        public void TST030_DataConsoleByVariable_VariavelValorEspacos()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,     ,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Variáveis" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">var: UserID = '1016283'" + Environment.NewLine;
            bloco += ">var: UserPass = '     '" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "  -descricao: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -saida: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, $(UserPass)$ as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = $(UserID)$" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">txt: Login + Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

        [TestMethod()]
        public void TST040_DataConsoleByVariable_VariavelTagComEspacos()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;

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
            bloco += "  -descricao: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -saida: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, '1234as' as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = $( UserID )$" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">txt: Login + Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

        [TestMethod()]
        public void TST050_DataConsoleByVariable_VariavelNaoEncontrada()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += Environment.NewLine;

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
            bloco += "  -descricao: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -saida: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, '1234as' as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = $( UserxID )$" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">txt: Login + Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

        [TestMethod()]
        public void TST060_DataConsoleByVariable_VariaveisMultiplas()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",1981.01.00079-8,OSWALDO REBELLO," + Environment.NewLine;
            output += ",1984.02.01883-1,PAULO LOUREIRO FILHO,805.545.047-15" + Environment.NewLine;
            output += ",1999.01.17202-8,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Variáveis" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">var: UserID = '1016283'" + Environment.NewLine;
            bloco += ">var: UserPass = '1234as'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela LOGIN" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">var: AlunoNovo = '4'" + Environment.NewLine;
            bloco += ">var: AlunoFormado = '10'" + Environment.NewLine;
            bloco += ">var: AlunoReprovado = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "  -descricao: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -saida: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, $(UserPass)$ as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = $(UserID)$" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela ALUNO" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -descricao: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -saida: matricula,getNomeAluno" + Environment.NewLine;
            bloco += "       -mask: { 'cod_matricula': '####.##.#####-#', 'cpf_responsavel_pgto': '###.###.###-##' }" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = $(AlunoNovo)$" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = $(AlunoReprovado)$" + Environment.NewLine; bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = $(AlunoFormado)$" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">txt: Login + Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }


    }

    [TestClass()]
    public class CAT_40_DataConsoleByData_Test : DataModelFactory_Test
    {

        public CAT_40_DataConsoleByData_Test()
        {

            path_out += @"DataConsole\ByData\";

            Console.Setup(path_ini, path_out);

            Console.SetAncora(prmAncora: new DateTime(2021, 06, 05));

        }

        [TestMethod()]
        public void TST010_DataConsoleByData_HOJE_DDMMAAAA()
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
            bloco += "  -descricao: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -saida: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, '$date(D+0:DDMMAAAA)$' as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = $(UserID)$" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">txt: Login + Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

        [TestMethod()]
        public void TST020_DataConsoleByData_3MesesAntes_MMAAAA()
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
            bloco += "  -descricao: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -saida: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, '$date(M-3:MMAAAA)$' as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = $(UserID)$" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">txt: Login + Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

        [TestMethod()]
        public void TST030_DataConsoleByData_3MesesDepois_MMAA()
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
            bloco += "  -descricao: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -saida: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, '$date(M+3:MMAA)$' as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = $(UserID)$" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">txt: Login + Aluno" + Environment.NewLine;

            Console.Play(prmBloco: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

    }

    [TestClass()]
    public class CAT_60_DataConsoleByFormat_Test : DataModelFactory_Test
    {

        public CAT_60_DataConsoleByFormat_Test()
        {

            path_out += @"DataConsole\ByFormat\";

            Console.Setup(path_ini, path_out);

        }

        [TestMethod()]
        public void TST010_DataFormat_ArquivoTXT_UTF8()
        {

            TesteGeneric_DataFormat(prmArquivoOUT: "ArquivoTXT_UTF8", prmEncoding: "UTF8");

        }

        [TestMethod()]
        public void TST020_DataFormat_ArquivoTXT_UTF7()
        {

            TesteGeneric_DataFormat(prmArquivoOUT: "ArquivoTXT_UTF7", prmEncoding: "UTF7");

        }

        [TestMethod()]
        public void TST030_DataFormat_ArquivoTXT_UTF32()
        {

            TesteGeneric_DataFormat(prmArquivoOUT: "ArquivoTXT_UTF32", prmEncoding: "UTF32");

        }
        [TestMethod()]
        public void TST040_DataFormat_ArquivoTXT_UNICODE()
        {

            TesteGeneric_DataFormat(prmArquivoOUT: "ArquivoTXT_UNICODE", prmEncoding: "UNICODE");

        }

        [TestMethod()]
        public void TST050_DataFormat_ArquivoTXT_ASCII()
        {

            TesteGeneric_DataFormat(prmArquivoOUT: "ArquivoTXT_ASCII", prmEncoding: "ASCII");

        }

        [TestMethod()]
        public void TST060_DataFormat_ArquivoTXT_CodePage_1252()
        {

            TesteGeneric_DataFormat(prmArquivoOUT: "ArquivoTXT_1252", prmEncoding: "1252");

        }

        [TestMethod()]
        public void TST070_DataFormat_ArquivoTXT_CodePage_28591()
        {

            TesteGeneric_DataFormat(prmArquivoOUT: "ArquivoTXT_ISO-8859-1", prmEncoding: "28591");

        }

        [TestMethod()]
        public void TST080_DataFormat_ArquivoTXT_CodePage_AJ21()
        {

            TesteGeneric_DataFormat(prmArquivoOUT: "ArquivoTXT_ERRO", prmEncoding: "AW32");

        }

        private void TesteGeneric_DataFormat(string prmArquivoOUT, string prmEncoding)
        {

            // arrange
            output = "";
            output += "test01_PesquisarDisciplinaPorDisciplina,nomDisciplina,nCodigoDisciplina,nInstituicao" + Environment.NewLine;
            output += ",FISIOFARMACOLOGIA,CIS0756,UNIVERSIDADE ESTÁCIO DE SÁ" + Environment.NewLine;
            
            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: PesquisaDisciplina" + Environment.NewLine;
            bloco += "  -descricao: test01_PesquisarDisciplinaPorDisciplina" + Environment.NewLine;
            bloco += "      -saida: nomDisciplina,nCodigoDisciplina,nInstituicao" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT ab.nom_disciplina, ab.cod_disciplina, ac.nom_instituicao" + Environment.NewLine;
            bloco += "        FROM sia.DISCIPLINA ab, sia.INSTITUICAO_ENSINO ac, sia.ALOC_CURSO_DISCIPLINA ad" + Environment.NewLine;
            bloco += "        WHERE (ab.cod_disciplina = ad.cod_disciplina and ac.cod_instituicao = ad.cod_instituicao)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">txt[" + prmEncoding + "]:" + Environment.NewLine;

            Console.Play(prmBloco: bloco, prmArquivoOUT);

            // & assert
            VerifyExpectedData(prmData: Console.output);
        }

    }

    [TestClass()]
    public class CAT_50_DataConsoleByImport_Test : DataModelFactory_Test
    {

        public CAT_50_DataConsoleByImport_Test()
        {

            path_out += @"DataConsole\ByImport\";

            Console.Setup(path_ini, path_out);

        }

        [TestMethod()]
        public void TST010_DataImport_ArquivoPadrao()
        {

            // arrange
            output = "";
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;
            output += ",199901172028,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;
            output += ",198101000798,OSWALDO REBELLO," + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.ImportINI(prmArquivoINI: "ArqDadosAtendimentoAoAluno");

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

        [TestMethod()]
        public void TST020_DataImport_ArquivoMascaramento()
        {

            // arrange
            output = "";
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",1984.02.01883-1,PAULO LOUREIRO FILHO,805.545.047-15" + Environment.NewLine;
            output += ",1999.01.17202-8,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;
            output += ",1981.01.00079-8,OSWALDO REBELLO," + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.ImportINI(prmArquivoINI: "ArqDadosAtendimentoAoAluno-Mascaramento");

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

        [TestMethod()]
        public void TST030_DataImport_ArquivoMultiplos()
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

            Console.ImportINI(prmArquivoINI: "ArqDadosAtendimentoAoAluno-Multiplos");

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

        [TestMethod()]
        public void TST040_DataImport_ArquivoNoTAGs()
        {

            // arrange
            output = "";
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;
            output += ",199901172028,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;
            output += ",198101000798,OSWALDO REBELLO," + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.ImportINI(prmArquivoINI: "ArqDadosAtendimentoAoAluno-NoTAGs");

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }

    }

    [TestClass()]
    public class CAT_70_DataConsoleByReal_Test : DataModelFactory_Test
    {

        public CAT_70_DataConsoleByReal_Test()
        {

            path_out += @"DataConsole\ByReal\";

            Console.Setup(path_ini, path_out);

        }

        [TestMethod()]
        public void TST010_DataReal_ArquivoLancarDebito()
        {

            // arrange
            output = "";
            output += "test_01 ValidarInformacoesDoAlunoPesquisarDebito,matricula, getNomAluno" + Environment.NewLine;
            output += ",2009.01.25014-1,LEONARDO BORGES DE OLIVEIRA QUINTANEIRO" + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.ImportINI(prmArquivoINI: "LancarDebito");

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }


        [TestMethod()]
        public void TST020_DataReal_ArquivoDadosDisciplina()
        {

            // arrange
            output = "";
            output += "test01_PesquisarDisciplinaPorDisciplina,nomDisciplina,nCodigoDisciplina,nInstituicao" + Environment.NewLine;
            output += ",FISIOFARMACOLOGIA,CIS0756,UNIVERSIDADE ESTÁCIO DE SÁ" + Environment.NewLine;

            // act
            ConnectDbOracle();

            Console.ImportINI(prmArquivoINI: "DadosDisciplina");

            // & assert
            VerifyExpectedData(prmData: Console.output);

        }
    }

}
