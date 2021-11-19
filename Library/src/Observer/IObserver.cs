using System;
using Library.src;

namespace Library
{
  /// <summary>
  /// The 'Observer' interface
  /// </summary>

  public interface IObserver
  {

    public string Name { get; set; }
    public Contestant PlayerType {get;set;}

    void Update(string name);
  }
  
}
