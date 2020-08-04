using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleNosqlGuestbook.Dtos;
using SimpleNosqlGuestbook.Models;

namespace SimpleNosqlGuestbook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GuestbookRepository _guestbookRepository;

        public HomeController(ILogger<HomeController> logger, GuestbookRepository guestbookRepository)
        {
            _logger = logger;
            _guestbookRepository = guestbookRepository;
        }

        public IActionResult Index()
        {
            var records = _guestbookRepository.GetAll().ToList();
            return View(new GuestbookViewModel() { Records = records });
        }

        [HttpPost("add")]
        public IActionResult Add(GuestbookRecordDto newRecord)
        {
            newRecord.AddedOn = DateTime.UtcNow;
            newRecord.Id = Guid.NewGuid();
            _guestbookRepository.Add(newRecord);

            var records = _guestbookRepository.GetAll().ToList();
            return View("Index", new GuestbookViewModel() { Records = records });
        }

        public IActionResult Privacy()
        {
            _guestbookRepository.Test();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
