//Project 4- Database Management System

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StacyDavis_Project4_DBMS
{
    class Program
    {
        //Miscellaneous Methods:
        //MM 1- Display All Students Method
        static void DisplayAll(Dictionary<string, List<int>> a)                                         //No return data & has parameter; "a" is the referenced dictionary
        {
            foreach (KeyValuePair<string, List<int>> i in a)                                            //Displays all student names in dictionary "a"
            {
                Console.WriteLine(i.Key);
            }
        }


        //Reports Methods:
        //RM 1- Displays grades for a single student
        static void DisplayOne(Dictionary<string, List<int>> a)                                         //No return data & has parameter; "a" is the referenced dictionary
        {
            string studentName;                                                                         //Creates variable to hold student name

            while (true)
            {
                Console.Clear();

                DisplayAll(a);                                                                          //Ref MM 1; Displays all students in dictionary "a"

                Console.WriteLine("\n\n**DISPLAY GRADES**\nEnter the student's full name (Case sensitive): ");
                studentName = Console.ReadLine();

                Console.Clear();

                if (!a.ContainsKey(studentName))                                                        //Searches for the "studentName" in dictionary "a"
                {
                    //If "studentName" does NOT exist:
                    Console.Clear();
                    Console.WriteLine("Record does not exist. Press any key to continue: ");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    //If "studentName" exists:
                    Console.WriteLine(studentName + "'s grades:");
                    for (int i = 0; i < a[studentName].Count; i += 1)                                   //Creates a temp variable "i"; Searches for each value "i" with the key name "studentName" in dictionary "a"; Increments "i"
                    {
                        Console.WriteLine("Exam " + (i + 1) + ": " + a[studentName][i]);                //1 added to "i" so the list looks like it begins at 1 instead of 0, visible to user only & does not change actual value "i"
                    }

                    break;
                }
            }
        }

        //RM 2- Displays student with highest average
        static void ShowTop(Dictionary<string, List<int>> a)                                            //No return data & has parameter; "a" is the referenced dictionary
        {
            Console.Clear();

            string hName = "";                                                                          //Creates variable to store student name with highest average
            double hScore = 0;                                                                          //Creates variable to store student average

            foreach (KeyValuePair<string, List<int>> i in a)                                            //Searches each student name in dictionary "a"
            {
                double avg = i.Value.Average();                                                         //Creates variable; Combines each grade associated with the student name and averages them; Stores the average value
                if (hScore < avg)                                                                       //Compares each subsequent average for a higher value
                {
                    //If score is higher:
                    hScore = avg;                                                                       //Stores the value as "hScore"
                    hName = i.Key;                                                                      //Stores the student name as "hName"
                }
            }
            Console.WriteLine("**STUDENT WITH THE HIGHEST AVERAGE**\n\n" + hName + " has the highest average of " + hScore + "%");
        }


        //Student Management Methods:
        //SMM 1- Change student
        static Dictionary<string, List<int>> ChangeName(Dictionary<string, List<int>> a)                //Has return data & has parameter; "a" is the referenced dictionary
        {
            string studentName;                                                                         //Creates variable to hold student name
            string newName;                                                                             //Creates variable to hold the new student name

            while (true)
            {
                Console.Clear();
                DisplayAll(a);                                                                          //Ref MM 1; Displays all students

                Console.WriteLine("\n\n**CHANGE STUDENT**\nEnter the student's full name (Case sensitive): ");
                studentName = Console.ReadLine();                                                       //Enter a student name

                if (!a.ContainsKey(studentName))                                                        //Searches for the "studentName" in dictionary "a"
                {
                    //If "studentName" does NOT exist:
                    Console.Clear();
                    Console.WriteLine("Record does not exist. Press any key to continue: ");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    //If "studentName" exists:
                    Console.Clear();
                    Console.Write("You have selected " + studentName + ". Are you sure you want to change this record?\n");

                    string uInput;
                    while (true)
                    {
                        Console.Write("\nEnter (y) to change the student's name or (n) to select a different student: ");
                        uInput = Console.ReadLine();

                        if (uInput == "y" || uInput == "Y")
                        {
                            break;
                        }
                        else if (uInput == "n" || uInput == "N")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input.");
                            continue;
                        }
                    }
                    if (uInput == "y" || uInput == "Y")
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //Loop to verify new student name is unique:
            while (true)
            {
                Console.Clear();
                Console.Write("Enter the corrected student name: ");
                newName = Console.ReadLine();                                                           //Creates variable "newName" & stores new student name

                if (a.ContainsKey(newName))                                                             //Searches for existing record in dictionary "a"
                {
                    //If "studentName" does NOT exist:
                    Console.Clear();
                    Console.WriteLine("Record already exists. Please enter a different name.\n\nPress any key to continue: ");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    break;
                }
            }

            a.Add(newName, new List<int> { });                                                          //Creates new list in dictionary "a" for new student name "newName"

            a[newName].AddRange(a[studentName]);                                                        //Copies values from old student name "studentName" to new student name "newName"
            a.Remove(studentName);                                                                      //Deletes old student name "studentName" and values

            Console.Clear();
            Console.WriteLine(studentName + " has been changed to " + newName);

            //Displays new name and grades:
            Console.WriteLine("\n" + newName + "'s grades:");
            for (int i = 0; i < a[newName].Count; i += 1)                                               //Displays all values in list "studentName" in dictionary "a"
            {
                Console.WriteLine("Exam " + (i + 1) + ": " + a[newName][i]);                            //1 added to "i" so the list looks like it begins at 1 instead of 0
            }

            return a;                                                                                   //Returns "a"; Required since the method has a return value
        }

        //SMM 2- Adds new student
        static Dictionary<string, List<int>> AddStudent(Dictionary<string, List<int>> a)                //Has return data & has parameter; "a" is the referenced dictionary
        {
            string newStudent;                                                                          //Creates variable to hold student name

            while (true)
            {
                //Loop to verify new student name is unique:
                while (true)
                {
                    Console.Clear();
                    DisplayAll(a);                                                                          //Ref MM 1; Displays all students

                    Console.WriteLine("\n\n**ADD STUDENT**\nEnter the student's full name (Case sensitive): ");
                    newStudent = Console.ReadLine();                                                        //Creates variable "newStudent" and stores new student name

                    if (a.ContainsKey(newStudent))                                                             //Searches for existing record in dictionary "a"
                    {
                        //If "studentName" does NOT exist:
                        Console.Clear();
                        Console.WriteLine("Record already exists. Please enter a different name.\n\nPress any key to continue: ");
                        Console.ReadKey();
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                Console.Clear();
                Console.Write("You have entered \"" + newStudent + "\". Is this correct?\n");

                string uInput;
                while (true)
                {
                    Console.Write("\nEnter (y) to add student or (n) to enter another name: ");
                    uInput = Console.ReadLine();

                    if (uInput == "y" || uInput == "Y")
                    {
                        break;
                    }
                    else if (uInput == "n" || uInput == "N")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input.");
                        continue;
                    }
                }
                if (uInput == "y" || uInput == "Y")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }

            List<int> temp1 = new List<int>();                                                          //Creates new empty list for the new student name
            a.Add(newStudent, temp1);                                                                   //Adds the new student list to dictionary "a"; Does not contain any values

            Console.Clear();
            DisplayAll(a);                                                                              //Ref MM 1; Displays all students

            return a;                                                                                   //Returns "a"; Required since the method has a return value
        }

        //SMM 3- Delete Student
        static Dictionary<string, List<int>> DeleteStudent(Dictionary<string, List<int>> a)             //Has return data & has parameter; "a" is the referenced dictionary
        {
            string studentName;                                                                         //Creates variable to hold student name

            while (true)
            {
                Console.Clear();
                DisplayAll(a);                                                                          //Ref MM 1; Displays all students

                Console.WriteLine("\n\n**REMOVE STUDENT**\nEnter the student's full name (Case sensitive): ");
                studentName = Console.ReadLine();                                                       //Enter a student name

                if (!a.ContainsKey(studentName))                                                        //Searches for the entry
                {
                    //If "studentName" does NOT exist:
                    Console.Clear();
                    Console.WriteLine("Record does not exist. Press any key to continue: ");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    //If "studentName" exists:                   
                    Console.Clear();
                    Console.Write("You have selected " + studentName + ". Are you sure you want to delete this record?\n");

                    string uInput;
                    while (true)
                    {
                        Console.Write("\nEnter (y) to delete grade or (n) to select a different student: ");
                        uInput = Console.ReadLine();

                        if (uInput == "y" || uInput == "Y")
                        {
                            break;
                        }
                        else if (uInput == "n" || uInput == "N")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input.");
                            continue;
                        }
                    }
                    if (uInput == "y" || uInput == "Y")
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            Console.Clear();
            Console.WriteLine(studentName + " has been removed.");
            a.Remove(studentName);                                                                      //Deletes student name "studentName" and values from dictionary "a"

            return a;                                                                                   //Returns "a"; Required since the method has a return value
        }


        //Grade Management Methods:
        //GMM 1- Change grades
        static Dictionary<string, List<int>> ChangeGrade(Dictionary<string, List<int>> a)               //Has return data & has parameter; "a" is the referenced dictionary
        {
            string studentName;                                                                         //Creates variable to hold student name
            int sCount;                                                                                 //Creates variable to hold the number of values in a list
            int index;                                                                                  //Creates variable to hold the selected value's index number
            int newGrade;                                                                               //Creates variable to hold the new grade

            while (true)
            {
                Console.Clear();
                DisplayAll(a);                                                                          //Ref MM 1; Displays all students

                Console.WriteLine("\n\n**CHANGE GRADE**\nEnter the student's full name (Case sensitive): ");
                studentName = Console.ReadLine();                                                       //Enter a student name

                if (!a.ContainsKey(studentName))                                                        //Searches for the entry
                {
                    //If "studentName" does NOT exist:
                    Console.Clear();
                    Console.WriteLine("Record does not exist. Press any key to continue: ");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    //If "studentName" exists:
                    sCount = a[studentName].Count();                                                    //Counts the number of values in list "studentName" in dictionary "a"; Stores the number in "sCount"

                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine(studentName + "'s grades: ");

                        for (int i = 0; i < a[studentName].Count; i += 1)                               //Displays all values in list "studentName" in dictionary "a"
                        {
                            Console.WriteLine("Exam " + (i + 1) + ". " + a[studentName][i]);            //1 added to "i" so the list looks like it begins at 1 instead of 0
                        }

                        //Loop to validate user input:
                        while (true)
                        {
                            Console.WriteLine("\nEnter the Exam number: ");
                            try
                            {
                                index = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("\nInvalid input.");
                                continue;
                            }

                            if ((index <= sCount) && (index > 0))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid input.");
                                continue;
                            }
                        }

                        Console.Clear();
                        Console.Write("You have selected Exam " + index + ". Are you sure you want to change this grade?\n");

                        string uInput;
                        while (true)
                        {
                            Console.Write("\nEnter (y) to delete grade or (n) to select a different Exam: ");
                            uInput = Console.ReadLine();

                            if (uInput == "y" || uInput == "Y")
                            {
                                break;
                            }
                            else if (uInput == "n" || uInput == "N")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid input.");
                                continue;
                            }
                        }

                        if (uInput == "y" || uInput == "Y")
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    Console.Clear();
                    //Loop to validate user input:
                    while (true)
                    {
                        Console.WriteLine("Enter the new grade: ");
                        try
                        {
                            newGrade = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("\nInvalid input.\n");
                            continue;
                        }

                        if ((newGrade <= 100) && (newGrade >= 0))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input.\n");
                            continue;
                        }
                    }

                    break;
                }
            }

            Console.Clear();
            index -= 1;                                                                                 //1 removed so that user's input matches the correct value's index
            Console.WriteLine(a[studentName][index] + " has been changed to " + newGrade);
            a[studentName][index] = newGrade;                                                           //Changes a value of "index" in list "studentName" in dictionary "a"

            for (int i = 0; i < a[studentName].Count; i += 1)                                           //Displays all values in list "studentName" in dictionary "a"
            {
                Console.WriteLine("Exam " + (i + 1) + ". " + a[studentName][i]);
            }

            return a;                                                                                   //Returns "a"; Required since the method has a return value
        }

        //GMM 2- Add grades:
        static Dictionary<string, List<int>> AddGrade(Dictionary<string, List<int>> a)                  //Has return data & has parameter; "a" is the referenced dictionary
        {
            string studentName;                                                                         //Creates variable to hold student name
            int newGrade;                                                                               //Creates variable to hold the new grade

            while (true)
            {
                Console.Clear();
                DisplayAll(a);                                                                          //Ref MM 1; Displays all students

                Console.WriteLine("\n\n**ADD GRADE**\nEnter the student's full name (Case sensitive): ");
                studentName = Console.ReadLine();

                if (!a.ContainsKey(studentName))
                {
                    //If "studentName" does NOT exist:
                    Console.Clear();
                    Console.WriteLine("Record does not exist. Press any key to continue: ");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    //If "studentName" exists:
                    Console.Clear();
                    Console.WriteLine(studentName + "'s grades:");
                    for (int i = 0; i < a[studentName].Count; i += 1)                                   //Displays all values in list "studentName" in dictionary "a"
                    {
                        Console.WriteLine("Exam " + (i + 1) + ": " + a[studentName][i]);
                    }

                    Console.WriteLine("");

                    //Loop to validate user input:
                    while (true)
                    {
                        Console.Write("Please add a grade: ");

                        try
                        {
                            newGrade = Convert.ToInt32(Console.ReadLine());                             //Captures and stores the new grade
                        }
                        catch
                        {
                            Console.WriteLine("\nInvalid input.\n");
                            continue;
                        }
                        break;
                    }

                    break;
                }
            }

            a[studentName].Add(newGrade);                                                               //Adds the new grade "newGrade" to list "studentName" in dictionary "a"

            Console.Clear();
            Console.WriteLine(studentName + "'s grades:");
            for (int i = 0; i < a[studentName].Count; i += 1)                                           //Displays all values in list "studentName" in dictionary "a"
            {
                Console.WriteLine("Exam " + (i + 1) + ": " + a[studentName][i]);
            }

            return a;                                                                                   //Returns "a"; Required since the method has a return value
        }

        //GMM 3- Delete grades
        static Dictionary<string, List<int>> DeleteGrade(Dictionary<string, List<int>> a)
        {
            string studentName;                                                                         //Creates variable to hold student name
            int index;                                                                                  //Creates variable to hold the selected value's index number
            int sCount;                                                                                 //Creates variable to hold the number of values in a list

            while (true)
            {
                Console.Clear();
                DisplayAll(a);                                                                          //Ref MM 1; Displays all students

                Console.WriteLine("\n\n**DELETE GRADE**\nEnter the student's full name (Case sensitive): ");
                studentName = Console.ReadLine();                                                       //Enter a student name

                if (!a.ContainsKey(studentName))                                                        //Searches for the entry
                {
                    //If "studentName" does NOT exist:
                    Console.Clear();
                    Console.WriteLine("Record does not exist. Press any key to continue: ");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    //If "studentName" exists:
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine(studentName + "'s grades: ");
                        for (int i = 0; i < a[studentName].Count; i += 1)                               //Displays all values in list "studentName" in dictionary "a"
                        {
                            Console.WriteLine("Exam " + (i + 1) + ". " + a[studentName][i]);
                        }

                        sCount = a[studentName].Count();                                                //Counts the number of values in list "studentName" in dictionary "a"; Stores the number in "sCount"

                        //Loop to validate user input:
                        while (true)
                        {
                            Console.WriteLine("\nEnter the Exam number: ");
                            try
                            {
                                index = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("\nInvalid input.");
                                continue;
                            }

                            if ((index <= sCount) && (index > 0))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid input.");
                                continue;
                            }
                        }

                        Console.Clear();
                        Console.Write("You have selected Exam " + index + ". Are you sure you want to delete this grade?\n");

                        string uInput;
                        while (true)
                        {
                            Console.Write("\nEnter (y) to delete grade or (n) to select a different Exam: ");
                            uInput = Console.ReadLine();

                            if (uInput == "y" || uInput == "Y")
                            {
                                break;
                            }
                            else if (uInput == "n" || uInput == "N")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid input.");
                                continue;
                            }
                        }

                        if (uInput == "y" || uInput == "Y")
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    break;
                }
            }

            Console.Clear();
            index -= 1;                                                                                 //1 removed so that user's input matches the correct value's index
            Console.WriteLine(a[studentName][index] + " has been deleted.");
            a[studentName].RemoveAt(index);                                                             //Changes a value of "index" in list "studentName" in dictionary "a"

            for (int i = 0; i < a[studentName].Count; i += 1)                                           //Displays all values in list "studentName" in dictionary "a"
            {
                Console.WriteLine("Exam " + (i + 1) + ". " + a[studentName][i]);
            }

            return a;                                                                                   //Returns "a"; Required since the method has a return value
        }

        //Main Program:
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> studentGrades = new Dictionary<string, List<int>>()           //Creates a new Dictionary "studentGrades"; Then new student lists and values
            {
                {"Alfred S. McKenzie",new List<int> {48, 96, 64}},
                {"Alison W. MacDonald",new List<int> {54, 99, 72}},
                {"Allan Y. Nguyen",new List<int> {42, 42, 41}},
                {"Audrey M. Kern",new List<int> {49, 67, 93}},
                {"Barry V. Gordon",new List<int> {66, 57, 52}},
                {"Beth G. Swanson",new List<int> {67, 55, 70}},
                {"Billy P. Carroll",new List<int> {70, 58, 80}},
                {"Calvin A. Diaz",new List<int> {86, 42, 50}},
                {"Charlotte G. Hamrick",new List<int> {43, 74, 40}},
                {"Chris Anderson",new List<int> {72, 67, 76}},
                {"Claire Q. Gray",new List<int> {63, 90, 47}},
                {"Clara H. Best",new List<int> {59, 63, 69}},
                {"Clifford Garrett",new List<int> {87, 89, 72}},
                {"Dean Leach",new List<int> {95, 40, 100}},
                {"Edgar P. Stuart",new List<int> {96, 49, 91}},
                {"Edna H. Hoyle",new List<int> {66, 70, 88}},
                {"Eileen Olson",new List<int> {100, 85, 51}},
                {"Franklin M. Coley",new List<int> {59, 63, 97}},
                {"Frederick J. McCall",new List<int> {97, 52, 57}},
                {"Glen R. Kramer",new List<int> {70, 48, 52}},
                {"Gordon D. Berman",new List<int> {88, 74, 46}},
                {"Jean M. Griffin",new List<int> {48, 86, 99}},
                {"Jeff T. Kaplan",new List<int> {54, 91, 72}},
                {"Joanna L. Middleton",new List<int> {43, 88, 73}},
                {"Joanne L. Bowling",new List<int> {78, 79, 79}},
                {"Julian E. Hendrix",new List<int> {99, 51, 91}},
                {"Keith X. Schwartz",new List<int> {97, 86, 97}},
                {"Ken T. Kennedy",new List<int> {80, 66, 40}},
                {"Kim T. Matthews",new List<int> {75, 95, 55}},
                {"Kristen O. Fisher",new List<int> {44, 72, 57}},
                {"Louise F. Coble",new List<int> {67, 63, 98}},
                {"Luis A. Burnett",new List<int> {85, 74, 52}},
                {"Luis N. Turner",new List<int> {86, 53, 86}},
                {"Margaret M. Burgess",new List<int> {76, 93, 63}},
                {"Martin Y. Hester",new List<int> {61, 74, 51}},
                {"Mary G. Byrd",new List<int> {95, 40, 95}},
                {"Nina Y. Savage",new List<int> {73, 41, 84}},
                {"Pauline N. Coley",new List<int> {73, 51, 87}},
                {"Penny Lamb",new List<int> {49, 94, 61}},
                {"Peter L. Guthrie",new List<int> {75, 70, 44}},
                {"Rhonda Chan",new List<int> {94, 52, 93}},
                {"Richard E. Hull",new List<int> {76, 99, 59}},
                {"Robyn K. Shapiro",new List<int> {45, 82, 68}},
                {"Samantha I. Hardin",new List<int> {89, 42, 95}},
                {"Sara Lucas",new List<int> {80, 60, 85}},
                {"Stephen Finch",new List<int> {84, 95, 70}},
                {"Tammy L. Lang",new List<int> {62, 73, 56}},
                {"Vincent Y. Fischer",new List<int> {79, 88, 92}},
                {"William S. McCormick",new List<int> {99, 68, 65}}
            };

            //Program loop
            while (true)
            {
                //Main Menu:
                Console.Clear();
                Console.Write("**MAIN MENU**\n" +
                "1) Reports\n" +
                "2) Student Management\n" +
                "3) Grade Management\n" +
                "4) Exit\n\n" +
                "Please choose a menu option: ");

                string menuInput = Console.ReadLine();
                if (menuInput == "1")
                {
                    //Reports menu:
                    while (true)
                    {
                        Console.Clear();
                        Console.Write("**REPORTS MENU**\n" +
                            "1) Show all grades for a single student\n" +
                            "2) Show the student name and grade average for the TOP student\n" +
                            "3) Return to the main menu\n\n" +
                            "Please choose a menu option: ");

                        string reportInput = Console.ReadLine();
                        if (reportInput == "1")
                        {
                            DisplayOne(studentGrades);                                                  //Ref RM 1; Displays grades for the selected student
                            Console.Write("\nPress any key to return to the previous menu: ");
                            Console.ReadKey();
                        }
                        else if (reportInput == "2")
                        {
                            ShowTop(studentGrades);                                                     //Ref RM 2; Displays student with highest average
                            Console.Write("\nPress any key to return to the previous menu: ");
                            Console.ReadKey();
                        }
                        else if (reportInput == "3")
                        {
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Input.\n\nPress any key to continue: ");
                            Console.ReadKey();
                            continue;
                        }
                    }
                }
                else if (menuInput == "2")
                {
                    while (true)
                    {
                        Console.Clear();

                        Console.Write("**STUDENT MANAGEMENT MENU**\n" +
                            "1) Change Student\n" +
                            "2) Add Student\n" +
                            "3) Delete Student\n" +
                            "4) Return to the main menu\n\n" +
                            "Please choose a menu option: ");

                        string reportInput = Console.ReadLine();
                        if (reportInput == "1")
                        {
                            studentGrades = ChangeName(studentGrades);                                  //Ref SMM 1; Change student name
                            Console.Write("\nPress any key to return to the previous menu: ");
                            Console.ReadKey();
                        }
                        else if (reportInput == "2")
                        {
                            studentGrades = AddStudent(studentGrades);                                  //Ref SMM 2; Add new student
                            Console.Write("\nPress any key to return to the previous menu: ");
                            Console.ReadKey();
                        }
                        else if (reportInput == "3")
                        {
                            studentGrades = DeleteStudent(studentGrades);                               //Ref SMM 3; Delete student
                            Console.Write("\nPress any key to return to the previous menu: ");
                            Console.ReadKey();
                        }
                        else if (reportInput == "4")
                        {
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Input.\n\nPress any key to continue: ");
                            Console.ReadKey();
                            continue;
                        }
                    }
                }
                else if (menuInput == "3")
                {
                    while (true)
                    {
                        Console.Clear();

                        Console.Write("**GRADE MANAGEMENT MENU**\n" +
                            "1) Change Grades\n" +
                            "2) Add Grades\n" +
                            "3) Delete Grades\n" +
                            "4) Return to the main menu\n\n" +
                            "Please choose a menu option: ");

                        string reportInput = Console.ReadLine();
                        if (reportInput == "1")
                        {
                            studentGrades = ChangeGrade(studentGrades);                                 //Ref GMM 1; Changes Student's grade
                            Console.Write("\nPress any key to return to the previous menu: ");
                            Console.ReadKey();
                        }
                        else if (reportInput == "2")
                        {
                            studentGrades = AddGrade(studentGrades);                                    //Ref GMM 3; Adds student's grade
                            Console.Write("\nPress any key to return to the previous menu: ");
                            Console.ReadKey();
                        }
                        else if (reportInput == "3")
                        {
                            studentGrades = DeleteGrade(studentGrades);                                 //Ref GMM 3; Deletes student's grade
                            Console.Write("\nPress any key to return to the previous menu: ");
                            Console.ReadKey();
                        }
                        else if (reportInput == "4")
                        {
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Input.\n\nPress any key to continue: ");
                            Console.ReadKey();
                            continue;
                        }
                    }
                }
                else if (menuInput == "4")
                {
                    Console.Clear();
                    Console.WriteLine("You have elected to Exit the program.\n\nPress any key to continue: ");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input.\n\nPress any key to continue: ");
                    Console.ReadKey();
                    continue;
                }
            }

            Console.Clear();
            Console.WriteLine("Bye");
            Console.ReadKey();
        }
    }
}