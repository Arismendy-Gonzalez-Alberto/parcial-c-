// se pudo con la ayuda de chatgpt, pero aprendi muchas cosas de c# y de la programacion orientada a objetos, y de como hacer un programa que simule un club deportivp


using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubDeportivo
{
    public enum TipoMembresia { Basica, Premium, VIP }

    public class Socio
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public TipoMembresia Membresia { get; set; }
        public int DiasRestantes { get; set; }

        public Socio(int id, string nombre, TipoMembresia membresia, int diasRestantes)
        {
            ID = id;
            Nombre = nombre;
            Membresia = membresia;
            DiasRestantes = diasRestantes;
        }

        public bool IntentarAcceso(out string mensaje)
        {
            if (DiasRestantes <= 0)
            {
                mensaje = $"Acceso DENEGADO. {Nombre} no tiene días vigentes (Días restantes: {DiasRestantes}).";
                return false;
            }

            string areasPermitidas = "";
            switch (Membresia)
            {
                case TipoMembresia.Basica: areasPermitidas = "área de pesas"; break;
                case TipoMembresia.Premium: areasPermitidas = "área de pesas y piscina"; break;
                case TipoMembresia.VIP: areasPermitidas = "todas las áreas (pesas, piscina y salas de masaje)"; break;
                default: areasPermitidas = "ninguna (tipo no válido)"; break;
            }

            DiasRestantes--;
            mensaje = $"Acceso PERMITIDO. {Nombre} (membresía {Membresia}) puede usar {areasPermitidas}. " +
                      $"Días restantes después del ingreso: {DiasRestantes}.";
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Socio> listaSocios = new List<Socio>
    {
        new Socio(1, "Carlos Pérez", TipoMembresia.VIP, 3),
        new Socio(2, "María Gómez", TipoMembresia.Premium, 5),
        new Socio(3, "Luis Fernández", TipoMembresia.Basica, 2),
        new Socio(4, "Ana Torres", TipoMembresia.VIP, 10)
    };

            // Calcular el máximo de días iniciales
            int maxDias = listaSocios.Max(s => s.DiasRestantes);

            Console.WriteLine($"=== SIMULACIÓN DE {maxDias} DÍAS (HASTA AGOTAR TODOS) ===\n");

            for (int dia = 1; dia <= maxDias; dia++)
            {
                Console.WriteLine($"--- DÍA {dia} ---");

                foreach (Socio socio in listaSocios)
                {
                    bool acceso = socio.IntentarAcceso(out string mensaje);
                    Console.WriteLine(mensaje);
                }

                Console.WriteLine("----------------------------------------\n");
            }

            Console.WriteLine("¡Todos los socios han agotado sus días!");
            Console.ReadKey();
        }
    }
}