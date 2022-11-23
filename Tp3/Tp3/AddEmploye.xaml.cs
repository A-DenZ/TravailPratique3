using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Tp3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddEmploye : Page
    {
        public AddEmploye()
        {
            this.InitializeComponent();
        }

        private void addEmp_Click(object sender, RoutedEventArgs e)
        {
            // action state message
            string submitMsg = "";

            // input values
            string mat = addMat.Text;
            string fn = addFN.Text;
            string ln = addLN.Text;

            // values validation
            if (mat.Length != 7)
            {
                submitMsg = "Le matricule doit contenir 7 caractères.";
            } else if (fn.Length <= 0) {
                submitMsg = "Veuillez entrer votre prénom.";
            } else if (ln.Length <= 0)
            {
                submitMsg = "Veuillez entrer votre nom de famille.";
            } else
            {
                try
                {
                    // parameter creation
                    Employe emp = new Employe()
                    {
                        Matricule = mat,
                        Nom = ln,
                        Prenom = fn
                    };

                    // form submission
                    GestionBD.getInstance().addEmploye(emp);
                    submitMsg = $"L'employé {mat} à été créé. avec succès.";
                }
                catch (Exception ex)
                {
                    submitMsg = $"Échec de l'ajout de l'employé {mat}.";
                }
            }

            // displaying action state message
            addMsg.Text = submitMsg;
        }
    }
}
