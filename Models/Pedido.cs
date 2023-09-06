using System.Collections.Generic;
namespace PizzariaProject.Models;

public class Pedido
{
    public string NomeCliente { get; set; }
    public string TelefoneCliente { get; set; }
    public List<Pizza> pizzas = new List<Pizza>();
    public double total { get; set; }
    public List<Pizza> pizzasPedido = new List<Pizza>();
    public double ValorTotal { get; set; }

    public Pedido criarPedido(List<Pizza> pizzas)
    {
        var pedido = new Pedido();
        var adicionarPizza = 1;
        pedido.pizzas = pizzas;
        Console.WriteLine("Quem é o cliente?");
        pedido.NomeCliente = Console.ReadLine();
        Console.WriteLine("Qual é o telefone do cliente?");
        pedido.TelefoneCliente = Console.ReadLine();
        Console.WriteLine("Escolha uma pizza para adicionar:");
        do
        {
            for (int i = 0; i < pizzas.Count; i = i + 1) {
                Console.WriteLine($"{pedido.pizzas[i].Nome.ToUpper()} - R${pedido.pizzas[i].Preco:F2}");
            }
            var pizzaEscolhida = Console.ReadLine();
            var pizzaSelecionada = pizzas.Find(pizza => pizza.Nome.ToUpper() == pizzaEscolhida);
            pedido.pizzasPedido.Add(pizzaSelecionada);
            pedido.ValorTotal = pedido.ValorTotal + pizzaSelecionada.Preco;
            Console.WriteLine("Deseja adicionar mais ma pizza? (1 - SIM | 2 - NÃO)");
            adicionarPizza = int.Parse(Console.ReadLine());
        } while (adicionarPizza != 2);

        Console.WriteLine("PEDIDO CRIADO");
        Console.WriteLine($"Total: R${pedido.ValorTotal:F2}");
        foreach (var pizza in pizzas) {
            Console.WriteLine($"{pizza.Nome} - {pizza.Preco}");
        }
        return pedido;
    }
}