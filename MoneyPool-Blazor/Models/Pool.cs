using System.Text.Json;

namespace MoneyPool.Blazor.Models
{
    public class Pool
    {
        public List<Participant> ParticipantsList { get; set; }
        public List<Round> RoundsList { get; set; }

        public int MonthlyAmount { get; set; }
        public int TotalAmount { get; set; }

        public DateTime StartingDate {  get; set; }

        public Pool(List<Participant> participantsList, int monthlyAmount, DateTime startingDate)
        {
            ParticipantsList = participantsList;
            RoundsList = new List<Round>();
            MonthlyAmount = monthlyAmount;
            TotalAmount = ParticipantsList.Count * MonthlyAmount;
            StartingDate = startingDate;
        }

        public void CalculateRounds()
        {
            Random random = new Random();
            RoundsList.Clear();


            List<Participant> shuffledParticipants = ParticipantsList.OrderBy(_ => random.Next()).ToList();

            foreach (var participant in shuffledParticipants)
            {
                RoundsList.Add(new Round { Date = StartingDate, Participant = participant });
                StartingDate = StartingDate.AddMonths(1);
                
            }
        }



        public string Serialize()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }


    }

}
