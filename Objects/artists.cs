using System.Collections.Generic;

namespace cds.Objects
{
  public class Album
  {
    private string _description;
    private int _id;
    private static List<Album> _instances = new List<Album>{};

    public Album (string description)
    {
      _description = description;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public static List<Album> GetAll()
    {
      return _instances;
    }
    public int GetId()
    {
      return _id;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Album Find(int searchId)
    {
      return _instances[searchId - 1];
    }
  }
}
