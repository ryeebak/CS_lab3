using System;

public abstract class Currency
{
    protected double value;
}
class CurrencyUSD : Currency
{
    public CurrencyUSD(double value)
    {
        this.value = value;
    }

    public static implicit operator CurrencyEUR(CurrencyUSD val) // преобразование неявное
    {
        return new CurrencyEUR(val.value / CurrencyEUR.ExChange);
    }
    public static implicit operator CurrencyRUB(CurrencyUSD val)
    {
        return new CurrencyRUB(val.value / CurrencyRUB.ExChange);
    }
    public double Value
    {
        get { return this.value; }
    }
}
class CurrencyEUR : Currency
{
    public static double ExChange { get; set; }

    public CurrencyEUR(double value)
    {
        this.value = value;
    }
    public static implicit operator CurrencyRUB(CurrencyEUR val)
    {
        return new CurrencyRUB(val.value * CurrencyEUR.ExChange / CurrencyRUB.ExChange);
    }
    public static implicit operator CurrencyUSD(CurrencyEUR val)
    {
        return new CurrencyUSD(val.value * CurrencyEUR.ExChange);
    }
    public double Value
    {
        get { return this.value; }
    }
}
class CurrencyRUB : Currency
{
    public static double ExChange { get; set; }
    public CurrencyRUB(double value)
    {
        this.value = value;
    }
    public static implicit operator CurrencyUSD(CurrencyRUB val)
    {
        return new CurrencyUSD(val.value * CurrencyRUB.ExChange);
    }
    public static implicit operator CurrencyEUR(CurrencyRUB val)
    {
        return new CurrencyEUR(val.value * CurrencyRUB.ExChange / CurrencyEUR.ExChange);
    }
    public double Value
    {
        get { return this.value; }
    }
}

public class lab3task3
{
    public static void Main(string[] args)
    {
        CurrencyEUR.ExChange = 1;
        CurrencyRUB.ExChange = 0.5;
        
        CurrencyEUR eur1 = new CurrencyEUR(100);
        Console.WriteLine($"We have " + eur1.Value + " euros");
        CurrencyRUB rub1 = eur1;
        Console.WriteLine($"It's {rub1.Value} RUB");
        CurrencyUSD usd1 = rub1;
        Console.WriteLine($"It's {usd1.Value} USD");

        CurrencyUSD cur2 = new CurrencyUSD(100);
        Console.WriteLine($"We have " + cur2.Value + " dollars");
        CurrencyEUR eur2 = cur2;
        Console.WriteLine($"It's {eur2.Value} EUR");
        CurrencyRUB rub2 = eur2;
        Console.WriteLine($"It's {rub2.Value} RUB");
        
        CurrencyRUB rub3 = new CurrencyRUB(200);
        Console.WriteLine($"We have " + rub3.Value + " rubles");
        CurrencyEUR eur3 = rub3;
        Console.WriteLine($"It's {eur3.Value} EUR");
        CurrencyUSD usd3 = eur3;
        Console.WriteLine($"It's {usd3.Value} USD");
    }
}
