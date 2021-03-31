using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDetails.Domain.Models;
using UserDetails.Domain.Repositories;
using UserDetails.Domain.Services;
using UserDetails.Domain.Services.Communication;

namespace UserDetails.Services
{
    public class UserAddressDetailService :IUserDetailAddressService
    {
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserAddressDetailService(IUserAddressRepository userAddressRepository, IUnitOfWork unitOfWork)
        {
            this._userAddressRepository = userAddressRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<UserAddressDetail>> ListAsync()
        {
            return await _userAddressRepository.ListAsync();
        }
        public async Task<SaveUserAddressDetailResponse> SaveAsync(UserAddressDetail userAddress)
        {

            try
            {
                await _userAddressRepository.AddAsync(userAddress);
                await _unitOfWork.CompleteAsync();

                return new SaveUserAddressDetailResponse(userAddress);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveUserAddressDetailResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }
    }
}
