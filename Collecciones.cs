using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PracticaParcial;

namespace PracticaParcial
{
    public class TarjetasUsuario
    {
        private List<Tarjeta> _lista;
        private bool _verificarTarjeta;

        public TarjetasUsuario()
        {
            _lista = new List<Tarjeta>();
        }

        public void AgregarTarjeta(int numeroTarjeta, string fechaVencimiento, int codigoSeguridad)
        {
            _lista.Add(new Tarjeta(numeroTarjeta, fechaVencimiento, codigoSeguridad));
        }
        public bool BuscarTarjeta(int numeroTarjeta, string fechaVencimiento, int codigoSeguridad)
        {
            foreach(var tarjeta in _lista)
            {
                if (tarjeta.VerificarTarjeta(numeroTarjeta, fechaVencimiento, codigoSeguridad) == true)
                {
                    return true;
                }
            }
            Console.WriteLine("La o las tarjetas no contienen los datos ingresados. Porfavor, intente denuevo.");
            return false;
        }
    }

    public class Usuarios
    {
        private List<Usuario> _lista;

        public Usuarios()
        {
            _lista = new List<Usuario>();
        }

        public bool VerificarLogueoUsuario(string nombreUsuario, string contraseñaUsuario)
        {
            foreach(Usuario usuario in _lista)
            {
                if(usuario.NombreUsuario == nombreUsuario && usuario.Contraseña == contraseñaUsuario)
                {
                    return true;
                }
            }
            return false;
        }

        public int AsignarLogueoUsuario(string nombreUsuario, string contraseñaUsuario, bool value)
        {
            if (value == true)
            {
                foreach (Usuario usuario in _lista)
                {
                    if (usuario.NombreUsuario == nombreUsuario && usuario.Contraseña == contraseñaUsuario)
                    {
                        return usuario.Id;
                    }
                }
                return 0;
            }
            else
            {
                return 0;
            }
        }
        public void AgregarUsuario(Usuario value)
        {
            _lista.Add(value);
        }

        public void QuitarUsuario(int value)
        {
            foreach(Usuario usuario in _lista)
            {
                if(usuario.Id == value)
                {
                    _lista.Remove(usuario);
                    break;
                }
            }
        }

        public void AgregarTarjetaUsuario(int id, int numeroTarjeta, string fechaVencimiento, int codigoSeguridad)
        {
            foreach(Usuario usuario in _lista)
            {
                if(usuario.Id == id)
                {
                    usuario.AgregarTarjeta(numeroTarjeta, fechaVencimiento, codigoSeguridad);
                }
            }
        }
        public Usuario AsignarUsuario(int value)
        {
            foreach(Usuario usuario in _lista)
            {
                if(usuario.Id == value)
                {
                    return usuario;
                }
            }
            return null;
        }

        public void MostrarUsuarios()
        {
            foreach(Usuario usuario in _lista)
            {
                Console.WriteLine("Usuario: " + usuario.NombreUsuario);
                Console.WriteLine("Contraseña: " + usuario.Contraseña);
                Console.WriteLine("/////////////////////////");
            }
        }
    }

    public class Libros
    {
        private List<Libro> _libros;

        public Libros()
        {
            _libros = new List<Libro>();
        }

        public void AgregarLibro(Libro value)
        {
            _libros.Add(value);
        }
        public void QuitarLibro(int value)
        {
            foreach(Libro libro in _libros)
            {
                if(libro.Id == value)
                {
                    _libros.Remove(libro);
                    break;
                }
            }
        }

        public void MostrarLibros()
        {
            foreach(Libro libro in _libros)
            {
                libro.MostrarInformacionUsuario();
            }
        }
    }

    public class Rubro
    {
        private List<Libro> _catalogo;
        private IRubros _rubro;
        private int _id;

        public List<Libro> Catalogo
        {
            get { return _catalogo; }
            set { _catalogo = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Rubro(int id, IRubros rubro)
        {
            Id = id;
            _rubro = rubro;
            _catalogo = new List<Libro>();
        }

        public void AgregarLibro(Libro value)
        {
            _catalogo.Add(value);
        }

        public void QuitarLibro(int value)
        {
            foreach(var libro in _catalogo)
            {
                if(libro.Id == value)
                {
                    _catalogo.Remove(libro);
                    break;
                }
            }
        }

        public void MostrarCatalogo()
        {
            Console.WriteLine("--------------");
            foreach(var libro in  _catalogo)
            {
                libro.MostrarInformacionUsuario();
                Console.WriteLine("--------------");
            }
        }

        public void MostrarNombreRubro()
        {
            Console.Write(this._rubro);
        }

        public Libro AsignarLibroOC(int value)
        {
            foreach(Libro libro in _catalogo)
            {
                if(libro.Id == value)
                {
                    return libro;
                }
            }
            return null;
        }
    }
    
    public class Rubros
    {
        private List<Rubro> _rubros;

        public List<Rubro> RRubros
        {
            get { return _rubros; }
            set { _rubros = value; }
        }

        public Rubros()
        {
            _rubros = new List<Rubro>();
        }

        public void AgregarRubro(Rubro value)
        {
            _rubros.Add(value);
        }

        public void QuitarRubro(int value)
        {
            foreach(var rubro in _rubros)
            {
                if(rubro.Id == value)
                {
                    _rubros.Remove(rubro);
                    break;
                }
            }

        }

        public void MostrarRubros()
        {
            foreach (Rubro rubro in _rubros)
            {
                Console.Write(rubro.Id + ". ");
                rubro.MostrarNombreRubro();
                Console.WriteLine("");
            }
        }

        public void MostrarRubro(int value)
        {
            foreach(Rubro rubro in _rubros)
            {
                if (rubro.Id == value)
                {
                    rubro.MostrarCatalogo();
                }
                //break; //Este break solamente me dejaba ver el primer id... Me queria matar cuando
            }            //No funcionaba.. :(
        }
        public void AgregarLibro(int id, Libro libro)
        {
            foreach(Rubro rubro in _rubros)
            {
                if(rubro.Id == id)
                {
                    rubro.AgregarLibro(libro);
                }
            }
        }

        public Libro AsignarLibroOC(int value)
        {
            foreach(Rubro rubro in _rubros)
            {
                if(rubro.AsignarLibroOC(value) != null)
                {
                    return rubro.AsignarLibroOC(value);
                }
            }
            return null;
        }
    }
    
    public class LineaOC
    {
        private Libro _libro;
        private int _stockOC;
        private int _idLineaOC;

        public int StockOC
        {
            get { return _stockOC; }
            set { _stockOC = value; }
        }
        public int IdLineaOC
        {
            get { return _idLineaOC; }
            set {  _idLineaOC = value; }
        }

        public LineaOC(int idLineaOC, Libro libro, int stockOC)
        {
            IdLineaOC = idLineaOC;
            _libro = libro;
            StockOC = stockOC;
        }

        public void MostrarDetallesLOC()
        {
            Console.WriteLine("Linea N°" + this.IdLineaOC);
            Console.WriteLine($"Libro: {_libro.Nombre}/Autor: {_libro.Autor}");
            Console.WriteLine($"Stock: {_stockOC}");
            Console.WriteLine("//////////////");
        }

        public void ModificarLOC(int value)
        {
            StockOC = value;
        }

        public float CalcularSubtotalLOC()
        {
            return (StockOC * this._libro.Precio);
        }

        public bool VerificarStockLOC()
        {
            if(this.StockOC <= this._libro.Stock)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoverStockLOC()
        {
            _libro.Stock -= StockOC;
        }
    }
    //
    public class OrdenDeCompra
    {
        private List<LineaOC> _ordenDeCompra;
        private float _totalOC;
        private Usuario _usuarioOC;
        private int _idOC;
        public OrdenDeCompra(int idOC, Usuario usuario)
        {
            _idOC = idOC;
            _ordenDeCompra = new List<LineaOC>();
            _usuarioOC = usuario;
        }

        public int IdOC
        {
            get { return _idOC; }
            set { _idOC = value; }
        }
        public void AgregarOC(int idLineaOC, Libro libro, int stockOC)
        {
            _ordenDeCompra.Add(new LineaOC(idLineaOC, libro, stockOC));
        }

        public void QuitarOC(int value)
        {
            foreach(LineaOC lineaOC in _ordenDeCompra)
            {
                if(lineaOC.IdLineaOC == value)
                {
                    _ordenDeCompra.Remove(lineaOC);
                    break;
                }
            }
        }

        public void ModificarOC(int idLineaOC, int nuevoStock)
        {
            foreach(LineaOC lineaOC in _ordenDeCompra)
            {
                if(lineaOC.IdLineaOC == idLineaOC)
                {
                    lineaOC.ModificarLOC(nuevoStock);
                }
            }
        }

        public void MostrarDetallesOC()
        {
            foreach(LineaOC lineaOC in _ordenDeCompra)
            {
                Console.WriteLine("//////////////");
                lineaOC.MostrarDetallesLOC();
            }
        }

        public bool VerificarStockOC()
        {
            foreach(LineaOC lineaOC in _ordenDeCompra)
            {
                if (!lineaOC.VerificarStockLOC())
                {
                    Console.WriteLine("La orden de compra excede el stock de uno o mas productos. Porfavor seleccione o remueva dicha compra de su orden.");
                    return false;
                }
            }
            return true;
        }

        public void CalcularTotalOC()
        {
            foreach(LineaOC lineaOC in _ordenDeCompra)
            {
                _totalOC += lineaOC.CalcularSubtotalLOC();
            }
        }

        public bool VerificarCompraOC()
        {
            int numeroTarjeta;
            string fechaVencimiento;
            int codigoSeguridad;
            char verificarCompra;

            if (VerificarStockOC() == true)
            {
                Console.WriteLine("Ingrese el numero de su tarjeta: ");
                numeroTarjeta = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese la fecha de expiracion de su tarjeta: ");
                fechaVencimiento = Console.ReadLine();

                Console.WriteLine("Ingrese el codigo de seguridad de su tarjeta: ");
                codigoSeguridad = int.Parse(Console.ReadLine());

                if(_usuarioOC.BuscarTarjeta(numeroTarjeta, fechaVencimiento, codigoSeguridad))
                {
                    Console.WriteLine("Datos verificados correctamente. Desea finalizar la compra" +
                        " y realizar el pago? (S/N)");
                    verificarCompra = char.Parse(Console.ReadLine());
                    if(verificarCompra == 's' || verificarCompra == 'S')
                    {
                        foreach(LineaOC lineaOC in _ordenDeCompra)
                        {
                            lineaOC.RemoverStockLOC();
                        }

                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Compra cancelada exitosamente.");
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }

    public class OrdenesCompras
    {
        private List<OrdenDeCompra> _ordenes;

        public OrdenesCompras()
        {
            _ordenes = new List<OrdenDeCompra>();
        }

        public void RegistrarOrden(OrdenDeCompra value)
        {
            _ordenes.Add(value);
        }

        public void RemoverOrden(int value)
        {
            foreach(OrdenDeCompra oc in _ordenes)
            {
                if(oc.IdOC == value)
                {
                    _ordenes.Remove(oc);
                }
            }
        }
    }
}
