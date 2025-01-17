using System;
using TrackApp_alish.Models;

namespace TrackApp_alish.Services
{
    public class AuthenticationService
    {
        private UserModel _authenticatedUser;

        public UserModel GetAuthenticatedUser()
        {
            return _authenticatedUser;
        }
        public void SetAuthenticatedUser(UserModel user)
        {
            _authenticatedUser = user;
        }

        public bool IsAuthenticated()
        {
            return _authenticatedUser != null;
        }
        public void Logout()
        {
            _authenticatedUser = null;
        }
    }
}
    