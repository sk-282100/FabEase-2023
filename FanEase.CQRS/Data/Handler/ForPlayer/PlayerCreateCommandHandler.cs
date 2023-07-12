using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForPlayer;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForPlayer
{
    public class PlayerCreateCommandHandler : IRequestHandler<PlayerCreateCommand, Response>

    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerCreateCommandHandler(IPlayerRepository PlayerRepository)
        {
            _playerRepository = PlayerRepository;
        }

        public async Task<Response> Handle(PlayerCreateCommand request, CancellationToken cancellationToken)
        {
            players player = new players
            {
                name = request.name,
                position = request.position,
                jerseyNo = request.jerseyNo,
                teamId = request.teamId,

            };

            var rowsAffected = await _playerRepository.CreatePlayer(player);
            Response data = new Response
            {
                Result = rowsAffected > 0 ? player : null,
                Message = rowsAffected > 0 ? "Player created successfully" : "Failed to create Player",
                IsSuccess = rowsAffected > 0
            };

            return data;
        }
    }
}
