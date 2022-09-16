/* 
 * todo:
 * We open the file
 * use contents to create accounts ( loop )

 * put the accounts in a list to be ready to query.

 * List All - prints out the names of each person, along with the total amount they owe or are owed, as before
    Mary owes 1000, is owned 50

 * List [Account] -prints out every transaction(with date, narrative, to and amount) for the specific account the user asks for.

        Mary | 12 / 09 / 2014 | pokemon training | people list of what is owed to | people list of what is owed from
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

// Dictionary<string, Account> accounts = new Dictionary<string, Account>();

// for (int i = 1; i < fileContents.Count; i++)
// {
//     string[] row = fileContents[i].Split(',');

//     if (!accounts.ContainsKey(row[1]))
//     {
//         accounts.Add(row[1], new Account(i, row[1]));
//     }
// }

List<Account> accounts = new List<Account>();
List<string> names = new List<string>();
for (int i = 1; i < fileContents.Count; i++)
{
    string[] row = fileContents[i].Split(',');

    if (!names.Contains(row[1]))
    {
        names.Add(row[1]);
        
        dynamic instance = new Account(
            i, 
            row[1],
            new Debt( i, 0, 0.6M, DateTime.Now, "test")
            );
        accounts.Add(instance);
    }
}

foreach (var account in accounts)
{
    Console.WriteLine(account.Id);
    Console.WriteLine(account.Name);
    Console.WriteLine(account.OwesTo[0].Narrative);
}