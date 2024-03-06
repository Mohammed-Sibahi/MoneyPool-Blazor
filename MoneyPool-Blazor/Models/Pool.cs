
public class Pool
{
    public List<Participants> ParticipantsList { get; set; }
    public List<Rounds> RoundsList { get; set; }

    public int MonthlyAmount { get; set; }

    public Pool(List<Participants> participantsList, int monthlyAmount)
    {
        ParticipantsList = participantsList;
        MonthlyAmount = monthlyAmount;
        RoundsList = new List<Rounds>();
    }

    public void CalculateRounds()
    {
        Random random = new Random();
        DateTime currentDate = new DateTime(2024, 2, 1);

        List<Participants> shuffledParticipants = ParticipantsList.OrderBy(_ => random.Next()).ToList();

        foreach (var participant in shuffledParticipants)
        {
            RoundsList.Add(new Rounds { Date = currentDate, Participant = participant });
            currentDate = currentDate.AddMonths(1);
        }
    }

    public void PrintResults()
    {
        Console.WriteLine($"Total amount for each participant: AED{ParticipantsList.Count * MonthlyAmount}");
        Console.WriteLine("Participants ordered by month (rounds): ");

        foreach (var round in RoundsList)
        {
            Console.WriteLine($"{round.Date:MMM d}: {round.Participant.Name}");
        }
    }

    public string Serialize()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }
}
