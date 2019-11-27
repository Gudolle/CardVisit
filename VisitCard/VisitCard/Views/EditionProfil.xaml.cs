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
    public partial class EditionProfil : ContentPage
    {
        public User Item { get; set; }
        public EditionProfil()
        {
            InitializeComponent();
        }
        public EditionProfil(User _user)
        {
            InitializeComponent();
            Item = _user;
            BindingContext = this; 
            CardGrid.Children.Add(new Image()
            {
                HeightRequest = 200,
                Source = Item.Image
            }, 0, 0);
            Nom.Text = Item.Nom;
            Prenom.Text = Item.Prenom;
            Status.Text = Item.Status;
        }

        public event EventHandler<EventArgs> OperationCompeleted;

        async void Save_Clicked(object sender, EventArgs e)
        {
            Services.Auth.UserAuth = Item;
            OperationCompeleted?.Invoke(this, EventArgs.Empty);
            await Navigation.PopModalAsync();
        }
    }
}