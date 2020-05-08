using System;
using System.Collections.Generic;
using Bakery.BakedGoods;

namespace Bakery
{
  public class Program
  {
    
    public static void Main()
    {
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
      Console.WriteLine("Can I get a name for your order?");
      string name = Console.ReadLine();
      Console.WriteLine("Let's get started " + name + "!");
      Console.WriteLine("Bread is buy 2 get 1 free at $5 a loaf.");
      Console.WriteLine("Pastries are one for $2 or 3 for $5!");

      Order customer = new Order(name);

      while (Order.GetContinueOrdering() == true)
      {
        int price = BeginOrder();
        customer.AddToOrder(price);
        Console.WriteLine("Your current total is: $" + customer.GetOrderPrice() + ".");
        Continue(customer.GetOrderPrice());
      }

      FinishOrder(customer.GetOrderPrice());
    }

    public static int BeginOrder()
    {
      Console.WriteLine("What would you like?");
      Console.WriteLine("B: Bread, P: Pastry");
      string breadOrPastry = Console.ReadLine().ToLower();

      if (breadOrPastry == "b" || breadOrPastry == "bread")
      {
        int breadPrice = BreadOrder();
        return breadPrice;
      }
      else if ( breadOrPastry == "p" || breadOrPastry == "pastry")
      {
        int pastryPrice = PastryOrder();
        return pastryPrice;
      }
      else
      {
        Console.WriteLine("Sorry! I didn't catch that!");
        return 0;
      }
    }

    public static int BreadOrder()
    {
      Bread bread = new Bread("bread", 5);
      Console.WriteLine("How many loaves would you like today?");
      string breadString = Console.ReadLine();
      while (!Int32.TryParse(breadString, out int result))
      {
        Console.WriteLine("Sorry I didn't catch that! Please enter a number of loaves.");
        breadString = Console.ReadLine();
      }
      int breadNumber = int.Parse(breadString);
      int breadTotalCost = Bakery.BakedGoods.Bread.CalculateBread(breadNumber, bread.Price);

      if (breadNumber >= 3)
      {
        Console.WriteLine("Lucky you! Bread is buy 2 get 1 free today!");
      }

      Console.WriteLine("Your bread total is: $" + breadTotalCost);
      return breadTotalCost;
    }

    public static int PastryOrder()
    {
      Pastry pastry = new Pastry("pastry", 2);

      Console.WriteLine("What kind of pastry would you like?");
      Console.WriteLine("1: Pain au Chocolat, 2: Croissant, 3: Strudel, 4: Cream Puff, 5: Tartlet");
      Console.WriteLine("Please pick a number 1-5:");
      string pastryID = Console.ReadLine();

      while (pastryID == "pancakes")
      {
        Console.WriteLine(@"
　　 　 　 　　　　 　 lヽ 　 　 /l
　　　　　　 　    　 |::|ヽ__/::|
　　　　　　　 　 　  ／､_     ,､;ヽ
　　　　　 　　 　 ＝|;( - |.| - );|=
　　　　　　 　　  　 ヽ  -----  'ノ
　　　　　　　 　 　 　 /`;;;‐'';|
　　　　　　　   　　 |;         ;|
　　　　　　　 　 　  |;          ;＼
　　　　　　 　   　 i;            ;ヽ
　　　　　 　　      i;   ;|;  ;|;   ;|
　 　 　             |;   ;|;  ;|;    ;
                    |;   ;|;  ;|;    ;|　　____,,,,,,,__
                    |;   ;|;  ;|;     ;|‐;;            ;ヽ 
                    ");
        Console.WriteLine("Jiji says don't get fat!");
        Console.WriteLine("Now put in a valid pastry ID please!");
        pastryID = Console.ReadLine();
      }

      string[] pastryName = DeterminePastry(pastryID);

      while (pastryName[0] == "error")
      {
        Console.WriteLine("Sorry I didn't catch that! Please enter a valid pastry ID number.");
        pastryID = Console.ReadLine();
        pastryName = DeterminePastry(pastryID);
      }

      Console.WriteLine("How many " + pastryName[0] + " would you like today?");
      string pastryString = Console.ReadLine();
      while (!Int32.TryParse(pastryString, out int result))
      {
        Console.WriteLine("Sorry I didn't catch that! Please enter a number of pastries.");
        pastryString = Console.ReadLine();
      }
      int pastryNumber = int.Parse(pastryString);
      int pastryTotalCost = Bakery.BakedGoods.Pastry.CalculatePastry(pastryNumber, pastry.Price);

      if (pastryNumber >= 3)
      {
        Console.WriteLine("You have an eye for deals! Pastries are 3 for $5!");
      }

      Console.WriteLine("That will be $" + pastryTotalCost);
      return pastryTotalCost;
    }

    public static string[] DeterminePastry(string pastryID)
    {
      if (pastryID == "1")
      {
        string[] pain = {"pains au chocolat", "painAuChocolat"};
        return pain;
      }
      else if (pastryID == "2")
      {
        string[] croissant = {"croissants", "croissant"};
        return croissant;
      }
      else if (pastryID == "3")
      {
        string[] strudel = {"strudels", "strudel"};
        return strudel;
      }
      else if (pastryID == "4")
      {
        string[] creamPuff = {"cream puffs", "creamPuff"};
        return creamPuff;
      }
      else if (pastryID == "5")
      {
        string[] tartlet = {"tartlets", "tartlet"};
        return tartlet;
      }
      else
      {
        string[] error = {"error", "error"};
        return error;
      }
    }

    public static void Continue(int price)
    {
      Console.WriteLine("Would you like to order more? Y/N");

      string continueAnswer = Console.ReadLine().ToLower();

      if (continueAnswer == "n" || continueAnswer == "no")
      {
        Order.DoneOrdering();
      }
    }

    public static void FinishOrder(int price)
    {
      Console.WriteLine(@"
        　　　　　　　　　　　　　　　　　 　 ,.rヽ
　　　　　　　　　　　　　　　　　　　　   　／　　 '.,
　　　　　　 ,,..,,　　　　　　　　　　　 ／　　　　 ヽ、
　　　　　　 |　 ｀'' ‐ ､　　　　　　　/　　　　　　　 ヽ
　　　　 　 /　　　　　 ヽ、　　　　/　　　　　　　　　 ' ,
　　　　 ／　　　　　　　 ヽ　　　/　　　　　　　　　　　ヽ
　　　, '　　　　　　　　　　 ヽ　 .l　　　　　　　　　　　　　',
　　 /　　　　　　　　　　　　 ',_,.|　,　　　　　　　　　　　,.､'
　　/　　　　　　　　＼　　　,.r‐レ　　　　　　　　　 ,.r'´:::ヽ、
　 .|　　　　　　　　　　 ヽ,,/　 ./______,,,,,.... --‐ 'ヽ´::ヽ、
　　l　　　　　　　　 ,,..... --'‐'''´　　　｀ '' ‐ ､　　　 ヽ::::ヽ
　　ヽ.....,,,,..__,.-‐''´:::::::::::::::::::::::::::::::::::ヽ、　 
　　　..,-__'',,..,.r'::::::::::::::::::l:::::::::::::::::::::::::::::::::＼　
　　　　　 ／:::::::::::::::/:/l:::::::::::l::::::::::､:::::::::::::::::::::::::ヽ　
　　　　 .//::::::l::::::l:::l .|::l:::::::::l ､:::::ヽ ､::::ヽ､::ヽ::::::::'.,
　　　　 |::|:i:::::|::::/l::|　',:::',::::::::',ヽ､::::ヽヽ､.,__ヽヽ:::',.!::::ヽ＼_
　　　　 |:|::|:::::|:::| .l:l 　 ヽヽ､::::ヽ、‐- ､.,,, ,,...`ヽ､ ､::::::::::::::ヽ、
　　　　　|/.l::::i::::',:l　ヽ、　　ヽ､ヽ..,`_､-‐''´_,,.,　　 `.ヽ::,.r'''ヽ::::::::::ヽ:',
　　　　　l　.ヽ::',:',:: 　 ,,. -‐ ‐　 `　　　 '´〈 ﾊ'　　　 .|| .|:::::::::,.r.ヽ:ｊヽ
　　　　　　　 |`ヽヽ､:ヽ　     , ''|':ヽ　　　 　　　.`'　　　　 /:::::::::::,..､r''´
　 　 　 　 　 .|:::::`|;;;', ヽ　　ゞ.'　　　　　 　　　　 　 .／;;;',|::l ﾚヾ
　　　　　　　 .|::::::|;;;;;ヽ ',.　　　　 ヽ　　　　　　　　　/,´.,r‐‐'´|j
　　　　　　　　|:::l::::|;;;;;;;i　　　　　　 　　/        　 ,. 'l´｀''
　　　　　　　　 ',::l:::|,;;;;;;;ヽ　　 　　- ‐-　　　　  ／　 ',
　　　　　　　　　ヽl:|ヽ,.-､.,r''` .､　　　　　　　    .／　　　.',
　　　　　　　　　　.l|　　　　　,.'´ `'‐- ...,,,.. - '　　　　　,.ヽ--‐‐- ､
　　　　　　　　　　　　　　　 l:.:.:.:.:.:.:.:.:.:/ l　　　　　,.r '´:.::.:.:.:.:.:}
　　　　　　　　　　　　　　　 |:.:.:.:.:.:.:.:.:i　　　　 ,.r ':.:.:..:.:.:..:.:.:.ヽ、
　　　　　　　　　　　　　　　 |:.:.:.:.:.:.:.:.ヽ　 ,. r ':.:.:.:.::.:.::.:.:.:.:.:.:.ヽ
　　　　　　　　　　　　　　　 .|:.:.:.:.:.:.:.:.:.:｀´:.:.:.:.:.:..:.:.:.:.:.:.:.:.:.:.ヽ
                                                                                    ");
      Console.WriteLine("Your total today is $" + price + ".");
      Console.WriteLine("See you later!");
    }
  }
}