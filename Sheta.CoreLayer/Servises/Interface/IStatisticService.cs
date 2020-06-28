using System;
using System.Collections.Generic;
using System.Text;

namespace Sheta.CoreLayer.Servises.Interface
{
    public interface IStatisticService
    {
        int NumberOfUsers();
        int NumberOfDeleteUser();
        int NumberOfGroups();
        int NumberOfBrands();
        int NumberOfProducts();
        int NumberOfSuccessFactors();
        int NumberOfUnpaidFactors();
        int NumberOfPostFactors();
        int NumberOfSuccessPostOrder();
    }
}
