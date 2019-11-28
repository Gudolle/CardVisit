using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitCard.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisitCard.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Recherche : ContentPage
    {
        public Recherche()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (Find.Children.Count != 0)
            {

                int Max = Find.Children.Count;
                for (int i = 0; i < Max; i++)
                    Find.Children.RemoveAt(0);
            }
            List<User> lfind = User.ListUser().Where(x => x.Nom.ToUpper().Contains(Filter.Text.ToUpper()) || x.Prenom.ToUpper().Contains(Filter.Text.ToUpper())).ToList();
            if(lfind.Count == 0)
            {
                Label label = new Label()
                {
                    Text = "Aucun résultat"
                };
                Find.Children.AddVertical(label);
            }
            else
            {
                int Compteur = 0;
                foreach (var item in lfind)
                {
                    Find.Children.Add(new Image() { Source = item.Image, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, HeightRequest=50 }, 0, Compteur);
                    Find.Children.Add(new Label() { Text = item.Nom, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, HeightRequest = 50 }, 1, Compteur);
                    Find.Children.Add(new Label() { Text = item.Prenom, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, HeightRequest = 50 }, 2, Compteur);
                    Compteur++;
                }
            }
        }
    }
}