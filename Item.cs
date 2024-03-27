class Item
{
    private readonly string _name;
    private int _quantity;
    private DateTime _date;  //? _createdAt OR _createdDate

    // item1 = new Item("coffee", 200)
    // item1 = new Item("coffee", 200, "2024-03-29")
    public Item(string name, int quantity, DateTime dateTime = default)
    {
        if (quantity < 0) throw new ArgumentException("Quantity should be greater than 0! ");
        _name = name;
        _quantity = quantity;
        _date = dateTime == default ? DateTime.Now : dateTime;
    }
    public DateTime GetDate()
    {
        return _date;
    }
    public string GetName()
    {
        return _name;
    }
    public void SetQuantity(int quantity)
    {
        if (quantity < 0) throw new ArgumentException("Quantity should be greater than 0! ");
        _quantity = quantity;
    }
    public int GetQuantity()
    {
        return _quantity;
    }
    public override string? ToString()
    {
        return $"Item name:  {_name}\nQuantity:  {_quantity}\nCreated date:  \n{_date}\n";
    }
}