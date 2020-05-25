using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly_Real.Models;

namespace Vidly_Real.Data_Transfer_Objects
{
    public class NewRentalDTO
    {
        public int CustomerId { get; set; }
        public List<int> MoviesIds { get; set; }
    }
}
