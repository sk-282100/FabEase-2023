using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForUser;
using FanEase.Middleware.Data.Handler.ForUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static System.Net.WebRequestMethods;

namespace FanEase_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IMediator _mediator;
        private static int otp = 0;
        public AccountController(IMediator mediator )
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] User user)
        {
            var status = await _mediator.Send(new AddUserCommand(user));
            if (status.data)
            {
                return Created("api/Created", status);
            }
            return BadRequest();

        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(LoginDto logindto)
        {

            var response = await _mediator.Send(new LoginCommand(logindto));
            if (response.data == null)

            {
                return Unauthorized();
            }
            else
            {
                return Ok(response);
            }

        }

        [HttpGet]
        [Route("forgetPassword/{email}")]
        public async Task<ActionResult> ForgetPassword(string email)
        {

            bool status = SendRegisterationLink.SendLink(email)
;
            otp = SendRegisterationLink.OTP;
            if (status)
            {
                return Ok(new ResponseModel<bool>
                {
                    data = status
                });
            }

            return BadRequest();
        }

        [HttpPost("SetPassword")]
        public async Task<ActionResult> SetPassword(SetPasswordVm setPasswordVm)
        {
            ResponseModel<bool> status = await _mediator.Send(new SetPasswordCommand(setPasswordVm.UserName, setPasswordVm.Password));
            if (status.data)
            {
                status.message = "Password Reset Successfully ";
                return Ok(status);
            }

            return BadRequest();
        }
        [HttpGet]
        [Route("VerifyOTP")]
        public async Task<ActionResult> VeriifyOTP(int OTP)
        {
            if (otp == OTP)
            {
                if (SendRegisterationLink.time > DateTime.Now)
                    return Ok(new ResponseModel<int>
                    {
                        data = OTP
                    });
                else
                    return BadRequest(new ResponseModel<int>
                    {
                        message = "timeout"
                    });
            }
            return BadRequest(new ResponseModel<int>
            {
                message = "notmatched"
            });
        }

        [HttpPut]
        [Route("ResetPassword")]
        public async Task<ActionResult> ResetPassword(string OldPassword,string UserId,string NewPassword)
        {
            ResponseModel<bool> status = await _mediator.Send(new ResetPasswordCommand(OldPassword, UserId, NewPassword));
            if (status.data)
            {
                status.message = "Password Reset Successfully ";
                return Ok(status);
            }

            return BadRequest();


        }

        [HttpPost]
        [Route("SetCreatorPassword")]
        public async Task<ActionResult> SetCreatorPassword(LoginDto login)
        {
            ResponseModel<bool> status = await _mediator.Send(new SetCreatorPasswordCommand(login.Email, login.Password));
            if (status.data)
            {
                status.message = "Password Reset Successfully ";
                return Ok(status);
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("SendCredentials")]
        public async Task<ActionResult> SendCredentials(CredentialVM credentials)
        {
            bool status = SendRegisterationLink.SendCredentials(credentials);
            if (status)
            {
                return Ok(new ResponseModel<bool>
                {
                    data = status
                });
            }

            return BadRequest();
        }

    }
}
