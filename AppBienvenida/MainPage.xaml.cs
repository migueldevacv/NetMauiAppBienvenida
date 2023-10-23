using AppBienvenida.Models;
using Microsoft.Maui.Controls;
using System;
using System.Collections;
using System.Diagnostics;

namespace AppBienvenida
{
    public partial class MainPage : ContentPage
    {
        private int _defaultScreen = (int)Screens.Main;
        private int _activeScreen;
        private Dictionary<int, Button> _menusList;


        public MainPage()
        {
            InitializeComponent();
            _activeScreen = _defaultScreen;
            _initiateMenus();
            _renderScreenContent();
        }


        private void manageScreenContent(object sender, EventArgs e)
        {
            if(sender.GetType() == typeof(Button)) { 
                _activeScreen = _menusList.Where(x => x.Value == (Button)sender)
                       .Select(x=>x.Key)
                       .First();
                manageMenuState();
            }
            Debug.Write($"Active {_activeScreen}");
            _renderScreenContent();
        }

        private void _renderScreenContent()
        {
            if (_activeScreen == (int)Screens.Main)
            {
                p1.IsVisible = true;
                p2.IsVisible = false;
                p3.IsVisible = false;
            }
            if (_activeScreen == (int)Screens.Web)
            {
                p1.IsVisible = false;
                p2.IsVisible = true;
                p3.IsVisible = false;
            }
            if (_activeScreen == (int)Screens.Profile)
            {
                p1.IsVisible = false;
                p2.IsVisible = false;
                p3.IsVisible = true;
            }

        }

        private void buttonStyleManager(Button btn, string c1, string c2)
        {
            btn.BackgroundColor = new ColorsModel(c1)._thisColor;
            btn.TextColor = new ColorsModel(c2)._thisColor;
        }

        private void manageMenuState()
        {
            Array others = _menusList.Where(x => x.Key != (int)_activeScreen)
                .ToArray();

            foreach (KeyValuePair<int, Button> other in others)
                buttonStyleManager(other.Value, ColorsModel.White, ColorsModel.Primary);

            Button active = _menusList.Where(x => x.Key == _activeScreen)
                       .Select(x => x.Value)
                       .First();
            
            buttonStyleManager(active, ColorsModel.Primary, ColorsModel.White);
        }

        private void _initiateMenus()
        {
            _menusList = Mp
                .GetVisualTreeDescendants()
                .Where(x => x.GetType() == typeof(Button))
                .Cast<Button>()
                .Select((button, index) => new { Index = index, Boton = button })
                .ToDictionary(x => x.Index, x => x.Boton);

            manageMenuState();
        }


        public enum Screens
        {
            Main, 
            Web,
            Profile
        }
    }
}