// See https://aka.ms/new-console-template for more information
using F2Pool.Services.Utilities;
using HashRates.F2Pool;

Console.WriteLine("Retrieving F2Pool Account Information");

try
{
    // ###################################################################################
    // ##                                                                               ##
    // ##                               INSTRUCTIONS                                    ##
    // ##                                                                               ##
    // ###################################################################################

    // You can pass in arguments when running this application.  
    //     Arg 1:  Account Token   ( ex:  thtxje7qqmx857463895vi91e7wpxxfbfk874kf86wsve0bmui5col1234asdf8i )
	//     Arg 2:  Miner Username  ( ex:  johndoe )

	// OR you can set these values in the appsetting.json file before running the application.

    // ###################################################################################


    Kadena kadena = new Kadena();
	var result = await kadena.GetAccountInformationAsync();

	Console.WriteLine($"Response:  {result.description}");

	Console.WriteLine("Retrieving F2Pool HashRate Information");

	//result = await kadena.GetHashRateAsync();

	Console.WriteLine($"Mining Username:  {result.mining_user_name}");
	Console.WriteLine($"Mining Description:  {result.mining_user_name}");
	foreach (var wallet in result.wallets)
	{

		Console.WriteLine($"----- Currency:  {wallet.currency}");
		Console.WriteLine($"----- Address:  {wallet.address}");
		Console.WriteLine($"----- Threshold:  {wallet.threshold}");
	}
}
catch (Exception ex)
{
	Console.WriteLine($"ERROR:  {ex.Message}");
}

Console.WriteLine("End");
Console.ReadLine();

