#pragma warning disable CS8618

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenPas.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string Nombre { get; set; }

        [MaxLength(14)]
        public string Password { get; set; }

        public string EncriptarPassword()
        {
            const string cadenaCaracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string cadenaEncriptada = "";
            int indiceSeleccionado;
            Random caracterAleatorio = new Random();
            string caracterSeleccionado;

            for (int i = 0; i < 14; i++)
            {
                indiceSeleccionado = caracterAleatorio.Next(cadenaCaracteres.Length);
                caracterSeleccionado = cadenaCaracteres.Substring(indiceSeleccionado, 1);
                cadenaEncriptada += caracterSeleccionado;
            }

            return cadenaEncriptada;
        }
    }
}