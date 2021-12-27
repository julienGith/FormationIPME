using System.Text.Json.Serialization;

namespace ConsoleManager.Data.Models
{
    public class Question
    {
        public Question(string text, uint possibleChoices, List<string>? PossibleResponse, Menu? menu, QuestionType questionType, List<Question>? QuestionsFilles)
        {
            _text = text;
            _possibleChoices = possibleChoices;
            _possibleResponse = PossibleResponse ?? new List<string>();
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
        private List<string> _possibleResponse;
        [JsonPropertyName("answers")]
        public List<Answer> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }
        [JsonPropertyName("possibleresponse")]
        public List<string> PossibleResponse
        {
            get { return _possibleResponse; }
            set { _possibleResponse = value; }
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