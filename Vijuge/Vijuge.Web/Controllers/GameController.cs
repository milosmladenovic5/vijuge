using Microsoft.AspNetCore.Mvc;
using Vijuge.Logic.RequestModels;
using Vijuge.Logic.Services.Implementation;

namespace Vijuge.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IUserService _userService;

        public GameController(IGameService gameService, IUserService userService)
        {
            this._gameService = gameService;
            this._userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> StartSearchForOponent(GameStartRequest gsRequest)
        {
            await _gameService.StartWaitingForOponent(gsRequest.UserId);

            //TODO fix this
            return Json(Ok(gsRequest));
        }
    }
}
