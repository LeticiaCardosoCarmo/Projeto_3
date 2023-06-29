using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_3
{
    [System.Serializable]
    internal class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possível dar entrada em estoque de um Ebook por ser um produto digital");
            Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar vendas no Ebook {nome}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Digite a quantidade de vendas feitas do Ebook {nome}: ");
            int entrada = int.Parse(Console.ReadLine());
            vendas += entrada;
            Console.WriteLine("Alteração realizada com sucesso!");
            Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Itens vendidos: {vendas}");
            Console.WriteLine("--------------------");
            Console.WriteLine();
        }
    }
}
