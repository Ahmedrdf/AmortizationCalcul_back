using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Application.ViewModel;

namespace Application.interfaces
{
   public interface IFirstResultsService
    {
        FirstResultsViewModel GetFirstResults();
        FirstResults GetFirstResults(int idFirstResults);
        bool FirstResultsExist(int id);
        bool CreatFirstResults(FirstResults firstResuls);
        bool UpdateFirstResults(FirstResults firstResuls);
        bool DeleteFirstResults(FirstResults firstResuls);
    }
}
