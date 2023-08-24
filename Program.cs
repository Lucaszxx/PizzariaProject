using System.Collections.Generic;
using PizzariaProject.Models;

List<Pizza> pizzaList = new List<Pizza>();
Console.WriteLine("Bem Vindo ao projeto de Pizzaria!");
var menuSet = 0;
do {
    Console.WriteLine("ESCOLHA UMA OPÇÃO:");
    Console.WriteLine("1 - Adicionar Pizza");
    Console.WriteLine("2 - Listar Pizzas\n");
    Console.WriteLine("Digite sua opção:");
    menuSet = int.Parse(Console.ReadLine());

    if(menuSet == 1) {
        var pizza = new Pizza();
        Console.WriteLine("Adicionar uma Pizza!");
        Console.WriteLine("Digite o nome da Pizza:");
        pizza.Nome = Console.ReadLine();
        Console.WriteLine("Digite os sabores da Pizza separados por vírgula:");
        pizza.Sabor = Console.ReadLine();
        Console.WriteLine("Digite o preço da Pizza (formato 00,00):");
        pizza.Preco = double.Parse(Console.ReadLine());

        if(!string.IsNullOrWhiteSpace(pizza.Nome) && !string.IsNullOrWhiteSpace(pizza.Sabor) && pizza.Preco != null){
            pizzaList.Add(pizza);
            Console.WriteLine("PIZZA CRIADA COM SUCESSO\n");
        } 
        else {
            Console.WriteLine("Preencha todos os campos!\n");
        }
    } else if (menuSet == 2) {
        if(pizzaList.Count > 0) {
            Console.WriteLine("Listar as Pizzas!");
            foreach (var pizza in pizzaList) {
                Console.WriteLine("NOME: " + pizza.Nome);
                Console.WriteLine("SABORES: "+ pizza.Sabor);
                Console.WriteLine("PREÇO: " + string.Format("R${0:F2}", pizza.Preco) + '\n');
            }
            break;
        } else {
            Console.WriteLine("Nenhuma Pizza foi cadastrada.");
            break;
        }
    } else {
        Console.WriteLine("Está opção não existe...\n");
    }
} while (menuSet != 1 || menuSet != 2);
