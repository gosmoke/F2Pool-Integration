using HashRates.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2Pool.Services.Utilities
{
    public static class Account
    {
        public static string GetToken()
        {
            string f2poolToken = ConfigHelper.GetAppSetting(Constants.F2POOL_TOKEN);
            if (string.IsNullOrEmpty(f2poolToken))
            {
                //TODO:  This doesn't work.  It grabs the first DLL in the bin for some reason.
                string passedInToken = Environment.GetCommandLineArgs().Length > 0 ? Environment.GetCommandLineArgs()[0] : string.Empty;
                if (string.IsNullOrEmpty(passedInToken))
                {
                    Console.Write("Please provide your F2Pool access token:  ");
                    var tokenResponse = Console.ReadLine();
                    if (tokenResponse != null)
                    {
                        passedInToken = tokenResponse;
                    }
                    else
                    {
                        throw new ArgumentException("No access token provided.  Cannot continue.");
                    }
                }

                f2poolToken = passedInToken;
            }

            return f2poolToken;
        }

        public static string GetUsername()
        {
            string minerUsername = ConfigHelper.GetAppSetting(Constants.F2POOL_MINER_USERNAME);
            if (string.IsNullOrEmpty(minerUsername))
            {
                string passedInUsername = Environment.GetCommandLineArgs().Length > 1 ? Environment.GetCommandLineArgs()[1] : string.Empty;
                if (string.IsNullOrEmpty(passedInUsername))
                {
                    Console.Write("Please provide your account username:  ");
                    var usernameResponse = Console.ReadLine();
                    if (usernameResponse != null)
                    {
                        passedInUsername = usernameResponse;
                    }
                    else
                    {
                        throw new ArgumentException("No username provided.  Cannot continue.");
                    }
                }

                minerUsername = passedInUsername;
            }

            return minerUsername;

            
        }
    }
}
