using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SisQuinta
{
    internal class Program
    {
        public static List<Registro> documentos = new List<Registro>();
        public static string nomeArquivo = "";
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
                    case ConsoleKey.F7:
                        carregarArquivo();
                        break;
                    case ConsoleKey.F8:
                        salvarArquivo();
                        break;

                    case ConsoleKey.F9:
                        Console.WriteLine("Deseja realmente sair? [s/n]");
                        String confirmacao = "";
                        confirmacao = Console.ReadLine();
                        if (confirmacao != "s")
                        {
                            opcao = new ConsoleKeyInfo();
                            Console.Clear();
                        }
                        break;
                }
                Console.Clear();
            }
        }

        static void menuCadastro(int tipo)  //1 = cadastrar, 2 = pesquisa, 3 = listagem
        {
            string nomeMaquina = Environment.MachineName;
            int id = 0;
            if (tipo == 2)
            {
                Console.WriteLine("Digite o id desejado: ");
                String entrada = Console.ReadLine();
                while (!int.TryParse(entrada, out id))
                {
                    Console.WriteLine("Valor inválido! ");
                    Console.WriteLine("Digite o id desejado: ");
                    entrada = Console.ReadLine();
                }
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
            Console.WriteLine(" Usuario: Vinicius         Terminal: "+ nomeMaquina + "          Nível: user");
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
        {   if (documentos.Count > 0)
            {
                if (index > documentos.Count-1)
                {
                    Console.Clear();
                    Console.WriteLine("Documento não encontrado!");
                    Console.WriteLine("Prosseguindo para inserção...");
                    Thread.Sleep(2000);
                    menuCadastro(1);
                }
                else {
                    limpaCampos();
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
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Não existem documentos cadastrados!");
                Console.WriteLine("Prosseguindo para inserção...");
                Thread.Sleep(2000);
                menuCadastro(1);
            }
        }

        static void limpaCampos()
        {
            Console.SetCursorPosition(15, 5);
            Console.WriteLine("                                                                ");
            Console.SetCursorPosition(15, 6);
            Console.WriteLine("                                                                ");
            Console.SetCursorPosition(15, 7);
            Console.WriteLine("                                                                ");
            Console.SetCursorPosition(15, 8);
            Console.WriteLine("                                                                ");
            Console.SetCursorPosition(15, 9);
            Console.WriteLine("                                                                ");
        }

        static void cadastrarDocumento(int indexEdicao)
        {
            Registro registro;
            if (indexEdicao > -1)
            {
                registro = documentos[indexEdicao];
            }
            else
            {
                registro = new Registro();
            }
            Console.SetCursorPosition(15, 5);
            string nome = Console.ReadLine();
            if (!string.IsNullOrEmpty(nome))
            {
                registro.Nome = nome;

            } 
            Console.SetCursorPosition(15, 6);
            string rg = Console.ReadLine();
            if (!string.IsNullOrEmpty(rg))
            {
                registro.RG = rg;
            }
            Console.SetCursorPosition(15, 7);
            string cpf = Console.ReadLine();
            if (!string.IsNullOrEmpty(cpf))
            {
                registro.CPF = cpf;
            }
            Console.SetCursorPosition(15, 8);
            string habilitacao = Console.ReadLine();
            if (!string.IsNullOrEmpty(habilitacao))
            {
                registro.Habilitacao = habilitacao;
            }
            Console.SetCursorPosition(15, 9);
            string titulo = Console.ReadLine();
            if (!string.IsNullOrEmpty(titulo))
            {
                registro.Titulo = titulo;
            }

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
            mensagem("Registro inserido com sucesso!");

        }
        static void mensagem(string msg)
        {
            Console.SetCursorPosition(6, 23);
            Console.WriteLine("                                                                             ");
            Console.SetCursorPosition(6, 23);
            Console.WriteLine(msg);
            Console.SetCursorPosition(0, 25);
        }

        static void salvarArquivo()
        {           
            Console.Clear();
            if (string.IsNullOrEmpty(nomeArquivo))
            {
                Console.WriteLine("Digite o nome do arquivo");
                nomeArquivo = Console.ReadLine();
                while (nomeArquivo == "")
                {
                    Console.Clear();
                    Console.WriteLine("Nome inválido! Tente novamente!");
                    nomeArquivo = Console.ReadLine();
                }
            }

            FileStream fileStream = new FileStream(nomeArquivo + ".dat", FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(fileStream, documentos);
            fileStream.Close();

            Console.WriteLine("Arquivo salvo com sucesso!");
            Thread.Sleep(2000);
        }

        static void carregarArquivo()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome do arquivo");
            string nomeArquivoCarregar = Console.ReadLine();
            if (File.Exists(nomeArquivoCarregar + ".dat"))
            {
                FileStream fileStream = new FileStream(nomeArquivoCarregar + ".dat", FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                documentos = (List<Registro>)binaryFormatter.Deserialize(fileStream);
                fileStream.Close();

                Console.WriteLine("Arquivo lido com sucesso!");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado!");
                Thread.Sleep(2000);
            }
        }
    }
}
