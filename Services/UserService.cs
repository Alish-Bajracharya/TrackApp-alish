using TrackApp_alish.Models;

namespace TrackApp_alish.Services
{
    public class UserService
    {
        // Simulate saving the user data to a database or API
        public bool RegisterUser(SignupModel signupModel)
        {
            // Example: Logic to save user to database
            // This could involve calling a database service or API here

            // For now, simulate success
            Console.WriteLine($"User {signupModel.Username} registered with email {signupModel.Email} and currency {signupModel.Currency}");

            return true;
        }
    private LoginModel loginModel = new LoginModel();

        private void HandleValidSubmit()
        {
            bool loginSuccess = UserService.LoginUser(loginModel);

            if (loginSuccess)
            {
                // Logic for successful login
                Console.WriteLine($"Login successful for {loginModel.Username}");
            }
            else
            {
                // Logic for failed login
                Console.WriteLine("Invalid credentials or missing fields.");
            }
        }

        private static bool LoginUser(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }
    }
}