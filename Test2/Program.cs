using System;
using System.Collections;

interface IStudent
{
    int StudID { get; set; }
    string StudName { get; set; }
    string StudGender { get; set; }
    int StudAge { get; set; }
    string StudClass { get; set; }
    float StudAvgMark { get; set; }
}
class Student : IStudent
{
    public int StudID { get; set; }
    public string StudName { get; set; }
    public string StudGender { get; set; }
    public int StudAge { get; set; }
    public string StudClass { get; set; }
    public float StudAvgMark { get; private set; }
    private int[] MarkList = new int[3];
    public int this[int index]
    {
        get { return MarkList[index]; }
        set { MarkList[index] = value; }
    }
    public void CalAvg()
    {
        StudAvgMark = (MarkList[0] + MarkList[1] + MarkList[2]) / 3.0f;
    }
    public void Print()
    {
        Console.WriteLine($"Sutdent ID: {StudID}");
        Console.WriteLine($"Name: {StudName}");
        Console.WriteLine($"Gender: {StudGender}");
        Console.WriteLine($"Age: {StudAge}");
        Console.WriteLine($"Class: {StudClass}");
        Console.WriteLine($"Average Mark: {StudAvgMark}");
    }
}
class Program
{
    static void Main()
    {
        Hashtable studentsHashtable = new Hashtable();
        while (true)
        {
            Console.WriteLine("1. Insert new student");
            Console.WriteLine("2. Display all students");
            Console.WriteLine("3. Display average marks of all students");
            Console.WriteLine("4. Search for a student");
            Console.WriteLine("5. Quit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Student newStudent = new Student();
                    Console.WriteLine("Enter Student ID: ");
                    newStudent.StudID = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Student Name: ");
                    newStudent.StudName = Console.ReadLine();
                    Console.WriteLine("Enter Student Gender: ");
                    newStudent.StudGender = Console.ReadLine();
                    Console.WriteLine("Enter Student Age: ");
                    newStudent.StudAge = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Student Class: ");
                    newStudent.StudClass = Console.ReadLine();
                    Console.WriteLine("Enter 3 marks: ");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine($"Mark {i + 1}: ");
                        newStudent[i] = int.Parse(Console.ReadLine());
                    }
                    newStudent.CalAvg();
                    studentsHashtable.Add(newStudent.StudID, newStudent);
                    break;
                case 2:
                    foreach (Student student in studentsHashtable.Values)
                    {
                        ((IStudent)entry.Value).Print();
                    }
                    break;
                case 3:
                    foreach (Student student in studentsHashtable.Values)
                    {
                        student.CalAvg();
                        student.Print();
                    }
                    break;
                case 4:
                    Console.WriteLine("Search by: ");
                    Console.WriteLine("1. ID: ");
                    Console.WriteLine("2. Name: ");
                    Console.WriteLine("3. Class: ");
                    int searchBy = int.Parse(Console.ReadLine());
                    ArrayList results = new ArrayList();
                    switch (searchBy)
                    {
                        case 1:
                            Console.WriteLine("Enter Student ID: ");
                            int searchID = int.Parse(Console.ReadLine());
                            if (studentsHashtable.ContainsKey(searchID))
                            {
                                results.Add(studentsHashtable[searchID]);
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter Student Name: ");
                            string searchName = Console.ReadLine();
                            foreach (Student student in studentsHashtable.Values)
                            {
                                if (student.StudName == searchName)
                                {
                                    results.Add(student);
                                }
                            }
                            results.Sort((x, y) => ((Student)x).StudName.CompareTo(((Student )y.StudName));
                            break;
                        case 3:
                            Console.Write("Enter Student Class: ");
                            string searchClass = Console.ReadLine();
                            foreach (Student student in studentsHashtable.Values)
                            {
                                if (student.StudClass == searchClass)
                                {
                                    results.Add(student);
                                }
                            }
                            results.Sort((x, y) => ((Student)x).StudName.CompareTo(((Student)y).StudName));
                            break;
                    }
                    foreach (var result in results)
                    {
                        ((IStudent)result).Print();
                    }
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid Choice. Please try again.");
                    break;
            }
        }
    }
}