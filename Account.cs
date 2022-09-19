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

        private List<Debt> debtList = new List<Debt>();
        public List<Debt> DebtList
        {
            get; 
            set;
        } = new List<Debt>(); //list of debt objects
        
        private List<Credit> creditList = new List<Credit>();
        public List<Credit> CreditList
        {
            get;
            set;
        } = new List<Credit>();

        public Account( int id, string name, Debt debt ) {
            this.Id = id;
            this.Name = name;
            this.DebtList.Add(debt);
        }
    }
}