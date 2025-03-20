namespace bigHomeWork.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Type { get; set; } // "Income" or "Expense"
        public string Name { get; set; }
    }
}