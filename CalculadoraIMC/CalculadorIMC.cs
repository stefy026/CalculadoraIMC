using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraIMC
{
    /// <summary>
    /// Clase que implementa el cálculo del Índice de Masa Corporal (IMC)
    /// Hereda de PersonaSalud y aplica la fórmula: IMC = peso / altura²
    /// </summary>
    public class CalculadorIMC : PersonaSalud
    {
        // Constructor que recibe nombre, peso y altura
        public CalculadorIMC(string nombre, double peso, double altura)
            : base(nombre, peso, altura)
        {
        }

        /// <summary>
        /// Calcula el IMC usando la fórmula estándar
        /// Fórmula: IMC = peso / (altura * altura)
        /// </summary>
        /// <returns>Valor del IMC calculado</returns>
        public override double CalcularIndice()
        {
            return peso / (altura * altura);
        }

        /// <summary>
        /// Clasifica el IMC según los estándares de la OMS
        /// </summary>
        /// <returns>Clasificación del IMC como texto</returns>
        public override string ObtenerClasificacion()
        {
            double imc = CalcularIndice();

            if (imc < 18.5)
                return "Bajo peso";
            else if (imc >= 18.5 && imc < 25)
                return "Peso normal";
            else if (imc >= 25 && imc < 30)
                return "Sobrepeso";
            else if (imc >= 30 && imc < 35)
                return "Obesidad Grado I";
            else if (imc >= 35 && imc < 40)
                return "Obesidad Grado II";
            else
                return "Obesidad Grado III (mórbida)";
        }

        /// <summary>
        /// Obtiene recomendaciones según la clasificación del IMC
        /// </summary>
        /// <returns>Recomendación de salud personalizada</returns>
        public string ObtenerRecomendaciones()
        {
            double imc = CalcularIndice();

            if (imc < 18.5)
                return "Se recomienda aumentar la ingesta calórica y consultar a un nutricionista.";
            else if (imc >= 18.5 && imc < 25)
                return "¡Excelente! Mantén tu estilo de vida saludable.";
            else if (imc >= 25 && imc < 30)
                return "Considera una dieta balanceada y aumentar la actividad física.";
            else
                return "Es importante consultar con un médico y nutricionista para un plan personalizado.";
        }
    }
}

