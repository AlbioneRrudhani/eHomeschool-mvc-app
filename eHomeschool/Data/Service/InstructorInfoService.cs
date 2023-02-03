using eHomeschool.Data.Base;
using eHomeschool.Models;

namespace eHomeschool.Data.Service
{
    public class InstructorInfoService : EntityBaseRepository<InstructorInformation>, IInstructorInfoService
    {
        public InstructorInfoService(AppDbContext context) : base(context)
        {

        }
    }
}
