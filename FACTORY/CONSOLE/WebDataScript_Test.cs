using Dooggy.Tests.Factory.lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dooggy.Tests.FACTORY.COMMAND
{
    [TestClass()]
    public class CAT_010_DataCommandByRaw_Test : DataModelFactory_Test
    {

        public CAT_010_DataCommandByRaw_Test()
        {

            path_out += @"DataCommand\ByRaw\";

        }

        [TestMethod()]
        public void TST010_DataCommandByRaw_SomenteRaw()
        {

            // arrange
            output = "";
            output += "CABECALHO" + Environment.NewLine;
            output += "DADOS DA LINHA#1 - VALOR FIXO" + Environment.NewLine;
            output += "DADOS DA LINHA#2 - VALOR FIXO" + Environment.NewLine;
            output += "DADOS DA LINHA#3 - VALOR FIXO" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = GetBlocoRaw_Padrao();
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST020_DataCommandByRaw_TurnON()
        {

            // arrange
            output = "";
            output += "CABECALHO" + Environment.NewLine;
            output += "DADOS DA LINHA#1 - VALOR FIXO" + Environment.NewLine;
            output += "DADOS DA LINHA#2 - VALOR FIXO" + Environment.NewLine;
            output += "DADOS DA LINHA#3 - VALOR FIXO" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = GetBlocoRaw_TurnOnOff(prmTagRaw: "[on]");
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST030_DataCommandByRaw_TurnOFF()
        {

            // arrange
            output = "";

            // act
            ConnectDbOracle();

            bloco = GetBlocoRaw_TurnOnOff(prmTagRaw: "[off]");
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST040_DataCommandByRaw_Raw_LineOFF()
        {

            // arrange
            output = "";
            output += "CABECALHO" + Environment.NewLine;
            output += "DADOS DA LINHA#1 - VALOR FIXO" + Environment.NewLine;
            output += "DADOS DA LINHA#3 - VALOR FIXO" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = bloco = GetBlocoRaw_LineOff(prmTagLine: "  -*: ");
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST050_DataCommandByRaw_RawComVariaveis()
        {


            // arrange
            output = "";
            output += "CABECALHO" + Environment.NewLine;
            output += "DADOS DA LINHA#1 - VALOR 80554504715" + Environment.NewLine;
            output += "DADOS DA LINHA#2 - VALOR 80554504715" + Environment.NewLine;
            output += "DADOS DA LINHA#3 - VALOR 80554504715" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">var: UserCPF = 80554504715" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += GetBlocoRaw_Variable(prmVariavel: "UserCPF");
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
        [TestMethod()]
        public void TST060_DataCommandByRaw_RawComViewItemZero()
        {


            // arrange
            output = "";
            output += "CABECALHO" + Environment.NewLine;
            output += "DADOS DA LINHA#1 - VALOR FIXO" + Environment.NewLine;
            output += "DADOS DA LINHA#2 - VALOR FIXO" + Environment.NewLine;
            output += "DADOS DA LINHA#3 - VALOR FIXO" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">var: AlunoAtivo = '6'" + Environment.NewLine;
            bloco += ">var: AlunoSuspenso = '10'" + Environment.NewLine;
            bloco += ">var: AlunoInativo = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += GetBlocoRaw_Padrao();
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -name: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,getNomeAluno" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
        [TestMethod()]
        public void TST070_DataCommandByRaw_RawComViewItemUnico()
        {


            // arrange
            output = "";
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;
            output += "DADOS DA LINHA#2 - VALOR FIXO" + Environment.NewLine;
            output += "DADOS DA LINHA#3 - VALOR FIXO" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">var: AlunoAtivo = '6'" + Environment.NewLine;
            bloco += ">var: AlunoSuspenso = '10'" + Environment.NewLine;
            bloco += ">var: AlunoInativo = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += GetBlocoRaw_Padrao();
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -name: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,getNomeAluno" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoAtivo)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
        [TestMethod()]
        public void TST080_DataCommandByRaw_RawComViewParcial()
        {


            // arrange
            output = "";
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;
            output += ",199901172028,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;
            output += "DADOS DA LINHA#3 - VALOR FIXO" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">var: AlunoAtivo = '6'" + Environment.NewLine;
            bloco += ">var: AlunoSuspenso = '10'" + Environment.NewLine;
            bloco += ">var: AlunoInativo = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += GetBlocoRaw_Padrao();
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -name: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,getNomeAluno" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoAtivo)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoSuspenso)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
        [TestMethod()]
        public void TST090_DataCommandByRaw_RawComViewTotal()
        {


            // arrange
            output = "";
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;
            output += ",199901172028,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;
            output += ",198101000798,OSWALDO REBELLO," + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">var: AlunoAtivo = '6'" + Environment.NewLine;
            bloco += ">var: AlunoSuspenso = '10'" + Environment.NewLine;
            bloco += ">var: AlunoInativo = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += GetBlocoRaw_Padrao();
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -name: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,getNomeAluno" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoAtivo)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoSuspenso)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoInativo)" + Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
        [TestMethod()]
        public void TST100_DataCommandByRaw_RawComViewAmpliado()
        {


            // arrange
            output = "";
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;
            output += ",199901172028,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;
            output += ",198101000798,OSWALDO REBELLO," + Environment.NewLine;
            output += ",198002005767,JOSE CLAUDIO V DE OLIVEIRA," + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">var: AlunoAtivo = '6'" + Environment.NewLine;
            bloco += ">var: AlunoSuspenso = '10'" + Environment.NewLine;
            bloco += ">var: AlunoInativo = '4'" + Environment.NewLine;
            bloco += ">var: AlunoBolsista = '8'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += GetBlocoRaw_Padrao();
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -name: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,getNomeAluno" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoAtivo)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoSuspenso)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoInativo)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Bolsista" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoBolsista)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST110_DataCommandByRaw_RawComViewAmpliadoSQLNull()
        {


            // arrange
            output = "";
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += "DADOS DA LINHA#1 - VALOR FIXO" + Environment.NewLine;
            output += ",199901172028,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;
            output += "DADOS DA LINHA#3 - VALOR FIXO" + Environment.NewLine;
            output += ",198002005767,JOSE CLAUDIO V DE OLIVEIRA," + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">var: AlunoAtivo = '6'" + Environment.NewLine;
            bloco += ">var: AlunoSuspenso = '10'" + Environment.NewLine;
            bloco += ">var: AlunoInativo = '4'" + Environment.NewLine;
            bloco += ">var: AlunoBolsista = '8'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += GetBlocoRaw_Padrao();
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -name: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,getNomeAluno" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoSuspenso)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Bolsista" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoBolsista)" + Environment.NewLine;
            bloco += ">save[txt]:" + Environment.NewLine;
            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        private string GetBlocoRaw_TurnOnOff(string prmTagRaw) => GetBlocoRaw_Padrao(prmTagRaw, prmTagLine: "", prmVariavel: "");
        private string GetBlocoRaw_LineOff(string prmTagLine) => GetBlocoRaw_Padrao(prmTagRaw: "", prmTagLine, prmVariavel: "");
        private string GetBlocoRaw_Variable(string prmVariavel) => GetBlocoRaw_Padrao(prmTagRaw: "", prmTagLine: "", prmVariavel);

        private string GetBlocoRaw_Padrao() => GetBlocoRaw_TurnOnOff(prmTagRaw: "");
        private string GetBlocoRaw_Padrao(string prmTagRaw, string prmTagLine, string prmVariavel)
        {

            string bloco; string tag_row; string tag_dif; string tag_dat = "   -";

            string txt_final; string txt_padrao = "VALOR FIXO";

            tag_row = ">raw";

            if (prmTagRaw != "")
                tag_row += prmTagRaw;

            if (prmTagLine != "")
                tag_dif = prmTagLine;
            else
                tag_dif = tag_dat;

            if (prmVariavel == "")
                txt_final = txt_padrao;
            else
                txt_final = String.Format("VALOR #({0})", prmVariavel);

            bloco = "";
            bloco += Environment.NewLine;
            bloco += tag_row + ": Dados Atendimento" + Environment.NewLine;
            bloco += tag_dat + ": CABECALHO" + Environment.NewLine;
            bloco += tag_dat + ": DADOS DA LINHA#1 - " + txt_final + Environment.NewLine;
            bloco += tag_dif + ": DADOS DA LINHA#2 - " + txt_final + Environment.NewLine;
            bloco += tag_dat + ": DADOS DA LINHA#3 - " + txt_final + Environment.NewLine;
            bloco += Environment.NewLine;

            return (bloco);

        }

    }

    [TestClass()]
    public class CAT_020_DataCommandByView_Test : DataModelFactory_Test
    {

        public CAT_020_DataCommandByView_Test()
        {

            path_out += @"DataCommand\ByView\";

        }

        [TestMethod()]
        public void TST010_DataCommandByView_RegistroUnico()
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
            bloco += ">save: Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST020_DataCommandByView_ComNotacoes()
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
            bloco += ">save: Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST030_DataCommandByView_RegistrosMultiplos()
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
            bloco += ">save: Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST040_DataCommandByView_MascaramentoFormatacao()
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
            bloco += "  -name: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,getNomeAluno" + Environment.NewLine;
            bloco += "        -mask: cod_matricula = ####.##.#####-#, cpf_responsavel_pgto = ###.###.###-##" + Environment.NewLine;
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
            bloco += ">save[txt]: Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
        [TestMethod()]
        public void TST060_DataCommandByView_MultiplosArquivos()
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
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST070_DataCommandByView_ExecucaoConsecutiva()
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
            bloco += ">save: Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
    }

    [TestClass()]
    public class CAT_030_DataCommandByModel_Test : DataModelFactory_Test
    {

        public CAT_030_DataCommandByModel_Test()
        {

            path_out += @"DataCommand\ByModel\";

        }

        [TestMethod()]
        public void TST010_DataCommandByModel_RegistroUnico()
        {

            // arrange
            output = "";
            output += "198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "   -select: sia.aluno_curso" + Environment.NewLine;
            bloco += "    -input: cod_matricula" + Environment.NewLine;
            bloco += "   -output: nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "   -filter: cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save:" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }


        [TestMethod()]
        public void TST020_DataCommandByModel_ComNotacoes()
        {

            // arrange
            output = "";
            output += "198402018831,PAULO LOUREIRO FILHO,80554504715" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -select: sia.aluno_curso" + Environment.NewLine;
            bloco += "   -output: cod_matricula, nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "   -filter: cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save: Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
        [TestMethod()]
        public void TST030_DataCommandByModel_RegistrosMultiplos()
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
            bloco += "  -select: sia.aluno_curso" + Environment.NewLine;
            bloco += "   -output: cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "     -filter:  cod_situacao_aluno = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += "     -filter:  cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += "     -filter:  cod_situacao_aluno = '10'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save: Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
        [TestMethod()]
        public void TST040_DataCommandByModel_MascaramentoFormatacao()
        {

            // arrange
            output = "test01_ValidarInformacoesDoAluno,matricula,responsavel,cpf" + Environment.NewLine;
            output += ",1981.01.00079-8,OSWALDO REBELLO," + Environment.NewLine;
            output += ",1984.02.01883-1,PAULO LOUREIRO FILHO,805.545.047-15" + Environment.NewLine;
            output += ",1999.01.17202-8,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -name: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "     -select: sia.aluno_curso" + Environment.NewLine;
            bloco += "     -output: matricula[cod_matricula:####.##.#####-#], responsavel[nom_responsavel_pgto], cpf[cpf_responsavel_pgto:###.###.###-##]" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "     -filter:  cod_situacao_aluno = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += "     -filter:  cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += "     -filter:  cod_situacao_aluno = '10'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST050_DataCommandByModel_MultiplasTabelas()
        {

            // arrange
            output = "";
            output += "ReconhecimentoPorInstituicao,nInstituicao,nCampusResultado,nomCurso,nAto" + Environment.NewLine;
            output += ",CENTRO UNIVERSITÁRIO TOLEDO WYDEN,ARAÇATUBA - UNITOLEDO,CURSO MIGRACAO,Autorização" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: AtosRegulatorios" + Environment.NewLine;
            bloco += "  -name: ReconhecimentoPorInstituicao" + Environment.NewLine;
            bloco += "     -select: sia.aluno_curso ab, sia.aluno ac, sia.curso ad, sia.campus ae, sia.LIVRO_REGISTRO_DIPLOMA af, sia.instituicao_ensino ag" + Environment.NewLine;
            bloco += "      -links: ad.COD_CURSO = ab.COD_CURSO_ATUAL and ae.COD_CAMPUS = ab.COD_CAMPUS_ATUAL and ag.cod_instituicao = ae.cod_instituicao and af.CPF_ALUNO = ac.CPF_ALUNO" + Environment.NewLine;
            bloco += "     -output: nInstituicao[ag.NOM_INSTITUICAO],nCampusResultado[ae.NOM_CAMPUS]" + Environment.NewLine;
            bloco += "     -output: nomCurso[ad.NOM_CURSO],nAto[af.TXT_PORT_DOU_AUTORIZACAO:X(11)]" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "     -filter:  cod_situacao_aluno = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: AtosRegulatorios" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
        [TestMethod()]
        public void TST060_DataCommandByModel_MultiplosArquivos()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno,cpf" + Environment.NewLine;
            output += ",1981.01.00079-8,OSWALDO REBELLO," + Environment.NewLine;
            output += ",1984.02.01883-1,PAULO LOUREIRO FILHO,805.545.047-15" + Environment.NewLine;
            output += ",1999.01.17202-8,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "  -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "    -select: seg.usuario" + Environment.NewLine;
            bloco += "     -input: login[cod_usuario], senha" + Environment.NewLine;
            bloco += "    -output: usuarioLogado[nom_usuario]" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += "      -enter:  login = '1016283'" + Environment.NewLine;
            bloco += "      -enter:  senha = '1234as'" + Environment.NewLine;
            bloco += "     -filter:  cod_usuario = #(login)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela ALUNO" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -name: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "     -select: sia.aluno_curso" + Environment.NewLine;
            bloco += "      -input: matricula[cod_matricula:####.##.#####-#]" + Environment.NewLine;
            bloco += "     -output: getNomeAluno[nom_responsavel_pgto]" + Environment.NewLine;
            bloco += "     -output: cpf[cpf_responsavel_pgto:000.###.###-##]" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "     -filter:  cod_situacao_aluno = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += "     -filter:  cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += "     -filter:  cod_situacao_aluno = '10'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST070_DataCommandByModel_ExecucaoConsecutiva()
        {

            // arrange
            output = "";
            output += "testLoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;
            output += "test01_ValidarInformacoesDoAluno,matricula,getNomeAluno,cpf" + Environment.NewLine;
            output += ",1981.01.00079-8,OSWALDO REBELLO," + Environment.NewLine;
            output += ",1984.02.01883-1,PAULO LOUREIRO FILHO,805.545.047-15" + Environment.NewLine;
            output += ",1999.01.17202-8,PAULA AMORIM GOULART FERREIRA," + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "  -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "    -select: seg.usuario" + Environment.NewLine;
            bloco += "     -input: login[cod_usuario], senha" + Environment.NewLine;
            bloco += "    -output: usuarioLogado[nom_usuario]" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += "      -enter:  login = '1016283'" + Environment.NewLine;
            bloco += "      -enter:  senha = '1234as'" + Environment.NewLine;
            bloco += "     -filter:  cod_usuario = #(login)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela ALUNO" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "  -name: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "     -select: sia.aluno_curso" + Environment.NewLine;
            bloco += "      -input: matricula[cod_matricula:####.##.#####-#]" + Environment.NewLine;
            bloco += "     -output: getNomeAluno[nom_responsavel_pgto]" + Environment.NewLine;
            bloco += "     -output: cpf[cpf_responsavel_pgto:000.###.###-##]" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "     -filter:  cod_situacao_aluno = '4'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += "     -filter:  cod_situacao_aluno = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += "     -filter:  cod_situacao_aluno = '10'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

    }

    [TestClass()]
    public class CAT_040_DataCommandBySuper_Test : DataModelFactory_Test
    {

        public CAT_040_DataCommandBySuper_Test()
        {

            path_out += @"DataCommand\BySuper\";

        }
        [TestMethod()]
        public void TST010_DataCommandBySuper_FlowFilters()
        {

            // arrange
            output = "";
            output += "ValidarCarneAluno,MesCompetencia,TipoCancelamento,Motivo,matricula,aluno" + Environment.NewLine;
            output += ",062021,DILUIÇÃO DE MENSALIDADES - DIS,Teste,201508930091,HILARIO GIOVANE TRUCI" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: CarnesAlunos" + Environment.NewLine;
            bloco += "  -name: ValidarCarneAluno" + Environment.NewLine;
            bloco += "  -select: sia.carne ca, sur.cobranca co, sia.aluno_curso ac, sia.aluno al, sia.tipo_cancelamento_carne tc" + Environment.NewLine;
            bloco += "  -select: sia.situacao_periodo sp, sia.aluno_periodo ap, sia.periodo_academico pa" + Environment.NewLine;
            bloco += "   -input: MesCompetencia, TipoCancelamento[tc.txt_tipo_cancelamento_carne], Motivo" + Environment.NewLine;
            bloco += "  -output:  matricula[ac.cod_matricula], aluno[al.NOM_ALUNO]" + Environment.NewLine;
            bloco += "   -links:  ca.NUM_SEQ_COBRANCA = co.NUM_SEQ_COBRANCA" + Environment.NewLine;
            bloco += "   -links:  ca.NUM_SEQ_ALUNO_CURSO = ac.NUM_SEQ_ALUNO_CURSO and ac.NUM_SEQ_ALUNO = al.NUM_SEQ_ALUNO" + Environment.NewLine;
            bloco += "   -links:  ap.num_seq_aluno_curso = ac.num_seq_aluno_curso" + Environment.NewLine;
            bloco += "   -links:  ac.num_seq_periodo_academico = pa.num_seq_periodo_academico and sp.cod_situacao_periodo = ap.cod_situacao_periodo" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "      -enter: MesCompetencia = '$date(D+0:mmaaaa)'" + Environment.NewLine;
            bloco += "      -enter: Motivo = 'Teste'" + Environment.NewLine;
            bloco += "     -filter: ac.COD_SITUACAO_ALUNO = '1' and sp.cod_situacao_periodo = '2'" + Environment.NewLine;
            bloco += "     -filter: ca.dt_cancelamento is null and ca.dt_baixa is null" + Environment.NewLine;
            bloco += "     -filter: ca.DT_MES_ANO_COMPETENCIA = '$date(D=1:dd/mm/aa)'" + Environment.NewLine;
            bloco += "     -filter: tc.cod_tipo_cancelamento_carne = 95" + Environment.NewLine;
            bloco += "     -filter: NOT EXISTS (select xca.txt_nosso_numero from sia.carne xca, sia.aluno_curso xad where xad.cod_matricula = ac.cod_matricula" + Environment.NewLine;
            bloco += "     -filter: xca.NUM_SEQ_ALUNO_curso = xad.NUM_SEQ_ALUNO_curso" + Environment.NewLine;
            bloco += "     -filter: xca.dt_cancelamento is null and xca.dt_baixa is null" + Environment.NewLine;
            bloco += "     -filter: xca.DT_MES_ANO_COMPETENCIA > '$date(D=1:dd/mm/aa)')" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
        [TestMethod()]
        public void TST020_DataCommandBySuper_FlowIndex()
        {

            // arrange
            output = "";
            output += "ValidarCarneAluno,MesCompetencia,TipoCancelamento,Motivo,matricula,aluno" + Environment.NewLine;
            output += ",062021,DILUIÇÃO DE MENSALIDADES - DIS,Teste,201512709697,LEANDRO SANT ANNA MARQUES" + Environment.NewLine;
            output += ",062021,DILUIÇÃO DE MENSALIDADES - DIS,Teste,201501594575,TIAGO DE OLIVEIRA DA SILVA" + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">view: CarnesAlunos" + Environment.NewLine;
            bloco += "  -name: ValidarCarneAluno" + Environment.NewLine;
            bloco += "  -select: sia.carne ca, sur.cobranca co, sia.aluno_curso ac, sia.aluno al, sia.tipo_cancelamento_carne tc" + Environment.NewLine;
            bloco += "  -select: sia.situacao_periodo sp, sia.aluno_periodo ap, sia.periodo_academico pa" + Environment.NewLine;
            bloco += "   -input: MesCompetencia, TipoCancelamento[tc.txt_tipo_cancelamento_carne], Motivo" + Environment.NewLine;
            bloco += "  -output:  matricula[ac.cod_matricula], aluno[al.NOM_ALUNO]" + Environment.NewLine;
            bloco += "   -links:  ca.NUM_SEQ_COBRANCA = co.NUM_SEQ_COBRANCA" + Environment.NewLine;
            bloco += "   -links:  ca.NUM_SEQ_ALUNO_CURSO = ac.NUM_SEQ_ALUNO_CURSO and ac.NUM_SEQ_ALUNO = al.NUM_SEQ_ALUNO" + Environment.NewLine;
            bloco += "   -links:  ap.num_seq_aluno_curso = ac.num_seq_aluno_curso" + Environment.NewLine;
            bloco += "   -links:  ac.num_seq_periodo_academico = pa.num_seq_periodo_academico and sp.cod_situacao_periodo = ap.cod_situacao_periodo" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "      -enter: MesCompetencia = '$date(D+0:mmaaaa)'" + Environment.NewLine;
            bloco += "      -enter: Motivo = 'Teste'" + Environment.NewLine;
            bloco += "     -filter: ac.COD_SITUACAO_ALUNO = '1' and sp.cod_situacao_periodo = '2'" + Environment.NewLine;
            bloco += "     -filter: ca.dt_cancelamento is null and ca.dt_baixa is null" + Environment.NewLine;
            bloco += "     -filter: ca.DT_MES_ANO_COMPETENCIA = '$date(D=1:dd/mm/aa)'" + Environment.NewLine;
            bloco += "     -filter: tc.cod_tipo_cancelamento_carne = 95" + Environment.NewLine;
            bloco += "     -filter: NOT EXISTS (select xca.txt_nosso_numero from sia.carne xca, sia.aluno_curso xad where xad.cod_matricula = ac.cod_matricula" + Environment.NewLine;
            bloco += "     -filter: xca.NUM_SEQ_ALUNO_curso = xad.NUM_SEQ_ALUNO_curso" + Environment.NewLine;
            bloco += "     -filter: xca.dt_cancelamento is null and xca.dt_baixa is null" + Environment.NewLine;
            bloco += "     -filter: xca.DT_MES_ANO_COMPETENCIA > '$date(D=1:dd/mm/aa)')" + Environment.NewLine;
            bloco += "      -index: 1" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += "      -enter: MesCompetencia = '$date(D+0:mmaaaa)'" + Environment.NewLine;
            bloco += "      -enter: Motivo = 'Teste'" + Environment.NewLine;
            bloco += "     -filter: ac.COD_SITUACAO_ALUNO = '1' and sp.cod_situacao_periodo = '2'" + Environment.NewLine;
            bloco += "     -filter: ca.dt_cancelamento is null and ca.dt_baixa is null" + Environment.NewLine;
            bloco += "     -filter: ca.DT_MES_ANO_COMPETENCIA = '$date(D=1:dd/mm/aa)'" + Environment.NewLine;
            bloco += "     -filter: tc.cod_tipo_cancelamento_carne = 95" + Environment.NewLine;
            bloco += "     -filter: NOT EXISTS (select xca.txt_nosso_numero from sia.carne xca, sia.aluno_curso xad where xad.cod_matricula = ac.cod_matricula" + Environment.NewLine;
            bloco += "     -filter: xca.NUM_SEQ_ALUNO_curso = xad.NUM_SEQ_ALUNO_curso" + Environment.NewLine;
            bloco += "     -filter: xca.dt_cancelamento is null and xca.dt_baixa is null" + Environment.NewLine;
            bloco += "     -filter: xca.DT_MES_ANO_COMPETENCIA > '$date(D=1:dd/mm/aa)')" + Environment.NewLine; 
            bloco += "      -index: 2" + Environment.NewLine;
            bloco += Environment.NewLine; bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
    }

        [TestClass()]
    public class CAT_050_DataCommandByVariable_Test : DataModelFactory_Test
    {
        public CAT_050_DataCommandByVariable_Test()
        {

            path_out += @"DataCommand\ByVariable\";

        }

        [TestMethod()]
        public void TST010_DataExtensionByVariable_VariavelSimples()
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
            bloco += "  -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -output: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, '1234as' as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = #(UserID)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST020_DataExtensionByVariable_VariavelValorVazio()
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
            bloco += "  -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -output: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, #(UserPass) as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = #(UserID)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST030_DataExtensionByVariable_VariavelValorEspacos()
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
            bloco += "  -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -output: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, #(UserPass) as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = #(UserID)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST040_DataExtensionByVariable_VariavelTagComEspacos()
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
            bloco += ">var:   UserID   =    '1016283'   " + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "  -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -output: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, '1234as' as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = #(   UserID   )" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST050_DataExtensionByVariable_VariavelNaoEncontrada()
        {

            // arrange
            output = "";
            output += "[ DAT] act# -db[SIA] -status: CONECTADO" + Environment.NewLine;
            output += "[ SET] act# -view[Login] -itens: 1" + Environment.NewLine;
            output += "[ERRO] Variável não encontrada ... -var: UserxID -cmd: SELECT cod_usuario, '1234as' as senha, nom_usuario FROM seg.usuario WHERE cod_usuario = #(UserxID)" + Environment.NewLine;
            output += "[ERRO] SQL falhou ... -error: [ORA-00936: expressão não encontrada] -db[SIA] -sql: SELECT cod_usuario, '1234as' as senha, nom_usuario FROM seg.usuario WHERE cod_usuario =" + Environment.NewLine;
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
            bloco += "        WHERE cod_usuario = #(UserxID)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.Log.txt);

        }

        [TestMethod()]
        public void TST060_DataExtensionByVariable_VariaveisMultiplas()
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
            bloco += "  -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -output: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, #(UserPass) as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = #(UserID)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela ALUNO" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "        -name: test01_ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,getNomeAluno" + Environment.NewLine;
            bloco += "        -mask: cod_matricula = ####.##.#####-#, cpf_responsavel_pgto = ###.###.###-##" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoNovo)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoReprovado)" + Environment.NewLine; bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoFormado)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }


    }

    [TestClass()]
    public class CAT_060_DataCommandByBreak_Test : DataModelFactory_Test
    {
        public CAT_060_DataCommandByBreak_Test()
        {

            path_out += @"DataCommand\ByVariable\";

        }

        [TestMethod()]
        public void TST010_DataExtensionByBreak_BreakBetweenViews()
        {

            // arrange
            output = "";
            output += "LoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;

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
            bloco += "  -name: LoginAdmValido" + Environment.NewLine;
            bloco += "      -output: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, #(UserPass) as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = #(UserID)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">break:" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela ALUNO" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "        -name: ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,getNomeAluno" + Environment.NewLine;
            bloco += "        -mask: cod_matricula = ####.##.#####-#, cpf_responsavel_pgto = ###.###.###-##" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoNovo)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoReprovado)" + Environment.NewLine; bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoFormado)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST020_DataExtensionByBreak_BreakBetweenFlows()
        {

            // arrange
            output = "";
            output += "LoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;
            output += "ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",1981.01.00079-8,OSWALDO REBELLO," + Environment.NewLine;

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
            bloco += "  -name: LoginAdmValido" + Environment.NewLine;
            bloco += "      -output: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, #(UserPass) as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = #(UserID)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela ALUNO" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "        -name: ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,getNomeAluno" + Environment.NewLine;
            bloco += "        -mask: cod_matricula = ####.##.#####-#, cpf_responsavel_pgto = ###.###.###-##" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoNovo)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">break:" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoReprovado)" + Environment.NewLine; bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoFormado)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST030_DataExtensionByBreak_BreakAllScript()
        {

            // arrange
            output = "";
            output += Environment.NewLine;

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
            bloco += ">break:" + Environment.NewLine;
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
            bloco += "  -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -output: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, #(UserPass) as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = #(UserID)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela ALUNO" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "        -name: ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,getNomeAluno" + Environment.NewLine;
            bloco += "        -mask: cod_matricula = ####.##.#####-#, cpf_responsavel_pgto = ###.###.###-##" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoNovo)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoReprovado)" + Environment.NewLine; bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoFormado)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST040_DataExtensionByBreak_BreakAreaDefined()
        {

            // arrange
            output = "";
            output += "ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
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
            bloco += ">break:" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela LOGIN" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "  -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -output: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, #(UserPass) as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = #(UserID)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">break:" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela ALUNO" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">var: AlunoNovo = '4'" + Environment.NewLine;
            bloco += ">var: AlunoFormado = '10'" + Environment.NewLine;
            bloco += ">var: AlunoReprovado = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "        -name: ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,getNomeAluno" + Environment.NewLine;
            bloco += "        -mask: cod_matricula = ####.##.#####-#, cpf_responsavel_pgto = ###.###.###-##" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoNovo)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoReprovado)" + Environment.NewLine; bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoFormado)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST050_DataExtensionByBreak_BreakOnOff()
        {

            // arrange
            output = "";
            output += "LoginAdmValido,login,senha,usuarioLogado" + Environment.NewLine;
            output += ",1016283,1234as,MARLI LOPES OGAWA DE FIGUEIREDO" + Environment.NewLine;
            output += "ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",1981.01.00079-8,OSWALDO REBELLO," + Environment.NewLine;
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
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "  -name: LoginAdmValido" + Environment.NewLine;
            bloco += "      -output: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, #(UserPass) as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = #(UserID)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela ALUNO" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">var: AlunoNovo = '4'" + Environment.NewLine;
            bloco += ">var: AlunoFormado = '10'" + Environment.NewLine;
            bloco += ">var: AlunoReprovado = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "        -name: ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,getNomeAluno" + Environment.NewLine;
            bloco += "        -mask: cod_matricula = ####.##.#####-#, cpf_responsavel_pgto = ###.###.###-##" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoNovo)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">break[on]:" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoReprovado)" + Environment.NewLine; 
            bloco += Environment.NewLine;
            bloco += ">break[off]:" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoFormado)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }

        [TestMethod()]
        public void TST060_DataExtensionByBreak_BreakOnOffOn()
        {

            // arrange
            output = "";
            output += "ValidarInformacoesDoAluno,matricula,getNomeAluno" + Environment.NewLine;
            output += ",1981.01.00079-8,OSWALDO REBELLO," + Environment.NewLine;

            // act
            ConnectDbOracle();

            bloco = "";
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Variáveis" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">break[on]:" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">var: UserID = '1016283'" + Environment.NewLine;
            bloco += ">var: UserPass = '1234as'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela LOGIN" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Login" + Environment.NewLine;
            bloco += "  -name: testLoginAdmValido" + Environment.NewLine;
            bloco += "      -output: login,senha,usuarioLogado" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Marli" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_usuario, #(UserPass) as senha, nom_usuario" + Environment.NewLine;
            bloco += "        FROM seg.usuario" + Environment.NewLine;
            bloco += "        WHERE cod_usuario = #(UserID)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">break[off]:" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += ">> Tabela ALUNO" + Environment.NewLine;
            bloco += ">>" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">var: AlunoNovo = '4'" + Environment.NewLine;
            bloco += ">var: AlunoFormado = '10'" + Environment.NewLine;
            bloco += ">var: AlunoReprovado = '6'" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">view: Aluno" + Environment.NewLine;
            bloco += "        -name: ValidarInformacoesDoAluno" + Environment.NewLine;
            bloco += "      -output: matricula,getNomeAluno" + Environment.NewLine;
            bloco += "        -mask: cod_matricula = ####.##.#####-#, cpf_responsavel_pgto = ###.###.###-##" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Padrao" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoNovo)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">break[on]:" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">item: Errado" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoReprovado)" + Environment.NewLine; bloco += Environment.NewLine;
            bloco += ">item: Novato" + Environment.NewLine;
            bloco += " -sql:  SELECT cod_matricula , nom_responsavel_pgto, cpf_responsavel_pgto" + Environment.NewLine;
            bloco += "         FROM sia.aluno_curso" + Environment.NewLine;
            bloco += "         WHERE cod_situacao_aluno = #(AlunoFormado)" + Environment.NewLine;
            bloco += Environment.NewLine;
            bloco += ">save[txt]: Login + Aluno" + Environment.NewLine;

            Console.Play(prmCode: bloco);

            // & assert
            VerifyExpectedData(prmData: Console.Result.data);

        }
    }


}
