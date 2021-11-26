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
using wpf4.Classes;
using wpf4.Entity;

namespace wpf4
{
    /// <summary>
    /// Логика взаимодействия для AgentsView.xaml
    /// </summary>
    public partial class AgentsView : Page
    {
        public AgentsView()
        {
            InitializeComponent();

        }

        private void filterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayAgents();
        }

        private void DisplayAgents()
        {
            var Agents = rpm_secondEntities.GetContext().Agent.ToList();

            if (filterBox.SelectedIndex > 0)
            {
                Agents = Agents.Where(p => p.AgentType.Title == filterBox.SelectedItem.ToString()).ToList();
            }

            if (findText.Text.Length > 0)
            {
                Agents = Agents.Where(p => p.Title.Contains(findText.Text) || p.Email.Contains(findText.Text) || p.Phone.Contains(findText.Text)).ToList();
            }

            foreach (var agent in Agents)
            {
                agent.ProductCount = agent.ProductSale.Where(p => p.SaleDate.Year == DateTime.Now.Year).Sum(p => p.ProductCount);
            }

            agentsList.ItemsSource = Agents;
        }

        private void findText_TextChanged(object sender, TextChangedEventArgs e)
        {
            DisplayAgents();
        }

        private void agentsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = agentsList.SelectedItem as Agent;
            if (item != null)
            {
                Manager.MainFrame.Navigate(new EditAgent(item));
            }
        }

        private void CreateAgentButton_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditAgent(null));
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            var types = rpm_secondEntities.GetContext().AgentType.ToList().Select(p => p.Title).ToList();

            types.Insert(0, "Все типы");

            filterBox.ItemsSource = types;

            DisplayAgents();
        }
    }
}
