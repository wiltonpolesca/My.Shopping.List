namespace My.Shopping.List.Repository;

public class InMemoryDatabase
{
    private readonly Dictionary<string, List<object>> _data;
    private static InMemoryDatabase? _instance;

    private InMemoryDatabase()
    {
        _data = new Dictionary<string, List<object>>();

    }

    public static InMemoryDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new InMemoryDatabase();
            }

            return _instance!;
        }
    }

    public void AddNewItem(string key, object value)
    {

        if (value == null)
        {
            throw new Exception("Invalid null value");
        }

        if (!_data.TryGetValue(key, out var listItems))
        {
            listItems = new List<object>();
            _data.Add(key, listItems);
        }

        listItems.Add(value);
    }
}
