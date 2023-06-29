using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_3
{
    [System.Serializable]
    internal class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Entrada no estoque de {nome}");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Digite a quantidade que gostaria de dar entrada no estoque: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada;
            Console.WriteLine("Alteração realizada com sucesso!");
            Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Saída no estoque de {nome}");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Digite a quantidade que gostaria de dar saída no estoque: ");
            int saida = int.Parse(Console.ReadLine());
            estoque -= saida;
            Console.WriteLine("Alteração realizada com sucesso!");
            Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Frete fixo: {frete}");
            Console.WriteLine($"Quantidade disponível: {estoque}");
            Console.WriteLine("--------------------");
            Console.WriteLine();
        }
    }
}
