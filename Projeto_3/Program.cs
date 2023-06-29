using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_3
{
    internal class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu {Listar = 1, Adicionar, Remover, Entrada, Saida, Sair}
        static void Main(string[] args)
        {
            Carregar();
            bool EscolhaSaida = false;
            while (EscolhaSaida == false) 
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("    SISTEMA DE ESTOQUE    ");
                Console.WriteLine("--------------------------");
                Console.WriteLine(" [1] Listar Produtos\n " +
                    "[2] Adicionar Produtos\n [3] Remover Produtos\n [4] Adicionar Entrada de Produtos\n" +
                    " [5] Adicionar Saída de Produto\n [6] Sair");
                int opc = int.Parse(Console.ReadLine());

                if (opc > 0 && opc <= 6)
                {
                    Menu escolha = (Menu)opc;
                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listar();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Sair:
                            EscolhaSaida = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("ERRO!!!! Digite uma opção válida!!!");
                }
                Console.Clear();
            }
        }

        static void Listar()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("  LISTA DE PRODUTOS  ");
            Console.WriteLine("---------------------");
            Console.WriteLine();
            int i = 0;
            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine("ID: " + i);
                produto.Exibir();
                i++;
            }
            Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }

        static void Remover()
        {
            Listar();
            Console.WriteLine("Digite o ID do produto que quer remover: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
            else
            {
                Console.WriteLine("ERRO!!! Digite um ID válido");
            }
        }

        static void Entrada()
        {
            Listar();
            Console.WriteLine("Digite o ID do produto que quer dar entrada (estoque e/ou vagas): ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
            else
            {
                Console.WriteLine("ERRO!!! Digite um ID válido");
            }
        }

        static void Saida()
        {
            Listar();
            Console.WriteLine("Digite o ID do produto que quer dar saída (estoque e/ou vagas e/ou vendas): ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
            else
            {
                Console.WriteLine("ERRO!!! Digite um ID válido");
            }
        }
        enum Menu2 {Fisico = 1, Ebook, Curso, Sair}
        static void Cadastro()
        {
            bool EscolhaSaida2 = false;
            while (EscolhaSaida2 == false)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("  CADASTRO DE PRODUTOS  ");
                Console.WriteLine("------------------------");
                Console.WriteLine(" [1] Produto Físico\n [2] Ebook\n [3] Curso\n [4] Sair");
                int opc2 = int.Parse(Console.ReadLine());

                if (opc2 > 0 && opc2 <= 4)
                {
                    Menu2 escolha2 = (Menu2)opc2;
                    switch (escolha2)
                    {
                        case Menu2.Fisico:
                            CadastrarPFisico();
                            break;
                        case Menu2.Ebook:
                            CadastrarEbook();
                            break;
                        case Menu2.Curso:
                            CadastrarCurso();
                            break;
                        case Menu2.Sair:
                            EscolhaSaida2 = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("ERRO!!!! Digite uma opção válida!!!");
                }
                Console.Clear();
            }
        }
        static void CadastrarPFisico()
        {
            Console.WriteLine("  CADASTRO DE PRODUTO FÍSICO  ");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }

        static void CadastrarEbook()
        {
            Console.WriteLine("  CADASTRO DE EBOOK  ");
            Console.WriteLine("---------------------");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();
        }

        static void CadastrarCurso()
        {
            Console.WriteLine("  CADASTRO DE CURSO  ");
            Console.WriteLine("---------------------");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Curso cr = new Curso(nome, preco, autor);
            produtos.Add(cr);
            Salvar();
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();
            encoder.Serialize(stream, produtos);
            stream.Close();
        }

        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();
            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);
                if (produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            } 
            catch(Exception e)
            {
                produtos = new List<IEstoque>();
            }
            
            stream.Close();
        }
    }
}
