namespace Models;

public class InterestEarningAccount: BankAccount{

    private decimal interestRate = 0.05M;

    public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance){
    }
    

    public override void PerformMonthlyOperation() {
        decimal interestEarned=Balance*interestRate;
        MakeDeposit(interestEarned, DateTime.Now.AddDays(30), "Monthly Earnings");

    }
    

}