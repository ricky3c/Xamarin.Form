using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Escala_Y_Rotacion
{
    class Escala : ContentPage
    {
        public Escala()
        {
            this.Title = "Escala";

            // Etiqueta que vamos a transformar
            var Etiqueta = new Label
            {
				Text = "Ricky!!",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Creamos un Label y un Slider con el que transformaremos nuestra etiqueta
            Label Valordeescala = new Label
            {
                YAlign = TextAlignment.Center
            };
            //seleccionamos la posicion de la etiqueta
            Grid.SetRow(Valordeescala, 0);
            Grid.SetColumn(Valordeescala, 0);

            //Creamos un slider con el que le daremos la escala a la etiqueta
            Slider SliderEscala = new Slider
            {
                Maximum = 10
            };
            //seleccionamos la posicion del slider
            Grid.SetRow(SliderEscala, 0);
            Grid.SetColumn(SliderEscala, 1);

            // Creamos nuestros Binding para el slider y la etiqueta que escalaremos 
            Valordeescala.BindingContext = SliderEscala;
            Valordeescala.SetBinding(Label.TextProperty,
                new Binding("Value", BindingMode.OneWay,
					null, null, "Escala = {0:F1}"));

            SliderEscala.BindingContext = Etiqueta;
            SliderEscala.SetBinding(Slider.ValueProperty,
				new Binding("Scale", BindingMode.TwoWay));


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
                            Valordeescala,
                            SliderEscala,
                           
                        }
                    }
                }
            };
        }
    }
}
