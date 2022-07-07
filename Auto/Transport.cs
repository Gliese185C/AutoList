using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Auto;

abstract public class Transport
{
    protected string TT;
    private string Width;
    private string Height;
    private string Weight;
    private string Power;
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
    public string width
    {
        get { return Width;}
        set
        {
            try
            {
                if (Convert.ToDouble(value) < 0 )
                {
                    Width = "-";
                }
                else
                {
                    Width = value;
                }
            }
            catch
            {
                Console.WriteLine("Width was entered incorrectly, not saved, needs to be changed");
                Width = "-";
            }
        }
    }

    public string height
    {
        get { return Height; }
        set
        {
            try
            {
                if (Convert.ToDouble(value) < 0 )
                {
                    Height = "-";
                }
                else
                {
                    Height = value;
                }
            }
            catch
            {
                Console.WriteLine("Height was entered incorrectly, not saved, needs to be changed");
                Height = "-";
            }
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

    public string weight
    {
        get { return Weight; }
        set
        {
            try
            {
                if (Convert.ToDouble(value) < 0 )
                {
                    Weight = "-";
                }
                else
                {
                    Weight = value;
                }
            }
            catch
            {
                Console.WriteLine("Weight was entered incorrectly, not saved, needs to be changed");
                Weight = "-";
            }
        }
    }

    public string power
    {
        
        get { return Power; }
        set
        {
            try
            {
                if (Convert.ToDouble(value) < 0 )
                {
                    Power = "-";
                }
                else
                {
                    Power = value;
                }
            }
            catch
            {
                Console.WriteLine("Power was entered incorrectly, not saved, needs to be changed");
                Power = "-";
            }
        }
    }
}

public class Machine : Transport
{
    public static string lastID;
    private string Transmission;
    private string Equipment;
    private string Mileage;
    private string Actuator;

    protected string[] add_n = {"Name: ", "Power: ", "Transmission: ","Actuator: ", "Equipment: ", "Mileage: ","Color: ", "Width: ","Height: ", "Weight: "};
    
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
    public string mileage
    {
        get { return Mileage; }
        set
        {
            try
            {
                if (Convert.ToDouble(value) < 0 )
                {
                    Mileage = "-";
                }
                else
                {
                    Mileage = value;
                }
            }
            catch
            {
                Console.WriteLine("Mileage was entered incorrectly, not saved, needs to be changed");
                Mileage = "-";
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
                Console.WriteLine("Actuator was entered incorrectly, not saved, needs to be changed");
                Actuator = "-";
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
                Console.WriteLine("Transmission was entered incorrectly, not saved, needs to be changed");
                Transmission = "-";
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
                Console.WriteLine("Equipment was entered incorrectly, not saved, needs to be changed");
                Equipment = "-";
            }
        }
    }

    public void CompleteData(string[] data)
    {
        this.type = data[0];
        this.id = data[1];
        this.name = data[2].Replace(" ","_");
        this.power = data[3];
        this.transmission = data[4];
        this.actuator = data[5];
        this.equipment = data[6];
        this.mileage = data[7];
        this.color = data[8];
        this.width = data[9];
        this.height = data[10];
        this.weight = data[11];
        
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
                this.power = data;
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
                this.mileage = data;
                break;
            case "7":
                this.color = data;
                break;
            case "8":
                this.width = data;
                break;
            case "9":
                this.height = data;
                break;
            case "10":
                this.weight = data;
                break;
            default:
                break;
        }

        return "0";
    }

    public void add_new()
    {
        string[] data = new string[12];
        data[0] = "Auto";
        data[1] = Convert.ToString(Convert.ToInt32(lastID) + 1);
        for (int i = 0; i < add_n.Length; i++)
        {
            Console.Write(add_n[i]);
            data[i+2]=(Console.ReadLine());
        }
        CompleteData(data);
    }
}