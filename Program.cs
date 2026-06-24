// se pudo con la ayuda de chatgpt, pero aprendi muchas cosas de c# y de la programacion orientada a objetos, y de como hacer un programa que simule un club deportivp


using System;
using System.Collections.Generic;   

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

    

            Console.WriteLine("=== SIMULACIÓN DE ACCESO PARA TODOS LOS SOCIOS (1 día) ===\n");
            foreach (Socio socio in listaSocios)
            {
                bool acceso = socio.IntentarAcceso(out string mensaje);
                Console.WriteLine(mensaje);
                Console.WriteLine("------------------------------------------------------");
            }


            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}