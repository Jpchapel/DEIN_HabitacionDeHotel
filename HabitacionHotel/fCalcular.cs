using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HabitacionHotel
{
    public partial class fCalcular : Form
    {
        int[,] aHabitaciones = new int[5, 8];

        int precioSimple = 0;
        int precioDoble = 0;
        int precioSuite = 0;

        public fCalcular(int[,] aHabitaciones)
        {
            InitializeComponent();
            this.aHabitaciones = aHabitaciones;
        }

        private void fCalcular_Load(object sender, EventArgs e)
        {
            for (int fila = 0; fila < aHabitaciones.GetLength(0); fila++)
            {
                for (int columna = 0; columna < aHabitaciones.GetLength(1); columna++)
                {
                    if (aHabitaciones[fila, columna] == 1)
                    {
                        if (columna < 2)
                        {
                            precioSimple += 10;
                        }
                        else if (columna >= 2 && columna < 6)
                        {
                            precioDoble += 20;
                        }
                        else if (columna >= 6 && columna < 8)
                        {
                            precioSuite += 30;
                        }
                    }

                }
            }

            VisualizarPrecio();
        }

        private void VisualizarPrecio()
        {
            lblSinxela.Text = Convert.ToString(precioSimple);
            lblDobre.Text = Convert.ToString(precioDoble);
            lblSuite.Text = Convert.ToString(precioSuite);
        }
    }
}
