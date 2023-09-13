using System;
using System.Collections.Generic;
namespace PizzariaProject.Models;

public class Pedido
{
    public int Id {get; set;} // CRIAR LÓGICA
    public string NomeCliente { get; set; }
    public string TelefoneCliente { get; set; }
    public List<Pizza> pizzas = new List<Pizza>();
    public List<Pizza> pizzasPedido = new List<Pizza>();
    public double ValorTotal { get; set; }
    public Boolean Pago { get; set; }
    public string StatusPago {get; set;}
    public double Restante { get; set; }

    public Pedido criarPedido(List<Pizza> pizzas)
    {
        var pedido = new Pedido();
        var adicionarPizza = 1;
        pedido.pizzas = pizzas;
        pedido.Pago = false;
        pedido.StatusPago = pedido.PagoTransform(pedido.Pago);
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
            Console.WriteLine("Deseja adicionar mais uma pizza? (1 - SIM | 2 - NÃO)");
            adicionarPizza = int.Parse(Console.ReadLine());
            pedido.Restante = pedido.ValorTotal;
        } while (adicionarPizza != 2);

        Console.WriteLine("PEDIDO CRIADO");
        Console.WriteLine($"Total: R${pedido.ValorTotal:F2}");
        foreach (var pizza in pizzas) {
            Console.WriteLine($"{pizza.Nome} - {pizza.Preco}");
        }
        return pedido;
    }

    private string PagoTransform(Boolean pago) {
        if (pago)
        {
            return "SIM";
        } else 
        {
            return "NÃO";
        }
    }
}