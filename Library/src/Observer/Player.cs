using System;

namespace Library
{
  /// <summary>
  /// The 'Observer' interface
  /// </summary>

  public abstract class Player
  {
    private string name;
    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    // Constructor
    protected Player(string name)
    {
      this.name = name;
    }

    public abstract void Update(Board sea);
  }
}
