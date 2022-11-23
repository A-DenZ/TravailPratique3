using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp3
{
    internal class Projet
    {
        string numero;
        string date;
        int budget;
        string description;
        string employe;

        public string Numero { get => numero; set => numero = value; }
        public string Date { get => date; set => date = value; }
        public int Budget { get => budget; set => budget = value; }
        public string Description { get => description; set => description = value; }
        public string Employe { get => employe; set => employe = value; }
    }
}
