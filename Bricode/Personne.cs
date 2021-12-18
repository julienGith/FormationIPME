namespace Bricode
{
    public abstract class Personne
    {
        public string Name { get; set; }
        public virtual void Parler()
        {
            System.Console.WriteLine("parle de tout et de rien...");
        }

    }
}