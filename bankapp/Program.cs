// See https://aka.ms/new-console-template for more information
using Models;


Menu.MainMenu();


/* Console.WriteLine(userAdmin.ToString());
Console.WriteLine(user.ToString());
Console.WriteLine(userNull.ToString()); */


/* var usersDict = new Dictionary<int, User>() 
{
 {1, userAdmin}, {2, user}, {3, new User{
    Name= "Toñin",
    LastName = "Coliseum",
    NIF = "Usado"
 }}
};

Console.WriteLine(usersDict[2].Name);

usersDict.Add(103, userAdmin); //No se puede repetir la key, lo demás si

foreach (var item in Enumerable.Range(1,3))
{
    Console.WriteLine(usersDict[item].Name); 
}


Console.WriteLine("Hello, World!");

BankAccount account = new BankAccount("Ivan", 100);
var today = DateTime.Now;
account.MakeDeposit(5000, today, "Colacao");
account.MakeDeposit(2000, today, "Churros");
var history = account.GetAccountHistory();
Console.WriteLine(history);


var balance = account.Balance;
var stringifyAccount = account.ToString();
Console.WriteLine(stringifyAccount);

BankAccount account2 = new BankAccount("Nano");

InterestEarningAccount bankaccPedrin = new InterestEarningAccount("Pedrin", 1000);
bankaccPedrin.MakeDeposit(1000, DateTime.Now, "CUMpleaños");
bankaccPedrin.PerformMonthlyOperation();
Console.WriteLine(bankaccPedrin.GetAccountHistory());

CreditCardAccount bankaccRajoy = new CreditCardAccount("Rajoy", 50);
Console.WriteLine(bankaccRajoy.GetAccountHistory());
bankaccRajoy.MakeWithdrawal(100,today, "Chuches");
bankaccRajoy.MakeDeposit(75,today, "Chuches");
bankaccRajoy.MakeWithdrawal(20,today, "Chuches");
bankaccRajoy.MakeWithdrawal(6,today, "Chuches");

bankaccRajoy.PerformMonthlyOperation();

Console.WriteLine(bankaccRajoy.GetAccountHistory());



Console.WriteLine("Bye, World!"); */

