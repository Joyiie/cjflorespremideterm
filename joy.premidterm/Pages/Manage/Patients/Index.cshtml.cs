using joy.premidterm.Infrastructure.Domian;
using joy.premidterm.Infrastructure.Domian.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace joy.premidterm.Pages.Manage.Patients
{
    public class IndexModel : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDbContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public IndexModel(DefaultDbContext context, ILogger<Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }

        public void OnGet(int? pageIndex = 1, int? pageSize = 10, string? sortBy = "", SortOrder sortOrder = SortOrder.Ascending, string? keyword = "")
        {
            var skip = (int)((pageIndex - 1) * pageSize);

            var query = (IQueryable<Patient>)_context.Patients;

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(a =>
                            a.FullName != null && a.FullName.ToLower().Contains(keyword.ToLower())
                        || a.Code != null && a.Code.ToLower().Contains(keyword.ToLower())
                       
                );
            }

            var totalRows = query.Count();

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortBy.ToLower() == "fullname" && sortOrder == SortOrder.Ascending)
                {
                    query = query.OrderBy(a => a.FullName);
                }
                else if (sortBy.ToLower() == "fullname" && sortOrder == SortOrder.Descending)
                {
                    query = query.OrderByDescending(a => a.FullName);
                }
                else if (sortBy.ToLower() == "code" && sortOrder == SortOrder.Ascending)
                {
                    query = query.OrderBy(a => a.Code);
                }
                else if (sortBy.ToLower() == "code" && sortOrder == SortOrder.Descending)
                {
                    query = query.OrderByDescending(a => a.Code);
                }
               
            }

            var patients = query
                            .Skip(skip)
                            .Take((int)pageSize)
                            .ToList();

            View.Patient = new Paged<Patient>()
            {
                Items = patients,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalRows = totalRows,
                SortBy = sortBy,
                SortOrder = sortOrder
            };
        }

        public class ViewModel
        {
            public Paged<Patient>? Patient { get; set; }
        }
    }
}
