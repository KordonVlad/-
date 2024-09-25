using System;

public class Triangle
{
    private double sideA;
    private double sideB;
    private double sideC;
    private string color;
    private bool isVisible;

    public Triangle()
    {
        sideA = 1;
        sideB = 1;
        sideC = 1;
        color = "white";
        isVisible = true;
    }

    public Triangle(double sideA, double sideB, double sideC, string color, bool isVisible)
    {
        this.sideA = sideA;
        this.sideB = sideB;
        this.sideC = sideC;
        this.color = color;
        this.isVisible = isVisible;
    }

    public double CalculateArea()
    {
        double semiPerimeter = (sideA + sideB + sideC) / 2;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Triangle Info:");
        Console.WriteLine($"Sides: {sideA}, {sideB}, {sideC}");
        Console.WriteLine($"Color: {color}");
        Console.WriteLine($"Visible: {(isVisible ? "Yes" : "No")}");
        Console.WriteLine($"Area: {CalculateArea()}");
    }

    public void FormatneVyvedennia()
    {
        Console.WriteLine($"Сторони: ({sideA}, {sideB}, {sideC}), Колір: {color}, Видимий: {isVisible}, Площа: {CalculateArea()}");
    }

    public string GetColor() => color;
}
