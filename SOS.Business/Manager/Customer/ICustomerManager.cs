using SOS.DataObjects.ComplexTypes.Customer;
using SOS.DataObjects.ResponseType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.Business.Manager.Customer
{
    public interface ICustomerManager
    {
        ISosResult Login(LoginDto loginDto);

        ISosResult RefreshToken(string RefreshToken);

        ISosResult RegisterCustomer(RegisterDto registerDto);

        ISosResult UpdateCustomer(int Customer_Id, UpdateCustomerDto updateCustomerDto);

        ISosResult LoginCustomer(LoginDto loginDto);

        ISosResult GetUserByRefreshToken(string Email);

        ISosResult DeleteCustomer(int customer_Id);

        ISosResult GetCustomer(int customer_Id);

        ISosResult ChangePassword(int Customer_Id, ChangePasswordDto changePasswordDto);
    }
}
