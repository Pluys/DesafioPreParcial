using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using PracticaParcial;

namespace PracticaParcial
{
    public class Usuario
    {
        private int _id;
        private string _nombreUsuario;
        private string _contraseña;
        private int _comprasRealizadas;
        private TarjetasUsuario _tarjetasUsuario;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _nombreUsuario = value;
                }
                else
                {
                    Console.WriteLine("El usuario debe contener un alias de al menos un caracter.");
                }
            }
        }

        public string Contraseña
        {
            get { return _contraseña; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _contraseña = value;
                }
                else
                {
                    Console.WriteLine("El usuario debe contener una contraseña de al menos un caracter.");

                }
            }
        }

        public int ComprasRealizadas
        {
            get { return _comprasRealizadas; }
            set { _comprasRealizadas = value; }
        }

        public Usuario(int id, string nombreUsuario, string contraseña, int comprasRealizadas)
        {
            Id = id;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            ComprasRealizadas = comprasRealizadas;
            _tarjetasUsuario = new TarjetasUsuario();
            //_tarjetasUsuario = new List<Tarjeta>(); No sirve?..
        }

        public bool LoguearUsuario(string nombre, string contraseña)
        {
            if (NombreUsuario == nombre && Contraseña == contraseña)
            {
                Console.WriteLine("Logueado Correctamente.");
                return true;
            }
            else
            {
                Console.WriteLine("Usuario o Contraseña incorrectos. Porfavor, intente de nuevo.");
                return false;
            }
        }
        public void AgregarTarjeta(int numeroTarjeta, string fechaVencimiento, int codigoSeguridad)
        {
            _tarjetasUsuario.AgregarTarjeta(numeroTarjeta, fechaVencimiento, codigoSeguridad);
        }

        public bool BuscarTarjeta(int numeroTarjeta, string fechaVencimiento, int codigoSeguridad)
        {
            return _tarjetasUsuario.BuscarTarjeta(numeroTarjeta, fechaVencimiento, codigoSeguridad);
        }

        public bool VerificarExistenciaTarjeta()
        {
            return _tarjetasUsuario.VerificarExistenciaTarjeta();
        }
    }

    public class Tarjeta
    {
        private int _numeroTarjeta;
        private string _fechaVencimiento;
        private int _codigoSeguridad;

        public int NumeroTarjeta
        {
            get { return _numeroTarjeta; }
            set { _numeroTarjeta = value; }
        }

        public string FechaVencimiento
        {
            get { return _fechaVencimiento; }
            set { _fechaVencimiento = value; }
        }

        public int CodigoSeguridad
        {
            get { return _codigoSeguridad; }
            set { _codigoSeguridad = value; }
        }

        public Tarjeta(int numeroTarjeta, string fechaVencimiento, int codigoSeguridad)
        {
            NumeroTarjeta = numeroTarjeta;
            FechaVencimiento = fechaVencimiento;
            CodigoSeguridad = codigoSeguridad;
        }

        public bool VerificarTarjeta(int numeroTarjeta, string fechaVencimiento, int codigoSeguridad)
        {
            if(NumeroTarjeta == numeroTarjeta && FechaVencimiento == fechaVencimiento && CodigoSeguridad == codigoSeguridad)
            {
                Console.WriteLine("Tarjeta verificada correctamente.");
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Libro
    {
        private string _nombre;
        private int _id;
        private string _autor;
        private IRubros _rubro;
        private float _precio;
        private int _stock;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Autor
        {
            get { return _autor; }
            set { _autor = value; }
        }

        public IRubros Rubro
        {
            get { return _rubro; }
            set { _rubro = value; }
        }

        public float Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        public Libro(int id, string nombre,  string autor, IRubros rubro, float precio, int stock)
        {
            Id = id;
            Nombre = nombre;
            Autor = autor;
            Rubro = rubro;
            Precio = precio;
            Stock = stock;
        }

        public void ActualizarStock(int value)
        {
            Stock = value;
        }

        public void ActualizarPrecio(float value)
        {
            Precio = value;
        }

        public void ActualizarRubro(IRubros value)
        {
            Rubro = value;
        }

        public void MostrarInformacionUsuario()
        {
            Console.WriteLine($"Libro: {Nombre}\nAutor: {Autor}\nStock: {Stock}\nId: {Id}");
        }
    }


}
