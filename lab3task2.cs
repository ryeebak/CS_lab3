using System;
using System.Collections.Generic;

class Car
{
    private string name;
    private int engine;
    private double maxSpeed;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Engine
    {
        get { return engine; }
        set { engine = value; }
    }

    public double MaxSpeed
    {
        get { return maxSpeed; }
        set { maxSpeed = value; }
    }

    public Car(string name, int engine, double maxSpeed)
    {
        Name = name;
        Engine = engine;
        MaxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return Name;
    }
}

class CarComparer : IEquatable<Car>
{
    public bool Equals(Car car1, Car car2)
    {
        if (car1 == null || car2 == null)
            return false;

        return car1.Name == car2.Name && car1.Engine == car2.Engine && car1.MaxSpeed == car2.MaxSpeed;
    }

    public bool Equals(Car other)
    {
        throw new NotImplementedException();
    }
}

class CarsCatalog
{
    private List<Car> cars;

    public CarsCatalog()
    {
        cars = new List<Car>();
    }

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public Car this[int index]
    {
        get
        {
            if (index >= 0 && index < cars.Count)
                return cars[index];
            else
                throw new IndexOutOfRangeException("Index is out of range");
        }
    }
}

class lab3task2
{
    static void Main()
    {
        Car car1 = new Car("Normal car", 200, 200);
        Car car2 = new Car("Super car", 800, 350);

        CarsCatalog catalog = new CarsCatalog();
        catalog.AddCar(car1);
        catalog.AddCar(car2);

        Console.WriteLine("Car 1 named " + catalog[0].Name + "; horse power - " + catalog[0].Engine + "; max speed - " + catalog[0].MaxSpeed);
        Console.WriteLine("Car 2 named " + catalog[1].Name + "; horse power - " + catalog[1].Engine + "; max speed - " + catalog[1].MaxSpeed);

        if (Equals(car1, car2))
            Console.WriteLine($"\n{car1} and {car2} are equal");
        else
            Console.WriteLine($"\n{car1} and {car2} are not equal");
    }
}
