using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Reportes
    {
        string nombreEmpleado;
        int meses;
        decimal sueldoMensual;

        public string NombreEmpleado { get => nombreEmpleado; set => nombreEmpleado = value; }
        public int Meses { get => meses; set => meses = value; }
        public decimal SueldoMensual { get => sueldoMensual; set => sueldoMensual = value; }
    }
}
