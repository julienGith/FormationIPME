namespace Bricode
{
    public class Instrument : IInstrument
    {
        public void MakeSound()
        {
            System.Console.WriteLine("sonnnnnnn");
        }
        public Instrument CreateInstrument()
        {
            Instrument instrument = new Instrument();
            return instrument;
        }
    }
}