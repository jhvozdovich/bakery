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
       (___ ) (___) (___) (___ ) (___) (___)        '.___.'   ");
      Console.WriteLine("We're originally known as Guchokipanya, but became famous for our delivery girl - Kiki!");
      Console.WriteLine("She's quite special! If you're lucky you might get to see her today.");

      Console.WriteLine("Can I get a name for your order?");
      string name = Console.ReadLine();
      Console.WriteLine("Let's get started " + name + "!");

      Order customer = new Order(name);
      
      BeginOrder();
       
    }

    public static void BeginOrder()
    {
      Console.WriteLine("What would you like?");
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
      Order.Bread bread = new Order.Bread("bread", 5);
      Console.WriteLine("How many loaves would you like today?");
      int breadNumber = int.Parse(Console.ReadLine());
      int breadTotalCost = Bakery.BakedGoods.Order.Bread.CalculateBread(breadNumber, bread.Price);

      if (breadNumber >= 3)
      {
        Console.WriteLine("Lucky you! Bread is buy 2 get 1 free today!");
      }

      Console.WriteLine("Your bread total is: $" + breadTotalCost);
      //add complete order logic
      Console.WriteLine("Would you like to order more? Y/N");

      string continueAnswer = Console.ReadLine().ToLower();
      Continue(continueAnswer);
    }

    public static void PastryOrder()
    {
      Order.Pastry pastry = new Order.Pastry("pastry", 2);
      Console.WriteLine("How many pastries would you like today?");
      int pastryNumber = int.Parse(Console.ReadLine());
      int pastryTotalCost = Bakery.BakedGoods.Order.Pastry.CalculatePastry(pastryNumber, pastry.Price);

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
        Console.WriteLine(@"
        　　　　　　　　　　　　　　　　　 　 ,.rヽ
　　　　　　　　　　　　　　　　　　　　   　／　　 '.,
　　　　　　 ,,..,,　　　　　　　　　　　 ／　　　　 ヽ、
　　　　　　 |　 ｀'' ‐ ､　　　　　　　/　　　　　　　 ヽ
　　　　 　 /　　　　　 ヽ、　　　　/　　　　　　　　　 ' ,
　　　　 ／　　　　　　　 ヽ　　　/　　　　　　　　　　　ヽ
　　　, '　　　　　　　　　　 ヽ　 .l　　　　　　　　　　　　　',
　　 /　　　　　　　　　　　　 ',_,.|　,　　　　　　　　　　　,.､'
　　/　　　　　　　　＼　　　,.r‐レ　　　　　　　　　 ,.r'´:::::ヽ、
　 .|　　　　　　　　　　 ヽ,,/　 ./______,,,,,.... --‐ 'ヽ´::::ヽ、
　　l　　　　　　　　 ,,..... --'‐'''´　　　｀ '' ‐ ､　　　 ヽ::::::ヽ
　　ヽ.....,,,,..__,.-‐''´:::::::::::::::::::::::::::::::::::ヽ、　 
　　　..,-__'',,..,.r'::::::::::::::::::l:::::::::::::::::::::::::::::::::＼　
　　　　　 ／:::::::::::::::/:/l:::::::::::l::::::::::､:::::::::::::::::::::::::ヽ　
　　　　 .//::::::l::::::l:::l .|::l:::::::::l ､:::::ヽ ､::::ヽ､::ヽ::::::::'.,
　　　　 |::|:i:::::|::::/l::|　',:::',::::::::',ヽ､::::ヽヽ､.,__ヽヽ:::',.!::::ヽ＼_
　　　　 |:|::|:::::|:::| .l:l 　 ヽヽ､::::ヽ、‐- ､.,,, ,,...`ヽ､ ､::::::::::::::ヽ、
　　　　　|/.l::::i::::',:l　ヽ、　　ヽ､ヽ..,`_､-‐''´_,,.,　　 `.ヽ::,.r'''ヽ::::::::::ヽ:',
　　　　　l　.ヽ::',:',:: 　 ,,. -‐ ‐　 `　　　 '´〈 ﾊ'　　　 .|| .|:::::::::,.r.ヽ:ｊヽ
　　　　　　　 |`ヽヽ､:ヽ　     , ''|':ヽ　　　　 　　　.`'　　　　 /:::::::::::,..､r''´
　 　 　 　 　 .|:::::`|;;;', ヽ　　ゞ.'　　　　　 　　　　 　 .／;;;',|::l ﾚヾ
　　　　　　　 .|::::::|;;;;;ヽ ',.　　　　 ヽ　　　　　　　　　/,´.,r‐‐'´|j
　　　　　　　　|:::l::::|;;;;;;;i　　　　　　　　/        　 ,. 'l´｀''
　　　　　　　　 ',::l:::|,;;;;;;;ヽ　　　　- ‐-　　　　  ／　 ',
　　　　　　　　　ヽl:|ヽ,.-､.,r''` .､　　　　　　　    .／　　　.',
　　　　　　　　　　.l|　　　　　,.'´ `'‐- ...,,,.. - '　　　　　,.ヽ--‐‐- ､
　　　　　　　　　　　　　　　 l:.:.:.:.:.:.:.:.:.:/ l　　　　　,.r '´:.::.:.:.:.:.:}
　　　　　　　　　　　　　　　 |:.:.:.:.:.:.:.:.:i　　　　 ,.r ':.:.:..:.:.:..:.:.:.ヽ、
　　　　　　　　　　　　　　　 |:.:.:.:.:.:.:.:.ヽ　 ,. r ':.:.:.:.::.:.:.:.:.:.:.:.:.:.:.:.:.ヽ
　　　　　　　　　　　　　　　 .|:.:.:.:.:.:.:.:.:.:｀´:.:.:.:.:.:..:.:.:.:.:.:.:.:.:..:.:.:.:.:.:.:.ヽ");
        Console.WriteLine("Your total today is $" + Order.OrderPrice + ".");
        Console.WriteLine("See you later!");
      }
    }
  }
}