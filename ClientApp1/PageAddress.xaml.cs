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

namespace ClientApp1
{
    /// <summary>
    /// Логика взаимодействия для PageAddress.xaml
    /// </summary>
    public partial class PageAddress : Page
    {
        public PageAddress()
        {
            InitializeComponent();
        }
        Socket socket; ClientData clientData = new ClientData();
        private void Button_Clik(object sender, RoutedEventArgs e)
        {
            clientData.Address = address.Text;
            clientData.Port = int.Parse(port.Text);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(clientData.Address), clientData.Port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientData.SocketConnect = socket;
                if (!socket.Connected)
                {
                socket.Close();
                }
               else
               {
                socket.Close();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }

        }
    }
}
