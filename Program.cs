using System.Collections.Generic;
using PizzariaProject.Models;

List<Pizza> pizzaList = new List<Pizza>();
List<Pedido> pedidosList = new List<Pedido>();
Console.WriteLine("Bem Vindo ao projeto de Pizzaria!");
var menuSet = 0;
do
{
    Console.WriteLine("ESCOLHA UMA OPÇÃO:");
    Console.WriteLine("1 - Adicionar Pizza");
    Console.WriteLine("2 - Listar Pizzas");
    Console.WriteLine("3 - Criar novo pedido");
    Console.WriteLine("4 - Listar Pedidos\n");
    Console.WriteLine("Digite sua opção:");
    menuSet = int.Parse(Console.ReadLine());

    if (menuSet == 1)
    {
        var pizza = new Pizza();
        Console.WriteLine("Adicionar uma Pizza!");
        Console.WriteLine("Digite o nome da Pizza:");
        pizza.Nome = Console.ReadLine();
        Console.WriteLine("Digite os sabores da Pizza separados por vírgula:");
        pizza.Sabor = Console.ReadLine();
        Console.WriteLine("Digite o preço da Pizza (formato 00,00):");
        pizza.Preco = double.Parse(Console.ReadLine());

        if (!string.IsNullOrWhiteSpace(pizza.Nome) && !string.IsNullOrWhiteSpace(pizza.Sabor) && pizza.Preco != null)
        {
            pizzaList.Add(pizza);
            Console.WriteLine("PIZZA CRIADA COM SUCESSO\n");
        }
        else
        {
            Console.WriteLine("Preencha todos os campos!\n");
        }
    }
    else if (menuSet == 2)
    {
        if (pizzaList.Count > 0)
        {
            Console.WriteLine("Listar as Pizzas!");
            foreach (var pizza in pizzaList)
            {
                Console.WriteLine("NOME: " + pizza.Nome);
                Console.WriteLine("SABORES: " + pizza.Sabor);
                Console.WriteLine("PREÇO: " + string.Format("R${0:F2}", pizza.Preco) + '\n');
            }
            break;
        }
        else
        {
            Console.WriteLine("Nenhuma Pizza foi cadastrada.");
            break;
        }
    }

    else if (menuSet == 3)
    {
        if (pizzaList.Count < 1)
        {
            Console.WriteLine("Nenhuma Pizza foi cadastrada.");
            break;
        }
        else
        {
            var pedido = new Pedido();
            var pedidoPronto = pedido.criarPedido(pizzaList);
            pedidosList.Add(pedidoPronto);
        }
    }

    else if (menuSet == 4) 
    {
        if (pedidosList.Count < 1)
        {
            Console.WriteLine("Nenhum pedido foi encontrado."); 
            break;
        }
        else 
        {
            Console.WriteLine("\nListar Pedidos!");
            foreach (Pedido pedido in pedidosList)
            {
                Console.WriteLine($"Cliente: {pedido.NomeCliente} - {pedido.TelefoneCliente}");
                Console.WriteLine("Pizzas do pedido:");
                foreach (Pizza pizza in pedido.pizzasPedido)
                {
                    Console.WriteLine($"{pizza.Nome.ToUpper()} - R${pizza.Preco:F2}");
                }
                Console.WriteLine($"Total do Pedido: {pedido.ValorTotal:F2}");
            }
            break;
        }
    }

    else
    {
        Console.WriteLine("Está opção não existe...\n");
    }
} while (menuSet != 1 || menuSet != 2);
