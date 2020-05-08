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
    }
  }
}