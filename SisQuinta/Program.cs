using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SisQuinta
{
    internal class Program
    {
        public static List<Registro> documentos = new List<Registro>();
        static void Main(string[] args)
        {
            ConsoleKeyInfo opcao = new ConsoleKeyInfo();
            while (opcao.Key != ConsoleKey.F9)
            {
                Console.WriteLine(" SisQuinta                  Sistema de Quinta                 " + DateTime.Now.ToString("dd/MM/yyyy"));
                Console.WriteLine(" ========================================================================");
                Console.WriteLine("");
                Console.WriteLine("  F1 - Cadastrar documentos");
                Console.WriteLine("  F2 - Pesquisar documentos");
                Console.WriteLine("  F3 - Listar documentos");
                Console.WriteLine("");
                Console.WriteLine("  F7 - Carregar documentos");
                Console.WriteLine("  F8 - Salvar documentos");
                Console.WriteLine("");
                Console.WriteLine("  F9 - Sair");
                opcao = Console.ReadKey();
                switch (opcao.Key)
                {
                    case ConsoleKey.F1:
                        menuCadastro(1);
                        break;
                    case ConsoleKey.F2:
                        menuCadastro(2);
                        break;
                    case ConsoleKey.F3:
                        menuCadastro(3);
                        break;
                }
                Console.Clear();
            }
        }

        static void menuCadastro(int tipo)  //1 = cadastrar, 2 = pesquisa, 3 = listagem
        {
            int id = 0;
            if (tipo == 2)
            {
                Console.WriteLine("Digite o id desejado: ");
                id = int.Parse(Console.ReadLine());
                Console.Clear();
            }
            int index = documentos.Count;
            ConsoleKeyInfo opcaoCad = new ConsoleKeyInfo();
            Console.Clear();
            Console.WriteLine(" SisQuinta                  Sistema de Quinta                 " + DateTime.Now.ToString("dd/MM/yyyy"));
            Console.WriteLine(" ========================================================================");
            Console.WriteLine("");
            Console.WriteLine(" Registro....: " + (index + 1) + " de " + documentos.Count);
            Console.WriteLine("");
            Console.WriteLine(" Nome........:");
            Console.WriteLine(" RG..........:");
            Console.WriteLine(" CPF.........:");
            Console.WriteLine(" Habilitação.:");
            Console.WriteLine(" Tit. Eleitor:");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" <F1> Insere novo <F2> Anterior <F3> Próximo <F5> Editar <F9> Sair");
            Console.WriteLine(" ========================================================================");
            Console.WriteLine(" Usuario: Vinicius         Terminal: Teste                    Nível: user");
            Console.WriteLine(" Msg:");
            switch (tipo)
            {
                case 1:
                    cadastrarDocumento(-1);
                    break;
                case 2:
                    index = id - 1;
                    listaCadastro(index);
                    break;
                case 3:
                    index = 0;
                    listaCadastro(index);
                    break;
            }
            while (opcaoCad.Key != ConsoleKey.F9)
            {
                Console.SetCursorPosition(0, 3);
                Console.Write(" Registro....: " + (index + 1) + " de " + documentos.Count);
                Console.SetCursorPosition(0, 25);
                opcaoCad = Console.ReadKey();
                switch (opcaoCad.Key)
                {
                    case ConsoleKey.F1:
                        menuCadastro(1);
                        break;
                    case ConsoleKey.F2:
                        index = index - 1;
                        if (index < 0) {
                            index = index + 1;
                            mensagem("Você já está no primeiro registro!");
                        }
                        else
                        {
                            listaCadastro(index);
                        }
                        break;
                    case ConsoleKey.F3:
                        index = index + 1;
                        if (index > (documentos.Count - 1))
                        {
                            index = index - 1;
                            mensagem("Você já está no último registro!");
                        }
                        else
                        {
                            listaCadastro(index);
                        }                        
                        break;
                    case ConsoleKey.F5:
                        cadastrarDocumento(index);
                        break;
                    case ConsoleKey.F9:
                        break;

                }
            }
        }

        static void listaCadastro(int index)
        {
            Console.SetCursorPosition(15, 5);
            Console.Write(documentos[index].Nome);
            Console.SetCursorPosition(15, 6);
            Console.Write(documentos[index].RG);
            Console.SetCursorPosition(15, 7);
            Console.Write(documentos[index].CPF);
            Console.SetCursorPosition(15, 8);
            Console.Write(documentos[index].Habilitacao);
            Console.SetCursorPosition(15, 9);
            Console.Write(documentos[index].Titulo);
            Console.SetCursorPosition(0, 25);
        }

        static void cadastrarDocumento(int indexEdicao)
        {
            Registro registro = new Registro();
            Console.SetCursorPosition(15, 5);
            registro.Nome = Console.ReadLine();
            Console.SetCursorPosition(15, 6);
            registro.RG = Console.ReadLine();
            Console.SetCursorPosition(15, 7);
            registro.CPF = Console.ReadLine();
            Console.SetCursorPosition(15, 8);
            registro.Habilitacao = Console.ReadLine();
            Console.SetCursorPosition(15, 9);
            registro.Titulo = Console.ReadLine();

            if (indexEdicao > -1)
            {
                registro.RegistroID = documentos[indexEdicao].RegistroID;
                documentos[indexEdicao] = registro;
            }
            else
            {
                registro.RegistroID = documentos.Count + 1;
                documentos.Add(registro);
            }

        }
        static void mensagem(string msg)
        {
            Console.SetCursorPosition(6, 23);
            Console.WriteLine(msg);
            Console.SetCursorPosition(0, 25);
        }
    }
}
