namespace Models;

using System.Text;
using System.Text.Json;

public class BankAccount
{
    public string? Number { get; }
    public string? Owner { get; set; }

    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (Transaction item in transactions)
            {
                balance += item.Amount;
            }
            return balance;
        }
    }

    private static int accountNumber_seed = 1;

    protected List<Transaction> transactions = new List<Transaction>();

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "No puede añadirse una cantidad por debajo de 0");
        }

        // DateTime trimmeDate = new DateTime(2023,10,23,18,26,0);
        // if (date > DateTime.Now){
        //     throw new InvalidDataException("La fecha no puede ser posterior a la actual");
        // }

        var deposit = new Transaction(amount, date, note);
        transactions.Add(deposit);
    }

    public virtual void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("No puede quitar una cantidad por debajo de 0");
        }
        if ((Balance - amount) < 0)
        {
            throw new InvalidOperationException("No puedes sacar dinero de donde no hay");
        }
        var withdrawal = new Transaction(-amount, date, note);
        transactions.Add(withdrawal);
    }

    public BankAccount(string name)
    {
        this.Owner = name;
        Number = accountNumber_seed.ToString();
        // Balance = 0;
        accountNumber_seed++;
    }
    public BankAccount(string name, decimal intialBalance)
    {
        this.Owner = name;
        MakeDeposit(intialBalance, DateTime.Now, "First deposit");          // this.Balance = intialBalance;
        Number = accountNumber_seed.ToString();
        accountNumber_seed++;
    }

    public override string ToString()
    {
        return (this.Owner ?? "No Owner") + " ";
    }


    public string GetAccountHistory()
    {
        var history = new StringBuilder();
        decimal balance = 0;
        history.AppendLine("Date\t\tAmount\tBalance\tNote");
        foreach (var item in transactions)
        {
            balance += item.Amount;
            history.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Note}");
        }
        var options = new JsonSerializerOptions { WriteIndented = true };

        string jsonString = JsonSerializer.Serialize(history, options);

        return history.ToString();

    }


    public virtual void PerformMonthlyOperation()
    {

    }

}

