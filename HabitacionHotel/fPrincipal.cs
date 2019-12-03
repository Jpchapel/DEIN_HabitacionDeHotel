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
    public partial class fPrincipal : Form
    {

        int[,] aHabitaciones = new int[5, 8];

        Random random = new Random();

        int contadorSimple = 0;
        int contadorDoble = 0;
        int contadorSuite = 0;

        public fPrincipal()
        {
            InitializeComponent();
        }

        private void nudNumeroPersoas_ValueChanged(object sender, EventArgs e)
        {
            if (nudNumeroPersoas.Value == 2)
            {
                rbtSencilla.Enabled = false;
                rbtDobre.Checked = true;
            }
            else
            {
                rbtSencilla.Enabled = true;
                rbtSencilla.Checked = true;
                rbtDobre.Checked = false;
            }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            ComprobarHabitacion();
        }

        private void ComprobarHabitacion()
        {
            bool ocupada = false;

            do
            {
                int filaRandom = random.Next(5);
                int columnaRandom = random.Next(8);

                if ((columnaRandom < 2) && (rbtSencilla.Checked))
                {
                    if (aHabitaciones[filaRandom, columnaRandom] == 0)
                    {
                        aHabitaciones[filaRandom, columnaRandom] = 1;

                        MarcarHabitacion(filaRandom, columnaRandom);

                        ocupada = true;

                        contadorSimple++;
                    }
                    else
                    {
                        ocupada = false;
                    }
                }
                else if ((columnaRandom >= 2 && columnaRandom < 6) && (rbtDobre.Checked))
                {
                    if (aHabitaciones[filaRandom, columnaRandom] == 0)
                    {
                        aHabitaciones[filaRandom, columnaRandom] = 1;

                        MarcarHabitacion(filaRandom, columnaRandom);

                        ocupada = true;

                        contadorDoble++;
                    }
                    else
                    {
                        ocupada = false;
                    }
                }
                else if ((columnaRandom >= 6 && columnaRandom < 8) && (rbtSuite.Checked))
                {
                    if (aHabitaciones[filaRandom, columnaRandom] == 0)
                    {
                        aHabitaciones[filaRandom, columnaRandom] = 1;

                        MarcarHabitacion(filaRandom, columnaRandom);

                        ocupada = true;

                        contadorSuite++;
                    }
                    else
                    {
                        ocupada = false;
                    }
                }

                ComprobarContadores();

            } while (!ocupada);

            
        }

        private void ComprobarContadores()
        {
            if (contadorSimple == 10)
            {
                MessageBox.Show("Habitaciones Simples llenas", "Habitaciones llenas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rbtSencilla.Visible = false;
                contadorSimple = 0;
            }
            else if (contadorDoble == 20)
            {
                MessageBox.Show("Habitaciones Dobles llenas", "Habitaciones llenas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rbtDobre.Visible = false;
                contadorDoble = 0;
            }
            else if (contadorSuite == 10)
            {
                MessageBox.Show("Habitaciones Suites llenas", "Habitaciones llenas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rbtSuite.Visible = false;
                contadorSuite = 0;
            }
        }

        private void MarcarHabitacion(int filas, int columnas)
        {
            String filaString = Convert.ToString(filas);
            String columnaString = Convert.ToString(columnas);

            foreach (Control item in Controls)
            {
                if (item.Name.Contains(filaString + columnaString) && item.Text.Equals(""))
                {
                    item.Text = "X";
                }
            }
        }

        private void bt_verImporte_Click(object sender, EventArgs e)
        {
            fCalcular formularioCalcular = new fCalcular(aHabitaciones);
            formularioCalcular.ShowDialog();
        }
    }
}
