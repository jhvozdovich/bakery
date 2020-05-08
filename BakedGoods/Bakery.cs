using System;

namespace Bakery.BakedGoods
{
  public class BakeryItems
  {
    public string Name { get; set; }
    public int Price { get; set; }

    public BakeryItems (string name, int price)
    {
      Name = name;
      Price = price;
    }
  }

  public class Bread : BakeryItems
  {
    public Bread(string name, int price) : base(name, price)
    {
      Name = name;
      Price = price;
    }

    public static int CalculateBread(double breadNumber, int breadPrice)
    {
      int breadDeal = Convert.ToInt32(breadNumber - Math.Floor(breadNumber / 3));
      int breadTotalCost = breadDeal * breadPrice;
      return breadTotalCost;
    }
  }

  public class Pastry : BakeryItems
  {
    public Pastry(string name, int price) : base(name, price)
    {
      Name = name;
      Price = price;
    }

    public static int CalculatePastry(double pastryNumber, int pastryPrice)
    {
      int pastryTotalCost = Convert.ToInt32(pastryNumber * pastryPrice - Math.Floor(pastryNumber / 3));
      return pastryTotalCost;
    }
  }

  

}