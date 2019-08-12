using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SOS.Business.Utilities.Response;
using SOS.Business.Utilities.Validation;
using SOS.Business.ValidationRules.FluentValidation.CustomerValidation;
using SOS.Core.Utilities.Security;
using SOS.DataAccess.Uow;
using SOS.DataObjects.ComplexTypes.Customer;
using SOS.DataObjects.Entities.CustomerSchema;
using SOS.DataObjects.ResponseType;

namespace SOS.Business.Manager.Customer
{
    public class CustomerManager : BaseManager, ICustomerManager
    {
        private IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CustomerManager(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public ISosResult DeleteCustomer(int customer_Id)
        {
            var entity = _uow.CustomerService.Get(customer_Id);

            if(entity == null)
                return HttpStatusCode.Unauthorized.SosErrorResult("Kullanıcı bulunamadı");

            _uow.CustomerService.Delete(entity);

            return HttpStatusCode.OK.SosOpResult(customer_Id, "Kayıt silindi");
        }

        public ISosResult RegisterCustomer(RegisterDto registerDto)
        {
            Validate<RegisterValidation, RegisterDto>.Valid(registerDto); 

            int customer = _uow.CustomerService.Select(s => s.Email == registerDto.Email).Count();
            if (customer > 0)
                return HttpStatusCode.BadRequest.SosErrorResult("Email zaten kayıtlı");

            if (registerDto.Password != registerDto.PasswordConfirm)
                return HttpStatusCode.BadRequest.SosErrorResult("Şifreler farklı");

            var result = _uow.CustomerService.Insert(new DataObjects.Entities.CustomerSchema.Customers()
            {
                Email = registerDto.Email,
                Password = Cryptography.GenerateHash(registerDto.Password),
                NameSurname = registerDto.NameSurname,
                PhoneNumber = registerDto.PhoneNumber,
                BirthDate = registerDto.BirthDate,
                Address = registerDto.Address,
                ActiveDate = DateTime.Now,
                Datetime = DateTime.Now
            });

            return HttpStatusCode.Created.SosOpResult((int)result, "Kayit başarılı");
        }

        public ISosResult LoginCustomer(LoginDto loginDto)
        {
            Validate<LoginValidation, LoginDto>.Valid(loginDto);

            var customers = _uow.CustomerService.Select(s => s.Email == loginDto.Email);

            if (customers.Count() > 1)
                return HttpStatusCode.BadRequest.SosErrorResult("Bu mail adresine ait birden fazla kayıt bulundu");

            if(customers.Count() == 0)
                return HttpStatusCode.BadRequest.SosErrorResult("Bu mail adresine ait kullanıcı bulunamadı");

            var customer = customers.FirstOrDefault();

            string[] passwordArray = customer.Password.Split('æ');

            if (passwordArray.Count() != 2)
                return HttpStatusCode.BadRequest.SosErrorResult("Şifre Yanlış");

            if (Cryptography.ValidateHash(passwordArray[0], passwordArray[1], loginDto.Password))
                return HttpStatusCode.OK.SosOpResult(customer.Id, "Giriş Başarılı");

            return HttpStatusCode.BadRequest.SosErrorResult("Şifre Yanlış");

        }

        public ISosResult UpdateCustomer(int Customer_Id, UpdateCustomerDto updateCustomerDto)
        {
            Validate<UpdateCustomerValidation, UpdateCustomerDto>.Valid(updateCustomerDto);

            var customer = _uow.CustomerService.Get(Customer_Id);

            if (customer == null)
                return HttpStatusCode.BadRequest.SosErrorResult("Kullanıcı bulunamadı");

            customer.NameSurname = updateCustomerDto.NameSurname;
            customer.PhoneNumber = updateCustomerDto.PhoneNumber;
            customer.BirthDate = updateCustomerDto.BirthDate;
            customer.Address = updateCustomerDto.Address;
            customer.PictureUrl = updateCustomerDto.PictureUrl;
            customer.Datetime = DateTime.Now;

            bool result = _uow.CustomerService.Update(customer);
            if (result == false)
                return HttpStatusCode.BadRequest.SosErrorResult();


            return HttpStatusCode.OK.SosOpResult(customer.Id, "Kayıt güncellendi");
        }

        public ISosResult GetCustomer(int customer_Id)
        {
            CustomerDto customerDto;

            var customer = _uow.CustomerService.Get(customer_Id);

            if (customer == null)
                return HttpStatusCode.BadRequest.SosErrorResult();

            customerDto = _mapper.Map<CustomerDto>(customer);

            return customerDto.SosResult();
        }

        public ISosResult ChangePassword(int Customer_Id, ChangePasswordDto changePasswordDto)
        {
            Validate<ChangePasswordValidation, ChangePasswordDto>.Valid(changePasswordDto);

            var customer = _uow.CustomerService.Get(Customer_Id);

            if (customer == null)
                return HttpStatusCode.Unauthorized.SosErrorResult("Kullanıcı bulunamadı");

            string[] passwordArray = customer.Password.Split('æ');

            if (passwordArray.Count() != 2)
                return HttpStatusCode.BadRequest.SosErrorResult("Şifre Yanlış");

            if (!Cryptography.ValidateHash(passwordArray[0], passwordArray[1], changePasswordDto.OldPassword))
                return HttpStatusCode.BadRequest.SosErrorResult("Şifre Yanlış");

            customer.Password = Cryptography.GenerateHash(changePasswordDto.NewPassword);

            bool result = _uow.CustomerService.Update(customer);
            if (result == false)
                return HttpStatusCode.BadRequest.SosErrorResult();


            return HttpStatusCode.OK.SosOpResult(customer.Id, "Şifre güncellendi");
        }
    }
}
