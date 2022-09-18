namespace Bank
{
    class Debt
    {
        private int accountId; 
        public int AccountId {get;set;} 
        private string owesTo; //other persons id
        public string OwesTo {get;set;}
        private decimal amount;
        public decimal Amount {get;set;} 
        private DateTime date;
        public DateTime Date {get;set;}
        private string? narrative;
        public string? Narrative{get; set;}

        public Debt(int id, string owesTo, decimal amount, DateTime date, string narrative)
        {
            this.AccountId = id;
            this.OwesTo = owesTo;
            this.Amount = amount;
            this.Date = date;
            this.Narrative = narrative;
        }
    }

}