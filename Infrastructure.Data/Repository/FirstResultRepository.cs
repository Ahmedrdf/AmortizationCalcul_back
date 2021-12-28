using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Infrastructure.Data.Interface;

namespace Infrastructure.Data.Repository
{
  public  class FirstResultRepository : IFirstResultsRepository
    {
        public TestTeckDbContext _context;
        public FirstResultRepository(TestTeckDbContext context)
        {
            _context = context;
        }
        public bool CreatFirstResults(FirstResults firsResult)
        {

            _context.results.Add(firsResult);
            return Save();
        }

        public bool DeleteFirstResults(FirstResults firsResult)
        {
            _context.results.Remove(firsResult);
            return Save();
        }

        public bool FirstResultsExist(int id)
        {
            return _context.results.Any(a => a.Id == id);

        }

        public IEnumerable<FirstResults> GetFirstResults()
        {
            return _context.results;
        }

        public FirstResults GetFirstResults(int firsResult)
        {
            return _context.results.FirstOrDefault(a => a.Id == firsResult);
        }


        public bool Save()
            {
                return _context.SaveChanges() >= 0 ? true : false;
            }
        

        public bool UpdateFirstResults(FirstResults firsResultUpdate)
        {
            FirstResults result = _context.results.FirstOrDefault(e => e.Id == firsResultUpdate.Id);
            if (result != null)
            {
                result.Mensualite = firsResultUpdate.Mensualite;
                result.MentantEmpBrut = firsResultUpdate.MentantEmpBrut;
                result.MentantEmpNet = firsResultUpdate.MentantEmpNet;
            }

            return Save();
        }
    }
}
