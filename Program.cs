using System;

namespace ClubDeportivo
{
    //tipos de membresía (si no es strings, entonces cambialo en su consola y dejeme feliz)
    public enum TipoMembresia
    {
        Basica,
        Premium,
        VIP
    }

    // los Socio
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

        // ingresar al club
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
                case TipoMembresia.Basica:
                    areasPermitidas = "área de pesas";
                    break;
                case TipoMembresia.Premium:
                    areasPermitidas = "área de pesas y piscina";
                    break;
                case TipoMembresia.VIP:
                    areasPermitidas = "todas las áreas (pesas, piscina y salas de masaje)";
                    break;
                default:
                    areasPermitidas = "ninguna (tipo no válido)";
                    break;
            }

        
            DiasRestantes--;
            mensaje = $"Acceso PERMITIDO. {Nombre} (membresía {Membresia}) puede usar {areasPermitidas}. " +
                      $"Días restantes después del ingreso: {DiasRestantes}.";
            return true;
        }
    }

    // Programa principal
    class Program
    {
        static void Main(string[] args)
        {

            Socio socio = new Socio(1, "Carlos Pérez", TipoMembresia.VIP, 3);

           
            for (int dia = 1; dia <= 5; dia++)
            {
                Console.WriteLine($"\n--- DÍA {dia} ---");
                bool acceso = socio.IntentarAcceso(out string mensaje);
                Console.WriteLine(mensaje);

  
                if (!acceso)
                {
                    Console.WriteLine("El socio ya no puede ingresar. Finalizando simulación.");
                    break;
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}