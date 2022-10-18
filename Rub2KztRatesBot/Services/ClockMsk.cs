namespace Rub2KztRatesBot.Services;

public interface IClock
{
    DateTime Current { get; }
    DateOnly CurrentDate { get; }
}

public class ClockMsk : IClock
{
    public DateTime Current => CurrentMSK;
    public DateOnly CurrentDate => DateOnly.FromDateTime(CurrentMSK);
    private static DateTime CurrentMSK => DateTime.UtcNow.AddHours(3);
}