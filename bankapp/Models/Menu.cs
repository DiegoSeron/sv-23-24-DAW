using System.Security.Cryptography.X509Certificates;
using System.Text.Json;


namespace Models;

public class Menu
{

    public const string accIdconst = "account";

    public static int idDictionary = 1;

    public static Dictionary<int, BankAccount> usersAcc = new Dictionary<int, BankAccount>();

    public static void MainMenu()
    {

        while (true)
        {
            Console.WriteLine("Elige una opción:");
            Console.WriteLine("####################################");
            Console.WriteLine("\t1 - Crear cuenta");
            Console.WriteLine("\t2 - Añadir dinero");
            Console.WriteLine("\t3 - Sacar dinero");
            Console.WriteLine("\t4 - Ver listado de operaciones");
            Console.WriteLine("\t5 - Salir");
            Console.WriteLine("####################################");

            string inputString = Console.ReadLine();
            int inputInt = int.Parse(inputString);
            while (inputInt == null || inputInt < 1 || inputInt > 6)
            {
                Console.WriteLine("Debe introducir una opción valida");
                inputString = Console.ReadLine();
                inputInt = int.Parse(inputString);
            }


            if (inputInt == 1)
            {
                Console.WriteLine("Titular de la cuenta");
                string owner = Console.ReadLine();
                Console.WriteLine("Identificador de la cuenta");
                // string accIdVar =  Console.ReadLine();
                // string accId = accIdconst + accIdVar;
                BankAccount accId2 = new BankAccount(owner);
                usersAcc.Add(Menu.idDictionary, accId2);
                Menu.idDictionary++;
                saveAccount();


            }
            else if (inputInt == 2)
            {

                Console.WriteLine("Nombre del titular de la cuenta");
                string titAccount = Console.ReadLine();
                Console.WriteLine("Introduzca la cantidad que desea ingresar");
                string amount2 = Console.ReadLine();
                Console.WriteLine("Concepto");
                string concepto = Console.ReadLine();
                foreach (var item in usersAcc)
                {
                    if (titAccount == item.Value.Owner)
                    {
                        Console.WriteLine(item.Value.Owner);
                        var userId = item.Key;
                        decimal amountDec = int.Parse(amount2);
                        usersAcc[userId].MakeDeposit(amountDec, DateTime.Now, concepto);
                    }
                }
                saveAccount();

            }
            else if (inputInt == 3)
            {
                Console.WriteLine("Nombre del titular de la cuenta");
                string titAccount = Console.ReadLine();
                Console.WriteLine("Introduzca la cantidad que desea retirar");
                string amount2 = Console.ReadLine();
                Console.WriteLine("Concepto");
                string concepto = Console.ReadLine();
                foreach (var item in usersAcc)
                {
                    if (titAccount == item.Value.Owner)
                    {
                        Console.WriteLine(item.Value.Owner);
                        var userId = item.Key;
                        decimal amountDec = int.Parse(amount2);
                        usersAcc[userId].MakeWithdrawal(amountDec, DateTime.Now, concepto);
                    }
                }
                saveAccount();


            }
            else if (inputInt == 4)
            {
                Console.WriteLine("Nombre del titular de la cuenta");
                string titAccount = Console.ReadLine();
                foreach (var item in usersAcc)
                {
                    if (titAccount == item.Value.Owner)
                    {
                        Console.WriteLine(item.Value.Owner);
                        var userId = item.Key;
                        var history = usersAcc[userId].GetAccountHistory();
                        Console.WriteLine(history);
                    }
                }


            }
            else if (inputInt == 5)
            {
                Console.WriteLine("Exit");
                Environment.Exit(0);
            }
        }
    }
     public static void saveAccount()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string fileName = "operationsBank.json";
        string jsonString = JsonSerializer.Serialize<Dictionary<int, BankAccount>>(usersAcc, options);
        File.WriteAllText(fileName, jsonString);
    }
    }
    

