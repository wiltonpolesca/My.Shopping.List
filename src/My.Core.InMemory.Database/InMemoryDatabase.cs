
using My.Core.Abstracts;

namespace My.Core.InMemory.Database;

public class InMemoryDatabase
{
    private readonly Dictionary<string, List<IEntity>> _data;
    private static InMemoryDatabase? _instance;

    private InMemoryDatabase()
    {
        _data = new Dictionary<string, List<IEntity>>();

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

    public void AddNewItem<T>(string key, T value)
        where T : IEntity
    {

        if (value == null)
        {
            throw new Exception("Invalid null value");
        }

        if (!_data.TryGetValue(key, out var listItems))
        {
            listItems = new List<IEntity>();
            _data.Add(key, listItems);
        }

        if (listItems.Count() > 0)
        {
            value.Id = listItems[listItems.Count() - 1].Id + 1;
        }
        else
        {
            value.Id = 1;
        }
        listItems.Add(value);
    }

    public void UpdateItem<T>(string key, int id, T value)
        where T : IEntity
    {

        if (value == null || id == default)
        {
            throw new Exception("Invalid null value");
        }

        var item = TryGetById<T>(key, id);
        if (item == null)
        {
            throw new Exception("Not found");
        }

        if (_data.TryGetValue(key, out var listItems))
        {
            listItems.Remove(item);
            listItems.Add(value);
        }
    }

    public void DeleteItem<T>(string key, int id)
        where T : IEntity
    {

        if (id == default)
        {
            throw new Exception("Invalid null value");
        }

        var item = TryGetById<T>(key, id);

        if (item == null)
        {
            throw new Exception("Not found");
        }

        if (_data.TryGetValue(key, out var listItems))
        {
            listItems.Remove(item);
        }
    }

    public T? TryGetById<T>(string key, int id)
    {
        if (_data.TryGetValue(key, out var list))
        {
            return (T?)list.FirstOrDefault(x => x.Id == id) ;
        }

        return default;
    }

    public IList<T> GetData<T>(string key)
        where T : IEntity
    {
        _data.TryGetValue(key, out var listItems);

        if (listItems != null)
        {
            return listItems.Select(x => (T)x).ToList();
        }
        return Enumerable.Empty<T>().ToList();
    }
}
