﻿using System.Collections.Generic;
using PizzariaProject.Models;

List<Pizza> pizzaList = new List<Pizza>();
List<Pedido> pedidosList = new List<Pedido>();
var numeroPedidos = 1;

Console.WriteLine("=============================================");
Console.WriteLine("Bem Vindo ao projeto de Pizzaria!");
Console.WriteLine("=============================================");
var menuSet = 0;
do
{
    Console.WriteLine("ESCOLHA UMA OPÇÃO:");
    Console.WriteLine("1 - Adicionar Pizza");
    Console.WriteLine("2 - Listar Pizzas");
    Console.WriteLine("3 - Criar novo pedido");
    Console.WriteLine("4 - Listar Pedidos");
    Console.WriteLine("5 - Pagar pedido\n");
    Console.WriteLine("Digite sua opção:");
    menuSet = int.Parse(Console.ReadLine());

    if (menuSet == 1)
    {
        var pizza = new Pizza();
        Console.WriteLine("============= ➕ Adicionar uma Pizza! =============");
        Console.WriteLine("🍕 Digite o nome da Pizza:");
        pizza.Nome = Console.ReadLine();
        Console.WriteLine("========================================================");
        Console.WriteLine("🧾 Digite os sabores da Pizza separados por vírgula:");
        pizza.Sabor = Console.ReadLine();
        Console.WriteLine("=================================================");
        Console.WriteLine("💵 Digite o preço da Pizza (formato 00,00):");
        pizza.Preco = double.Parse(Console.ReadLine());

        if (!string.IsNullOrWhiteSpace(pizza.Nome) && !string.IsNullOrWhiteSpace(pizza.Sabor) && pizza.Preco != null)
        {
            pizzaList.Add(pizza);
            Console.WriteLine("============ ✅ PIZZA CRIADA COM SUCESSO ==============\n");
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
        }
        else
        {
            Console.WriteLine("Nenhuma Pizza foi cadastrada.");
        }
    }

    else if (menuSet == 3)
    {
        if (pizzaList.Count < 1)
        {
            Console.WriteLine("❌ Nenhuma Pizza foi cadastrada.");
        }
        else
        {
            var pedido = new Pedido();
            var pedidoPronto = pedido.criarPedido(pizzaList, numeroPedidos);
            pedidosList.Add(pedidoPronto);
            numeroPedidos = numeroPedidos + 1;
        }
    }

    else if (menuSet == 4)
    {
        if (pedidosList.Count < 1)
        {
            Console.WriteLine("❌ Nenhum pedido foi encontrado.");
        }
        else
        {
            Console.WriteLine("\n ========== Listar Pedidos! ==========");
            foreach (Pedido pedido in pedidosList)
            {
                Console.WriteLine($"PEDIDO {pedido.Id}");
                Console.WriteLine($"🙋 Cliente: {pedido.NomeCliente} - 📞 {pedido.TelefoneCliente}");
                Console.WriteLine("========== 📦 Pizzas do pedido ==========");
                foreach (Pizza pizza in pedido.pizzasPedido)
                {
                    Console.WriteLine($"🍕 {pizza.Nome.ToUpper()} - R${pizza.Preco:F2}");
                }
                Console.WriteLine($"Total: {pedido.ValorTotal:F2}");
                Console.WriteLine($"Quanto falta para Pagar: R${pedido.Restante:F2}");
                Console.WriteLine($"Pago: {pedido.StatusPago}");
                Console.WriteLine("========================= VALOR TOTAL ==============================");
                Console.WriteLine($"💵 R${pedido.ValorTotal:F2}\n====================================================================\n");
            }
        }
    }
    else if (menuSet == 5)
    {
        if(pedidosList.Count == 0) {
            Console.WriteLine("Não há pedidos cadastrados");
        } else {
            var pagamento = new Pagamento();
            pedidosList = pagamento.EfetuarPagamento(pedidosList);
        }
    }

    else
    {
        Console.WriteLine("Está opção não existe...\n");
    }
} while (menuSet != 1 || menuSet != 2);
