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
    public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, ResponseModel<bool>>
    {
        private readonly IPlayerRepository _playerRepository;
        public UpdatePlayerCommandHandler(IPlayerRepository PlayerRepository)
        {
            _playerRepository = PlayerRepository;
        }
        public async Task<ResponseModel<bool>> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            players player = new players
            {
                palyerId = request.palyerId,
                name = request.name,
                position = request.position,
                jerseyNo = request.jerseyNo,
                teamId = request.teamId
            };

            var rowsAffected = await _playerRepository.UpdatePlayer(player);

            return new ResponseModel<bool>
            {
                data = rowsAffected > 0 ? true : false,
                message = "Player updated successfully",

            };

        }
    }
}
