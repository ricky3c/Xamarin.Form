﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Escala_Y_Rotacion
{
    public class App
    {
        public static Page GetMainPage()
        {
            return new NavigationPage(new PaginaPrincipal());
        }
    }
}
