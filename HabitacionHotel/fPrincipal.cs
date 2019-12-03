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
        public fPrincipal()
        {
            InitializeComponent();
        }

        int[,] aHabitaciones = new int[5, 8];
        Random random = new Random();

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
            Sortear();

            for (int fila = 0; fila < aHabitaciones.GetLength(0); fila++)
            {
                for (int columna = 0; columna < aHabitaciones.GetLength(1); columna++)
                {
                    Console.WriteLine(aHabitaciones[fila, columna]);
                }

                }
        }

        private void Sortear()
        {
            if (rbtSencilla.Checked)
            {
                int filaRandom = random.Next(5);
                int columnaRandom = random.Next(0, 2);

                ComprobarHabitacion(filaRandom, columnaRandom);
            }
            else if (rbtDobre.Checked)
            {
                int filaRandom = random.Next(5);
                int columnaRandom = random.Next(2, 6);

                ComprobarHabitacion(filaRandom, columnaRandom);
            }
            else if (rbtSuite.Checked)
            {
                int filaRandom = random.Next(5);
                int columnaRandom = random.Next(6, 8);

                ComprobarHabitacion(filaRandom, columnaRandom);
            }

        }

        private void ComprobarHabitacion(int filaGenerada, int columnaGenerada)
        {
            for (int fila = 0; fila < aHabitaciones.GetLength(0); fila++)
            {
                for (int columna = 0; columna < aHabitaciones.GetLength(1); columna++)
                {
                    if (aHabitaciones[filaGenerada, columnaGenerada] == 0)
                    {
                        aHabitaciones[filaGenerada, columnaGenerada] = 1;
                        MarcarHabitacion(filaGenerada, columnaGenerada);
                    }
                    else
                    {
                        
                    }
                    
                }
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

        }
    }
}
