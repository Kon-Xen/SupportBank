using System.Collections.Generic;
/* 
 * TODO:
 * We open the file
 * [V] use contents to create accounts ( loop )

 * [V] put the accounts in a list to be ready to query.

 * [ ] List All - prints out the names of each person, along with the total amount they owe or are owed, as before
       Mary owes 1000, is owned 50

 * [ ] List [Account] -prints out every transaction(with date, narrative, to and amount) for the specific account the user asks for.
        calculate diff as Disha pointed out!
 */

using Bank;

Dictionary<string, Account> accounts = new Dictionary<string, Account>();
List<string> data = getData("Transactions2014.csv");

populateAccounts(data);

 calculation();

printAll();


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

        if (!accounts.ContainsKey(row[1]))
        {
            idCounter++;

            dynamic instance = new Account(
               idCounter,
               row[1],
               new Debt(
                   idCounter,
                   row[2],
                   Convert.ToDecimal(row[4]),
                   DateTime.Parse(row[0]),
                   row[3]
               )
           );
            accounts.Add(row[1], instance);

        }
        else if (accounts.ContainsKey(row[1]))
        {
            dynamic debt = new Debt(
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
                Console.WriteLine(credit.AccountId + " owed by : " + credit.From + " " + credit.Amount + "£ for " + credit.Narrative + " on the: " + credit.Date);
            }


            Console.WriteLine(" Total debt = £" + account.Value.TotalDebit);
                     Console.WriteLine(" Total credit = £" + account.Value.TotalCredit);
            Console.WriteLine("----------");


        }
    }



    // take each account and compare it to all of the other accounts...

    // foreach (var pair in accounts)
    // {
    //     Account account = pair.Value;
    //     string name = pair.Key;

    //     // go through the debt list. and for each entry look for other entries???
    //     foreach (var otherPair in accounts)
    //     {
    //         if (name != otherPair.Key)
    //         {
    //             foreach (var dept in otherPair.Value.DebtList)
    //             {
    //                 if (dept.to == name)
    //                 {
    //                     account.credit.Add()


    //             }
    //             }
    //         }
    //         dept.OwesTo


    // }

    // }