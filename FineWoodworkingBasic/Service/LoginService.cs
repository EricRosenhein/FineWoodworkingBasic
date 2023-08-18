using FineWoodworkingBasic.Model;
namespace FineWoodworkingBasic.Service

{
    public class LoginService
    {
        public Task<ResultMessage> LoginAsync(string username, string password)
        {
            return Task.FromResult(LoginAsyncHelper(username, password));   
        }

        public ResultMessage LoginAsyncHelper(string uname, string pwd)
        {
            string loginMessage;
            FineWoodworkingBasic.Model.AuthorizedUser au = new FineWoodworkingBasic.Model.AuthorizedUser();

            au.Populate(uname);

            if (au.IsPopulated())
            {
                if (au.CheckIfPasswordsMatch(pwd))
                {
                    loginMessage = "Login successful!!";
                    return new ResultMessage(ResultMessage.ResultMessageType.Success, loginMessage);
                }
                else
                {
                    loginMessage = "ERROR: Passwords don't match!";
                    return new ResultMessage(ResultMessage.ResultMessageType.Error, loginMessage);
                }
            }
            else
            {
                ResultMessage mesg = au.RetrievePopulateMessage();
                if (mesg != null)
                {
                    loginMessage = "ERROR: User with user name: " + uname + " not found!";
                    
                }
                else
                {
                    loginMessage = "ERROR: Unexpected error in retrieving user with user name: " + uname + " from database!";
                    
                }
                return new ResultMessage(ResultMessage.ResultMessageType.Error, loginMessage);

            }

        }

    
    }
}
