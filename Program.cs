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
      Pastry pastry = new Pastry("pastry", 2);

      Console.WriteLine(@"
      ,--.   ,--.       ,--.                                  ,--------. ,-----.  
      |  |   |  | ,---. |  | ,---. ,---. ,--,--,--. ,---.     '--.  .--''  .-.  ' 
      |  |.'.|  || .-. :|  || .--'| .-. ||        || .-. :       |  |   |  | |  | 
      |   ,'.   |\   --.|  |\ `--.' '-' '|  |  |  |\   --.       |  |   '  '-'  ' 
      '--'   '--' `----'`--' `---' `---' `--`--`--' `----'       `--'    `-----'

        ___                ___               .--.             
       (   )         .-.  (   )         .-.  |  |             
        | |   ___   ( __)  | |   ___   ( __) '..'     .--.    
        | |  (   )  (''')  | |  (   )  (''')        /  _  \   
        | |  ' /     | |   | |  ' /     | |        . .' `. ;  
        | |,' /      | |   | |,' /      | |        | '   | |  
        | .  '.      | |   | .  '.      | |        _\_`.(___) 
        | | `. \     | |   | | `. \     | |       (   ). '.   
        | |   \ \    | |   | |   \ \    | |        | |  `\ |  
        | |    \ .   | |   | |    \ .   | |        ; '._,' '  
       (___ ) (___) (___) (___ ) (___) (___)        '.___.'   
       ");
       Console.WriteLine("We're originally known as Guchokipanya, but became famous for our delivery girl - Kiki!");
       Console.WriteLine("She's quite special! If you're lucky you might get to see her today.");
       BeginOrder();
    }

    public static void BeginOrder()
    {
      Console.WriteLine("What would you like to order?");
      Console.WriteLine("B: Bread, P: Pastry");
      string breadOrPastry = Console.ReadLine().ToLower();

      if (breadOrPastry == "b" || breadOrPastry == "bread")
      {
        BreadOrder();
      }
      else if ( breadOrPastry == "p" || breadOrPastry == "pastry")
      {
        PastryOrder();
      }
      else
      {
        Console.WriteLine("Sorry! I didn't catch that!");
        BeginOrder();
      }
    }

    public static void BreadOrder()
    {
      Console.WriteLine("How many loaves would you like today?");
      int breadNumber = int.Parse(Console.ReadLine());
      int breadTotalCost = Bakery.BakedGoods.Bread.CalculateBread(breadNumber, Bread.Price);

      if (breadNumber >= 3)
      {
        Console.WriteLine("Lucky you! Bread is buy 2 get 1 free today!");
      }

      Console.WriteLine("Your pastry total is: $" + breadTotalCost);
      //add complete order logic
      Console.WriteLine("Would you like to order more? Y/N");

      string continueAnswer = Console.ReadLine().ToLower();
      Continue(continueAnswer);
    }

    public static void PastryOrder()
    {
      Console.WriteLine("How many pastries would you like today?");
      int pastryNumber = int.Parse(Console.ReadLine());
      int pastryTotalCost = Bakery.BakedGoods.Pastry.CalculatePastry(pastryNumber, Pastry.Price);

      if (pastryNumber >= 3)
      {
        Console.WriteLine("You have an eye for deals! Pastries are 3 for $5!");
      }

      Console.WriteLine("Your pastry total is: $" + pastryTotalCost);
      //add complete order logic
      Console.WriteLine("Would you like to order more? Y/N");

      string continueAnswer = Console.ReadLine().ToLower();
      Continue(continueAnswer);
    }

    public static void Continue(string continueAnswer)
    {
      if (continueAnswer == "y" || continueAnswer == "yes")
      {
        BeginOrder();
      }
      else
      {
        Console.WriteLine("add order total logic");
      }
    }
  }
}