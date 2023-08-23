// See https://aka.ms/new-console-template for more information
using PizzariaProject.Models;

static void Menu() {
    Console.WriteLine("ESCOLHA UMA OPÇÃO:");
    Console.WriteLine("1 - Adicionar Pizza");
    Console.WriteLine("2 - Listar Pizzas");
    Console.WriteLine("Digite sua opção:");
    var menuSet = int.Parse(Console.ReadLine());
    
    switch (menuSet)
{
    case 1:
        var pizza = new Pizza();

        Console.WriteLine("Adicionar Pizza");
        Console.WriteLine("Digite o nome da Pizza:");
        pizza.Nome = Console.ReadLine();
        Console.WriteLine("Digite os sabores da Pizza separados por vírgula:");
        pizza.Sabor = Console.ReadLine();
        Console.WriteLine("Digite o preço da Pizza (formato 00,00):");
        pizza.Preco = double.Parse(Console.ReadLine());

        if(!string.IsNullOrWhiteSpace(pizza.Nome) && !string.IsNullOrWhiteSpace(pizza.Sabor) && pizza.Preco != null){
            Console.WriteLine("PIZZA CRIADA COM SUCESSO");
            Menu();
        } 
        else {
            Console.WriteLine("Preencha todos os campos!");
            Menu();
        }
        break;
    case 2:
        Console.WriteLine("Listar Pizzas");
        break;
    }
}
Console.WriteLine("Bem vindo a Projeto de Pizzaria");
Menu();