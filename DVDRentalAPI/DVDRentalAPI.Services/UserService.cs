using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using DVDRentalAPI.Core.Model;
using DVDRentalAPI.Helpers;
using DVDRentalAPI.Models;
using DVDRentalAPI.Repository.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace DVDRentalAPI.Services
{
    public interface IUserService
    {
        UserModel Authenticate(string userName, string password);
        IEnumerable<Users> GetAll();
        bool Register(UserModel model);
    }
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public UserModel Authenticate(string username, string password)
        {
            UserModel userModel = null;
            var user = _unitOfWork.Users.Find(x => x.UserName == username && x.Password == password).FirstOrDefault();

            // return null if user not found
            if (user == null)
                return null;

            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, user.UserId.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};

            //Map Data Entity to Model
            userModel = _mapper.Map<UserModel>(user);


            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserId.ToString())
                    }),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            userModel.JwtToken = tokenHandler.WriteToken(token);
            return userModel;
        }

        public IEnumerable<Users> GetAll()
        {
            return _unitOfWork.Users.GetAll();
        }

        public bool Register(UserModel model)
        {
            var user = _mapper.Map<Users>(model);

            _unitOfWork.Users.Add(user);

            return _unitOfWork.Commit();
        }
    }
}
