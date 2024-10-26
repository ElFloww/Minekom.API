using Asp.Versioning;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Minekom.API.Presenters;
using Minekom.API.Presenters.Authentication;
using Minekom.API.Presenters.CellTowers;
using Minekom.API.Requests;
using Minekom.Core.Requests.Authentication;
using Minekom.Core.Requests.CellTowers;

namespace Minekom.API.Controllers
{    
    /// <summary>
     /// Controller used to handle actions bound to cell towers
     /// </summary>
    [ApiVersion("1")]
    public class AntennesController : BaseController
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="p_Logger"></param>
        /// <param name="p_Mediator"></param>
        /// <param name="p_ValidationPresenter"></param>
        public AntennesController(ILogger<AntennesController> p_Logger, IMediator p_Mediator, ValidationPresenter p_ValidationPresenter) 
            : base(p_Logger, p_Mediator, p_ValidationPresenter)
        {

        }

        /// <summary>
        /// Get all wireless towers
        /// </summary>
        /// <param name="p_Presenter"></param>
        /// <param name="p_CancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetTowersAsync(
            [FromServices] GetAllCellTowersPresenter p_Presenter,
            CancellationToken p_CancellationToken = default)
        {
            p_Presenter.Handle(await m_Mediator.Send(new GetAllCellTowersRequest(), p_CancellationToken));

            return p_Presenter.ContentResult;
        }
    }
}
