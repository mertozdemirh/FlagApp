using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlagApp.Models
{
    public class FlagCreateViewModel
    {
        public Flag Flag { get; set; }
        public IFormFile Image { get; set; }
    }
}
