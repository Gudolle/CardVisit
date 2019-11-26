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
    public partial class Auth : ContentPage
    {
        public User Item { get; set; }
        public Auth()
        {
            InitializeComponent();
            Item = new User();
            BindingContext = this;

        }
        public Auth(User _user)
        {
            InitializeComponent();
            Item = _user;
            BindingContext = this;
        }


        public event EventHandler<EventArgs> OperationCompeleted;
        async void OnLogin(object sender, EventArgs args)
        {
            Services.Auth.UserAuth = Item;
            OperationCompeleted?.Invoke(this, EventArgs.Empty);

            await Navigation.PopModalAsync();
        }
    }
}