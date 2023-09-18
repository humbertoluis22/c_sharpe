using bytebank.Modelos.Conta;

namespace bytebank_ATENDIMENTO.bytebank.Util
{
    public class ListaDeContaCorrente 
    {
        private ContaCorrente[] _itens = null;
        private int _proximaPosicao = 0;

        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }

        public ListaDeContaCorrente(int tamanhoInicial = 3)
        {
            _itens = new ContaCorrente[tamanhoInicial];
        }

        public void Adcionar(ContaCorrente item)
        {
            Console.WriteLine($"adicionando item na posição {_proximaPosicao}");
            VerificarCapacidade(_proximaPosicao + 1);
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length > tamanhoNecessario)
            {
                return;
            }
            Console.WriteLine("aumentando a capacidade do array");
            ContaCorrente[] _novoArray = new ContaCorrente[tamanhoNecessario];

            for (int i = 0; i < _itens.Length; i++)
            {
                _novoArray[i] = _itens[i];
            }

            _itens = _novoArray;

        }

        public ContaCorrente MaiorSaldo()
        {
            ContaCorrente conta = null;
            double maiorValor = 0;

            for (int i = 0; i < _itens.Length; i++)
            {
                if (_itens[i] != null)
                {
                    if (maiorValor < _itens[i].Saldo)
                    {
                        maiorValor = _itens[i].Saldo;
                        conta = _itens[i];
                    }
                }
            }
            return conta;
        }

        public void Remover(ContaCorrente conta)
        {
            int indiceItem = -1;

            for (int i = 0; i < _proximaPosicao; i++)
            {
                if (_itens[i] == conta)
                {
                    indiceItem = i;
                    break;
                }
            }

            for (int i = indiceItem; i < _proximaPosicao - 1; i++)
            {
                _itens[i] = _itens[i + 1];

            }
            _proximaPosicao--;
            _itens[_proximaPosicao] = null;

        }

        public void ImprimeConta()
        {
            for (int i = 0; i < _itens.Length; i++)
            {
                Console.WriteLine($"conta {_itens[i].Numero_agencia}");
            }
        }


        public ContaCorrente RecuperarContaNoIndice(int indice)
        {
            if (indice < 0 || indice > _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }
            return _itens[indice];
        }



        //indexador
        public ContaCorrente this[int indice]
        {
            get
            {
                return RecuperarContaNoIndice(indice);
            }
        }
    }
}
