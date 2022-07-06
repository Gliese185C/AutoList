using Auto;

string path = "C:\\Users\\JonyHowman\\Desktop\\Test\\AutoList\\Auto\\Catalog.txt";
List<Machine> Auto_list = new List<Machine>();
string message = "You can change next information of this item: \n" +
                 "[ 1 ] Name\n" +
                 "[ 2 ] Power\n" +
                 "[ 3 ] Transmission\n" +
                 "[ 4 ] Actuator\n" +
                 "[ 5 ] Equipment\n" +
                 "[ 6 ] Mileage\n" +
                 "[ 7 ] Color\n" +
                 "[ 8 ] Width\n" +
                 "[ 9 ] Height\n" +
                 "[ 10 ] Weight\n";

using (StreamReader reader = new StreamReader(path))
{
    string? line;
    int count = 0;
    while ((line = await reader.ReadLineAsync()) != null)
    {
        Auto_list.Add(new Machine());
        string[] data = line.Split(' ');
        Auto_list[count].CompleteData(data);
        count++;
    }
}

Console.WriteLine("The AutoCatalog application has been launched...");
bool application = true;
while (application)
{
    Console.WriteLine("General Menu:\n" +
                      "[ 1 ] Show the list of items|\n" +
                      "[ 2 ] Show item info by id  |\n" +
                      "[ 3 ] Edit item info        |\n");


    string key = Console.ReadLine();
    switch (key)
    {
        case "1":
            bool sec1 = true;
            Console.WriteLine("----------------------------------------------");
            foreach (Machine data in Auto_list)
            {
                Console.WriteLine(data.showdata().Replace("_", " "));
            }

            while (sec1)
            {
                Console.WriteLine("[ 1 ] Back     [ 2 ] General menu");
                Console.Write("|[1-2]<=::::| ");
                string Sec1 = Console.ReadLine();
                if (Sec1 == "1" || Sec1 == "2")
                {
                    sec1 = false;
                }
                else
                {
                    Console.WriteLine("Incorrect data input");
                }
            }

            break;
        case "2":
            bool sec2 = true;
            while (sec2)
            {
                Console.Write("Enter the id: ");
                string id = Console.ReadLine();
                IEnumerable<string> item = from items in Auto_list where items.id == id select items.showdata();
                if (item.Count() > 0)
                {
                    Console.WriteLine(item.ElementAt(0));
                    /*foreach (string info in item)
                    {
                        Console.WriteLine(info);
                    }*/
                }
                else Console.WriteLine("There is no available information on this identifier");

                bool sec2_2 = true;
                while (sec2_2)
                {
                    Console.WriteLine("[ 1 ] Back     [ 2 ] General menu      [ 3 ] Find other information");
                    Console.Write("|[1-3]<=::::| ");
                    string Sec2 = Console.ReadLine();
                    if (Sec2 == "1" || Sec2 == "2")
                    {
                        sec2_2 = false;
                        sec2 = false;
                    }
                    else if (Sec2 == "3")
                    {
                        sec2_2 = false;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect data input");
                    }
                }
            }

            break;
        case "3":
            bool sec3 = true;
            while (sec3)
            {

                Console.Write("Enter the name or ID of the item: ");
                string choose = Console.ReadLine();
                IEnumerable<Machine> list = from items in Auto_list
                    where items.name == choose.Replace(" ", "_") || items.id == choose.Replace(" ", "")
                    select items;
                if (list.Count() > 1)
                {
                    bool sec3_3 = true;
                    int index = 0;
                    Console.WriteLine("Several objects were found according to your request: ");
                    bool l120 = true;
                    while (l120) {
                    int i = 1;
                    foreach (Machine elements in list)
                    {
                        Console.WriteLine($"[ {i} ] {elements.name}");
                        i++;
                    }
                    Console.WriteLine($"[ {i} ] Back");
                    Console.Write("|:::=>| ");
                    try
                    {
                        index = Convert.ToInt32(Console.ReadLine());
                        if (index <= i)
                        {
                            if (index == i)
                            {
                                l120 = false;
                                sec3_3 = false;
                            }
                            else{
                            l120 = false;
                            sec3_3 = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect data input");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Incorrect data input");
                        sec3_3 = false;
                    }
                    }
                    while (sec3_3)
                    {
                        bool l160 = true;
                        int tmp = 0;
                        while (l160)
                        {
                            Console.WriteLine(message);
                            Console.WriteLine("[ 11 ] Back");
                            Console.Write("|:::=>| ");
                            
                            try
                            {
                                tmp = Convert.ToInt32(Console.ReadLine());
                                if (tmp > 11 || tmp <= 0)
                                {
                                    Console.WriteLine("Incorrect data input");
                                }
                                else
                                {
                                    if (tmp == 11)
                                    {
                                        l160 = false;
                                        sec3_3 = false;
                                    }
                                    else
                                    {
                                        l160 = false;
                                    }
                                }
                                
                            }
                            catch
                            {
                                Console.WriteLine("Incorrect data input");
                            }
                        }

                        if (sec3_3 == false)
                        {
                            break;
                        }
                        Console.WriteLine("Enter new information");
                        Console.Write("|:::=>| ");
                        string info = Console.ReadLine();
                        string problem = list.ElementAt(index).ChangeInfo(Convert.ToString(tmp), info);
                        if (problem == "1")
                        {
                            Console.WriteLine("The entered information does not correspond to this parameter\n" +
                                              "The information was not saved");
                        }
                        Console.WriteLine(
                            "[ 1 ] Back     [ 2 ] General menu      [ 3 ] Change over information of this item      [ 4 ] Change information another item");
                        Console.Write("|[1-4]<=::::| ");
                        string keysec3 = Console.ReadLine();
                        if (keysec3 == "1" || keysec3 == "2")
                        {
                            sec3_3 = false;
                            sec3 = false;
                        }
                        else if (keysec3 == "4")
                        {
                            sec3_3 = false;
                        }
                        else if (keysec3 == "3")
                        {
                            continue;
                        }
                    }
                }
                else if (list.Count() == 1)
                {
                    bool l224 = true;
                    int tmpt = 0;
                    while (l224)
                    {
                        bool l228 = true;
                        while (l228)
                        {
                            Console.WriteLine(message);
                            Console.WriteLine("[ 11 ] Back");
                            Console.Write("|:::=>| ");
                            try
                            {
                                tmpt = Convert.ToInt32(Console.ReadLine());
                                if (tmpt > 11 || tmpt <= 0)
                                {
                                    Console.WriteLine("Incorrect data input");
                                }
                                else
                                {
                                    if (tmpt == 11)
                                    {
                                        l228 = false;
                                        l224 = false;
                                    }
                                    else
                                    {
                                        l228 = false;
                                    }
                                }

                            }
                            catch
                            {
                                Console.WriteLine("Incorrect data input");
                            }
                        }

                        if (l224 == false)
                        {
                            break;
                        }
                        Console.WriteLine("Enter new information");
                        Console.Write("|:::=>| ");
                        string info = Console.ReadLine();
                        foreach (Machine elements in list)
                        {
                            string problem = elements.ChangeInfo(Convert.ToString(tmpt), info);
                            if (problem == "1")
                            {
                                Console.WriteLine("The entered information does not correspond to this parameter\n" +
                                                  "The information was not saved");
                            }
                        }
                    }
                }
                else
                {
                    bool l201 = true;
                    while (l201)
                    {
                    Console.WriteLine(
                        "Nothing was found, you may have entered incorrect data or such an item does not exist");
                    Console.WriteLine("[ 1 ] Back     [ 2 ] General menu     [ 3 ] Again");
                    string exit_return = Console.ReadLine();
                    
                    
                        if (exit_return == "1" || exit_return == "2")
                        {
                            l201 = false;
                            sec3 = false;
                        }
                        else if (exit_return == "3")
                        {
                            l201 = false;
                            
                        }
                        else
                        {
                            Console.WriteLine("Incorrect data input");
                        }
                    }
                }


            }

            break;
        case "4":
            break;
        default:
            break;
        

    }
}


