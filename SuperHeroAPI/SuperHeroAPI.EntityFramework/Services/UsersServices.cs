using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace SuperHeroAPI.EntityFramework
{
    public class UsersServices : BaseServices, IUsersServices
    {

        private readonly SuperHeroAPIContext _context;
        public UsersServices(SuperHeroAPIContext context)
        {
            UnityOfWork = new UnityOfWork(context);
            _context = context;
        }

        public  User Get(int id)
        {
            var dbUser = (from _user in _context.User.Include(_ => _.Roles).ToList()
                          where _user.Id == id
                          select new User
                          {
                              Id = _user.Id,
                              Username = _user.Username,
                              Password = _user.Password,
                              Roles = (from _role in _user.Roles
                                      select new Role
                                      {
                                          Id = _role.Id,
                                          Name = _role.Name,
                                          User_Id = _user.Id
                                      }).ToList()
                          }).FirstOrDefault();

            return dbUser;
        }

        public List<User> GetAll()
        {
            List<User> dbUsers = (from _user in  _context.User.AsQueryable().Include(x => x.Roles).ToList()
                                  select new User
                                  {
                                      Id = _user.Id,
                                      Username = _user.Username,
                                      Password = _user.Password,
                                      Roles = (from _role in _user.Roles
                                               select new Role
                                               {
                                                   Id = _role.Id,
                                                   Name = _role.Name,
                                                   User_Id = _user.Id
                                               }).ToList()
                                  }).ToList();

            return dbUsers;
        }

        public User Create(User user)
        {
            string _password = user.Password;
            user.Password = new PreparaHash.PreparaHash().RetornaSenhaCriptografada(_password);

            UnityOfWork.UsersRepository.Add(user);

            UnityOfWork.SaveAllChanges();
          
            return user;
        }

        public User Update(User user)
        {
            string _password = user.Password;
            user.Password = new PreparaHash.PreparaHash().RetornaSenhaCriptografada(_password);

            var dbuser = UnityOfWork.UsersRepository.Update(user);

            UnityOfWork.SaveAllChanges();

            return dbuser;
        }

        public User Remove(int id)
        {
            var user = UnityOfWork.UsersRepository.Get(r => r.Id == id);

            if (user != null)
            {
               var dbUser = UnityOfWork.UsersRepository.Remove(user);

                UnityOfWork.SaveAllChanges();

                return dbUser;
            }

            return null;
        }
 
        public User Authenticate(string username, string password)
        {
            string _passwordCript = new PreparaHash.PreparaHash().RetornaSenhaCriptografada(password);

            var users = _context.User.Include(x => x.Roles);

            User user = users.AsQueryable().Where(x => x.Username == username && x.Password == _passwordCript).FirstOrDefault();
            
            return user;
        }

    }
}