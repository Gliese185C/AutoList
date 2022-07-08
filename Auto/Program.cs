using System.Diagnostics;
using System.Linq.Expressions;
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
    Console.Clear();
    Console.WriteLine("General Menu:\n" +
                      "[ 1 ] Show the list of items|\n" +
                      "[ 2 ] Show item info by id  |\n" +
                      "[ 3 ] Edit item info        |\n" +
                      "[ 4 ] Add new item          |\n" +
                      "[ 5 ] Delete item           |\n");

    Console.Write("|:::=>| ");
    string key = Console.ReadLine();
    switch (key)
    {
        case "1":
            Console.Clear();
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
                    Console.Clear();
                }
            }

            break;
        case "2":
            bool sec2 = true;
            while (sec2)
            {
                Console.Clear();
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
                    Console.Clear();
                }
            }

            break;
        case "3":
            bool sec3 = true;
            while (sec3)
            {
                Console.Clear();
                Console.Write("Enter the name or ID of the item: ");
                
                string choose = Console.ReadLine();
                IEnumerable<Machine> list2 = from items in Auto_list
                    where items.name == choose.Replace(" ", "_") || items.id == choose.Replace(" ", "")
                    select items;
                Machine[] list = new Machine[list2.Count()];
                int g = 0;
                foreach (Machine t in list2)
                {
                    list[g] = t;
                    g++;
                }
                Console.WriteLine("HELLO");
                if (list2.Count() > 1)
                {
                    bool sec3_3 = true;
                    int index = 0;
                    Console.WriteLine("Several objects were found according to your request: ");
                    bool l120 = true;
                    while (l120) {
                    int i = 1;
                    foreach (Machine elements in list2)
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
                            Console.Clear();
                            Console.WriteLine("Incorrect data input");
                        }
                    }
                    catch
                    {
                        Console.Clear();
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
                        // this string delete my element in list2 why?????????
                        list2.ElementAt(index-1).ChangeInfo(Convert.ToString(tmp), info);
                        //list[index].ChangeInfo(Convert.ToString(tmp), info);
                        //if (problem == "1")
                        //{
                        //    Console.WriteLine("The entered information does not correspond to this parameter\n" +
                        //                      "The information was not saved");
                       // }
                        
                        Console.WriteLine("The information was successfully saved");
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
                else if (list2.Count() == 1)
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
                            elements.ChangeInfo(Convert.ToString(tmpt), info);
                        }
                    }
                }
                else
                {
                    bool l201 = true;
                    while (l201)
                    {
                        Console.Clear();
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
            bool l318 = true;
            while (l318)
            {
                Machine elemnt = new Machine();
                elemnt.add_new();
                Console.WriteLine("[ 1 ] Save and exit    [ 2 ] Re-enter the data     [ 3 ] Do not save and exit");
                bool l324 = true;
                while (l324)
                {
                    Console.Write("|[1-3]<=::::| ");
                    string k327 = Console.ReadLine();
                    if (k327 == "1")
                    {
                        Auto_list.Add(elemnt);
                        Console.WriteLine("The item was successfully saved and added to the catalog");
                        l324 = false;
                        l318 = false;
                    }
                    else if (k327 == "2")
                    {
                        l324 = false;
                    }
                    else if (k327 == "3")
                    {
                        l318 = false;
                        l324 = false;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect data input");
                    }
            }
            }
            break;
        case "5":
            bool l354 = true;
            while (l354)
            {
                Console.Clear();
                Console.WriteLine("[ 1 ] Delete item by id\n" +
                                  "[ 2 ] Show all items to select one to delete\n" +
                                  "[ 3 ] Remove items by a certain characteristic\n" +
                                  "[ 4 ] Delete the entire directory\n" +
                                  "[ 5 ] General menu\n");
                Console.Write("|[1-5] <==::| ");
                string k363 = Console.ReadLine();
                switch (k363)
                {
                    case "1":
                        bool l368 = true;
                        while (l368)
                        {
                            Console.Clear();
                            Console.Write("Enter item id: ");
                            string k372 = Console.ReadLine();
                            int index = Auto_list.FindIndex(item => item.id == k372);
                            if (index == -1)
                            {
                                Console.WriteLine("No item with this id was found");
                            }
                            else
                            {
                                Auto_list.RemoveAt(index);
                            }

                            bool l385 = true;
                            while (l385) {
                            Console.Write("[ 1 ] Back     [ 2 ] Delete another item\n|[1-2] <==::| ");
                            string k389 = Console.ReadLine();
                            if (k389 == "1")
                            {
                                l385 = false;
                                l368 = false;
                            }
                            else if (k389 == "2")
                            {
                                l385 = false;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect input data");
                            }
                            }
                            Console.Clear();
                        }

                        break;
                    case "2":
                        bool l405 = true;
                        while (l405)
                        {
                            Console.Clear();
                            int count = 1;
                            foreach (Machine item in Auto_list)
                            {
                                Console.WriteLine($"[           {count}         ]");
                                Console.WriteLine(item.showdata());
                                count++;
                            }
                            bool l415 = true;
                            while (l415)
                            {
                                Console.Write("[ 1 ] Back     [ 2 ] Delete item\n|[1-2]<==:::| ");
                                string k419 = Console.ReadLine();
                                if (k419 == "1")
                                {
                                    l415 = false;
                                    l405 = false;
                                }
                                else if (k419 == "2")
                                {
                                    bool l426 = true;
                                    while (l426)
                                    {
                                        
                                        Console.Write($"Enter the number of item in the list above\n|[1-{count-1}]<==:::| ");
                                        string k430 = Console.ReadLine();
                                        try
                                        {
                                            Auto_list.RemoveAt(Convert.ToInt32(k430)-1);
                                            Console.WriteLine("The item was successfully deleted");
                                            l426 = false;
                                            l415 = false;
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Incorrect data input");
                                            Console.Write("[ 1 ] Back\n|[1-2]<==:::| ");
                                            string k441 = Console.ReadLine();
                                            if (k441 == "1")
                                            {
                                                l426 = false;
                                                l415 = false;
                                            }
                                        }
                                    }
                                }
                                Console.Clear();
                            } 
                        }
                        break;
                    case "3":
                        bool l454 = true;
                        while (l454)
                        {
                            Console.Clear();
                            Console.Write(
                                "Enter some data to search for the item you need, it can be an id or part of a name or other characteristics such as power\n|<==:::| ");
                            string k458 = Console.ReadLine();
                            IEnumerable<Machine> find_items = from item in Auto_list
                                where item.name.Contains(k458) || item.color.Contains(k458) ||
                                      item.actuator.Contains(k458)
                                      || item.equipment.Contains(k458) || item.mileage.Contains(k458) ||
                                      item.power.Contains(k458)
                                      || item.width.Contains(k458) || item.weight.Contains(k458) ||
                                      item.height.Contains(k458) || item.id.Contains(k458)
                                      orderby item.name
                                select item;
                            if (find_items.Count() > 0)
                            {
                                int count = 0;

                                //Machine[] items = new Machine[find_items.Count()];
                                List<Machine> items = new List<Machine>();

                                foreach (Machine info in find_items)
                                {
                                    //items[i]=info;
                                    items.Add(info);

                                }

                                bool l480 = true;
                                while (l480)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Count of items found {items.Count()}");
                                    if (items.Count() == 0)
                                    {
                                        Console.WriteLine("The list is empty");
                                        Console.Write("[ 1 ] Menu\n|[1]<==:::| ");
                                        string k490 = Console.ReadLine();
                                        if (k490 == "1")
                                        {
                                            l480 = false;
                                            l454 = false;
                                            
                                        }
                                    }
                                    else
                                    {
                                        if (count == 0)
                                        {
                                            Console.WriteLine($"[           {count + 1}         ]");
                                            Console.WriteLine(items[count].showdata());
                                            Console.Write(
                                                "[ 1 ] Menu     [ 2 ] Next     [ 3 ] Delete this\n|[1-2]<==:::| ");
                                            string k490 = Console.ReadLine();
                                            if (k490 == "1")
                                            {
                                                l480 = false;
                                                l454 = false;
                                            }
                                            else if (k490 == "2")
                                            {
                                                count++;
                                            }
                                            else if (k490 == "3")
                                            {
                                                Auto_list.RemoveAt(Auto_list.FindIndex(c => c.id == items[count].id));
                                                items.RemoveAt(count);
                                            }
                                            
                                        }
                                        else if (count < items.Count() - 1)
                                        {
                                            Console.WriteLine("The following items were found: ");
                                            Console.WriteLine($"[           {count + 1}         ]");
                                            Console.WriteLine(items[count].showdata());
                                            Console.Write(
                                                "[ 1 ] Menu     [ 2 ] Back     [ 3 ] Next     [ 4 ] Delete this\n|[1-2]<==:::| ");
                                            string k490 = Console.ReadLine();
                                            if (k490 == "1")
                                            {
                                                l480 = false;
                                                l454 = false;
                                            }
                                            else if (k490 == "2")
                                            {
                                                count--;
                                            }
                                            else if (k490 == "3")
                                            {
                                                count++;
                                            }
                                            else if (k490 == "4")
                                            {
                                                Auto_list.RemoveAt(Auto_list.FindIndex(c => c.id == items[count].id));
                                                items.RemoveAt(count);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("The following items were found: ");
                                            Console.WriteLine($"[           {count + 1}         ]");
                                            Console.WriteLine(items[count].showdata());
                                            Console.Write(
                                                "[ 1 ] Menu     [ 2 ] Back     [ 3 ] Delete this\n|[1-2]<==:::| ");
                                            string k490 = Console.ReadLine();
                                            if (k490 == "1")
                                            {
                                                l480 = false;
                                                l454 = false;
                                            }
                                            else if (k490 == "2")
                                            {
                                                count--;
                                            }
                                            else if (k490 == "3")
                                            {
                                                Auto_list.RemoveAt(Auto_list.FindIndex(c => c.id == items[count].id));
                                                items.RemoveAt(count);
                                                count--;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("According to this information, nothing was found");
                                bool l483 = true;
                                while (l483)
                                {
                                    Console.Write("[ 1 ] Back     [ 2 ] Re-enter information\n|[1-2]<==:::| ");
                                    string k487 = Console.ReadLine();
                                    if (k487 == "1")
                                    {
                                        l483 = false;
                                        l454 = false;
                                    }
                                    else if (k487 == "2")
                                    {
                                        l483 = false;
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
                    case "5":
                        l354 = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect data input");
                        break;
                }
            }

            break;
        default:
            break;
        

    }
}


