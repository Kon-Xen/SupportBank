namespace Bank
{
    class Credit
    {
        private int accountId; 
        public int AccountId {get;set;} 
        private string from; //other persons id
        public string From {get;set;}
        private decimal amount;
        public decimal Amount {get;set;} 
        private DateTime date;
        public DateTime Date {get;set;}
        private string? narrative;
        public string? Narrative{get; set;}

        public Credit(int id, string from, decimal amount, DateTime date, string narrative)
        {
            this.AccountId = id;
            this.From = from;
            this.Amount = amount;
            this.Date = date;
            this.Narrative = narrative;
        }
    }

}