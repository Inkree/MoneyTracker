using Application.Interfaces;
using Core.interfaces;
using Core.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Money_tracker.ViewModels.Transactions;

namespace Money_tracker.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]

    public class TransactionController : Controller
    {
        private readonly ITransactionsService _transactionService;
        private readonly ICategoriesService _categoriesService;
        private readonly IUserService _userService;
        
        public TransactionController(ITransactionsService transactionService, ICategoriesService categoriesService,IUserService userService)
        {
            _transactionService = transactionService;
            _categoriesService = categoriesService;
            _userService = userService;
            
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var viewModel = new IndexTransactionViewModel();
            var userId = _userService.GetUserId(User);
            viewModel.Transactions = await _transactionService.GetGroupedTransactionsByUserId(userId);
            viewModel.Balance = await _transactionService.GetUserBalance(userId);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateTransactionViewModel();
            var userId = _userService.GetUserId(User);
            viewModel.Categories = await _categoriesService.GetAllByUserIdAsync(userId);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Transaction transaction)
        {
            transaction.UserId = _userService.GetUserId(User);
            await _transactionService.Create(transaction);
            return RedirectToAction("Index", "Transaction");
        }

        public IActionResult Statistic()
        {
            return View();
        }

    }
}
