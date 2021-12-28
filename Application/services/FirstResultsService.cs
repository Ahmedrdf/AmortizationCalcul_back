using System;
using System.Collections.Generic;
using System.Text;
using Application.interfaces;
using Application.ViewModel;
using Domain;
using Infrastructure.Data.Interface;

namespace Application.services
{
  public  class FirstResultsService : IFirstResultsService
    {
        public IFirstResultsRepository _firstResultsRepository;

        public FirstResultsService(IFirstResultsRepository firstResultsRepository)
        {
            _firstResultsRepository = firstResultsRepository;
        }

        public bool CreatFirstResults(FirstResults firstResuls)
        {
            return _firstResultsRepository.CreatFirstResults(firstResuls);
        }

        public bool DeleteFirstResults(FirstResults firstResuls)
        {
            return _firstResultsRepository.DeleteFirstResults(firstResuls);
        }

        public bool FirstResultsExist(int id)
        {
            return _firstResultsRepository.FirstResultsExist(id);
        }

        public FirstResultsViewModel GetFirstResults()
        {
            return new FirstResultsViewModel()
            {
                results = _firstResultsRepository.GetFirstResults()
            };
        }

        public FirstResults GetFirstResults(int idFirstResults)
        {
            return _firstResultsRepository.GetFirstResults(idFirstResults);
        }

        public bool UpdateFirstResults(FirstResults firstResuls)
        {
            return _firstResultsRepository.UpdateFirstResults(firstResuls);
        }
    }
}
