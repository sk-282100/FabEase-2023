using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForDashboard;
using FanEase.Repository.Interfaces;
using MediatR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForDashboard
{
    public class AdminDashBoardQueryHandler:IRequestHandler<AdminDashBoardQuery,ResponseModel<AdminDashboardDTO>>
    {
        readonly IDashBoardRepository _dashboardRepository;

        public AdminDashBoardQueryHandler(IDashBoardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<ResponseModel<AdminDashboardDTO>> Handle(AdminDashBoardQuery request, CancellationToken cancellationToken)
        {
            AdminDashboardDTO dashBoardData = await _dashboardRepository.GetAdminDashBoard();

            return
                new ResponseModel<AdminDashboardDTO>
                {
                    data = dashBoardData,
                    message = "data received"

                };
            

        }
    }
}
