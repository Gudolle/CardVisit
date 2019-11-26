using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VisitCard.Models;

namespace VisitCard.Services
{
    public class Auth
    {
        public static User UserAuth { get; set; }

        public Auth()
        {
            UserAuth = null;
        }


        public async Task<bool> AddItemAsync(User item)
        {
            UserAuth = item;
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync()
        {
            UserAuth = null;
            return await Task.FromResult(true);
        }

        public async Task<User> GetItemAsync()
        {
            return await Task.FromResult(UserAuth);
        }
    }
}
