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
    public class PlayerDeleteCommandHandler : IRequestHandler<PlayerDeleteCommand, ResponseModel<bool>>
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerDeleteCommandHandler(IPlayerRepository PlayerRepository)
        {
            _playerRepository = PlayerRepository;
        }
        public async Task<ResponseModel<bool>> Handle(PlayerDeleteCommand request, CancellationToken cancellationToken)
        {
            var Player = await _playerRepository.GetPlayerById(request.palyerId);
            if (Player == null) return default;
            int rowsAffected = await _playerRepository.DeletePlayer(request.palyerId);
            ResponseModel<bool> data = new ResponseModel<bool>
            {
                data = rowsAffected > 0 ? true : false,
                message = rowsAffected > 0 ? "Player deleted successfully" : "Failed to delete Player",
                Succeed = rowsAffected > 0
            };

            return data;
        }
    }
}
