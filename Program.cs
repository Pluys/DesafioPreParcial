using PracticaParcial;
using System.Collections.Generic;
using System.Threading.Channels;

namespace PracticaParcial
{
    /*
       La biblioteca esta pre hecha, pero deberia ser declarativa (O como se llame) y 100% funcional si es que
       lo codeé bien.

       Las funciones de Usuario/Administrador estan codeadas sin restrincciones la una de la otra para la
       accesibilidad de testeo.

       EL PROGRAMA VIENE CON DOS USUARIOS YA HECHOS!!
    Usuario_1:
    Nombre: Huichaqueo
    Contraseña: Menu
        Tarjeta:
        Nro Tarjeta: 5
        Fecha Vencimiento: "Hoy"
        Cod Seguridad: 485

    Usuario_2
    Nombre: Tarico
    Contraseña: Javascript
        Tarjeta:
        Nro Tarjeta: 8
        Fecha Vencimiento: "Ayer"
        Cod Seguridad: 541
     */
    class Program
    {

        static void Main()
        {

            int idRubro = 3;
            int idLibro = 6;
            int idUsuario = 3;
            int idOC = 0;
            int desicion = 0;
            bool verificacion = false;
            string nombreUsuario;
            string contraseñaUsuario;
            string deberitas;
            int idUsuarioLogueado = 0;
            int idRubroElegido = 0;
            int stockOC = 0;
            int idLibroOC = 0;
            int idLineaOCElegida = 0;

            OrdenesCompras ordenes = new OrdenesCompras();
            Usuarios usuarios = new Usuarios();
            Rubros rubros = new Rubros();


            Usuario Tarico = new Usuario(1, "Tarico", "Javascript", 0);
            usuarios.AgregarUsuario(Tarico);
            Tarico.AgregarTarjeta(8, "Ayer", 541);

            Usuario Huichaqueo = new Usuario(2, "Huichaqueo", "Menu", 0);
            usuarios.AgregarUsuario(Huichaqueo);
            Huichaqueo.AgregarTarjeta(5, "Hoy", 485);


            rubros.AgregarRubro(new Rubro(1, IRubros.Otros));
            rubros.AgregarRubro(new Rubro(2, IRubros.Fantasia));
            rubros.AgregarRubro(new Rubro(3, IRubros.Cientificos));


            rubros.AgregarLibro(1, new Libro(1, "Historia LGBTQ+", "Martin J. J.", IRubros.Otros, 23.2F, 7));
            rubros.AgregarLibro(1, new Libro(2, "Trans", "Martin J. J.", IRubros.Otros, 50.1F, 12));

            rubros.AgregarLibro(2, new Libro(3, "Las asombrosas aventuras de Jorgelina", "Jorgelina D.", IRubros.Fantasia, 100.1F, 10));
            rubros.AgregarLibro(2, new Libro(4, "Programacion: El anime", "Josefina S.", IRubros.Fantasia, 120F, 9));

            rubros.AgregarLibro(3, new Libro(5, "Mateo y la teoria de la relatividad", "Mateo D.", IRubros.Cientificos, 77.7F, 9));
            rubros.AgregarLibro(3, new Libro(6, "La psicologia humana", "Candela C.", IRubros.Cientificos, 109F, 16));


            while(verificacion != true)
            {
                Console.WriteLine("Porfavor, logueese para acceder.\n1.Loguearse\n2.Crear una cuenta");
                desicion = int.Parse(Console.ReadLine());

                switch (desicion)
                {
                        case 1:
                        { 
                            Console.Write("Porfavor, escriba su nombre de usuario: ");
                            nombreUsuario = Console.ReadLine();

                            Console.Write("Porfavor, escriba su contraseña de usuario: ");
                            contraseñaUsuario = Console.ReadLine();

                            if (usuarios.VerificarLogueoUsuario(nombreUsuario, contraseñaUsuario) == true)
                            {
                                verificacion = true;
                                idUsuarioLogueado = usuarios.AsignarLogueoUsuario(nombreUsuario, contraseñaUsuario, true);
                            }
                            else
                            {
                                Console.WriteLine("\nEl nombre y/o la contraseña son incorrectas. Porfavor, " +
                                    "intente denuevo.");
                                Console.ReadKey();
                            }

                            break;
                        }

                        case 2:
                        {
                            Console.Write("Escriba su nuevo nombre de usuario: ");
                            nombreUsuario = Console.ReadLine();

                            Console.Write("Escriba su nueva contraseña de usuario: ");
                            contraseñaUsuario = Console.ReadLine();

                            idUsuario++;
                            usuarios.AgregarUsuario(new Usuario(idUsuario, nombreUsuario, contraseñaUsuario, 0));

                            break;
                        }
                } //switch

                Console.Clear();
            } //while
            Console.WriteLine("Logueado correctamente.");
            desicion = 1;

            while(desicion != 0)
            {
                Console.WriteLine("Menu\n------\n0. Desloguearse y salir\n1. Ver categorias/rubros\n" +
                    "2. Ver catalogo de libros\n3. Agregar tarjeta\n4. Generar orden de compra");
                desicion = int.Parse(Console.ReadLine());
                

                switch (desicion)
                {
                    case 0:

                        break;

                    case 1:
                        VerCategorias();

                        break;

                    case 2:
                        VerCatalagoLibros();

                        break;

                    case 3:
                        AgregarTarjeta();

                        break;

                    case 4:
                        Console.Clear();
                        GenerarOC();

                        break;
                } //switch

                Console.Clear();
            } //while

            Console.WriteLine("Gracias por usar las aereolineas M.J.J. x Juan el Caballo..");

            void VerCategorias()
            {
                rubros.MostrarRubros();
                Console.WriteLine("\nPresione cualquier tecla para confirmar...");
                Console.ReadKey();
            } //funcion

            void VerCatalagoLibros()
            {
                Console.WriteLine("Porfavor, elija el numero de el rubro del que desea ver " +
                                  "los libros.");
                idRubroElegido = int.Parse(Console.ReadLine());

                rubros.MostrarRubro(idRubroElegido);
                Console.WriteLine("\nPresione cualquier tecla para confirmar...");
                Console.ReadKey();

            } //funcion

            void AgregarTarjeta()
            {
                Console.WriteLine("Escriba su numero de tarjeta.");
                int numeroTarjeta = int.Parse(Console.ReadLine());

                Console.WriteLine("Escriba la fecha de caducidad.");
                string fechaVencimiento = Console.ReadLine();

                Console.WriteLine("Escriba el codigo de seguridad.");
                int codigoSeguridad = int.Parse(Console.ReadLine());

                usuarios.AgregarTarjetaUsuario(idUsuarioLogueado, numeroTarjeta, fechaVencimiento, codigoSeguridad);

                Console.WriteLine("\nPresione cualquier tecla para confirmar...");
                Console.ReadKey();
            } //funcion

            void GenerarOC()
            {
                Console.Clear();

                idOC++;
                OrdenDeCompra nuevaOrden = new OrdenDeCompra(idOC, usuarios.AsignarUsuario(idUsuarioLogueado));
                int idLineaOC = 0;

                Console.WriteLine("Orden de compra creada de manera exitosa.");
                verificacion = false;

                while (verificacion == false)
                {
                    Console.WriteLine("Que desea hacer?\n-----------\n0. Volver\n" +
                        "1. Ver rubros\n2. Ver Libros\n" +
                        "3. Elegir libro\n4. Remover linea pedido\n5. Modificar linea pedido\n" +
                        "6. Mostrar compra\n7. Terminar compra");
                    desicion = int.Parse(Console.ReadLine());

                    switch (desicion)
                    {
                        case 0:
                            Console.WriteLine("Volver a la pagina anterior deshara cualquier intento" +
                                " de crear una orden de compra. ¿Deberitas hacia atras? (S/N)");
                            deberitas = Console.ReadLine();
                            if(deberitas == "S" || deberitas == "s")
                            {
                                verificacion = true;
                                desicion = 10;
                            }

                            break;
                        case 1:
                            VerCategorias();
                            break;

                        case 2:
                            VerCatalagoLibros();
                            break;

                        case 3:
                            Console.Write("Escriba el Id del libro a comprar: ");
                            idLibroOC = int.Parse(Console.ReadLine());

                            Console.Write("Escriba el Id del rubro perteneciente: ");
                            idRubroElegido = int.Parse(Console.ReadLine());

                            Console.Write("Escriba el stock del libro a comprar: ");
                            stockOC = int.Parse(Console.ReadLine());

                            foreach(Rubro rubro in rubros.RRubros)
                            {
                                if(rubro.Id == idRubroElegido)
                                {
                                    foreach(Libro libro in rubro.Catalogo)
                                    {
                                        if(libro.Id == idLibroOC)
                                        {
                                            idLineaOC++;
                                            nuevaOrden.AgregarOC(idLineaOC, libro, stockOC);
                                            break;
                                        }
                                    }
                                }
                            }

                            Console.WriteLine("\nPresione cualquier tecla para confirmar...");
                            Console.ReadKey();
                            break;

                        case 4: //RemoverLineaOC
                            Console.WriteLine("Elija la id de la linea de la compra para removerla.");
                            idLineaOCElegida = int.Parse(Console.ReadLine());

                            nuevaOrden.QuitarOC(idLineaOCElegida);

                            Console.WriteLine("\nPresione cualquier tecla para confirmar...");
                            Console.ReadKey();
                            break;

                        case 5: //ModificarOC
                            Console.WriteLine("Elija la id de la linea a modificar.");
                            idLineaOCElegida = int.Parse(Console.ReadLine());

                            Console.WriteLine("Elija el nuevo stock para este pedido.");
                            stockOC = int.Parse(Console.ReadLine());

                            nuevaOrden.ModificarOC(idLineaOCElegida, stockOC);

                            Console.WriteLine("\nPresione cualquier tecla para confirmar...");
                            Console.ReadKey();
                            break;

                        case 6: //MostrarOC
                            nuevaOrden.MostrarDetallesOC();

                            Console.WriteLine("\nPresione cualquier tecla para confirmar...");
                            Console.ReadKey();
                            break;

                        case 7: //TerminarOC
                            nuevaOrden.VerificarCompraOC();
                            break;
                    } //switch

                    Console.Clear();
                } //while
            } //funcion

        }

    }
}