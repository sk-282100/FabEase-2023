using FanEase.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Repository.Interfaces
{
    public interface IStateRepository
    {
        Task<bool> AddState(State state);
        Task<List<State>> GetAllState();
        Task<State> GetStateById(int id);
        Task<bool> DeleteState(int id);
        Task<bool> UpdateState(State state);
    }
}
