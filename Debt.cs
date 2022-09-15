namespace Bank
{
    class Debt
    {
       
        private int accountId;        
        private int owesTo;
        private decimal amount;
        private DateTime date;
        private string narrative;
        
        Debt(int id, int owesTo, decimal amount, DateTime date, string narrative ){
            this.accountId = id;
            this.owesTo = owesTo;
            this.amount = amount;
            this.date = date;
            this.narrative = narrative;
        }
    }
    
}