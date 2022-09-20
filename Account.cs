namespace Bank
{
    class Account
    {
        private int id;
        public int Id{ get; set; }
        private string? name;
        public string Name{ get; set; }

        private decimal totalDebit;
        public decimal TotalDebit{get;set;}

        private decimal totalCredit;
        public decimal TotalCredit{get;set;}

        public Account( int id, string name ) {
            this.Id = id;
            this.Name = name;
        }
    }
}