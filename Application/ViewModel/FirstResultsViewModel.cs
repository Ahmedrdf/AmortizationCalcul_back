using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Infrastructure.Data.Interface;

namespace Application.ViewModel
{
   public  class FirstResultsViewModel
    {
        public IEnumerable<FirstResults> results { get; set; }

    }
}
