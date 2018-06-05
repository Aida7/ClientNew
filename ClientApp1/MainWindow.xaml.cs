using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


//Создать клиент-серверное приложение чат.Чат будет работать ТОЛЬКО ДЛЯ ТРЁХ клиентов.
//Суть проста, клиент построен на постоянном соединении с сервером.
//Когда клиент подключается к серверу, все уже подключенные клиенты об этом узнают (Пользователь N заходит в чат). 
//Отправленное сообщение любым клиентом видно другим клиентам.
//Сообщения передавать в формате json(от кого, сообщение).

//Клиент отправляет данные серверу, сервер рассылает их всем клиентам.


namespace ClientApp1
{
    public partial class MainWindow : Window
    { 
       
        ClientData clientData = new ClientData();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Send_Clik(object sender, RoutedEventArgs e)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(clientData.Address),clientData.Port);
            clientData.SocketConnect = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {

                list.Items.Add("Oтправка сообщения...");
                clientData.SocketConnect.Connect(endPoint);

                ClientData info = new ClientData { Sender = nameUser.Text, Text = text.Text, SentDate = DateTime.Now };
                clientData.SocketConnect.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(info)));
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }

            list.Items.Add(await ReceiveMessage());
        }


        public Task<string> ReceiveMessage()
        {
            string newData;
            return Task.Run(
             () =>
                 {
                     while (true)
                     {
                         int bytes;
                         byte[] data = new byte[1024];
                         bytes = clientData.SocketConnect.Receive(data);
                         newData = Encoding.UTF8.GetString(data, 0, bytes);
                         return newData;
                     }            
              });
        }
    }
}



