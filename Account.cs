namespace Bank
{
    class Account
    {
        private int id;
        public int Id{ get; set; }
        private string? name;
        public string Name{ get; set; }

        private Dictionary<string, Debt> owesTo = new Dictionary<string, Debt>();
        public Dictionary<string, Debt> OwesTo{
            get; set; } = new Dictionary<string, Debt>();

        public Account( int id, string name ) {
            this.id = id;
            this.Name = name;
        }
    }
}