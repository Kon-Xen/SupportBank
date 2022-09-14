
# todo:
 * We open the file
 * use to create accounts ( loop )

 * put the accounts in a list  to be ready to query.

 * List All - prints out the names of each person, along with the total amount they owe or are owed, as before
    Mary owes 1000, is owned 50

 * List [Account] - prints out every transaction (with date, narrative, to and amount) for the specific account the user asks for.

        Mary | 12/09/2014 | pokemon training  | people list of what is owed to | people list of what is owed from
        calculate diff as Disha pointed out!
 */

```
class Acount{
    
    private int id;
    private string name;
    private list owesTo; // list of ids
    private list owesFrom; // list of ids
    private DateTime dateOf;
    
}

{
    owesTo:
        [
            {
                id: 5;
                name: bob
                amount: 300; 
            },
            {
                id: 10;
                name: Jade
                amount: 6; 
            },
            {
                id: 67;
                name: Rubby
                amount: 30; 
            }
        ]
}


   {
     owesFrom:
        [
            {
                id: 5;
                // name: bob
                amount: 300; 
            },
            {
                id: 10;
                name: Jade
                amount: 6; 
            },
            {
                id: 67;
                name: Rubby
                amount: 30; 
            }
        ]
   }
```
