using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Tp3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageAffichageEmploye1 : Page
    {
        public PageAffichageEmploye1()
        {
            this.InitializeComponent();
            lvEmploye.ItemsSource = GestionBD.getInstance().GetEmployes();
        }

        private void toAddEmpPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddEmploye));
        }

        private void empSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvEmploye.ItemsSource = GestionBD.getInstance().SearchEmploye(empSearchBox.Text);
        }

        private void toggleSearch_Click(object sender, RoutedEventArgs e)
        {
            if (empSearchBox.Visibility == Visibility.Collapsed)
            {
                empSearchBox.Visibility = Visibility.Visible;
                toggleSearch.Content = "Fermer recherche";
            }
            else
            {
                empSearchBox.Visibility = Visibility.Collapsed;
                toggleSearch.Content = "Rechercher";
                lvEmploye.ItemsSource = GestionBD.getInstance().GetEmployes();
            } 
        }
    }
}
