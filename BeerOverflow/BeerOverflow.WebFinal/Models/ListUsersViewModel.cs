using BeerOverflow.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Models
{
    public class ListUsersViewModel
    {
        public ListUsersViewModel(IDictionary<string, List<UserDTO>> users)
        {
            this.Users = users;
        }

        public IDictionary<string, List<UserDTO>> Users { get; set; } = new Dictionary<string, List<UserDTO>>();
    }
}
