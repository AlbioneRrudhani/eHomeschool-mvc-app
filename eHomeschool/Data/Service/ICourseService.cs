using eHomeschool.Data.Base;
using eHomeschool.Data.ViewModels;
using eHomeschool.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eHomeschool.Data.Service
{
    public interface ICourseService : IEntityBaseRepository<Course>
    {
        Task<Course> GetCourseByIdAsync(int id);
        Task<NewCourseDropDownVM> GetNewCourseDropDownsValue();
        Task AddNewCourseAsync(NewCourseVM data);

        Task UpdateCourseAsync(NewCourseVM data);
    }
}
