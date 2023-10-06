using Expenses.DataAccess.Repositories;
using Expenses.Model;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.web.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesRepository _exRepo;

        public ExpensesController(IExpensesRepository exRepo)
        {
            _exRepo = exRepo;
        }

        public IActionResult Index(string searching)
        {
            List<ExpenseModel> lists= new List<ExpenseModel>();
            if(string.IsNullOrEmpty(searching))
            {
                lists =_exRepo.GetAllExpenses().ToList();
            }
            else
            {
                lists = _exRepo.Search(searching).ToList();
            }
            return View(lists);
        }
    }
}
