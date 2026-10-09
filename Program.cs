using System;

namespace Ejercicio1_MotorDC
{
    /// <summary>
    /// Clase que modela las características y comportamiento de un motor de corriente directa.
    /// </summary>
    public class MotorDC
    {
        // PROPIEDADES (Atributos de la clase)
        public string Identificador { get; set; } // Identificador o nombre del motor
        public double Voltaje { get; set; }     // Voltaje de alimentación en Voltios (V)
        public double Corriente { get; set; }   // Corriente consumida en Amperios (A)

        /// <summary>
        /// Constructor para inicializar un objeto de la clase MotorDC.
        /// </summary>
        public MotorDC(string identificador, double voltaje, double corriente)
        {
            Identificador = identificador;
            Voltaje = voltaje;
            Corriente = corriente;
        }

        /// <summary>
        /// Método que calcula la potencia eléctrica consumida mediante P = V * I.
        /// </summary>
        /// <returns>Potencia eléctrica en Watts (W)</returns>
        public double CalcularPotencia()
        {
            return Voltaje * Corriente;
        }

        /// <summary>
        /// Método para evaluar si el consumo es normal (<= 120 W) o elevado (> 120 W).
        /// </summary>
        /// <returns>Cadena con el dictamen de consumo</returns>
        public string EvaluarConsumo()
        {
            double potencia = CalcularPotencia();
            if (potencia <= 120.0)
            {
                return "Consumo NORMAL";
            }
            else
            {
                return "Consumo ELEVADO";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("  EJERCICIO 1: EVALUACIÓN DE CONSUMO EN MOTOR DC");
            Console.WriteLine("====================================================\n");

            // Lectura del identificador del motor
            Console.Write("Ingrese el identificador del motor: ");
            string id = Console.ReadLine();

            // Lectura y validación de entrada para el voltaje
            double voltaje;
            Console.Write("Ingrese el voltaje de alimentación (V): ");
            while (!double.TryParse(Console.ReadLine(), out voltaje) || voltaje < 0)
            {
                Console.Write("Valor inválido. Ingrese un voltaje válido en Voltios (V): ");
            }

            // Lectura y validación de entrada para la corriente
            double corriente;
            Console.Write("Ingrese la corriente consumida (A): ");
            while (!double.TryParse(Console.ReadLine(), out corriente) || corriente < 0)
            {
                Console.Write("Valor inválido. Ingrese una corriente válida en Amperios (A): ");
            }

            // CREACIÓN DEL OBJETO (Instanciación de la clase MotorDC)
            MotorDC motor = new MotorDC(id, voltaje, corriente);

            // Invocación de métodos del objeto
            double potencia = motor.CalcularPotencia();
            string resultado = motor.EvaluarConsumo();

            // Despliegue de resultados con sus respectivas unidades
            Console.WriteLine("\n---------------- RESULTADOS ----------------");
            Console.WriteLine($"Motor Evaluado:        {motor.Identificador}");
            Console.WriteLine($"Voltaje Aplicado:      {motor.Voltaje:F2} V");
            Console.WriteLine($"Corriente Consumida:   {motor.Corriente:F2} A");
            Console.WriteLine($"Potencia Calculada:    {potencia:F2} W");
            Console.WriteLine($"Estado de Consumo:     {resultado}");
            Console.WriteLine("--------------------------------------------");
        }
    }
}