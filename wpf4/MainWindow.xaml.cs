using System;
using System.Collections.Generic;
using System.Linq;
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
using wpf4.Entity;
using wpf4.Classes;

namespace wpf4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    
    class AgentsInfo
    {
        public AgentsInfo(string type, string agentName, int countSale, string phone, int pririty)
        {
            this.type = type;
            this.agentName = agentName;
            this.countSale = countSale;
            Phone = phone;
            this.priority = pririty;
        }

        public string type { get; set; }
        public string agentName { get; set; }
        public int countSale { get; set; }
        public string Phone { get; set; }
        public int priority { get; set; }
        public Image ImagePreview { get; set; }


    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            mainFrame.Navigate(new AgentsView());
            Manager.MainFrame = mainFrame;
        }
    }
}
