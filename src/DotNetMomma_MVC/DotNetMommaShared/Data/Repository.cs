using DotNetMommaShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMommaShared.Data
{
    public class Repository
    {
        private Context _context = null;
        public Repository(Context context)
        {
            _context = context;
        }


        public IList<Category> GetCategories()
        {
            return _context.Categories
                .OrderBy(s => s.Name)
                .ToList();
        }


    }
}
