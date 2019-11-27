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
    public partial class Profil : ContentPage
    {
        public User Item { get; set; }
        public Profil()
        {
            
            InitializeComponent();
            Item = Services.Auth.UserAuth;
            if(Item == null)
            {
                Item = new User();
                Login();
            }
            BindingContext = this;

        }

        async void Login()
        {

            var AuthPage = new Auth(Item);
            // Subscribe to the event when things are updated
            AuthPage.OperationCompeleted += Auth_OperationCompleted;

            await Navigation.PushModalAsync(AuthPage);
        }

        private void Auth_OperationCompleted(object sender, EventArgs e)
        {
            // Unsubscribe to the event to prevent memory leak
            (sender as Auth).OperationCompeleted -= Auth_OperationCompleted;
            Update();
        }
        private void Edition_OperationCompleted(object sender, EventArgs e)
        {
            // Unsubscribe to the event to prevent memory leak
            (sender as EditionProfil).OperationCompeleted -= Auth_OperationCompleted;
            Update();
        }
        private void Update()
        {
            // Do something after change
            Item = Services.Auth.UserAuth;
            Name.Text = Item.Nom;
            Prenom.Text = Item.Prenom;
            Status.Text = Item.Status;
            int compteur = 0;
            if (Competences.Children.Count != 0)
            {
                for (int i = 0; i <= Competences.Children.Count; i++)
                    Competences.Children.RemoveAt(0);
            }
            foreach (var item in Item.Competences)
            {

                Competences.Children.Add(new Label()
                {
                    Text = item.Name
                }, 0, compteur);
                compteur++;
            }
            CardGrid.Children.Add(new Image()
            {
                HeightRequest = 200,
                Source = Item.Image
            }, 0, 0);
        }
        private void Disconnect_Clicked(object sender, EventArgs e)
        {
            Item = new User();
            Login();
        }

        private void Edition_Clicked(object sender, EventArgs e)
        {
            Edition();
        }
        async void Edition()
        {
            var UpdateProfil = new EditionProfil(Item);
            // Subscribe to the event when things are updated
            UpdateProfil.OperationCompeleted += Edition_OperationCompleted;

            await Navigation.PushModalAsync(UpdateProfil);
        }
    }
}