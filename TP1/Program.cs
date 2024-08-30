// See https://aka.ms/new-console-template for more information
using System;
int n=0;
Pedido pedido = new Pedido(n, Console.ReadLine(),Console.ReadLine(),Console.ReadLine(),Console.ReadLine(),Console.ReadLine());
int x = 0;

while (x < 10)
{
    Console.WriteLine("----Menu----");
    Console.WriteLine("1. Dar de alta pedidos");
    Console.WriteLine("2. Asignarlos a un Cadete");
    Console.WriteLine("3.Cambiar estado de un pedido");
    Console.WriteLine("4.Reasignar pedido a otro Cadete");

    switch (x)
    {
        case 1:
        Console.WriteLine("Crear nuevo pedido: ");
        Console.ReadLine();
        continue;

        default:
        break;
    }
}