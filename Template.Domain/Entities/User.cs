using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities
{
    public class User : IUser<Guid>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

        public bool IsInRole(string controller, string action)
        {
            return Roles.Where(e => e.Controller == controller && e.Action == action).Any();
        }
    }
}
