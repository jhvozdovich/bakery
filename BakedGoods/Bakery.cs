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
  }

  public class Pastry : BakeryItems
  {
    public Pastry(string name, int price) : base(name, price)
    {
      Name = name;
      Price = price;
    }
  }
}