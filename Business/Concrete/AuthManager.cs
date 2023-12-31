﻿using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{


    namespace Business.Concrete
    {
        public class AuthManager : IAuthService
        {
            private IUserService _userService;
            private ITokenHelper _tokenHelper;

            public AuthManager(IUserService userService, ITokenHelper tokenHelper)
            {
                _userService = userService;
                _tokenHelper = tokenHelper;
            }

            public IDataResult<User> Register(UserForRegisterDTO userForRegisterDto, string password)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                var user = new User
                {
                    Email = userForRegisterDto.Email,
                    Username = userForRegisterDto.Username,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                };
                _userService.Add(user);
                return new SuccessDataResult<User>(user, Messages.UserRegistered);
            }

            public IDataResult<User> Login(UserForLoginDTO userForLoginDto)
            {
                var userToCheck = _userService.GetByUsername(userForLoginDto.Username);
                if (userToCheck == null)
                {
                    return new ErrorDataResult<User>(null, Messages.UserNotFound);
                }

                if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                {
                    return new ErrorDataResult<User>(null, Messages.PasswordError);
                }

                return new SuccessDataResult<User>(userToCheck, Messages.LoginSuccessful);
            }

            public IResult UsernameExists(string username)
            {
                if (_userService.GetByUsername(username) != null)
                {
                    return new ErrorResult(Messages.UsernameAlreadyExists);
                }
                return new SuccessResult();
            }

            public IResult EmailExists(string email)
            {
                if (_userService.GetByEmail(email) != null)
                {
                    return new ErrorResult(Messages.EmailAlreadyExists);
                }
                return new SuccessResult();
            }

            public IDataResult<AccessToken> CreateAccessToken(User user)
            {
                var accessToken = _tokenHelper.CreateToken(user);
                return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
            }
        }
    }
}
