using System;
using System.Collections.Generic;
using Bakery.BakedGoods;

namespace Bakery
{
  public class Program
  {
    public static void Main()
    {
      Bread bread = new Bread("bread", 5);
      Console.WriteLine(bread.Price);
    }
  }
}