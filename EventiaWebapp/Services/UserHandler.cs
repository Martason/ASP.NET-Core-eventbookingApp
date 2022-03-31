using EventiaWebapp.Models;
using EventiaWebapp.Services.Data;

namespace EventiaWebapp.Services
{
    public class UserHandler
    {
        private readonly EpicEventsContext _context;

        public UserHandler(EpicEventsContext context)
        {
            _context = context;
        }

        public EventiaUser RegisterNewUser(string username, string password, string email)
        {
            //if (password != passwordRepeat) throw new Exception("passwords don't match!");
            var newUser = new EventiaUser
            {
                Username = username,
                Password = password,
                Email = email,
            };

            try
            {
                _context.Add(newUser);
                _context.SaveChanges();
                return newUser;
            }
            catch (Exception ex)
            {
                //TODO
                Console.WriteLine(ex.Message);

            }

            return null;
        }

        //TODO bool eller user?
        public EventiaUser LoginUser(string username, string password)
        {
            bool userExists = false;
            bool passwordMatch = false;


            var query = _context.Users.Where(u => u.Username == username);

            var user = query.FirstOrDefault();

            //check user exists
            if (user != null) userExists = true;

            //check password
            if(user.Password == password) passwordMatch = true;

            if (passwordMatch && userExists) return user;

            return null;


        }
    }
}
