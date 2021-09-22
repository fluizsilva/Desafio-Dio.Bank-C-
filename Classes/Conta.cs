using DIO.Bank.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank.Conta
{
    class Conta
    {

        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public bool Sacar(double ValorSaque)
        {
            //validacaode saldo suficiente
            if (this.Saldo - ValorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo infusuficiente");
                return false;
            }

            this.Saldo -= ValorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public void Depositar(double ValorDeposito)
        {
            this.Saldo += ValorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

        }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de Conta: " + this.TipoConta + " | ";
            retorno += "Nome:" + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Crédito: " + this.Credito + " | ";

            return retorno;
        }
    }
}
