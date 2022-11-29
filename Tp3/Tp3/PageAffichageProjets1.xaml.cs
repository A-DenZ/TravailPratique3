using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
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
    public sealed partial class PageAffichageProjets1 : Page
    {
        public PageAffichageProjets1()
        {
            this.InitializeComponent();
            lvProjet.ItemsSource = GestionBD.getInstance().GetProjets();
        }

        private void projSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvProjet.ItemsSource = GestionBD.getInstance().SearchProjet(projSearchBox.Text);
        }

        private void toggleProjSearch_Click(object sender, RoutedEventArgs e)
        {
            if (projSearchBox.Visibility == Visibility.Collapsed)
            {
                projSearchBox.Visibility = Visibility.Visible;
                toggleProjSearch.Content = "Fermer recherche";
            }
            else
            {
                projSearchBox.Visibility = Visibility.Collapsed;
                toggleProjSearch.Content = "Rechercher";
                lvProjet.ItemsSource = GestionBD.getInstance().GetProjets();
            }
        }

        private void toAddProjPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PageAjoutProjet));
        }
    }
}
