using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Escala_Y_Rotacion
{
   
    class PaginaPrincipal : ContentPage 
    {
        public PaginaPrincipal ()
        {
         Command<Type> Comandonavegacion = 
                new Command<Type>(async (Type tipopagina) =>
                {
                    if (tipopagina == null)
                    {
                        await this.DisplayAlert("Escala y Rotacion", 
                                    "Pagina no implementada", "OK", null);
                        return;
                    }
                    // Obtenemos todos los constructores del tipo de pagina y lo pasamos a un IEnumerable List
                    IEnumerable<ConstructorInfo> constructors = 
                            tipopagina.GetTypeInfo().DeclaredConstructors;
                    //For each para obtener la informacion de cada constructor
                    foreach (ConstructorInfo constructor in constructors)
                    {
                        // Comprobamos si el constructor no tiene parametros
                        if (constructor.GetParameters().Length == 0)
                        {
                            // Si es asi creamos la instancia y navegamos en ella
                            Page page = (Page)constructor.Invoke(null);
                            await this.Navigation.PushAsync(page);
                            break;
                        }
                    }
                });
           //Definimos el titulo de la pagina
            this.Title = "Escala y Rotacion";
            //Creamos un table view con las opciones que tendremos en nuestra aplicacion
            this.Content = new TableView
                {
                    Intent = TableIntent.Menu,
                    Root = new TableRoot
                    {
                        new TableSection()
                        {
                            new TextCell
                            {
                                Text = "Escala",
                                Command = Comandonavegacion,
                                CommandParameter = typeof(Escala)
                            },

                            new TextCell
                            {
                                Text = "Rotacion",
                                Command = Comandonavegacion,
                                CommandParameter = typeof(Rotacion)
                            },
                        }
                    }
                };
           }
    }
}
