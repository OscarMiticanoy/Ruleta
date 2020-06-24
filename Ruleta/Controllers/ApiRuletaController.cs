using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ruleta.contexts;
using Ruleta.dao;
using Ruleta.Model;

namespace Ruleta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiRuletaController : ControllerBase
    {
        
        private readonly ILogger<ApiRuletaController> _logger;
        private readonly ContexConn context;
        private UserDao userDao;
        private RuletasDAO ruletaDao;

        public ApiRuletaController(ILogger<ApiRuletaController> logger, ContexConn context)
        {
            _logger = logger;
            this.context = context;
            this.userDao = new UserDao();
            this.ruletaDao = new RuletasDAO();
        }
        [HttpPost]
        public int PostRuleta(Ruletas ruleta)
        {
            try
            {
                return ruletaDao.createRuleta(ruleta);
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        [HttpPost]
        public void PostBet(string id, int bet)
        {
            ruletaDao.setBet(id,bet);
        }
        [HttpGet]
        public IEnumerable<Ruletas> GetRuletas()
        {
            return ruletaDao.ruletasList().ToList<Ruletas>();
        }
        [HttpGet("{id}")]
        public bool GetActivate(int id)
        {
            return ruletaDao.activateRuleta(id);
        }
        [HttpGet("{id}")]
        public IEnumerable<User> GetBets(int id)
        {
            return ruletaDao.CloseBetList(id).ToList<User>();
        }
    }
}
