using bytebank.Modelos.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.bytebank.Util
{
    public class ListaConta
    {
        private new ContaCorrente[] _item = null;
        private int _posicao = 0;
        public int Tamanho  { get
            { 
                return _posicao;
            
            } }

        public ListaConta(int tamanho=3)
        {
            _item = new ContaCorrente[tamanho];
        }

        
       public void Adicionar(ContaCorrente item)
        {
            Console.WriteLine($"adicionando item na posicao {_posicao}");
            AumentandoCapacidade(_posicao + 1);
            _item[_posicao] = item;
            _posicao++;
        }

       private void AumentandoCapacidade(int tamanhoNecessario) 
        {
            if(_item.Length >= tamanhoNecessario)
            {
                return;
            }
            Console.WriteLine("aumentando capacidade do array");
            ContaCorrente[] _novoArray = new ContaCorrente[tamanhoNecessario];
            for(int i = 0;i< _item.Length; i++)
            {
                _novoArray[i] = _item[i];
            }
            _item = _novoArray;

        }

        public void   RemoveConta (ContaCorrente  conta1) 
        {
            int indice = -1;
            for(int i = 0; i < _posicao; i++)
            {
                if (_item[i] == conta1)
                {
                    indice = i;
                }
            }


            for(int i = indice; i < _posicao -1; i++)
            {
                _item[i] = _item[i + 1];
            }
            _posicao--;
            _item[_posicao] = null;

        }

        public ContaCorrente DescobreIndice(int indice)
        {
            if(indice < 0 || indice > _posicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }
            return _item[indice];
        }

        //indexador 
        public ContaCorrente this[int indice]
        {
            get
            {
                return DescobreIndice(indice);
            }
        }
 
        public ContaCorrente MaiorValor()
        {
            ContaCorrente conta = null;
            double maiorValor = 0;

            for(int i = 0; i< _item.Length; i++)
            {
                if (_item[i] != null)
                {
                    if(maiorValor < _item[i].Saldo)
                    {
                        maiorValor= _item[i].Saldo;
                        conta = _item[i];
                    }
                }
            }
            return conta;
        }

        public void ImprimeConta()
        {
            for(int i = 0; i < _posicao; i++)
            {
                Console.WriteLine($"conta {_item[i].Numero_agencia}");
            }
        }

    }
}
