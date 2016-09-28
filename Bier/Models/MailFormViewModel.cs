using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Bier.Models
{
    public class ConfirmationEmail
    {
        [Required]
        public string UserName { get; set; }
        [Required,EmailAddress]
        public string FromEmail { get; set; }
    }
}