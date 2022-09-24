using System;
using System.Collections.Generic;

namespace Restaurante{
    class Program{
        public class Dish{
            private string name;
            private double price;
            
            public Dish(string name, double price){
                this.name = name;
                this.price = price;
            }

            public string getName(){
                return name;
            }

            public double getPrice(){
                return price;
            }

            public override string ToString()
            {
                return $"{name}.....{price}";
            }

        }

        public class Table{
            private int numChair;
            private int numPerson;
            private List<Dish> orders;

            public Table(int numChair, int numPerson){
                this.numChair = numChair;
                this.numPerson = numPerson;
                this.orders = new List<Dish>();
            }

            public int getNumChair(){
                return numChair;
            }

            public int getNumPerson(){
                return numPerson;
            }

            public List<Dish> getOrders(){
                return orders;
            }

            //methods

            public void addOrder(Dish order){
                orders.Add(order);
            }

            public double calcBill(){
                double totalAmout = 0;
                foreach(Dish order in orders){
                    totalAmout += order.getPrice();
                }

                return totalAmout;
            }

            public double calcBillDivided(){
                double totalAmount = 0;
                foreach(Dish order in orders){
                    totalAmount += order.getPrice();
                }

                return totalAmount / numPerson;
            }

            public override string ToString()
            {
                return $"The table has {numChair} chairs, which {numPerson} is occupied and they order {orders.Count} things.";
            }

        }


        public class Restaurant{
            private string name;
            private double stars;
            private Table[] tables;
            private int numTables;
            private List<Dish> menu;

            public Restaurant(string name, double stars, int numTables){
                this.name = name;
                this.stars = stars;
                this.numTables = numTables;
                this.tables = new Table[numTables];
                this.menu = new List<Dish>();
            }


            // Gets
            public string getName(){
                return name;
            }

            public double getStars(){
                return stars;
            }

            public Table[] getTables(){
                return tables;
            }

            public List<Dish> getMenu(){
                return menu;
            }

            public double getTableBill(int tableId){
                return tables[tableId].calcBill();
            }

            public double getTableBillDivided(int tableId){
                return tables[tableId].calcBillDivided();
            }

            //Adding
            public bool addTable(int numChair, int numPerson){
                for (int i = 0; i < numTables; i++){
                    if (tables[i] == null){
                        tables[i] = new Table(numChair, numPerson);
                        return true;
                    }
                }
                return false;
            }
            public void addMenuItem(Dish newItem){
                menu.Add(newItem);
            }

            public void addTableOrder(int tableId, int dishId){
                tables[tableId].addOrder(menu[dishId]);
            }

            //Printing
            public void getting(){
                int occupied = 0;
                Console.Write($"{this.name} is a restaurant {this.stars} stars and has {this.numTables} tables.");
                for (int i = 0; i < numTables; i++){
                    if (tables[i] != null){
                        occupied++;
                    }
                }
                Console.WriteLine($" Which {occupied} is occupied.");
            }

            public void printMenu(){
                foreach(Dish order in menu){
                    Console.WriteLine($"#{menu.IndexOf(order)}-{order.getName()}...........{order.getPrice()}");
                }
            }

            public void printTables(){
                foreach(Table t in tables){
                    if(t != null){
                        Console.WriteLine($"The table #{Array.IndexOf(tables, t)} has {t.getNumChair()} chairs and {t.getNumPerson()} persons.");
                        foreach(Dish order in t.getOrders()){
                            Console.WriteLine($"\t#{t.getOrders().IndexOf(order)}-{order}");
                        }
                    }
                }
            }

        }



        static void Main(string[] args){
            const int invalidInput = -1;
            Restaurant restaurant = new Restaurant("Burguer King", 3.5, 6);
            int action = 0;

            string name;
            double price = invalidInput;
            int numChair = invalidInput;
            int numPerson = invalidInput;

            bool addTable;
            int tableId = invalidInput;
            int orderId = invalidInput;

            restaurant.addMenuItem(new Dish("Cheddar Duplo", 11.5));
            restaurant.addMenuItem(new Dish("Whopper", 18.75));
            restaurant.addMenuItem(new Dish("Chicken Junior", 13.25));
            restaurant.addMenuItem(new Dish("Batata Suprema Individual", 12.55));

            do{
                Console.WriteLine($"Welcome to the {restaurant.getName()}!");
                Console.WriteLine($"If you want to go out only insert -1");
                Console.WriteLine($"1 - Restaurant info");
                Console.WriteLine($"2 - Restaurant menu");
                Console.WriteLine($"3 - Add a new menu item");
                Console.WriteLine($"4 - Register a new table");
                Console.WriteLine($"5 - View tables list");
                Console.WriteLine($"6 - Add a new order to a table");
                Console.WriteLine($"7 - End a table's count");
                Console.Write($"In what we can get you? ");
                action = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                switch (action){
                    case 1:
                        restaurant.getting();
                        break;

                    case 2:
                        restaurant.printMenu();
                        break;
                    
                    case 3:
                        Console.Write("Insert the name of the menu item: ");
                        name = Console.ReadLine();
                        do{
                            Console.Write("Insert the price of the menu item: ");
                            price = Convert.ToDouble(Console.ReadLine());
                            var test = (price <= 0) ? (price = invalidInput) : (price);
                        } while (price == invalidInput);

                        restaurant.addMenuItem(new Dish(name, price));
                        Console.WriteLine($"{name} added to the menu!");
                        break;
                    
                    case 4:
                        do{
                            Console.Write("Insert the number of chairs the table has: ");
                            numChair = Convert.ToInt32(Console.ReadLine());
                            var input = numChair <= 0 ? (numChair = invalidInput) : (numChair);
                        } while (numChair == invalidInput);
                        
                        do{
                            Console.Write("Insert the number of person is in this table: ");
                            numPerson = Convert.ToInt32(Console.ReadLine());
                            var input = (numPerson <= 0 || numPerson > numChair) ? (numPerson = invalidInput) : (numPerson);
                        } while (numPerson == invalidInput);
                        addTable = restaurant.addTable(numChair, numPerson);
                        string tableIsAdded =  addTable == true ? ("Table has been registered!") : ("Table hasn't been registered");
                        Console.WriteLine(tableIsAdded);
                        break;
                    
                    case 5:
                        restaurant.printTables();
                        break;

                    case 6:
                        do{
                            Console.Write("Insert the table's number: ");
                            tableId = Convert.ToInt32(Console.ReadLine());
                            if(tableId < 0 || tableId > restaurant.getTables().Length){
                                tableId = invalidInput;
                            }
                        } while (tableId == invalidInput);

                        do{
                            Console.Write("Insert the order's number: ");
                            orderId = Convert.ToInt32(Console.ReadLine());
                            if(orderId < 0 || orderId >= restaurant.getMenu().Count){
                                orderId = invalidInput;
                            }
                        } while (orderId == invalidInput);

                        restaurant.addTableOrder(tableId, orderId);
                        Console.WriteLine("The order is added.");
                        break;
                    
                    case 7:
                        Console.Write("Insert table's number: ");
                        do{
                            tableId = Convert.ToInt32(Console.ReadLine());
                            if (tableId < 0 || tableId >= restaurant.getTables().Length)
                            {
                                tableId = invalidInput;
                            }
                        } while (tableId == invalidInput);

                        Console.WriteLine($"The table #{tableId} bill is {restaurant.getTableBill(tableId)}R$. If they want to divide: {restaurant.getTableBillDivided(tableId)}R$");
                        break;

                    case -1:
                        Console.WriteLine("Ending the app...");
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;



                }


                Console.ReadKey();
                Console.Clear();
            } while (action != -1);


        }
    }
}
