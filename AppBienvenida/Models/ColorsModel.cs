using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBienvenida.Models 
{
    internal class ColorsModel
    {
        public static string Primary = "Primary";
        public static string Secondary = "Secondary";
        public static string White = "White";

        public Color _thisColor;
        public ColorsModel(string color) {
            App.Current.Resources.TryGetValue(color, out var c);
            if (c != null)
                _thisColor = (Color)c;
        }
    }
}
