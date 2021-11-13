using System;

namespace Library
{
  /// <summary>
  /// The 'Observer' interface
  /// </summary>

  public abstract class Player
  {
    public Game game;// test 
    public Board zee;// test nog uitwerken met propertie ?
    private string name;
    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    // Constructor
    public Player() { }
    protected Player(string name)
    {
      this.name = name;
    }
    public Player(string name, Board sea)
    {
      this.name = name;
      this.zee = sea;
    }

    public abstract void Update(Board sea);
  }
}
