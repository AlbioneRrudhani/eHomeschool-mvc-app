using eHomeschool.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eHomeschool.Data.Service
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}
