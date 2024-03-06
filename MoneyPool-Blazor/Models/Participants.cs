
    
public class Participants
    {
        public int Number { get; set; }
        public string Name { get; set; }

        public Participants(string name, int number)
        {
            Number = number;
            Name = name;
        }
    }