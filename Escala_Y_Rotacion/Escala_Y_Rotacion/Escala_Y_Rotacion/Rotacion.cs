using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Escala_Y_Rotacion
{
    class Rotacion : ContentPage
    {
        public Rotacion()
        {
            //Agregamos nuestro titulo a nuestra pagina
            this.Title = "Rotacion";

            // Etiqueta que vamos a transformar
            Label Etiqueta = new Label
            {
				Text = "Ricky!!",
                Font = Font.SystemFontOfSize(50),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            //  Creamos un Label y un Slider con el que transformaremos nuestra etiqueta
            Label Valorderotacion = new Label
            {
                YAlign = TextAlignment.Center
            };
            //seleccionamos la posicion de la etiqueta
            Grid.SetRow(Valorderotacion, 0);
            Grid.SetColumn(Valorderotacion, 0);

            //Creamos nuestro slider 
            Slider SliderRotacion = new Slider
            {
                //la rotacion maxima de la etiqueta 
                Maximum = 360
            };
            //seleccionamos la posicion del slider
            Grid.SetRow(SliderRotacion, 0);
            Grid.SetColumn(SliderRotacion, 1);

            // Creamos nuestros Binding para el slider y la etiqueta que rotaremos
            Valorderotacion.BindingContext = SliderRotacion;
            Valorderotacion.SetBinding(Label.TextProperty,
                new Binding("Value", BindingMode.OneWay,
                            null, null, "Rotacion = {0:F0}\u00B0"));

            SliderRotacion.BindingContext = Etiqueta;
            SliderRotacion.SetBinding(Slider.ValueProperty,
				new Binding("Rotation", BindingMode.TwoWay));


            //Montamos la pagina.
            this.Content = new StackLayout
            {
                Children =
                {
                    Etiqueta,
                    new Grid
                    {
                        Padding = 10,
                        RowDefinitions = 
                        {
                            new RowDefinition { Height = GridLength.Auto },
                            new RowDefinition { Height = GridLength.Auto },
                            new RowDefinition { Height = GridLength.Auto }
                        },
                        ColumnDefinitions = 
                        {
                            new ColumnDefinition { Width = GridLength.Auto },
                            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)}
                        },
                        Children = 
                        {
                            Valorderotacion,
                            SliderRotacion
                        
                        }
                    }
                }
            };
        }
    }
}
