using eHomeschool.Data.Base;
using eHomeschool.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eHomeschool.Data.Service
{
    public class LecturesService : EntityBaseRepository<Lecture>, ILecturesService
    {
        private readonly AppDbContext _context;

        public LecturesService(AppDbContext context) : base(context) { }
  

    
    }
}
