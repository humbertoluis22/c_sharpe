using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using bytebank_ATENDIMENTO.bytebank.Util;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Channels;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

Console.WriteLine(Guid.NewGuid().ToString().Substring(1,10));
//new ByteBankAtendimento().AtendimentoCliente();


#region exemplos arrays em c#
void TestaArray()
{
    int[] idades = new int[5];
    idades[0] = 30;
    idades[1] = 35;
    idades[2] = 45;
    idades[3] = 37;
    idades[4] = 22;


    Console.WriteLine($"tamanho do array = {idades.Length}");

    int acumlador = 0;
    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"indice{i} = {idade}");

        acumlador += idade;
    }

    int media = acumlador / idades.Length;
    Console.WriteLine($"a media das idades é de = {media}");
}
//TestaArray();


void NovoTeste()
{
    string[] _nomes = { "Humberto luis", "maria de jesus", "guilherme luis", "isabella" };

    for (int i = 0; i < _nomes.Length; i++)
    {
        Console.WriteLine($"o indice {i} é do {_nomes[i]}");
    }
    Console.WriteLine($"tamanho do array {_nomes.Length}");

}

//NovoTeste();

void CalcularMediaDeIdadeDacasa()
{
    int[] idadesDeCasa = new int[4] { 22, 46, 37, 19 };

    int acumuladorDeIdade = 0;
    for (int i = 0; i < idadesDeCasa.Length; i++)
    {
        Console.WriteLine($"o indice {i} armazena a idade {idadesDeCasa[i]}");
        acumuladorDeIdade += idadesDeCasa[i];
    }

    int mediaDeIdade = acumuladorDeIdade / idadesDeCasa.Length;
    Console.WriteLine($"a media de idade da casa é de {mediaDeIdade}");
}
//CalcularMediaDeIdadeDacasa();

void TestaBuscaPalavra()
{
    string[] palavras = new string[5];
    for (int i = 0; i < palavras.Length; i++)
    {
        Console.Write($"digite a {i + 1} palavra: ");
        palavras[i] = Console.ReadLine();
    }

    Console.WriteLine("digite a palavra a ser encontrada: ");
    string busca = Console.ReadLine();

    //if(palavras.Contains(busca))
    //{
    //    Console.WriteLine($"a palavra {busca} foi encontada");
    //}
    //else
    //{
    //    Console.WriteLine($"palavra {busca} não encontrada");
    //}

    int cont = 0;

    //foreach (string palavra in palavras)
    //{

    //    if (palavra.Equals(busca))
    //    {

    //        Console.WriteLine($"a palavra {busca} foi encontrada no indice {cont}");
    //        break;
    //    }
    //    cont++;
    //}


    int loque = 0;
    for (int i = 0; i < palavras.Length; i++)
    {
        Console.WriteLine($"{i} --- {palavras[i]}");
        if (palavras[i].Equals(busca))
        {
            loque = cont;
        }

        cont++;
    }

    Console.WriteLine(palavras[loque]);

}

//TestaBuscaPalavra();


Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);



void TestaMediana(Array array)
{
    if (array.Length == 0 || array == null)
    {
        Console.WriteLine("o array esta vazio");
    }

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;

    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] : (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;
    Console.WriteLine($"com base na amostra  a mediana {mediana}");
}

//TestaMediana(amostra);


void geraTabuada(int numero)
{
    for (int i = 0; i < 11; i++)
    {
        Console.WriteLine($"{numero} x {i} = {numero * i}");
    }

}

void segundoTesteArray()
{
    int[] idades = new int[6];
    idades[0] = 10;
    idades[1] = 22;
    idades[2] = 30;
    idades[3] = 43;
    idades[4] = 60;
    idades[5] = 36;

    int contador = 0;
    for (int i = 0; i < idades.Length; i++)
    {
        Console.WriteLine($"{i} --- {idades[i]}");
        contador += idades[i];
    }

    int media = contador / idades.Length;
    Console.WriteLine($"a media de idade é {media}");
}
//segundoTesteArray();

void testeArrayString()
{
    string[] nomess = new string[4];
    for (int i = 0; i < nomess.Length; i++)
    {
        Console.Write($"digite o {i + 1} nome: ");
        string palavra = Console.ReadLine();
        nomess[i] = palavra;
    }

    Console.Write("digite a palavra a ser encontrada: ");
    string busca = Console.ReadLine();

    int indicePalavra = 0;
    int cont = 1;

    foreach (string nome in nomess)
    {
        if (nome.Equals(busca))
        {
            indicePalavra = cont;
            Console.WriteLine("________________________________________________________");
            Console.WriteLine($"o nome {busca} foi encontrado na posição {indicePalavra}");
            Console.WriteLine("________________________________________________________");
        }

        cont++;

    }

}
//testeArrayString();

Array amostra2 = Array.CreateInstance(typeof(int), 3);
amostra2.SetValue(3, 0);
amostra2.SetValue(6, 1);
amostra2.SetValue(7, 2);

double[] dados = new double[4];
dados[0] = 13.9;
dados[1] = 14.3;
dados[2] = 15.5;
dados[3] = 16.8;



void encontradaMediana(Array array)
{
    if (array.Length == 0 || array == null)
    {
        Console.WriteLine("o array esta vazio não tem como encotrar o meio ");
    }

    int[] arrayOrdenadoo = (int[])array.Clone();
    Array.Sort(arrayOrdenadoo);

    int tamanho = arrayOrdenadoo.Length;
    int meio = tamanho / 2;

    double mediano = (tamanho % 2 != 0) ? arrayOrdenadoo[meio] : arrayOrdenadoo[tamanho] + arrayOrdenadoo[tamanho - 1] / 2;

    Console.WriteLine($"de acordo com os dados a mediana é {mediano}");
}

//encontradaMediana(dados);



Array amostra3 = Array.CreateInstance(typeof(double), 3);
amostra3.SetValue(5.0, 0);
amostra3.SetValue(6.9, 1);
amostra3.SetValue(7.9, 2);


double calcularMediaAmostra(double[] amostra)
{

    double contador = 0;
    double media = 0;

    if (amostra == null || amostra.Length == 0)
    {
        Console.WriteLine("valor da amostra zerado ");
    }


    for (int i = 0; i < amostra.Length; i++)
    {
        contador += amostra[i];
    }
    media = contador / amostra.Length;
    Console.WriteLine(media);
    return media;

}

//calcularMediaAmostra(dados);


void testaArraContaCorrente()
{
    ContaCorrente[] contas = new ContaCorrente[]
    {
        new ContaCorrente(769 ),
        new ContaCorrente(444),
        new ContaCorrente(897)

    };

    for (int i = 0; i < contas.Length; i++)
    {
        ContaCorrente contaAuxiliar = contas[i];
        Console.WriteLine($"{i} --- {contaAuxiliar.Conta}");
    }


}
//testaArraContaCorrente();

void testaArraContaCorrente2()
{
    ListaDeContaCorrente listaDeContas = new ListaDeContaCorrente();
    listaDeContas.Adcionar(new ContaCorrente(1234));
    listaDeContas.Adcionar(new ContaCorrente(4325));
    listaDeContas.Adcionar(new ContaCorrente(9746));
    listaDeContas.Adcionar(new ContaCorrente(23));
    listaDeContas.Adcionar(new ContaCorrente(43));
    ContaCorrente h1berto = new ContaCorrente(666);
    //listaDeContas.Adcionar(h1berto);
    //listaDeContas.ImprimeConta();
    //Console.WriteLine("++++++++++++++++++");
    //listaDeContas.Remover(h1berto);
    //listaDeContas.ImprimeConta();
    Console.WriteLine("****************************");
    for (int i = 0; i < listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = listaDeContas[i];
        Console.WriteLine(conta.Numero_agencia);
    }
}

//testaArraContaCorrente2();

void testaArrayContaCorrente3()
{
    ListaConta conta2 = new ListaConta();
    conta2.Adicionar(new ContaCorrente(234));
    conta2.Adicionar(new ContaCorrente(432));
    conta2.Adicionar(new ContaCorrente(553));
    conta2.Adicionar(new ContaCorrente(553));
    ContaCorrente humberto = new ContaCorrente(777);
    conta2.Adicionar(humberto);
    Console.WriteLine("+++++++++++++++++++++++++");
    for (int i = 0; i < conta2.Tamanho; i++)
    {
        ContaCorrente conta3 = conta2[i];
        Console.WriteLine(conta3.Numero_agencia);

    }
    Console.WriteLine("++++++++++++++++++++++++++++");
    conta2.RemoveConta(humberto);
    conta2.ImprimeConta();

}

//testaArrayContaCorrente3();
#endregion
#region exemplo de classe generica
//exemplo de classe generica

//Generica<int> teste1 = new Generica<int>();
//teste1.Mensagem(10);

//Generica<string> teste2 = new Generica<string>();
//teste2.Mensagem("mensagem");

//public class Generica<T>
//{
//    public void Mensagem(T t)
//    {
//        Console.WriteLine(t);
//    }
//}

#endregion


//List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
//{
//    new ContaCorrente(333){Saldo = 100,Titular = new Cliente{Cpf = "123", Nome = "humberto" } },
//    new ContaCorrente(333){Saldo = 333,Titular = new Cliente{ Cpf = "321", Nome= "guilherme", Profissao = "deve pleno"} },
//    new ContaCorrente(999){Saldo = 200, Titular = new Cliente{Cpf = "54321", Nome  = "guilherme" } },
//    new ContaCorrente(888){Saldo = 300}
//};

//void AtendimentoCliente()
//{
//    try
//    {
//        char opcao = '0';
//        while (opcao != '6')
//        {
//            Console.Clear();
//            Console.Clear();
//            Console.WriteLine("===============================");
//            Console.WriteLine("===       Atendimento       ===");
//            Console.WriteLine("===1 - Cadastrar Conta      ===");
//            Console.WriteLine("===2 - Listar Contas        ===");
//            Console.WriteLine("===3 - Remover Conta        ===");
//            Console.WriteLine("===4 - Ordenar Contas       ===");
//            Console.WriteLine("===5 - Pesquisar Conta      ===");
//            Console.WriteLine("===6 - Sair do Sistema      ===");
//            Console.WriteLine("===============================");
//            Console.WriteLine("\n\n");
//            Console.Write("Digite a opção desejada: ");

//            try
//            {
//                opcao = Console.ReadLine()[0];
//            }
//            catch (Exception e)
//            {

//                throw new ByteBankException(e.Message);
//            }
            
//            switch (opcao)
//            {
//                case '1':
//                    CadastrarConta();
//                    break;
//                case '2':
//                    ListarConta();
//                    break;
//                case '3':
//                    RemoverContas();
//                    break;
//                case '4':
//                    OrdenarContas();
//                    break;
//                case '5':
//                    PesquisarContas();
//                    break;
//                default:
//                    Console.WriteLine("Opcao não implementada.");
//                    break;


//            }
//        }

//    }
//    catch (ByteBankException excessao)
//    {

//        Console.WriteLine($"{excessao.Message}");
//    }

//}

//void PesquisarContas()
//{
//    Console.Clear();
//    Console.WriteLine("===============================");
//    Console.WriteLine("===    PESQUISAR CONTAS     ===");
//    Console.WriteLine("===============================");
//    Console.WriteLine("\n");
//    Console.Write("Deseja pesquisar por (1) NUMERO DA AGENCIA  ou (2)CPF TITULAR ? ");
//    Console.WriteLine();
//    switch (int.Parse(Console.ReadLine()))
//    {
//        case 1:
//            {
//                Console.Write("DIGITE O NUME DA AGENCIA :");
//                int agencia = int.Parse(Console.ReadLine());
//                var consultaConta = ConsultaPrAgencia(agencia);
//                ExibirListaDeContas(consultaConta);
//                Console.WriteLine(consultaConta.ToString());
//                Console.ReadKey();
//                break;
//            }
//        case 2:
//            {
//                Console.Write("DIGITE O CPF DO TITULAR:");
//                string cpf = Console.ReadLine();
//                ContaCorrente consultaCPf = ConsultaPorCpf(cpf);
//                Console.WriteLine(consultaCPf.ToString());
//                Console.ReadKey();
//                break;
//            }
//        default:
//            break;
//    }
//}

//void ExibirListaDeContas(List<ContaCorrente> consultaConta)
//{
//    Console.WriteLine();
//    if (consultaConta == null)
//    {
//        Console.WriteLine("a consulta não retornou dados");
//    }
//    else
//    {
//        for (int i = 0; i < consultaConta.Count; i++)
//        {
//            Console.WriteLine(consultaConta[i].ToString());
//            Console.WriteLine();
//        }
//    }
//}

//ContaCorrente ConsultaPorCpf(string? cpf)
//{
//    //ContaCorrente conta2 = null;
//    //for(int i = 0; i < _listaDeContas.Count;i++)
//    //{
//    //    if (_listaDeContas[i].Titular.Cpf.Equals(cpf))
//    //    {
//    //        conta2 = _listaDeContas[i];
//    //        break;
//    //    }
//    //}
//    //return conta2;

//    return _listaDeContas.Where(conta => conta.Titular.Cpf.Equals(cpf)).FirstOrDefault();
//}

//List<ContaCorrente> ConsultaPrAgencia(int? agencia)
//{
//    #region  exemplo de pesquisa antigo desconsiderar
//    //ContaCorrente conta = null;
//    //for(int i = 0; i < _listaDeContas.Count; i++)
//    //{
//    //    if (_listaDeContas[i].Numero_agencia.Equals(agencia))
//    //    {
//    //        conta = _listaDeContas[i];
//    //    }
//    //}
//    //return conta;
//    #endregion

//    var consulta = (
//        from conta in _listaDeContas
//        where conta.Numero_agencia == agencia
//        select conta
//        ).ToList();
//    return consulta;
//}



//void OrdenarContas()
//{

//        _listaDeContas.Sort();
//        Console.WriteLine("a lista foi ordenada");
//        Console .ReadKey();
//}

//void RemoverContas()
//{
//    Console.Clear();
//    Console.WriteLine("===============================");
//    Console.WriteLine("===      REMOVER CONTAS     ===");
//    Console.WriteLine("===============================");
//    Console.WriteLine("\n");
//    Console.WriteLine("digite o numero da agencia que deseja remover: ");
//    int numeroASerRemovido = int.Parse(Console.ReadLine());
//    ContaCorrente conta = null;

//    foreach(var item in _listaDeContas)
//    {
//        if (item.Numero_agencia.Equals(numeroASerRemovido))
//        {
//            conta = item;
//        }
//    }
//    if (conta != null)
//    {
//        _listaDeContas.Remove(conta);

//        Console.WriteLine($"a conta  foi removida ....");
//    }
//    else
//    {
//        Console.WriteLine($"não foi localizada a conta {conta} para realizar a remoção");
//    }
//    Console.ReadKey();


//}

//AtendimentoCliente();

//void ExibirTituloDaOpção(string titulo)
//{
//    int quantidadeDeLetras = titulo.Length;
//    string sinalDeIgual = string.Empty.PadLeft(quantidadeDeLetras, '=');
//    Console.WriteLine(sinalDeIgual);
//    Console.WriteLine(titulo);
//    Console.WriteLine($"{sinalDeIgual}\n");

//}

//void CadastrarConta()
//{
//    Console.Clear();
//    Console.WriteLine("===============================");
//    Console.WriteLine("===   CADASTRO DE CONTAS    ===");
//    Console.WriteLine("===============================");
//    Console.WriteLine("\n");
//    Console.WriteLine("=== Informe dados da conta ===");

//    Console.Write("informe o numero da agencia: ");
//    int numeroDaAgencia = int.Parse(Console.ReadLine());

//    ContaCorrente conta = new ContaCorrente(numeroDaAgencia);

//    Console.Write("informe o saldo inicial da conta: ");
//    conta.Saldo = double.Parse(Console.ReadLine());

//    Console.Write("informe o nome do titular:");
//    conta.Titular.Nome = Console.ReadLine();

//    Console.Write("informe o cpf do cliente: ");
//    conta.Titular.Cpf = Console.ReadLine();

//    Console.Write("informe a profissao do cliente: ");
//    conta.Titular.Profissao = Console.ReadLine();

//    _listaDeContas.Add(conta);
//    Console.WriteLine("conta cadastrada com sucesso  ...\n");

//    Console.Write("digite qualquer telcla para voltar ao menu inicial");
//    Console.ReadKey();


//}

//void ListarConta()
//{
//    ExibirTituloDaOpção("Listar Contas");

//    if (_listaDeContas.Count <= 0)
//    {
//        Console.WriteLine("...LISTA VAZIA");
//    }

//    foreach (ContaCorrente conta in _listaDeContas)
//    {
//        //Console.WriteLine($"numero da Agencia: {conta.Numero_agencia}");
//        //Console.WriteLine($"saldo da conta: {conta.Saldo}");
//        //Console.WriteLine($"nome do titular: {conta.Titular.Nome}");
//        //Console.WriteLine($"cpf do titular: {conta.Titular.Cpf}");
//        //Console.WriteLine($"profissao do titular: {conta.Titular.Profissao}");


//        Console.WriteLine(conta.ToString());
//        Console.WriteLine("digete qualquer tecla para voltar ao menu inicial!!");
//        Console.ReadKey();
//        Console.Clear();

//    }
//}






