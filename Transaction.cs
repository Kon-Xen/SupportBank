namespace Bank
{
    class Transaction
    {
        private int id;
        public int Id { get; set; }
        private int to; //other persons id
        public int To { get; set; }        
        private int from; //other persons id
        public int From { get; set; }
        private decimal amount;
        public decimal Amount { get; set; }
        private DateTime date;
        public DateTime Date { get; set; }
        private string? narrative;
        public string? Narrative { get; set; }        

        public Transaction(int id, int to, int from, decimal amount, DateTime date, string narrative)
        {
            this.Id = id;
            this.To = to;
            this.From = from;
            this.Amount = amount;
            this.Date = date;
            this.Narrative = narrative;
        }
    }
}