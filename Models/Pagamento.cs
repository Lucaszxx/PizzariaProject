using System;
using System.Collections.Generic;

namespace PizzariaProject.Models
{
    public class Pagamento
    {
        public double Valor { get; private set; }
        public double Troco { get; private set; }
        public int TipoPagamento { get; set; }
        public List<string> TiposPagamento = new List<string>();
        public double Faltante { get; set; }
        public List<Pedido> pedidos = new List<Pedido>();

        public List<Pedido> EfetuarPagamento(List<Pedido> pedidos)
        {
            Console.WriteLine("Qual é o número do pedido:");
            foreach (var pedido in pedidos)
            {
                Console.WriteLine($"#{pedido.Id} - Cliente: {pedido.NomeCliente} - Faltante: R${pedido.Restante:F2}");
            }
            int pedidoSelecionado = int.Parse(Console.ReadLine());

            var pedidoPagante = pedidos.Find(pedido => pedido.Id == pedidoSelecionado);

            if (pedidoPagante == null)
            {
                Console.WriteLine("Pedido não encontrado. Pagamento cancelado.");
                return pedidos;
            }
            else if (pedidoPagante.Restante == 0)
            {
                Console.WriteLine("O pedido já foi completamente pago");
                return pedidos;
            }
            else
            {
                // Verificar o número de tipos de pagamento diferentes já usados
                if (pedidoPagante.TiposPagos.Count >= 2)
                {
                    // Console.WriteLine("Você já usou dois tipos diferentes de pagamento para este pedido. Não é possível adicionar mais.");
                    // return pedidos;

                    if (pedidoPagante.TiposPagos.Contains("Dinheiro") && pedidoPagante.TiposPagos.Contains("Cartão") || pedidoPagante.TiposPagos.Contains("Dinheiro") && pedidoPagante.TiposPagos.Contains("Vale") || pedidoPagante.TiposPagos.Contains("Cartão") && pedidoPagante.TiposPagos.Contains("Vale"))
                    {
                        Console.WriteLine("Você já usou dois tipos diferentes de pagamento para este pedido. Não é possível adicionar mais.");
                        return pedidos;
                    }
                }

                Console.WriteLine("Escolha a forma de pagamento:");
                Console.WriteLine("1 - Dinheiro");
                Console.WriteLine("2 - Cartão de Débito");
                Console.WriteLine("3 - Vale-Refeição");
                TipoPagamento = int.Parse(Console.ReadLine());

                if (TipoPagamento == 1) // Pagamento Dinheiro
                {
                    Console.WriteLine("Qual o valor (no formato 00.00): ");
                    double valorPago = double.Parse(Console.ReadLine());
                    pedidoPagante.TiposPagos.Add("Dinheiro");

                    if (valorPago <= 0)
                    {
                        Console.WriteLine("Valor inválido. Pagamento cancelado.");
                        return pedidos;
                    }
                    else if (valorPago > pedidoPagante.Restante)
                    {
                        pedidoPagante.Restante -= valorPago;
                        Troco = pedidoPagante.Restante;
                        pedidoPagante.Pago = true;
                        pedidoPagante.StatusPago = pedidoPagante.PagoTransform(pedidoPagante.Pago);
                        pedidoPagante.Restante = 0;
                        Troco = Math.Abs(Troco);
                        Console.WriteLine($"VALOR RECEBIDO COM SUCESSO\n");
                        Console.WriteLine($"TOTAL PAGO: {valorPago:F2} - ({ConverteTipoPagamento(TipoPagamento)})");
                        Console.WriteLine($"FALTA: R${pedidoPagante.Restante:F2}");
                        Console.WriteLine($"TROCO: {Troco:F2}");
                        Console.WriteLine($"PAGO: {pedidoPagante.StatusPago}");
                        return pedidos;
                    }
                    else if (valorPago < pedidoPagante.Restante)
                    {
                        pedidoPagante.Restante -= valorPago;
                        pedidoPagante.Pago = false;
                        pedidoPagante.StatusPago = pedidoPagante.PagoTransform(pedidoPagante.Pago);
                        Console.WriteLine($"VALOR RECEBIDO COM SUCESSO\n");
                        Console.WriteLine($"TOTAL PAGO: {valorPago:F2} - ({ConverteTipoPagamento(TipoPagamento)})");
                        Console.WriteLine($"FALTA: R${pedidoPagante.Restante:F2}");
                        Console.WriteLine($"TROCO: {Troco:F2}");
                        Console.WriteLine($"PAGO: {pedidoPagante.StatusPago}");
                        foreach (var tipoPago in pedidoPagante.TiposPagos)
                        {
                            Console.WriteLine(tipoPago);
                        }
                        return pedidos;
                    }
                    else if (valorPago == pedidoPagante.Restante)
                    {
                        pedidoPagante.Restante -= valorPago;
                        pedidoPagante.Pago = true;
                        pedidoPagante.StatusPago = pedidoPagante.PagoTransform(pedidoPagante.Pago);
                        Console.WriteLine($"VALOR RECEBIDO COM SUCESSO\n");
                        Console.WriteLine($"TOTAL PAGO: {valorPago:F2} - ({ConverteTipoPagamento(TipoPagamento)})");
                        Console.WriteLine($"FALTA: R${pedidoPagante.Restante:F2}");
                        Console.WriteLine($"TROCO: {Troco:F2}");
                        Console.WriteLine($"PAGO: {pedidoPagante.StatusPago}");
                        foreach (var tipoPago in pedidoPagante.TiposPagos)
                        {
                            Console.WriteLine(tipoPago);
                        }
                        return pedidos;
                    }
                    else
                    {
                        return pedidos;
                    }
                }
                else if (TipoPagamento == 2) // Pagamento via Cartão
                {
                    Console.WriteLine("Qual o valor (no formato 00,00): ");
                    double valorPago = double.Parse(Console.ReadLine());
                    pedidoPagante.TiposPagos.Add("Cartão");

                    if (valorPago <= 0)
                    {
                        Console.WriteLine("Valor inválido. Pagamento cancelado.");
                        return pedidos;
                    }
                    else if (valorPago > pedidoPagante.Restante)
                    {
                        Console.WriteLine("ERRO! O valor é maior do que o preço do pedido!");
                        return pedidos;
                    }
                    else if (valorPago < pedidoPagante.Restante)
                    {
                        pedidoPagante.Restante -= valorPago;
                        pedidoPagante.Pago = false;
                        pedidoPagante.StatusPago = pedidoPagante.PagoTransform(pedidoPagante.Pago);
                        Console.WriteLine($"VALOR RECEBIDO COM SUCESSO\n");
                        Console.WriteLine($"TOTAL PAGO: {valorPago:F2} - ({ConverteTipoPagamento(TipoPagamento)})");
                        Console.WriteLine($"FALTA: R${pedidoPagante.Restante:F2}");
                        Console.WriteLine($"PAGO: {pedidoPagante.StatusPago}");
                        foreach (var tipoPago in pedidoPagante.TiposPagos)
                        {
                            Console.WriteLine(tipoPago);
                        }
                        return pedidos;
                    }
                    else if (valorPago == pedidoPagante.Restante)
                    {
                        pedidoPagante.Restante -= valorPago;
                        pedidoPagante.Pago = true;
                        pedidoPagante.StatusPago = pedidoPagante.PagoTransform(pedidoPagante.Pago);
                        Console.WriteLine($"VALOR RECEBIDO COM SUCESSO\n");
                        Console.WriteLine($"TOTAL PAGO: {valorPago:F2} - ({ConverteTipoPagamento(TipoPagamento)})");
                        Console.WriteLine($"FALTA: R${pedidoPagante.Restante:F2}");
                        Console.WriteLine($"PAGO: {pedidoPagante.StatusPago}");
                        foreach (var tipoPago in pedidoPagante.TiposPagos)
                        {
                            Console.WriteLine(tipoPago);
                        }
                        return pedidos;
                    }
                    else
                    {
                        return pedidos;
                    }
                }
                else if (TipoPagamento == 3) // Pagamento via Vale Refeição
                {
                    Console.WriteLine("Qual o valor (no formato 00.00): ");
                    double valorPago = double.Parse(Console.ReadLine());
                    pedidoPagante.TiposPagos.Add("Vale");

                    if (valorPago <= 0)
                    {
                        Console.WriteLine("Valor inválido. Pagamento cancelado.");
                        return pedidos;
                    }
                    else if (valorPago > pedidoPagante.Restante)
                    {
                        Console.WriteLine("ERRO! O valor é maior do que o preço do pedido!");
                        return pedidos;
                    }
                    else if (valorPago < pedidoPagante.Restante)
                    {
                        pedidoPagante.Restante -= valorPago;
                        pedidoPagante.Pago = false;
                        pedidoPagante.StatusPago = pedidoPagante.PagoTransform(pedidoPagante.Pago);
                        Console.WriteLine($"VALOR RECEBIDO COM SUCESSO\n");
                        Console.WriteLine($"TOTAL PAGO: {valorPago:F2} - ({ConverteTipoPagamento(TipoPagamento)})");
                        Console.WriteLine($"FALTA: R${pedidoPagante.Restante:F2}");
                        Console.WriteLine($"PAGO: {pedidoPagante.StatusPago}");
                        foreach (var tipoPago in pedidoPagante.TiposPagos)
                        {
                            Console.WriteLine(tipoPago);
                        }
                    }
                    else if (valorPago == pedidoPagante.Restante)
                    {
                        pedidoPagante.Restante -= valorPago;
                        pedidoPagante.Pago = true;
                        pedidoPagante.StatusPago = pedidoPagante.PagoTransform(pedidoPagante.Pago);
                        Console.WriteLine($"VALOR RECEBIDO COM SUCESSO\n");
                        Console.WriteLine($"TOTAL PAGO: {valorPago:F2} - ({ConverteTipoPagamento(TipoPagamento)})");
                        Console.WriteLine($"FALTA: R${pedidoPagante.Restante:F2}");
                        Console.WriteLine($"PAGO: {pedidoPagante.StatusPago}");
                        foreach (var tipoPago in pedidoPagante.TiposPagos)
                        {
                            Console.WriteLine(tipoPago);
                        }
                        return pedidos;
                    }
                    else
                    {
                        return pedidos;
                    }
                }
                else
                {
                    Console.WriteLine("Opção Inexistente");
                }
            }
            return pedidos;
        }

        private string ConverteTipoPagamento(int tipoPagamento)
        {
            if (tipoPagamento == 1)
            {
                return "DINHEIRO";
            }
            else if (tipoPagamento == 2)
            {
                return "CARTÃO DE CRÉDITO";
            }
            else
            {
                return "VALE-REFEIÇÃO";
            }
        }
    }
}
