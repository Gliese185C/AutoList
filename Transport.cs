using System.Drawing;
using System.Text.Json;

namespace Auto;

abstract public class Transport
{
    protected string TT;
    private double Width;
    private double Height;
    private double Weight;
    private double Power;
    private string Type;
    private string Color;

    private string Id;
    /*protected Transport(string name, double width, double height, double weight, double power)
    {
        Width = width;
        Height = height;
        Weight = weight;
        TT = name;
        Power = power;
    }*/

    public string id
    {
        get { return Id; }
        set { Id = value; }
    }
    public string type
    {
        get { return Type; }
        set
        {
            Type = value;
        }
    }
    
    public string color
    {
        get { return Color; }
        set { Color = value; }
    }
    public double width
    {
        get { return Width;}
        set
        {
            if (value > 0) Width = value;
        }
    }

    public double height
    {
        get { return Height; }
        set
        {
            if (value > 0) Height = value;
        }
    }

    public string name
    {
        get { return TT; }
        set
        {
            TT = value;
        }
    }

    public double weight
    {
        get { return Weight; }
        set
        {
            if (value > 0) Weight = value;
        }
    }

    public double power
    {
        
        get { return Power; }
        set
        {
            if (value > 0) Power = value;
        }
    }
}

public class Machine : Transport
{
    public static string lastID;
    private string Transmission;
    private string Equipment;
    private double Mileage;
    private string Actuator;
    /*public Machine(string name, double width, double height, double weight, double power,string dt, string equ) : base(name, width, height,
        weight, power)
    {
        Transmission = dt;
        Equipment = equ;
    }*/

    public string lastid
    {
        get { return lastID; }
    }
    public double mileage
    {
        get { return Mileage; }
        set
        {
            if (value >= 0)
            {
                Mileage = value;
            }
            else
            {
                Console.WriteLine("Error, incorrect input data");
            }
        }
    }
    public string actuator
    {
        get { return Actuator; }
        set {
            if (value == "FWD" || value == "RWD" || value == "4WD")
            {
                Actuator = value;
            }
            else
            {
                Console.WriteLine("Error, incorrect data input");
            }
        }
    }
    public string transmission
    {
        get { return Transmission; }
        set
        {
            if (value == "MT" || value == "AT" || value == "CVT" || value == "DCT")
            {
                Transmission = value;
            }
            else
            {
                Console.WriteLine("Error, incorrect data input");
            }
        }
    }

    public string equipment
    {
        get { return Equipment; }
        set
        {
            if (value == "Classic" || value == "Comfort" || value == "Luxe" || value == "Prestige" ||
                value == "Premium")
            {
                Equipment = value;
            }
            else
            {
                Console.WriteLine("Error, incorrect data input");
            }
        }
    }

    public void CompleteData(string[] data)
    {
        this.type = data[0];
        this.id = data[1];
        this.name = data[2];
        this.power = Convert.ToDouble(data[3]);
        this.transmission = data[4];
        this.actuator = data[5];
        this.equipment = data[6];
        this.mileage = Convert.ToDouble(data[7]);
        this.color = data[8];
        this.width = Convert.ToDouble(data[9]);
        this.height = Convert.ToDouble(data[10]);
        this.weight = Convert.ToDouble(data[11]);
        lastID = this.id;
    }

    public string showdata()
    {
        string info = "Name: " + this.name + "\n" +
                      "" + "Power: " + this.power + " h.p." + "\n" +
                      "" + "Transmission: " + this.transmission +"\n" +
                      "" + "Actuator: " + this.actuator + "\n" +
                      "" + "Equipment: " + this.equipment + "\n" +
                      "" + "Mileage: " + this.mileage + " km" + "\n" +
                      "" + "Color: " + this.color + "\n" +
                      "" + "Width: " + this.width +  " mm" + "\n" + 
                      "" + "Height: " + this.height + " mm" + "\n" +
                      "" + "Weight: " + this.weight + " kg" + "\n" +
                      "----------------------------------------------";
        return info;
    }

    public string ChangeInfo(string tmp,string data)
    {
        switch (tmp)
        {
            case "1":
                this.name = data;
                break;
            case "2":
                try
                {
                    this.power = Convert.ToDouble(data);
                }
                catch
                {
                    return "1";
                }
                break;
            case "3":
                this.transmission = data;
                break;
            case "4":
                this.actuator = data;
                break;
            case "5":
                this.equipment = data;
                break;
            case "6":
                try
                {
                    this.mileage = Convert.ToDouble(data);
                }
                catch
                {
                    return "1";
                }
                break;
            case "7":
                this.color = data;
                break;
            case "8":
                try
                {
                    this.width = Convert.ToDouble(data);
                }
                catch
                {
                    return "1";
                }
                break;
            case "9":
                try
                {
                    this.height = Convert.ToDouble(data);
                }
                catch
                {
                    return "1";
                }
                break;
            case "10":
                try
                {
                    this.weight = Convert.ToDouble(data);
                }
                catch
                {
                    return "1";
                }
                break;
            default:
                break;
        }

        return "0";
    }
}