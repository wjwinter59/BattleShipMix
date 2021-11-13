using System;

namespace Library
{
  /// <summary>
  /// The 'Observer' interface
  /// </summary>

  public interface IPlayer
  {
    public string Name { get; }
    void Update(string name);
  }
  
}
