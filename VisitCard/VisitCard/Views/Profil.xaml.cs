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
            // Do something after change
            Item = Services.Auth.UserAuth;
            EmailTest.Text = String.Format("{0} {1}", Item.Nom, Item.Prenom);
        }
    }
}