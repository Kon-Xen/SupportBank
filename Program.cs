
/* todo:
*We open the file
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
        data.Add(line);
    }
    return data;
}

List<string> names = new List<string>();

for (int i = 1; i < fileContents.Count; i++)
{
    string[] row = fileContents[i].Split(',');
    if(!names.Contains(row[1])){
        names.Add(row[1]);
    }
    if (!names.Contains(row[2]))
    {
        names.Add(row[2]);
    }
}

Dictionary<int,Account> accounts = new Dictionary<int, Account>();

foreach (var name in names)
{
    accounts.Add(name, $"{name + i}" = new Account();
}



foreach (var name in names)
{
    Console.WriteLine(name);
}

// foreach (var row in fileContents)
// {
//     Console.WriteLine(row);
// }