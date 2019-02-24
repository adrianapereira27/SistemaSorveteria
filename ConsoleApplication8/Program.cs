using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    public class Usuario
    {
        public string Login { get; set; }
        public string Senha { get; set; }        
    }
    public class Pessoa
    {
        public string Nome { get; set; }             
    }
    public class Sorvetes
    {
        public int CodSorvete { get; set; }
        public string NomeSorvete { get; set; }
        public double Preco { get; set; }
    }
    public class Sabores
    {
        public int CodSabor { get; set; }
        public string NomeSabor { get; set; }
    }
    class Program
    {
        public static List<Usuario> usuarios = new List<Usuario>();
        public static List<Sorvetes> sorvetes = new List<Sorvetes>();
        public static List<Sabores> sabores = new List<Sabores>();
        public static double lucro;
        
        static void Main(string[] args)
        {
            
            Menu();            

            Console.ReadLine();
        }
        public static void Menu()
        {
            int opcao = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Bem Vindo ao Sistema da Sorveteria do Joãozinho");
                Console.WriteLine();
                Console.WriteLine("Escolha uma opção abaixo: ");
                Console.WriteLine("Opção 1 - Realizar Venda de Sorvete");
                Console.WriteLine("Opção 2 - Visualizar Opções de Sorvete e Preços");
                Console.WriteLine("Opção 3 - Visualizar Opções de Sabores");
                Console.WriteLine("Opção 7 - Cadastro de Sorvetes");
                Console.WriteLine("Opção 8 - Cadastro de Sabores");
                Console.WriteLine("Opção 9 - Configuração da Conta");
                Console.WriteLine("Opção 0 - Sair");
                Console.WriteLine("Informe a opção do menu: ");
                opcao = Convert.ToInt32(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        RealizarVenda();
                        break;
                    case 2:
                        VisualizarOpcoesPrecosSorvetes();
                        break;
                    case 3:
                        VisualizarOpcoesSabores();
                        break;
                    case 7:                        
                        CadastroSorvete();
                        break;
                    case 8:
                        CadastroSabores();
                        break;
                    case 9:
                        ConfiguracaoConta();
                        break;  
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Obrigado por Utilizar o Sistema!"); 
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        Menu();
                        break;
                }
                Console.ReadLine();
            } while (opcao != 0);  
        }
        public static void RealizarVenda()
        {
            if (sorvetes.Count == 0 || sabores.Count == 0)
            {
                Console.WriteLine("Nenhum sorvete ou sabor cadastrado");
                Console.ReadLine();
                Menu();
                return;
            }
            
            double valorTotal = 0;
            int sorvete = 0;
            int sabor = 0;
            char fim = 'N';

            Pessoa pe = new Pessoa();
                        
            Console.WriteLine("Informe o nome: ");
            pe.Nome = Console.ReadLine();
                       
            do{
                Console.WriteLine("Informe o Sorvete: ");
                sorvete = Convert.ToInt32(Console.ReadLine());
                int verificaSorvete = 0;
                foreach (var item in sorvetes)
                {
                    if (sorvete == item.CodSorvete)
                    {
                        verificaSorvete = 1;                        
                        valorTotal += RetornaPrecoSorvete(sorvete);
                    }
                }
                if(verificaSorvete == 0){
                    Console.WriteLine("Código de sorvete inválido");                    
                }

                Console.WriteLine("Informe o Sabor: ");
                sabor = Convert.ToInt32(Console.ReadLine());
                int verificaSabor = 0;
                foreach (var item in sabores)
                {
                    if (sabor == item.CodSabor)
                    {
                        verificaSabor = 1;
                    }
                }
                if (verificaSabor == 0)
                {
                    Console.WriteLine("Código de sabor inválido");
                }
                
                Console.WriteLine("Finaliza compra? S/N");
                fim = Convert.ToChar(Console.ReadLine());

            } while (fim == 'N');
                        
            lucro += valorTotal;
            Console.WriteLine("Valor Total R$ " + valorTotal);
            Console.ReadLine();
            Menu();
        }
        public static double RetornaPrecoSorvete(int codSorv)
        {                
            foreach (var item in sorvetes)
            {
                if (item.CodSorvete == codSorv)
                {
                    return item.Preco;                    
                }
            }
            return 0;
        }
        public static void VisualizarOpcoesPrecosSorvetes()
        {
            foreach (Sorvetes sorv in sorvetes)
            {
                Console.WriteLine("Sorvete: " + sorv.CodSorvete + " - " + sorv.NomeSorvete + " - R$ " + sorv.Preco);                
            }
            Console.ReadLine();
            Menu();
        }
        public static void VisualizarOpcoesSabores()
        {
            foreach (Sabores sab in sabores)
            {
                Console.WriteLine("Sabor: " + sab.CodSabor + " - " + sab.NomeSabor);
            }
            Console.ReadLine();
            Menu();
        }
        public static void CadastroSorvete()
        {
            if (sorvetes.Count == 10)
            {
                Console.WriteLine("Limite de sorvetes excedido");
                Console.ReadLine();
                Menu();
                return;
            }
            int retorno = verificaLoginSenha();
            if (retorno == 0)
            {
                Console.WriteLine("Acesso Negado!");
                Console.ReadLine();
                return;
            }

            Sorvetes so = new Sorvetes();

            Console.WriteLine("Informe o código do sorvete: ");
            so.CodSorvete = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe a descrição do sorvete: ");
            so.NomeSorvete = Console.ReadLine();

            Console.WriteLine("Informe o preço do sorvete: ");
            so.Preco = Convert.ToDouble(Console.ReadLine());
            sorvetes.Add(so);
            
            Menu();
        }
        public static void CadastroSabores()
        {
            if (sabores.Count == 5)
            {
                Console.WriteLine("Limite de sabores excedido");
                Console.ReadLine();
                Menu();
                return;
            }
            int retorno = verificaLoginSenha();
            if(retorno == 0){
                Console.WriteLine("Acesso Negado!");
                Console.ReadLine();
                return;
            }
           
            Sabores sa = new Sabores();

            Console.WriteLine("Informe o código do sabor: ");
            sa.CodSabor = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe a descrição do sabor: ");
            sa.NomeSabor = Console.ReadLine();
            sabores.Add(sa);
           
            Menu();            
        }
        
        public static int verificaLoginSenha()
        {
            Console.WriteLine("Informe o Login: ");
            string login = Console.ReadLine();

            Console.WriteLine("Informe a Senha: ");
            string senha = Console.ReadLine();

            foreach (var item in usuarios)
            {
                if (login == item.Login && senha == item.Senha)
                {
                    return 1;
                }
            }
            return 0;            
        }
        public static void ConfiguracaoConta()
        {
            int opcao = 0;
            do{
                Console.Clear();
                Console.WriteLine("Escolha uma opção abaixo: ");
                Console.WriteLine("Opção 1 - Cadastrar Usuário");
                Console.WriteLine("Opção 2 - Alterar Login");
                Console.WriteLine("Opção 3 - Alterar Senha");
                Console.WriteLine("Opção 4 - Visualizar Lucro");               
                Console.WriteLine("Opção 9 - Sair");
                Console.WriteLine("Informe a opção do menu: ");
                opcao = Convert.ToInt32(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        CadastrarUsuario(0);
                        break;
                    case 2:
                        AlterarLogin();
                        break;
                    case 3:
                        CadastrarUsuario(1);
                        break;
                    case 4:
                        Console.WriteLine("O lucro obtido até o momento é R$ " + lucro);
                        break;
                    case 9:
                        Menu();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                
            } while(opcao == 9);

        }
        public static void CadastrarUsuario(int indAlterar)
        {            
            Usuario usu = new Usuario();
            string confirmSenha = "";
            int verificaSenha = 0;
            int verificaLogin = 0;

            if (indAlterar == 0)
            {
                Console.WriteLine("Informe o Login: ");
                usu.Login = Console.ReadLine();

                foreach (var item in usuarios)
                {
                    if (usu.Login == item.Login)
                    {                       
                        verificaLogin = 1;
                    }
                }
                if (verificaLogin == 1)
                {
                    Console.WriteLine("Login já cadastrado!");
                    ConfiguracaoConta();
                    return;
                }                
            }            

            Console.WriteLine("Informe a Senha: ");
            usu.Senha = Console.ReadLine();
           
            Console.WriteLine("Confirme a Senha: ");
            confirmSenha = Console.ReadLine();

            if (indAlterar == 0)
            {
                if (usu.Senha == confirmSenha)
                {                    
                    usuarios.Add(usu);
                }
                else
                {
                    Console.WriteLine("Senha inválida");                    
                }
                ConfiguracaoConta();
            }
            else
            {
                foreach (var item in usuarios)
                {
                    if (usu.Senha == item.Senha)
                    {
                        item.Senha = confirmSenha;
                        verificaSenha = 1;
                    }
                }
                if (verificaSenha == 1)
                {
                    Console.WriteLine("Senha alterada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Senha não cadastrado!");
                }
            }
        }
        public static void AlterarLogin()
        {
            Usuario usu = new Usuario();
            int verificaLogin = 0;

            Console.WriteLine("Informe o Login Atual: ");
            usu.Login = Console.ReadLine();

            Console.WriteLine("Informe o Novo Login: ");
            string log = Console.ReadLine();

            foreach (var item in usuarios)
            {
                if (usu.Login == item.Login)
                {
                    item.Login = log;
                    verificaLogin = 1;
                }
            }
            if (verificaLogin == 1)
            {
                Console.WriteLine("Login alterado com sucesso!");
            }
            else
            {
                Console.WriteLine("Login não cadastrado!");
            }
            Console.ReadLine();
            ConfiguracaoConta();
        }        
    }
}
