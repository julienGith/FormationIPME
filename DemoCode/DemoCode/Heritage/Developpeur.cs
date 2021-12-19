namespace DemoCode
{
    public class Developpeur : Personne
    {
        
        public Developpeur(string name)
        {
            Name = name;
        }
        void code()
        {
            System.Console.WriteLine("je code");
        }
        public override void Parler()
        {
            System.Console.WriteLine("je parle de code et je m'appelle : {0}",Name);
        }
    }
}