using System.ComponentModel.Design;
using System.Collections.Generic;

using Bank;

Menu menu = new Menu();

// Dictionary<string, Account> accounts = new Dictionary<string, Account>();
List<string> names = new List<string>();
List<Account> accounts = new List<Account>();
List<Transaction> transactions = new List<Transaction>();
List<string> data = getData("Transactions2014.csv");

populateAccounts(data);
calculation();

menu.menuA();

if (menu.choice == 1)
{
    printAll();
}

if (menu.choice == 2)
{
    int index = 1;
   
    foreach (var account in accounts)
    {
        Console.WriteLine(index++ + ". " + account.Name);
    }

    menu.menuB(keyColl.Count);

    printOne(menu.name);
}


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

            dynamic instance = new Account(
               idCounter,
               row[1]
           );
            
            accounts.Add(instance);           
        }
    }
}

 void populateTransactions(List<string> data)
{   
    int idCounter = 0;
    for (int i = 1; i < data.Count; i++){

    string[] row = data[i].Split(',');

    foreach (var account in accounts)
    {
        if (account.Name == (row[1]) ){
                dynamic transaction = new Transaction(
                       i,
                       account.Id,
                       row[2],// how do I get this guy?
                       Convert.ToDecimal(row[4]),
                       DateTime.Parse(row[0]),
                       row[3]
               );
        }
    }

//replace each name with the correct ID from accounts.

        if(accounts.Contains(row[1]) )
    {
            dynamic transaction = new Transaction(
                   accounts[row[1]].Id,
                   row[2],
                   Convert.ToDecimal(row[4]),
                   DateTime.Parse(row[0]),
                   row[3]
           );

            accounts[row[1]].DebtList.Add(debt);

        }

        if (accounts.ContainsKey(row[2]))
        {
            dynamic credit = new Credit(
                  accounts[row[2]].Id,
                  row[1],
                  Convert.ToDecimal(row[4]),
                  DateTime.Parse(row[0]),
                  row[3]
          );

            accounts[row[2]].CreditList.Add(credit);
        }

    }

     }

void calculation()
{
    foreach (var account in accounts)
    {

        foreach (var debt in account.Value.DebtList)
        {
            account.Value.TotalDebit += debt.Amount;
        }

        foreach (var credit in account.Value.CreditList)
        {
            account.Value.TotalCredit += credit.Amount;
        }
    }

}


void printAll()
{
    foreach (var account in accounts)
    {
        Console.WriteLine("account : " + account.Value.Id);
        Console.WriteLine(account.Value.Name);

        foreach (var debt in account.Value.DebtList)
        {
            Console.WriteLine(debt.AccountId + " owes to: " + debt.To + " " + debt.Amount + "£ for " + debt.Narrative + " on the: " + debt.Date);
        }

        foreach (var credit in account.Value.CreditList)
        {
            Console.WriteLine(credit.AccountId + " owed by: " + credit.From + " " + credit.Amount + "£ for " + credit.Narrative + " on the: " + credit.Date);
        }


        Console.WriteLine(" Total debt = £" + account.Value.TotalDebit);
        Console.WriteLine(" Total credit = £" + account.Value.TotalCredit);
        Console.WriteLine("----------");
    }
}

void printOne(int name)
{

    foreach (var account in accounts)
    {
        if (account.Value.Id == name)
        {
            Console.WriteLine("account : " + account.Value.Id);
            Console.WriteLine(account.Value.Name);

            foreach (var debt in account.Value.DebtList)
            {
                Console.WriteLine(" owes to: " + debt.To + " " + debt.Amount + "£ for " + debt.Narrative + " on the: " + debt.Date);
            }

            foreach (var credit in account.Value.CreditList)
            {
                Console.WriteLine(" owed by: " + credit.From + " " + credit.Amount + "£ for " + credit.Narrative + " on the: " + credit.Date);
            }

            Console.WriteLine("----------");
            Console.WriteLine(" Total debt = £" + account.Value.TotalDebit);
            Console.WriteLine("----------");
            Console.WriteLine(" Total credit = £" + account.Value.TotalCredit);
        }
    }
}

