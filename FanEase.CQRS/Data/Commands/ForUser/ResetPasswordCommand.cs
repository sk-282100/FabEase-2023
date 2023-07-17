using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;

namespace FanEase.Middleware.Data.Commands.ForUser
{
    public class ResetPasswordCommand : IRequest<ResponseModel<bool>>
    {
        public ResetPasswordCommand(string oldPassword, string userId, string newPassword)
        {
            OldPassword = oldPassword;
            UserId = userId;
            NewPassword = newPassword;
        }

        public string OldPassword { get; }
        public string UserId { get; }
        public string NewPassword { get; }
    }
}