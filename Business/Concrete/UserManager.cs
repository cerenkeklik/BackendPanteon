using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    using Core.Entities.Concrete;
    using Core.Utilities.Results;
    using DataAccess.Abstract;
    using global::Business.Abstract;
    using global::Business.Constants;
    using System;
    using System.Collections.Generic;
    using System.Text;

    namespace Business.Concrete
    {
        public class UserManager : IUserService
        {
            IUserDal _userdal;

            public UserManager(IUserDal userDal)
            {
                _userdal = userDal;
            }


            public  IResult Add(User user)
            {
                _userdal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }

            public User GetByUsername(string username)
            {
                return _userdal.Get(u => u.Username == username);
            }

            public User GetByEmail(string email)
            {
                return _userdal.Get(u => u.Email == email);
            }

        }
    }
}
