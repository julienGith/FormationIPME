namespace ConsoleManager.Data.Models
{
    public class Question
    {
        public Question(string text, uint possibleChoices, List<string>? PossibleResponse)
        {
            _text = text;
            _possibleChoices = possibleChoices;
            _possibleResponse = PossibleResponse ?? new List<string>();
            _answers = new List<Answer>();
        }
        private List<Answer> _answers;
        private int _id { get; init; }
        private string _text;
        private uint _possibleChoices;
        private List<string> _possibleResponse;
        public List<Answer> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }
        public List<string> PossibleResponse
        {
            get { return _possibleResponse; }
            set { _possibleResponse = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public uint PossibleChoices
        {
            get { return _possibleChoices; }
            set { _possibleChoices = value; }
        }
        public int Id { get { return _id; } }
    }
}