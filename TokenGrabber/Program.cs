using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCRMSDK.CRM.Library.Setup.RestClient;
using ZCRMSDK.OAuth.Client;
using ZCRMSDK.OAuth.Contract;

namespace TokenGrabber {
    class Program {
        static void Main( string[] args ) {

            Console.WriteLine("Enter Client Email:");
            string clientMail = Console.ReadLine();

            Console.WriteLine("Enter Client ID:");
            string clientId = Console.ReadLine();

            Console.WriteLine("Enter Client Secret:");
            string clientSecret = Console.ReadLine();

            Console.WriteLine( "Enter Grant token:" );
            string grantToken = Console.ReadLine();



            Dictionary<string, string> config = new Dictionary<string, string>() {
                {"client_id", clientId},
                {"client_secret", clientSecret},
                {"redirect_uri", "test"},
                {"access_type", "offline"},
                {"persistence_handler_class", "ZCRMSDK.OAuth.ClientApp.ZohoOAuthFilePersistence, ZCRMSDK"},
                {"oauth_tokens_file_path", "./tokens.txt"},
                {"apiBaseUrl", "{https://www.zohoapis.com}"},
                {"fileUploadUrl", "{https://content.zohoapis.com}"},
                {"apiVersion", "v2"},
                {"currentUserEmail", clientMail}
            };

            ZCRMRestClient.Initialize( config );

            ZohoOAuthClient authClient = ZohoOAuthClient.GetInstance();
            ZohoOAuthTokens tokens = authClient.GenerateAccessToken( grantToken );
            Console.WriteLine( tokens.AccessToken );
            Console.WriteLine( tokens.RefreshToken );
            Console.ReadLine();
        }
    }
}


