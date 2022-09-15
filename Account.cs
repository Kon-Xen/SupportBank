namespace Bank
{
    class Account
    {
        private int id;
        private string name;
        private string Name{ get; set; }

        private Dictionary<string, Debt> owesTo = new Dictionary<string, Debt>();    

        Account( int id, string name ) {
            this.id = id;
            this.Name = name;
        }
    }
}