namespace RandomDataGenWebApp.Models
{
    [Serializable]
    public class SourceDataModel
    {
        public string[] RU_names { get; set; }
        public string[] UK_names { get; set; }
        public string[] USA_names { get; set; }

        public string[] RU_surenames { get; set; }
        public string[] UK_surenames { get; set; }
        public string[] USA_surenames { get; set; }

        public string[] RU_middlenames { get; set; }
        public string[] UK_middlenames { get; set; }
        public string[] USA_middlenames { get; set; }

        public string[] RU_cities { get; set; }
        public string[] UK_cities { get; set; }
        public string[] USA_cities { get; set; }

        public string[] RU_villages { get; set; }

        public string[] RU_streets { get; set; }
        public string[] UK_streets { get; set; }
        public string[] USA_streets { get; set; }
    }
}
