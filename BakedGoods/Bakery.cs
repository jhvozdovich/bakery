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
    private string _type;
    public Bread(string name, int price) : base(name, price)
    {
      Name = name;
      Price = price;
      _type = "bread";
    }
  }

  public class Pastry : BakeryItems
  {
    private string _type;
    public Pastry(string name, int price) : base(name, price)
    {
      Name = name;
      Price = price;
      _type = "pastry";
    }
  }
}