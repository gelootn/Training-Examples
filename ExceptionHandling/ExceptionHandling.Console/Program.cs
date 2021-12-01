// See https://aka.ms/new-console-template for more information


using ExceptionHandling;
using ExceptionHandling.Console;

Console.WriteLine("Exception Handling!!!");
Console.ReadLine();

var calculator = new Calculator();

try
{
    Console.WriteLine("Try");
    //throw new NotImplementedException();
    //throw new MyFirstException("somthing was wrong");

    var result = calculator.Divide(10, 0);
    Console.ReadLine();


}
catch (MyFirstException ex)
{
    Console.WriteLine("My Catch");
    Console.Write(ex.MyProp);
    Console.ReadLine();
}
catch (NotImplementedException ex)
{
    Console.WriteLine("Specific Catch");
    Console.Write(ex.Message);
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine("General Catch");
    Console.Write(ex.Message);
    Console.ReadLine();

}
finally
{
    Console.WriteLine("Finaly");

    Console.ReadLine();
}


