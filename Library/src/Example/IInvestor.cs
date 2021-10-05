using System;

namespace Library
{
  /// <summary>
  /// The 'Observer' interface
  /// </summary>

  public interface IInvestor
  {
    void Update(Stock stock);
  }
}
