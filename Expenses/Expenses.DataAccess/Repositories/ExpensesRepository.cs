using Expenses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.DataAccess.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly ApplicationDbContext _db;

        public ExpensesRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(ExpenseModel expense)
        {
            try
            {
                _db.ExpensesTable.Add(expense);
                _db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var expense= GetExpenseById(id);
                if (expense != null)
                {
                    _db.ExpensesTable.Remove(expense);
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<ExpenseModel> GetAllExpenses()
        {
            try
            {
                var expenses = _db.ExpensesTable.ToList();
                return expenses;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ExpenseModel GetExpenseById(int id)
        {
            try
            {
                var expense = _db.ExpensesTable.Find(id);
                return expense;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<ExpenseModel> Search(string searchString)
        {
            try
            {
                var searchExpenses = GetAllExpenses().
                    Where(x => x.Title.Contains(searchString)).ToList();
                return searchExpenses;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int update(ExpenseModel expense)
        {
            try
            {
                _db.Entry(expense).State=
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
