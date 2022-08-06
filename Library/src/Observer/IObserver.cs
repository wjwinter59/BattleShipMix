using System;
using Library.src.Harbour;

namespace Library.src.Observer
{
  /// <summary>
  /// The 'Observer' interface
  /// </summary>

  public interface IObserver
  {

    public string Name { get; set; }
    public Contestant PlayerType { get; set; }

    bool Update(string name);
    public void ShowFleet();
  }

}
