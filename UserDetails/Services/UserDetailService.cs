using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDetails.Domain.Models;
using UserDetails.Domain.Repositories;
using UserDetails.Domain.Services;
using UserDetails.Domain.Services.Communication;
using UserDetails.Persistence.Repositories;

namespace UserDetails.Services
{
    public class UserDetailService : IUserDetailService
    {
        private readonly  IUserDetailRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserDetailService(IUserDetailRepository userRepository, IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<SaveUserDetailResponse> SaveAsync(User user)
        {
           
                try
                {
                    await _userRepository.AddAsync(user);
                    await _unitOfWork.CompleteAsync();

                    return new SaveUserDetailResponse(user);
                }
                catch (Exception ex)
                {
                    // Do some logging stuff
                    return new SaveUserDetailResponse($"An error occurred when saving the category: {ex.Message}");
                }
            }
        }
    }
