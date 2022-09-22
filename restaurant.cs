using System;
using System.Collections.Generic;


public class Table{
    private int numChair;
    
    public Table(int numChair){
        this.numChair = numChair;
    }
    
    public int getNumChair(){
        return numChair;
    }
    
    //methods
    public float calcBill(float totalAmount){
        return (totalAmount/numChair);
    }
    
}


public class Restaurant{
    private string name;
    private double stars;
    private Table[] tables;
    private int numTables;
    
    public Restaurant(string name, double stars, int numTables){
        this.name = name;
        this.stars = stars;
        this.numTables = numTables;
        this.tables = new Table[numTables];
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
    
    public void addTable(int numChair){
        for(int i = 0; i < numTables; i++){
            if(tables[i] == null){
                tables[i] = new Table(numChair);
                break;
            }
        }
    }
    
    public void getting(){
        int occupied = 0;
        Console.Write($"{this.name} is a restaurant {this.stars} stars and has {this.numTables} tables.");
        for(int i = 0; i < numTables; i++){
            if(tables[i] != null){
                occupied++;
            }
        }
        Console.WriteLine($" Which {occupied} is occupied.");
    }
    
}




class Program {
  static void Main() {
    
    Restaurant bk = new Restaurant("Burguer King", 3.5, 6);
    
    Console.WriteLine(bk.getName());
    Console.WriteLine(bk.getStars());
    bk.addTable(4);
    bk.addTable(6);
    bk.addTable(12);
    foreach(Table t in bk.getTables()){
        if(t != null){
            Console.WriteLine(t.getNumChair());
            
        }
    }
    
    bk.getting();
    
    
  }
  
  
  
}
