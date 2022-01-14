using System.Text.Json.Serialization;

namespace ConsoleManager.Data.Models
{
    public class Question
    {
        public Question(string text, QuestionType questionType)
        {
            _text = text;
            _possibleChoices = 0;
            _possibleResponses = new List<string>();
            _questionType = questionType;
            _answers = new List<Answer>();
            _questionsFilles = new List<Question>();
        }
        public Question(string text, uint possibleChoices, QuestionType questionType):this(text,questionType)
        {
            _text = text;
            _possibleChoices = possibleChoices;
            _possibleResponses = new List<string>();
            _questionType = questionType;
            _answers = new List<Answer>();
            _questionsFilles = new List<Question>();
        }
        public Question(string text, uint possibleChoices, List<string>? PossibleResponses, Menu? menu, QuestionType questionType, List<Question>? QuestionsFilles):this(text, possibleChoices, questionType)   
        {
            _text = text;
            _possibleChoices = possibleChoices;
            _possibleResponses = PossibleResponses ?? new List<string>();
            _questionType = questionType;
            _answers = new List<Answer>();
            _questionsFilles = QuestionsFilles ?? new List<Question>();
        }
        private List<Question> _questionsFilles;

        public List<Question> QuestionsFilles
        {
            get { return _questionsFilles; }
            set { _questionsFilles = value; }
        }

        private Menu _menu;
        [JsonPropertyName("menu")]
        public Menu Menu
        {
            get { return _menu; }
            set { _menu = value; }
        }
        private QuestionType _questionType;
        [JsonPropertyName("questiontype")]
        public QuestionType QuestionType
        {
            get { return _questionType; }
            set { _questionType = value; }
        }

        private List<Answer> _answers;
        private int _id { get; init; }
        private string _text;
        private uint _possibleChoices;
        private List<string> _possibleResponses;
        [JsonPropertyName("answers")]
        public List<Answer> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }
        [JsonPropertyName("possibleresponses")]
        public List<string> PossibleResponses
        {
            get { return _possibleResponses; }
            set { _possibleResponses = value; }
        }
        [JsonPropertyName("text")]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        [JsonPropertyName("possiblechoices")]
        public uint PossibleChoices
        {
            get { return _possibleChoices; }
            set { _possibleChoices = value; }
        }
        [JsonPropertyName("id")]
        public int Id { get { return _id; } }
    }
}