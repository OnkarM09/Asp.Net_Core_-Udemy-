//Any stetment which are written above namespane or class is called as Top level statement
//For example

using System.Xml.Serialization;

int age = 26;
Console.WriteLine(age);

//We can't write them below namespace or Class
//For example  
class Person
{
    public string? Name { get; set; }
}

//And then try to write 
//int age = 26;
//Console.WriteLine(age);
//This will throw error as top level statements are written below person class

//Any variable of top level statement is not accessible to any class in same file or different file 
// for example  
// class Person{
//  public int Age { get; set; } = age //Won't work
//}

//Top level statement can only be written in 1 file and not more than 1 file in whole project.