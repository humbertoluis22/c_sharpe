using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.bytebank.Atendimento
{
    internal class ByteBankAtendimento
    {
    private  List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
{
    new ContaCorrente(333){Saldo = 100,Titular = new Cliente{Cpf = "123", Nome = "humberto" } },
    new ContaCorrente(333){Saldo = 333,Titular = new Cliente{ Cpf = "321", Nome= "guilherme", Profissao = "deve pleno"} },
    new ContaCorrente(999){Saldo = 200, Titular = new Cliente{Cpf = "54321", Nome  = "guilherme" } },
    new ContaCorrente(888){Saldo = 300}
};

        public void  AtendimentoCliente()
        {
            try
            {
                char opcao = '0';
                while (opcao != '6')
                {
                    Console.Clear();
                    Console.Clear();
                    Console.WriteLine("===============================");
                    Console.WriteLine("===       Atendimento       ===");
                    Console.WriteLine("===1 - Cadastrar Conta      ===");
                    Console.WriteLine("===2 - Listar Contas        ===");
                    Console.WriteLine("===3 - Remover Conta        ===");
                    Console.WriteLine("===4 - Ordenar Contas       ===");
                    Console.WriteLine("===5 - Pesquisar Conta      ===");
                    Console.WriteLine("===6 - Sair do Sistema      ===");
                    Console.WriteLine("===============================");
                    Console.WriteLine("\n\n");
                    Console.Write("Digite a opção desejada: ");

                    try
                    {
                        opcao = Console.ReadLine()[0];
                    }
                    catch (Exception e)
                    {

                        throw new ByteBankException(e.Message);
                    }

                    switch (opcao)
                    {
                        case '1':
                            CadastrarConta();
                            break;
                        case '2':
                            ListarConta();
                            break;
                        case '3':
                            RemoverContas();
                            break;
                        case '4':
                            OrdenarContas();
                            break;
                        case '5':
                            PesquisarContas();
                            break;
                        case '6':
                            EncerrandoAplicacao();
                            break;
                        default:
                            Console.WriteLine("Opcao não implementada.");
                            break;


                    }
                }

            }
            catch (ByteBankException excessao)
            {

                Console.WriteLine($"{excessao.Message}");
            }

        }

        private void EncerrandoAplicacao()
        {
            Console.WriteLine(" ..... encerrando aplicação .");
            Console.ReadKey();
            
        }

        void PesquisarContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===    PESQUISAR CONTAS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.Write("Deseja pesquisar por (1) NUMERO DA AGENCIA  ou (2)CPF TITULAR ? ");
            Console.WriteLine();
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Console.Write("DIGITE O NUME DA AGENCIA :");
                        int agencia = int.Parse(Console.ReadLine());
                        var consultaConta = ConsultaPrAgencia(agencia);
                        ExibirListaDeContas(consultaConta);
                        Console.WriteLine(consultaConta.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        Console.Write("DIGITE O CPF DO TITULAR:");
                        string cpf = Console.ReadLine();
                        ContaCorrente consultaCPf = ConsultaPorCpf(cpf);
                        Console.WriteLine(consultaCPf.ToString());
                        Console.ReadKey();
                        break;
                    }
                default:
                    break;
            }
        }

        void ExibirListaDeContas(List<ContaCorrente> consultaConta)
        {
            Console.WriteLine();
            if (consultaConta == null)
            {
                Console.WriteLine("a consulta não retornou dados");
            }
            else
            {
                for (int i = 0; i < consultaConta.Count; i++)
                {
                    Console.WriteLine(consultaConta[i].ToString());
                    Console.WriteLine();
                }
            }
        }

        ContaCorrente ConsultaPorCpf(string? cpf)
        {
            //ContaCorrente conta2 = null;
            //for(int i = 0; i < _listaDeContas.Count;i++)
            //{
            //    if (_listaDeContas[i].Titular.Cpf.Equals(cpf))
            //    {
            //        conta2 = _listaDeContas[i];
            //        break;
            //    }
            //}
            //return conta2;

            return _listaDeContas.Where(conta => conta.Titular.Cpf.Equals(cpf)).FirstOrDefault();
        }

        List<ContaCorrente> ConsultaPrAgencia(int? agencia)
        {
            #region  exemplo de pesquisa antigo desconsiderar
            //ContaCorrente conta = null;
            //for(int i = 0; i < _listaDeContas.Count; i++)
            //{
            //    if (_listaDeContas[i].Numero_agencia.Equals(agencia))
            //    {
            //        conta = _listaDeContas[i];
            //    }
            //}
            //return conta;
            #endregion

            var consulta = (
                from conta in _listaDeContas
                where conta.Numero_agencia == agencia
                select conta
                ).ToList();
            return consulta;
        }



        void OrdenarContas()
        {

            _listaDeContas.Sort();
            Console.WriteLine("a lista foi ordenada");
            Console.ReadKey();
        }

        void RemoverContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===      REMOVER CONTAS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.WriteLine("digite o numero da agencia que deseja remover: ");
            int numeroASerRemovido = int.Parse(Console.ReadLine());
            ContaCorrente conta = null;

            foreach (var item in _listaDeContas)
            {
                if (item.Numero_agencia.Equals(numeroASerRemovido))
                {
                    conta = item;
                }
            }
            if (conta != null)
            {
                _listaDeContas.Remove(conta);

                Console.WriteLine($"a conta  foi removida ....");
            }
            else
            {
                Console.WriteLine($"não foi localizada a conta {conta} para realizar a remoção");
            }
            Console.ReadKey();


        }

       

        void ExibirTituloDaOpção(string titulo)
        {
            int quantidadeDeLetras = titulo.Length;
            string sinalDeIgual = string.Empty.PadLeft(quantidadeDeLetras, '=');
            Console.WriteLine(sinalDeIgual);
            Console.WriteLine(titulo);
            Console.WriteLine($"{sinalDeIgual}\n");

        }

        void CadastrarConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===   CADASTRO DE CONTAS    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.WriteLine("=== Informe dados da conta ===");

          
            Console.Write("informe o numero da agencia: ");
            int numeroDaAgencia = int.Parse(Console.ReadLine());

            ContaCorrente conta = new ContaCorrente(numeroDaAgencia);

            Console.WriteLine($"NUmero da conta [NOVA]: {conta.Conta}");


            Console.Write("informe o saldo inicial da conta: ");
            conta.Saldo = double.Parse(Console.ReadLine());

            Console.Write("informe o nome do titular:");
            conta.Titular.Nome = Console.ReadLine();

            Console.Write("informe o cpf do cliente: ");
            conta.Titular.Cpf = Console.ReadLine();

            Console.Write("informe a profissao do cliente: ");
            conta.Titular.Profissao = Console.ReadLine();

            _listaDeContas.Add(conta);
            Console.WriteLine("conta cadastrada com sucesso  ...\n");

            Console.Write("digite qualquer telcla para voltar ao menu inicial");
            Console.ReadKey();


        }

        void ListarConta()
        {
            ExibirTituloDaOpção("Listar Contas");

            if (_listaDeContas.Count <= 0)
            {
                Console.WriteLine("...LISTA VAZIA");
            }

            foreach (ContaCorrente conta in _listaDeContas)
            {
                //Console.WriteLine($"numero da Agencia: {conta.Numero_agencia}");
                //Console.WriteLine($"saldo da conta: {conta.Saldo}");
                //Console.WriteLine($"nome do titular: {conta.Titular.Nome}");
                //Console.WriteLine($"cpf do titular: {conta.Titular.Cpf}");
                //Console.WriteLine($"profissao do titular: {conta.Titular.Profissao}");


                Console.WriteLine(conta.ToString());
                Console.WriteLine("digete qualquer tecla para voltar ao menu inicial!!");
                Console.ReadKey();
                Console.Clear();

            }
        }


    }
}
