namespace Kumibot.App.Helpers;

public static class BettingHelper
{
    public static int GetOdds(string oddsString)
    {
        bool isInt;
        if (oddsString.Contains('-'))
        {
            isInt = int.TryParse(oddsString, out var negativeOdds);
            if (isInt) return negativeOdds;
        }

        if (oddsString.Contains('+'))
        {
            isInt = int.TryParse(oddsString.Replace("+", string.Empty), out var positiveOdds);
            if (isInt) return positiveOdds;
        }

        isInt = int.TryParse(oddsString, out var odds);
        return isInt ? odds : 0;
    }
    
    public static double CalculateProfit(double betAmount, int odds)
    {
        var profit = odds switch
        {
            > 0 => betAmount * Math.Abs((double)odds / 100),
            < 0 => Math.Abs(betAmount / ((double)odds / 100)),
            _ => 0.00
        };

        return profit;
    }
}