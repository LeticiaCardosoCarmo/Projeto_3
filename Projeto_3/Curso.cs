using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_3
{
    [System.Serializable]
    internal class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar vagas no curso {nome}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Digite a quantidade de vagas que gostaria de adicionar ao curso {nome}: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada;
            Console.WriteLine("Alteração realizada com sucesso!");
            Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Retirada de vagas do curso {nome}");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Digite a quantidade de vagas que gostaria de retirar do curso {nome}: ");
            int saida = int.Parse(Console.ReadLine());
            vagas -= saida;
            Console.WriteLine("Alteração realizada com sucesso!");
            Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vagas disponíveis: {vagas}");
            Console.WriteLine("--------------------");
            Console.WriteLine();
        }
    }
}
