using eHomeschool.Data.Base;
using eHomeschool.Models;

namespace eHomeschool.Data.Service
{
    public class EducationalStagesSevice : EntityBaseRepository<EducationalStage>, IEducationalStagesService
    {
        public EducationalStagesSevice(AppDbContext context) : base(context)
        {

        }
    }
}
