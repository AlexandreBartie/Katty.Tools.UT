using Dooggy.Factory;
using Dooggy.Factory.Console;
using Dooggy.Factory.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dooggy.Tests.Factory.lib
{

    public class DataFactory_Test : DataModelFactory_Test
    { }
    public class DataModelFactory_Test : DataViewFactory_Test
    {

        public string GetComandoSQL_Login(int prmUsuario)
        {

            string regra; string sql;

            regra = String.Format("cod_usuario = '{0}'", prmUsuario);

            sql = "";
            sql += "SELECT cod_usuario as login, '1234as' as senha, nom_usuario as usuarioLogado";
            sql += " FROM seg.usuario";
            sql += " WHERE " + regra;


            return (sql);

        }

        public string GetComandoSQL_Aluno(int prmSituacao) => GetComandoSQL_Aluno(prmSituacao, prmCPF: true);
        public string GetComandoSQL_Aluno(int prmSituacao, bool prmCPF)
        {

            string regraCPF; string regra; string sql;

            if (prmCPF) regraCPF = "is not"; else regraCPF = "is";

            regra = String.Format("cod_situacao_aluno = {0} and cpf_responsavel_pgto {1} NULL", prmSituacao, regraCPF);
            
            
            sql = "";
            sql += "SELECT cod_matricula as matricula, nom_responsavel_pgto as responsavel, cpf_responsavel_pgto as cpf";
            sql += " FROM sia.aluno_curso";
            sql += " WHERE " + regra;


            return(sql);

        }

        public string GetTagCabecalho(string prmTag) => prmTag + "|ListaResponsaveis|" + "Matricula,NomeResponsavel,CPF";

        public string GetModelAluno() => @"{'#TABELAS#':'sia.aluno_curso','#CAMPOS#':'cod_matricula as matricula, nom_responsavel_pgto as nome, cpf_responsavel_pgto as cpf '}";

        public string GetTabelasAluno() => @"{'#TABELAS#':'sia.aluno_curso'}";
        public string GetCamposAluno() => @"{'#CAMPOS#':'cod_matricula as matricula, nom_responsavel_pgto as nome, cpf_responsavel_pgto as cpf '}";

        public string GetMaskAluno() => "{ 'matricula': '####.##.#####-#', 'cpf': '###.###.###-##' }";

        public string GetRegrasAluno(string prmSituacao) => GetRegrasAluno(prmSituacao, prmCPF: true);

        public string GetRegrasAluno(string prmSituacao, bool prmCPF)
        {

            string regraCPF; string regra;

            if (prmCPF) regraCPF = "is not"; else regraCPF = "is";

            regra = String.Format("'#CONDICAO#': 'cod_situacao_aluno = {0} and cpf_responsavel_pgto {1} NULL'", prmSituacao, regraCPF);

            return ("{ " + regra + " }");

        }

        public string GetModelLogin() => @"{'#TABELAS#':'seg.usuario','#CAMPOS#':'cod_usuario as login, <##>1234as<##> as senha, nom_usuario as usuarioLogado '}";

        public string GetRegrasLogin(string prmKeyUsuario)
        {

            string regra;

            regra = String.Format(@"'#CONDICAO#': 'cod_usuario = <##>{0}<##>'", prmKeyUsuario);

            return ("{ " + regra + " }");

        }

        public string GetName(Object prmOrigem) => (prmOrigem.GetType().Name);

        public string GetPath() => (@"C:\Users\alexa\OneDrive\Área de Trabalho\MassaTeste\");

    }

    public class DataViewFactory_Test : DataBasicFactory_Test
    {

        public string GetComandoSQL() => GetComandoSQL(prmSituacao: 6);

        public string GetComandoSQL(int prmSituacao) => GetComandoSQL(prmSituacao, prmUnico: false);

        public string GetComandoSQL(bool prmUnico) => GetComandoSQL(prmSituacao: 6, prmUnico);

        public string GetComandoSQL(int prmSituacao, bool prmUnico) => SQLGenericBuilding(prmSituacao, prmAliasMatricula: "", prmAliasResponsavel: "", prmAliasCPF: "", prmUnico);

        public string GetComandoSQL_Alias() => SQLGenericBuilding(prmSituacao: 6, prmAliasMatricula: "matricula", prmAliasResponsavel: "responsavel", prmAliasCPF: "cpf", prmUnico: true);

        public string SQLGenericBuilding(int prmSituacao, string prmAliasMatricula, string prmAliasResponsavel, string prmAliasCPF, bool prmUnico)
        {

            string alias_A = ""; string alias_B = ""; string alias_C = ""; string numero_cpf = ""; string restricao = "";

            if (prmAliasMatricula != "")
            { alias_A = "as " + prmAliasMatricula; }

            if (prmAliasResponsavel != "")
            { alias_B = "as " + prmAliasResponsavel; }

            if (prmAliasCPF != "")
            { alias_C = ", cpf_responsavel_pgto as " + prmAliasCPF; numero_cpf = "and CPF_RESPONSAVEL_PGTO is not NULL"; }

            if (!prmUnico)
            { restricao = "and ROWNUM = 1"; }

            return (String.Format("SELECT cod_matricula {1}, nom_responsavel_pgto {2} {3} FROM sia.aluno_curso WHERE cod_situacao_aluno = '{0}' {4} {5}", prmSituacao, alias_A, alias_B, alias_C, numero_cpf, restricao));

        }

        public string GetCommandoSQL_PadraoCLI(int prmSituacao)
        {

            string sql = GetComandoSQL(prmSituacao);

            if (xString.IsStringOK(sql))
                return @"{ 'sql': """ + sql + @""" }";

            return ("");

        }

    }

    public class DataBasicFactory_Test : TestDataProject
    {

        public string input;
        public string output;

        public string bloco;

        public string path_ini = @"C:\MassaTestes\POC\Console\INI\";
        public string path_out = @"C:\MassaTestes\POC\Console\OUT\";

        public void ConnectDbOracle() { ConnectDbOracle(prmSenha: "asdfg"); }

        public void ConnectDbOracle(string prmSenha)
        {

            Connect.Oracle.user = "desenvolvedor_sia";
            Connect.Oracle.password = prmSenha;

            Connect.Oracle.host = "10.250.1.35";
            Connect.Oracle.port = "1521";
            Connect.Oracle.service = "branch_1083.prod01.redelocal.oraclevcn.com";

            Connect.Oracle.Add(prmTag: "SIA");

        }
        public void VerifyExpectedData(string prmData)
        {

            // assert
            if (output != prmData)
                Assert.Fail(string.Format("{4}Gerado: <{1}>{4}{0}{4}Esperado:<{3}>{4}{2}{4}", prmData, prmData.Length, output, output.Length, Environment.NewLine));

        }


    }

}
