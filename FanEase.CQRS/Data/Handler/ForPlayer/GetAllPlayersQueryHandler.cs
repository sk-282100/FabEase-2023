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
    public class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, Response>
    {
        private readonly IPlayerRepository _playerRepository;
        public GetAllPlayersQueryHandler(IPlayerRepository PlayerRepository)
        {
            _playerRepository = PlayerRepository;
        }
        public async Task<Response> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            List<players> player = await _playerRepository.GetAllPlayers();
            Response data = new()
            {
                Result = player,
                Message = "All Player",
                IsSuccess = true,
            };
            return data;
        }
    }
}
