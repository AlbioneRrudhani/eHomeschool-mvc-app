using eHomeschool.Data.Base;
using eHomeschool.Models;

namespace eHomeschool.Data.Service
{
    public class SyllabiService : EntityBaseRepository<Syllabus>, ISyllabiService
    {
        public SyllabiService(AppDbContext context) : base(context)
        {

        }
    }
}
