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
using System.Security.Cryptography.X509Certificates;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Tp3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageAjoutProjet : Page
    {
        public PageAjoutProjet()
        {
            this.InitializeComponent();
            datePicker.SelectedDate = DateTimeOffset.Now;
        }

        private void ButAjoutProjet_Click(object sender, RoutedEventArgs e)
        {
            

            bool valide = true;
            reset();

            if(Description.Text.Length == 0) 
            {
                valide = false;
                tblErreurDescription.Visibility = Visibility.Visible;
            }
            if(Budget.Text.Length == 0)
            {
                valide = false;
                tblErreurBudget.Visibility = Visibility.Visible;
            }
            if(Numero.Text.Length == 0)
            {
                valide = false;
                tblErreurNumero.Visibility = Visibility.Visible;
            }
            if(tblEmploye.Text.Length == 0)
            {
                tblErreurEmploye.Visibility = Visibility.Visible;
            }


            
            

            if(valide == true)
            {
                setInfo();
                this.Frame.Navigate(typeof(PageAffichageProjets1));
            }


            



        }

        public int validateBudg()
        {
            int prixBudg = 0;
            try
            {
                prixBudg = Convert.ToInt32(Budget.Text);
                return prixBudg;
            }
            catch (Exception ex)
            {
                return prixBudg;
            }
        }


            public void setInfo()
        {
            Projet p = new Projet()
            {
                Numero = Numero.Text,
                Date = datePicker.Date.Date.ToString("yyyy-MM-dd"),
                Description = Description.Text,
                Budget = validateBudg(),
                Employe = tblEmploye.Text,
            };
            GestionBD.getInstance().addProjet(p);
        }




        public void reset()
        {
            tblErreurBudget.Visibility = Visibility.Collapsed;
            tblErreurDate.Visibility = Visibility.Collapsed;
            tblErreurDescription.Visibility = Visibility.Collapsed;
            tblErreurEmploye.Visibility = Visibility.Collapsed;
            tblErreurNumero.Visibility = Visibility.Collapsed;
        }
    }
}
