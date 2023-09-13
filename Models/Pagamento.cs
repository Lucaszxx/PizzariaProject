namespace PizzariaProject.Models;

public class Pagamento {
    public double Valor {get; private set;}
    public double Troco {get; private set;}
    public string TipoPagamento {get; set;}
}