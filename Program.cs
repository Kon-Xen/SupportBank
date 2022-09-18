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

var fileContents = getData("Transactions2014.csv");

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

Dictionary<string, Account> accounts = new Dictionary<string, Account>();

for (int i = 1; i < fileContents.Count; i++)
{
    string[] row = fileContents[i].Split(',');

    if (!accounts.ContainsKey(row[1]))
    {
        dynamic instance = new Account(
           i,
           row[1],
           new Debt(
               i,
               row[2],
               Convert.ToDecimal(row[4]),
               DateTime.Parse(row[0]),
               row[3]
           )
       );
        accounts.Add(row[1], instance);

    } else if (accounts.ContainsKey(row[1]))
    {
        dynamic debt = new Debt(
               i,
               row[2],
               Convert.ToDecimal(row[4]),
               DateTime.Parse(row[0]),
               row[3]
       );

        accounts[row[1]].OwesTo.Add(debt);

    }
}

foreach (var account in accounts)
{
    Console.WriteLine("account : " + account.Value.Id);
    Console.WriteLine( account.Value.Name );
    decimal total = 0;
    foreach (var debt in account.Value.OwesTo)
    {
        Console.WriteLine(" owes to: " + debt.OwesTo + " " + debt.Amount + "$ for " + debt.Narrative + " on the: " + debt.Date);
        total = total + debt.Amount;        
    }

    Console.WriteLine(" Total debt = " + total);
    Console.WriteLine("----------");

}
