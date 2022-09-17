// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Net.Sockets;
using System.Text;

internal class Program
{

    private const int MAX_CLIENTS = 2;

    public static void Main(string[] args)
    {
        Console.WriteLine("Arrancando servidor");

        var socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        var localEndpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);

        socketServer.Bind(localEndpoint);

        socketServer.Listen(1);

        int counter = 0;

        while (MAX_CLIENTS > counter)
        {
            var socketClient = socketServer.Accept();

            new Thread(() => ManejarCliente(socketClient)).Start();
        }

        Console.ReadLine();

        socketServer.Shutdown(SocketShutdown.Both);

        socketServer.Close();
    }

    public static void ManejarCliente(Socket socketCliente)
    {
        

        try
        {
            Console.WriteLine("Se acepto una nueva conexion");

            while (socketCliente.Connected)
            {
                byte[] data = new byte[1048576];

                socketCliente.Receive(data);

                var parsedData = Encoding.UTF8.GetString(data);

                Console.WriteLine(parsedData);

                socketCliente.Send(data);
            }

            Console.WriteLine("Cliente desconectado");
        }
        catch(SocketException e)
        {
            Console.WriteLine(e.Message);
        }

        
    }
}