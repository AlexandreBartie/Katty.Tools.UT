using BlueRocket.CORE.Tests.Factory.lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueRocket.CORE.Tests.FACTORY.COMMAND
{
    [TestClass()]
    public class CAT_010_CommandTag_Test : UTC_BlueRocketCORE
    {

        [TestMethod()]
        public void TST010_CommandTag_DefinicaoUnica()
        {

            // arrange
            input(">>");
            input(">> TAGS");
            input(">>");
            input();
            input(">tags:");
            input("   -: categoria = FUNCIONAL");
            input("   -:   impacto = ALTO");
            input("   -:      tipo = REGRESSIVO");
            input("   -:  analista = ALEXANDRE");
            input("   -:  situacao = PRONTO");
            input();
            input(">loc: UserID = '1016283'");
            input();
            input(">view: Login");
            input("  -name: testLoginAdmValido");
            input("      -output: login,senha,usuarioLogado");
            input("");
            input(">item: Marli");
            input(" -sql:  SELECT cod_usuario, '$date(D+0:DDMMAAAA)' as senha, nom_usuario");
            input("        FROM seg.usuario");
            input("        WHERE cod_usuario = #(UserID)");
            input();
            input(">save[txt]");

            output("[ categoria] 'FUNCIONAL'");
            output("[   impacto] 'ALTO'");
            output("[      tipo] 'REGRESSIVO'");
            output("[  analista] 'ALEXANDRE'");
            output("[  situacao] 'PRONTO'");

            // act

            Play(prmCode: inputTXT);

            // & assert
            AssertTest(prmResult: Script.Tags.log);

        }

        [TestMethod()]
        public void TST020_CommandTag_DadosInexistentes()
        {

            // arrange
            input(">>");
            input(">> TAGS");
            input(">>");
            input();
            input(">tags:");
            input("   -: categoria = FUNCIONAL");
            input("   -:     teste = ALTO");
            input("   -:      tipo = REGRESSIVO");
            input("   -:  analista = NINGUEM");
            input("   -:  situacao = PRONTO");
            input();
            input(">loc: UserID = '1016283'");
            input();
            input(">view: Login");
            input("  -name: testLoginAdmValido");
            input("      -output: login,senha,usuarioLogado");
            input("");
            input(">item: Marli");
            input(" -sql:  SELECT cod_usuario, '$date(D+0:DDMMAAAA)' as senha, nom_usuario");
            input("        FROM seg.usuario");
            input("        WHERE cod_usuario = #(UserID)");
            input();
            input(">save[txt]");

            output("[ categoria] 'FUNCIONAL'");
            output("[   impacto] ''");
            output("[      tipo] 'REGRESSIVO'");
            output("[  analista] ''");
            output("[  situacao] 'PRONTO'");

            // act

            Play(prmCode: inputTXT);

            // & assert
            AssertTest(prmResult: Script.Tags.log);

        }

        [TestMethod()]
        public void TST030_CommandTag_DadosSobreposicao()
        {

            // arrange
            input(">>");
            input(">> TAGS");
            input(">>");
            input();
            input(">tags:");
            input("   -: categoria = FUNCIONAL");
            input("   -:   impacto = ALTO");
            input("   -:      tipo = REGRESSIVO");
            input("   -:  analista = ALEXANDRE");
            input("   -:  situacao = PRONTO");
            input("   -:  analista = VITOR");
            input("   -:   impacto = MEDIO");
            input();
            input(">loc: UserID = '1016283'");
            input();
            input(">view: Login");
            input("  -name: testLoginAdmValido");
            input("      -output: login,senha,usuarioLogado");
            input("");
            input(">item: Marli");
            input(" -sql:  SELECT cod_usuario, '$date(D+0:DDMMAAAA)' as senha, nom_usuario");
            input("        FROM seg.usuario");
            input("        WHERE cod_usuario = #(UserID)");
            input();
            input(">save[txt]");

            output("[ categoria] 'FUNCIONAL'");
            output("[   impacto] 'MEDIO'");
            output("[      tipo] 'REGRESSIVO'");
            output("[  analista] 'VITOR'");
            output("[  situacao] 'PRONTO'");

            // act

            Play(prmCode: inputTXT);

            // & assert
            AssertTest(prmResult: Script.Tags.log); ;

        }

    }

    [TestClass()]
    public class CAT_020_CommandDB_Test : UTC_BlueRocketCORE
    {

        [TestMethod()]
        public void TST010_CommandDB_ManterFormatacaoPadrao()
        {

            // arrange

            input(">view: Login");
            input("  -name: test01_RealizarBaixaOrigemBancoDepositoChequesCustodiados");
            input("      -input: nossoNumero");
            input("      -output: nossoNumeroResultado,getMatNomAluno,getValorOriginal,origemCredito,banco,dataCredito,valorCredito");
            input("");
            input(">item: Marli");
            input("    -sql: select co.txt_nosso_numero, co.txt_nosso_numero, ac.cod_matricula || '-' || al.nom_aluno, co.val_a_pagar, 'Banco', '341 - BANCO ITAÚ S.A', $date(D=12:DDMMAAAA), co.val_a_pagar");
            input("        from sia.aluno al, sia.carne ca, sia.aluno_curso ac, sur.cobranca co");
            input("        where al.num_seq_aluno = ac.num_seq_aluno and ac.num_seq_aluno_curso = ca.num_seq_aluno_curso and ca.num_seq_cobranca = co.num_seq_cobranca");
            input("        and co.dt_competencia = '$date(D=1:DD/MM/AA)'");
            input("        and co.val_a_pagar >= '100,00' and co.val_a_pagar < '1000,00'");
            input("        and co.dt_cancelamento is null and ca.dt_baixa is null");
            input();
            input(">save[txt]");

            output(@"test01_RealizarBaixaOrigemBancoDepositoChequesCustodiados,nossoNumero,nossoNumeroResultado,getMatNomAluno,getValorOriginal,origemCredito,banco,dataCredito,valorCredito");
            output(@",2022459129785,2022459129785,201608255409-RAFAELA RIQUESMA SILVA DO VALE,""355,04"",Banco,341 - BANCO ITAÚ S.A,12052022,""355,04""");
            output("");

            // act

            Play(prmCode: inputTXT);

            // & assert
            AssertTest(prmResult: Script.Result.data);

        }

        [TestMethod()]
        public void TST020_CommandDB_ForcarFormatacaoErrada()
        {

            // arrange

            input(">db: Alter Session set NLS_NUMERIC_CHARACTERS = '.,'");
            input();
            input(">view: Login");
            input("  -name: test01_RealizarBaixaOrigemBancoDepositoChequesCustodiados");
            input("      -input: nossoNumero");
            input("      -output: nossoNumeroResultado,getMatNomAluno,getValorOriginal,origemCredito,banco,dataCredito,valorCredito");
            input("");
            input(">item: Marli");
            input("    -sql: select co.txt_nosso_numero, co.txt_nosso_numero, ac.cod_matricula || '-' || al.nom_aluno, co.val_a_pagar, 'Banco', '341 - BANCO ITAÚ S.A', $date(D=12:DDMMAAAA), co.val_a_pagar");
            input("        from sia.aluno al, sia.carne ca, sia.aluno_curso ac, sur.cobranca co");
            input("        where al.num_seq_aluno = ac.num_seq_aluno and ac.num_seq_aluno_curso = ca.num_seq_aluno_curso and ca.num_seq_cobranca = co.num_seq_cobranca");
            input("        and co.dt_competencia = '$date(D=1:DD/MM/AA)'");
            input("        and co.val_a_pagar >= '100,00' and co.val_a_pagar < '1000,00'");
            input("        and co.dt_cancelamento is null and ca.dt_baixa is null");
            input();
            input(">save[txt]");

            output(@"test01_RealizarBaixaOrigemBancoDepositoChequesCustodiados,nossoNumero,nossoNumeroResultado,getMatNomAluno,getValorOriginal,origemCredito,banco,dataCredito,valorCredito");
            output("");
            output("");

            // act

            Play(prmCode: inputTXT);

            // & assert
            AssertTest(prmResult: Script.Result.data);

        }

    }
}
