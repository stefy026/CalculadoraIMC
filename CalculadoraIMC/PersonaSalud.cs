using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraIMC
{
    // ===================================================================
    // FASE 1: ANÁLISIS - Clase base para cálculos médicos
    // ===================================================================
    /// <summary>
    /// Clase base abstracta que encapsula los datos de una persona
    /// para cálculos relacionados con salud
    /// </summary>
    public abstract class PersonaSalud
    {
        // Campos protected - accesibles solo por clases derivadas
        protected double peso;      // Peso en kilogramos
        protected double altura;    // Altura en metros
        protected string nombre;    // Nombre de la persona

        // ===================================================================
        // FASE 2: DISEÑO - Propiedades con validación
        // ===================================================================
        /// <summary>
        /// Propiedad para el peso con validación
        /// </summary>
        public double Peso
        {
            get { return peso; }
            set
            {
                if (value > 0 && value < 500)
                    peso = value;
                else
                    throw new ArgumentException("El peso debe estar entre 0 y 500 kg");
            }
        }

        /// <summary>
        /// Propiedad para la altura con validación
        /// </summary>
        public double Altura
        {
            get { return altura; }
            set
            {
                if (value > 0 && value < 3)
                    altura = value;
                else
                    throw new ArgumentException("La altura debe estar entre 0 y 3 metros");
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        // Constructor protegido - solo accesible por clases derivadas
        protected PersonaSalud(string nombre, double peso, double altura)
        {
            this.nombre = nombre;
            this.Peso = peso;
            this.Altura = altura;
        }

        // Métodos abstractos - deben ser implementados por clases derivadas
        public abstract double CalcularIndice();
        public abstract string ObtenerClasificacion();
    }
}

