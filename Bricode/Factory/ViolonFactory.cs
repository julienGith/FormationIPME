namespace Bricode
{
    public class ViolonFactory : InstrumentFactory
    {
        public override IInstrument CreateInstrument()
        {
            IInstrument violon = new Violon();
            return violon;
        }
    }
}