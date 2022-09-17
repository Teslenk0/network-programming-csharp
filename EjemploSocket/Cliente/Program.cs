// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Iniciando cliente");

var socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

socketClient.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000));

Console.WriteLine("Cliente conectado");


while (true)
{
    Console.WriteLine("Escribe un mensaje");
    
    string mensaje = Console.ReadLine();

    if(mensaje.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
    {
        break;
    }

    byte[] data = Encoding.UTF8.GetBytes(mensaje);

    socketClient.Send(data);
}

Console.ReadLine();

socketClient.Shutdown(SocketShutdown.Both);

socketClient.Close();