using System;

namespace SimpleShop.DAL.Repositories
{
    public interface IProductOrderRepository
    {
        decimal GetTotalSaleByDay(DateTime dateTime);
        decimal GetTotalSaleByMonth(DateTime dateTime);
        decimal GetTotalSaleByYear(int year);
    }
}