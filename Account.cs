namespace Bank
{
    class Account
    {
        private int id;
        public int Id{ get; set; }
        private string? name;
        public string Name{ get; set; }

        private List<Debt> owesTo = new List<Debt>();
        public List<Debt> OwesTo
        {
            get; 
            set;
        } = new List<Debt>(); //list of debt objects

        public Account( int id, string name, Debt debt ) {
            this.Id = id;
            this.Name = name;
            this.OwesTo.Add(debt);
        }
    }
}