using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForPlayer;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForPlayer
{
    public class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, ResponseModel<List<players>>>
    {
        private readonly IPlayerRepository _playerRepository;
        public GetAllPlayersQueryHandler(IPlayerRepository PlayerRepository)
        {
            _playerRepository = PlayerRepository;
        }
        public async Task<ResponseModel<List<players>>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            List<players> player = await _playerRepository.GetAllPlayers();
            ResponseModel<List<players>> data = new()
            {
                data = player,
                message = "All Player",
                Succeed = true,
            };
            return data;
        }
    }
}
