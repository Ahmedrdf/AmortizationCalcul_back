using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Infrastructure.Data.Interface
{
   public interface IFirstResultsRepository
    {
        IEnumerable<FirstResults> GetFirstResults();
        FirstResults GetFirstResults(int firsResult);
        bool FirstResultsExist(int id);
        bool CreatFirstResults(FirstResults firsResult);
        bool UpdateFirstResults(FirstResults firsResult);
        bool DeleteFirstResults(FirstResults firsResult);
        bool Save();
    }
}
