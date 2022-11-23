using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace Tp3
{
    internal class GestionBD
    {
        MySqlConnection con;
        static GestionBD gestionBD = null;
        public GestionBD()
        {
            this.con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_eq14;Uid=1979090;Pwd=1979090;");
        }

        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }

        public int addEmploye(Employe e)
        {
            try
            {

                string matricule = e.Matricule;
                string nom = e.Nom;
                string prenom = e.Prenom;

                int retour = 0;

                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into employe values(@matricule, @nom, @prenom) ";


                commande.Parameters.AddWithValue("@matricule", e.Matricule);
                commande.Parameters.AddWithValue("@nom", e.Nom);
                commande.Parameters.AddWithValue("@prenom", e.Prenom);

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();
                return retour;
            }
            catch (MySqlException ex)
            {
                con.Close();
                return 0;
            }

        }

        public int addProjet(Projet p)
        {
            try
            {

                string numero = p.Numero;
                string debut = p.Date;
                string description = p.Description;
                string employe = p.Employe;
                int budget = p.Budget;


                int retour = 0;

                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "insert into projet values(@numero, @date, @descriotion,@employe,@budget) ";


                commande.Parameters.AddWithValue("@numero", p.Numero);
                commande.Parameters.AddWithValue("@date", p.Date);
                commande.Parameters.AddWithValue("@description", p.Description);
                commande.Parameters.AddWithValue("@employe", p.Employe);
                commande.Parameters.AddWithValue("@budget", p.Budget);

                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();
                return retour;
            }
            catch (MySqlException ex)
            {
                con.Close();
                return 0;
            }

        }

        ObservableCollection<Projet> listeProjets = new ObservableCollection<Projet>();
        ObservableCollection<Employe> listeEmployes = new ObservableCollection<Employe>();

        public ObservableCollection<Projet> GetProjets()
        {
            try
            {
            listeProjets.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from projet";
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();

                MySqlDataReader r = commande.ExecuteReader();
                while (r.Read() == true)
                {
                    Projet unProjet = new Projet()
                    {
                        Numero = r.GetString("numero"),
                        Date = r.GetString("debut"),
                        Budget = r.GetInt32("budget"),
                        Description = r.GetString("description"),
                        Employe = r.GetString("employe")

                    };

                    listeProjets.Add(unProjet);
                }

                r.Close();
                con.Close();

                return listeProjets;
            }
            catch(MySqlException ex)
            {
                return listeProjets;
                con.Close();
            }
        }


        public void SearchEmploye(String s)
        {

            listeProjets.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from employe where nom ='" + s + "'";
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read() == true)
            {
                Employe unEmploye = new Employe()
                {
                    Matricule = r.GetString("matricule"),
                    Nom = r.GetString("nom"),
                    Prenom = r.GetString("prenom")
                    
                };

                listeEmployes.Add(unEmploye);
            }

            r.Close();
            con.Close();

            ;
        }


        public void SearchProjet(String s)
        {

            listeProjets.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from projet where debut ='" + s + "'";
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read() == true)
            {
                Projet unProjet = new Projet()
                {
                    Numero = r.GetString("numero"),
                    Date = r.GetString("debut"),
                    Budget = r.GetInt32("budget"),
                    Description = r.GetString("description"),
                    Employe = r.GetString("employe")

                };

                listeProjets.Add(unProjet);
            }

            r.Close();
            con.Close();

            ;
        }





    }
}
