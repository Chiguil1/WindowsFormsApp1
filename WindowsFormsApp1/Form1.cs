using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Empleados> emple = new List<Empleados>();
        List<Asistencias> asis = new List<Asistencias>();
        List<Reportes> repor = new List<Reportes>();
        public Form1()
        {
            InitializeComponent();
        }

        private void mostrarEmpleados() {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = emple;
            dataGridView1.Refresh();
        }

        private void mostrarAsistencias() {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = asis;
            dataGridView2.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarEmpleados();
            cargarAsistencia();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "NumEmpleado";
            comboBox1.DataSource = emple;
            label1.Visible = false;
            label2.Visible = false;
        }
        public void cargarEmpleados() {
            string fileName = "empleado.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Empleados empleado = new Empleados();
                empleado.NumEmpleado = Convert.ToInt16(reader.ReadLine());
                empleado.Nombre = reader.ReadLine();
                empleado.SueldoHora = Convert.ToDecimal(reader.ReadLine());

                emple.Add(empleado);
            }

            reader.Close();
        }

        public void cargarAsistencia() {
            string fileName = "asistencia.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while(reader.Peek() > -1)
            {
                Asistencias asistencias = new Asistencias();
                asistencias.NoEmpelado = Convert.ToInt16(reader.ReadLine());
                asistencias.HoraMes = Convert.ToInt16(reader.ReadLine());
                asistencias.Mes = Convert.ToInt16(reader.ReadLine());

                asis.Add(asistencias);
            }

            reader.Close();
        }

        private void sueldos() {
            foreach (Empleados empleado in emple) {
                foreach (Asistencias asistencia in asis) {
                    if (empleado.NumEmpleado == asistencia.NoEmpelado) { 
                        Reportes reporte = new Reportes();
                        reporte.NombreEmpleado = empleado.Nombre;
                        reporte.Meses = asistencia.Mes;
                        reporte.SueldoMensual = empleado.SueldoHora * asistencia.HoraMes;

                        repor.Add(reporte);
                    }
                }
            }
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = repor;
            dataGridView3.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //cargarEmpleados();
            //cargarAsistencia();
            mostrarEmpleados();
            mostrarAsistencias();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sueldos();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numEmpleado = Convert.ToInt32(comboBox1.SelectedValue);

            Empleados empleadoEncontrado = emple.Find(c => c.NumEmpleado == numEmpleado);
            Asistencias asistenciaEncontrado = asis.Find(c => c.NoEmpelado == numEmpleado);

            decimal sueldo = empleadoEncontrado.SueldoHora * asistenciaEncontrado.HoraMes;

            label1.Text = empleadoEncontrado.Nombre;
            label2.Text = sueldo.ToString();
            label1.Visible = true;
            label2.Visible = true;

        }

    }
}
