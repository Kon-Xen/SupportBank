using System.ComponentModel.Design;
using System.Collections.Generic;

using Bank;

Menu menu = new Menu();

// Dictionary<string, Account> accounts = new Dictionary<string, Account>();
List<string> names = new List<string>();

Dictionary<string, Account> accounts = new Dictionary<string, Account>();
// List<Account> accounts = new List<Account>();
List<Transaction> transactions = new List<Transaction>();
List<string> data = getData("Transactions2014.csv");

populateAccounts(data);
populateTransactions(data);

printAllTransactions();
printOne(8);

List<string> getData(string path)
{
    var reader = new StreamReader(File.OpenRead(path));

    List<string> data = new List<string>();

    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();

        if (line != null)
        {
            data.Add(line);
        }
    }
    return data;
}

void populateAccounts(List<string> data)
{
    int idCounter = 0;
    for (int i = 1; i < data.Count; i++)
    {
        string[] row = data[i].Split(',');

        if (!names.Contains(row[1]))
        {
            idCounter++;
            names.Add((row[1]));

            addAccount(idCounter, row[1]);
        }
    }
}

void populateTransactions(List<string> data)
{
    int fromId;
    int toId;

    for (int i = 1; i < data.Count; i++)
    {
        string[] row = data[i].Split(',');

        fromId = accounts[row[1]].Id;
        toId = accounts[row[2]].Id;

        addTransaction(i, fromId, toId, Convert.ToDecimal(row[4]), DateTime.Parse(row[0]), row[3]);

    }

}

void addAccount(int id, string name)
{
    dynamic instance = new Account(
              id,
              name
          );

    accounts.Add(name, instance);
}

void addTransaction(int id, int from, int to, decimal ammount, DateTime date, string narrative)
{
    dynamic transaction = new Transaction(
                                       id,
                                       from,
                                       to,
                                       ammount,
                                       date,
                                       narrative
                               );
    transactions.Add(transaction);
}


void printAllTransactions()
{
    foreach (var transaction in transactions)
    {
        Console.WriteLine(transaction.Id + "/ " + transaction.From + " owes to: " + transaction.To + " " + transaction.Amount + "£ for " + transaction.Narrative + " on the: " + transaction.Date);
    }
}

void printOne(int id)
{
    decimal debit = 0;

    Console.WriteLine("----------");

    foreach (var account in accounts)
    {
        if (account.Value.Id == id)
        {
            foreach (var transaction in transactions)
            {
                if (transaction.From == id){
                    Console.WriteLine(transaction.Id + "/ " + account.Value.Name + " owes to: " + transaction.To + " " + transaction.Amount + "£ for " + transaction.Narrative + " on the: " + transaction.Date);
                    debit += transaction.Amount;
                }    
            }           

            Console.WriteLine("----------");
            Console.WriteLine(" Total debt = £" + debit);           
        }
    }
}

