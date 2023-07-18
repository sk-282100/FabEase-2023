using ExceptionHandling;
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
    public class PlayerCreateCommandHandler : IRequestHandler<PlayerCreateCommand, ResponseModel<bool>>

    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerCreateCommandHandler(IPlayerRepository PlayerRepository)
        {
            _playerRepository = PlayerRepository;
        }

        public async Task<ResponseModel<bool>> Handle(PlayerCreateCommand request, CancellationToken cancellationToken)
        {
            players player = new players
            {
                name = request.name,
                position = request.position,
                jerseyNo = request.jerseyNo,
                teamId = request.teamId,

            };

            var rowsAffected = await _playerRepository.CreatePlayer(player);
            ResponseModel<bool> data = new ResponseModel<bool>
            {
                data = rowsAffected > 0 ? true : false,
                message = rowsAffected > 0 ? "Player created successfully" : "Failed to create Player",
                Succeed = rowsAffected > 0
            };

            return data;
        }
    }
}
