using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraIMC
{
    // ===================================================================
    // FASE 4: PRUEBAS - Formulario de interfaz gráfica
    // ===================================================================
    /// <summary>
    /// Formulario principal para la aplicación de cálculo de IMC
    /// Implementa la interfaz gráfica y maneja los eventos del usuario
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento para calcular el IMC cuando se presiona el botón
        /// </summary>
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("Por favor, ingrese el nombre.", "Campo requerido",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Convertir y validar los valores numéricos
                double peso = Convert.ToDouble(txtPeso.Text);
                double altura = Convert.ToDouble(txtAltura.Text);

                // Crear instancia del calculador de IMC
                CalculadorIMC calculador = new CalculadorIMC(txtNombre.Text, peso, altura);

                // Calcular y mostrar resultados
                double imc = calculador.CalcularIndice();
                string clasificacion = calculador.ObtenerClasificacion();
                string recomendaciones = calculador.ObtenerRecomendaciones();

            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos para peso y altura.",
                    "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("La altura no puede ser cero.", "Error de cálculo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Limpia todos los campos del formulario
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtPeso.Clear();
            txtAltura.Clear();
            gbResultados.Visible = false;
            txtNombre.Focus();
        }

        /// <summary>
        /// Determina el color de la etiqueta según el valor del IMC
        /// </summary>
        private Color ObtenerColorClasificacion(double imc)
        {
            if (imc < 18.5)
                return Color.FromArgb(52, 152, 219);  // Azul - Bajo peso
            else if (imc >= 18.5 && imc < 25)
                return Color.FromArgb(46, 204, 113);  // Verde - Normal
            else if (imc >= 25 && imc < 30)
                return Color.FromArgb(241, 196, 15);  // Amarillo - Sobrepeso
            else
                return Color.FromArgb(231, 76, 60);   // Rojo - Obesidad
        }
    }
}
