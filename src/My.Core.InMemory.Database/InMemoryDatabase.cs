
using My.Core.Abstracts;

namespace My.Core.InMemory.Database;

public class InMemoryDatabase
{
    private readonly Dictionary<string, List<IEntity>> _data;

    //Armazena qualquer coisa
    private readonly Dictionary<string, List<object>> _objectData;
    private static InMemoryDatabase? _instance;

    private InMemoryDatabase()
    {
        _data = new Dictionary<string, List<IEntity>>();
        _objectData = new Dictionary<string, List<object>>();

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

    /// <summary>
    /// Armazena qualquer coisa que não implementa IEntity
    /// </summary>

    public void AddNewItem(string key, object value)
    {

        if (value == null)
        {
            throw new Exception("Invalid null value");
        }

        if (!_objectData.TryGetValue(key, out var listItems))
        {
            listItems = new List<object>();
            _objectData.Add(key, listItems);
        }

        listItems.Add(value);
    }

    public void Add<T>(string key, T value)
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

    public void Update<T>(string key, T value)
        where T : IEntity
    {

        if (value == null || value.Id == default)
        {
            throw new Exception("Invalid null value");
        }

        var item = TryGetById<T>(key, value.Id);
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

    public void Delete<T>(string key, int id)
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


    /// <summary>
    /// Retorna lista de objetos que não implementam o IEntity
    /// </summary>
    public IList<object> GetData(string key)
    {
        _objectData.TryGetValue(key, out var listItems);

        if (listItems != null)
        {
            return listItems;
        }
        return Enumerable.Empty<object>().ToList();
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
