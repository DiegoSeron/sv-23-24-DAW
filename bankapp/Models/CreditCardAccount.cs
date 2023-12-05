// Cuenta que me cobre intereses mensuales del total de lo que debo 
namespace Models;

public class CreditCardAccount : BankAccount
{

    private decimal interestRate = 0.05M;

    public CreditCardAccount(string name, decimal initialBalance) : base(name, initialBalance)
    {
    }

    public override void MakeWithdrawal(decimal amount, DateTime date, string note)
 {
        var withdrawal = new Transaction(-amount, date, note);
        transactions.Add(withdrawal);
    }

    public override void PerformMonthlyOperation()
    {
        if (Balance < 0)
        {
            decimal interestEarned = Balance * interestRate;
            MakeWithdrawal(-interestEarned, DateTime.Now.AddDays(30), "Te quito dinero");
        }


    }


}