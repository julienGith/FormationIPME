namespace DemoCode
{
    public class Exception
    {
        public static void crash(string a)
        {
            int v1;
        
            try
            {
                v1= int.Parse(a);
                System.Console.WriteLine(v1);
            }
            catch (System.FormatException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}