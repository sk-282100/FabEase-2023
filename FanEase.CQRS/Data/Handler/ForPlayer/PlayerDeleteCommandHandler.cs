using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForPlayer;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForPlayer
{
    public class PlayerDeleteCommandHandler : IRequestHandler<PlayerDeleteCommand, Response>
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerDeleteCommandHandler(IPlayerRepository PlayerRepository)
        {
            _playerRepository = PlayerRepository;
        }
        public async Task<Response> Handle(PlayerDeleteCommand request, CancellationToken cancellationToken)
        {
            var Player = await _playerRepository.GetPlayerById(request.palyerId);
            if (Player == null) return default;
          int rowsAffected = await _playerRepository.DeletePlayer(request.palyerId);
            Response data = new Response
            {
                Result = rowsAffected > 0 ? request.palyerId : null,
                Message = rowsAffected > 0 ? "Player deleted successfully" : "Failed to delete Player",
                IsSuccess = rowsAffected > 0
            };

            return data;
        }
    }
}
