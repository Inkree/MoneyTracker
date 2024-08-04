using Application.Interfaces;
using Application.services;
using Core.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Money_tracker.Controllers
{
    [Route("[controller]/[action]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionsService _transactionService;
        public TransactionController(ITransactionsService transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
           ViewBag.ActiveIcon = "index";
           var transactions = await _transactionService.GetAllByUserId("20a41740-0419-49d1-a22c-891478876840");
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ActiveIcon = "create";
            return View();
        }

    }
}
