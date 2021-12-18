namespace Bricode
{
    public class GuitareFactory : InstrumentFactory
    {
        public override IInstrument CreateInstrument()
        {
            IInstrument guitare = new Guitare();
            return guitare;
        }
    }
}