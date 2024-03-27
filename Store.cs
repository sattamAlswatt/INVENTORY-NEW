enum SortOrder
{
    ASC,
    DESC
}
class Store<T> where T : Item
{
    private List<T> _items;
    private int _capacity;
    //CAN ADD NAME.
    public Store(int capacity)
    {
        _capacity = capacity;
        _items = new List<T>();//_items=[];
    }
    public List<T> GetItems()
    {
        return _items;
    }
    public void Display(List<T>? listItems = null)
    {
        if (listItems is null)
        {
            foreach (var item in _items)
            {
                Console.WriteLine('\n' + item.ToString() + '\n');
            }
        }
        else
        {
            foreach (var item in listItems)
            {
                Console.WriteLine('\n' + item.ToString() + '\n');
            }
        }
    }
    public void AddItem(T newItem)
    {
        if (GetCurrentVolume() + newItem.GetQuantity() >= _capacity)
        {
            Console.WriteLine("You reached the limit!.");
        }
        else
        {
            if (!_items.Any(item => item.GetName() == newItem.GetName()))// if(!_items.Contains(newItem)){ } //* other way?
            {
                _items.Add(newItem);
                Console.WriteLine($"Added:\n {newItem}");
            }
            else
            {
                Console.WriteLine($"You already have {newItem.GetName()}");
            }
        }
    }
    public List<T> SortByDate(SortOrder sort) //!CHECK
    {
        if (sort is SortOrder.DESC)
        {
            var descSort = from item in _items
                           orderby item.GetDate() descending
                           select item;
            return descSort.ToList();
        }
        else
        {
            var ascSort = from item in _items
                          orderby item.GetDate()
                          select item;
            return [.. ascSort];
        }
    }
    public void GroupByDate()
    {
        var groupByMonth = (from item in _items
                            let currentDate = DateTime.Now
                            let category = (currentDate - item.GetDate()).TotalDays <= 90 ? "New Arrival" : "Old"
                            group item by category into newGroup
                            orderby newGroup.Key
                            select newGroup);
        foreach (var monthGroup in groupByMonth)
        {
            Console.WriteLine($"{monthGroup.Key} ( {monthGroup.Count()} ) : ");
            foreach (var item in monthGroup)
            {
                Console.WriteLine($" - {item.GetName()},\n Created: {item.GetDate()}");
            }
        }
    }
    public void Delete(T deletedItem)
    {
        T? deleted = _items.Find(item => item.GetName() == deletedItem.GetName());
        if (deleted is not null)
        {
            _items.Remove(deletedItem);
            Console.WriteLine($"{deletedItem.GetName()} is removed");
        }
        else
        {
            Console.WriteLine($"{deletedItem.GetName()} is not found");
        }
    }
    public int GetCurrentVolume()
    {
        return _items.Sum(item => item.GetQuantity());
    }
    public void FindItemByName(string itemName)
    {
        T? found = _items.Find(item => item.GetName() == itemName);
        if (found is not null)
        {
            Console.WriteLine($"{found}");
        }
        else
        {
            Console.WriteLine($"{itemName} Not Found");
        }
    }
    public List<T> SortByNameAsc()
    {
        return _items.OrderBy(item => item.GetName()).ToList();
    }

    public List<T> SortByName(SortOrder sort)
    {
        if (sort is SortOrder.DESC)
        {
            return _items.OrderByDescending(item => item.GetName()).ToList();
        }
        else return _items.OrderBy(item => item.GetName()).ToList();
    }
}