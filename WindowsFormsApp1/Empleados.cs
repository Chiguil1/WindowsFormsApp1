using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Empleados
    {
        int numEmpleado;
        string nombre;
        decimal sueldoHora;

        public int NumEmpleado { get => numEmpleado; set => numEmpleado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal SueldoHora { get => sueldoHora; set => sueldoHora = value; }
    }
}
