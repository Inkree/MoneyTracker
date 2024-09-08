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

        public TransactionController(ITransactionsService transactionService, ICategoriesService categoriesService, IUserService userService)
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
        public async Task<IActionResult> GetTransaction(string Id)
        {
            var transaction = await _transactionService.GetByIdAsync(Id);
            return View(transaction);
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
        [HttpGet]
        public IActionResult Statistic()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Settings()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetCategoryExpenses(DateTime startDate, DateTime endDate)
        {
            var categoryExpenses = await _transactionService.GetTotalSpentByAllCategoriesAsync(startDate, endDate);
            return Json(categoryExpenses);
        }


        [HttpGet]
        public IActionResult Find(string name)
        {
            var transactions = _transactionService.Find(name).ToList();
            return Json(transactions);
        }

    }
}
