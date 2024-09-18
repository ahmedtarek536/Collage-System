
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CollageSystem
{
    internal class Program
    {
        public static List<User> users = new List<User>();
        public static List<Course> courses = new List<Course>();

        public static  User CurrentUser;
        static void Main(string[] args)
        {
            SignList();

        }
        static void MainList()
        {
            Console.WriteLine();
            Console.WriteLine("1. Profile");
            Console.WriteLine("2. List Courses");
            Console.WriteLine("3. Create Course");
            Console.WriteLine("4. Logout");
            Console.Write("Enter action: ");
            int action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
                case 1:
                    Profile();
                    break;
                case 2:
                    ListCourses();
                    break;
                case 3:
                    CreateCourse();
                    break;
                case 4:
                    Console.WriteLine("Succeful Logout");
                    SignList();
                    break;
                default:
                    Console.WriteLine("Please Enter vaild Action ");
                    break;
            }
        }
        static void Profile()
        {
            Console.WriteLine();
            Console.WriteLine("MyProfile");
            Console.WriteLine($"\t Name: {CurrentUser.fullName}");
            Console.WriteLine($"\t Email: {CurrentUser.email}");
            Console.WriteLine($"\t Password: {CurrentUser.password}");
            Console.WriteLine();
            MainList();
        }
        static void ListCourses()
        {
            Dictionary<int ,Course> DictionaryCourses = new Dictionary<int ,Course>();
            Console.WriteLine();
            Console.WriteLine("List Courses");
            int count = 0;
            foreach(Course course in courses)
            {
                DictionaryCourses[count] = course;
                Console.WriteLine($"\t{count++}. {course.title} ,  {course.duration}/hour");
            }
            Console.WriteLine();
            Console.WriteLine("1. Show Detail of spesfic course");
            Console.WriteLine("2. Back");
            Console.Write("Enter Action: ");
            int action = Convert.ToInt32(Console.ReadLine());
            if(action == 2)
            {
                MainList();
                return;
            }
            Console.Write("Enter Num of course: ");
            int numCourse = Convert.ToInt32(Console.ReadLine());
            CourseDetails(DictionaryCourses[numCourse]);
        }
        static void CourseDetails(Course course)
        {
            Dictionary<int, Assignment> DicionaryAssignment = new Dictionary<int, Assignment>();
            Console.WriteLine();
            Console.WriteLine("Title: " + course.title);
            Console.WriteLine("Description: "+ course.description);
            Console.WriteLine("Assignment: ");
            int count = 0;
            foreach(Assignment assignment in course.assignmentes)
            {
                Console.WriteLine($"{count}. {assignment.title}");
                DicionaryAssignment[count++] = assignment;
            }
                Console.WriteLine();
            if(CurrentUser.role == "S")
            {
                Console.WriteLine("1. Show Detail of spesfic assignment");
                Console.WriteLine("2. Back");
                Console.Write("Enter Action: ");
                int action = Convert.ToInt32(Console.ReadLine());
                if (action == 2)
                {
                    ListCourses();
                    return;
                }
                Console.Write("Enter Num of assignment: ");
                int numCourse = Convert.ToInt32(Console.ReadLine());
                AssignmentDetails(DicionaryAssignment[numCourse]);
            }
            else
            {
                Console.WriteLine("1. Show Detail of spesfic assignemen");
                Console.WriteLine("2. Create Assignmetn");
                Console.WriteLine("3. Back");
                Console.Write("Enter Action: ");
                int action = Convert.ToInt32(Console.ReadLine());
                if (action == 1)
                {
                    Console.Write("Enter Num of assignment: ");
                    int numCourse = Convert.ToInt32(Console.ReadLine());
                    AssignmentDetails(DicionaryAssignment[numCourse]);
                }else if(action == 2)
                {
                    string title, description;
                    Console.Write("Enter title of Assignmetn: ");
                    title = Console.ReadLine();
                    Console.Write("Enter description of Assignmetn: ");
                    description = Console.ReadLine();
                    course.assignmentes.Add(new Assignment(title ,description));
                    CourseDetails(course);

                }
                else
                {
                    ListCourses();
                    return;
                }
                
            }
        }
        static void AssignmentDetails(Assignment assignment)
        {
            Console.WriteLine();
            Console.WriteLine("Title: "+ assignment.title );
            Console.WriteLine("Description: "+ assignment.description);
            Console.WriteLine();
            Console.WriteLine(CurrentUser.role == "S" ? "1. Add New Soluation" : "1. Show All Soluations");
            Console.WriteLine("2. Back");
            Console.Write("Enter Action: ");
            int action = Convert.ToInt32(Console.ReadLine());
            if (action == 2) ListCourses();
            else
            {
                if(CurrentUser.role == "S")
                {
                    string title, description;
                    Console.WriteLine();
                    Console.Write("Enter title of your soluation: ");
                    title = Console.ReadLine();
                    Console.Write("Enter description of your soluation: ");
                    description = Console.ReadLine();
                    assignment.soluations.Add(new Soluation(title, description, CurrentUser));
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Soluations: ");
                    int count = 0;
                    foreach (Soluation soulation in assignment.soluations)
                    {
                        Console.WriteLine($"{count++}. Name: {soulation.student.fullName}  ,  Title: {soulation.title} , description: {soulation.description}");
                    }
                }
                    AssignmentDetails(assignment);
            }
        }
        static void CreateCourse()
        {
            if(CurrentUser.role == "S")
            {
                Console.WriteLine("Student can not create any course!!!");
                MainList();
                return;
            }
            string title;
            string description; 
            int duration;
            Console.Write("Enter title of course :");
             title = Console.ReadLine();
            Console.Write("Enter description of course :");
             description = Console.ReadLine();
            Console.Write("Enter duration of course :");
            duration = Convert.ToInt32(Console.ReadLine());
            courses.Add(new Course(title, description, duration));
            Console.WriteLine("Succeful add coures");
            MainList();
        }

        static void SignList()
        {
            Console.WriteLine();
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Signup");
            Console.WriteLine("3. Exit");
            Console.Write("Enter action : ");
            int action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
                  case 1:
                    Login();
                   
                    break;
                  case 2:
                    Signup();
                 
                    break;
                  case 3:
                    Console.WriteLine("Thank you for use system!");
                    break;
                  default:
                    Console.WriteLine("Please Enter Vaild Data");
                    SignList();
                    break;
            }
        }
        static void Login() {
            string email, password;
            Console.Write("Enter your email : ");
            email = Console.ReadLine();
            Console.Write("Enter your password : ");
            password = Console.ReadLine();

            CurrentUser = users.Find(user => user.email == email && user.password == password);
            if (CurrentUser != null) {
                Console.WriteLine($"Welcome, {CurrentUser.fullName}!");
                MainList();
            }
            else
            {
                Console.WriteLine("Invalid email or password.");
                SignList();
            }
            
        }
        static void Signup()
        {
            string fullName, email, password , role;
            Console.Write("Enter your fullName : ");
            fullName = Console.ReadLine();
            Console.Write("Enter your Role (D/S): ");
            role = Console.ReadLine().ToUpper();
            Console.Write("Enter your email : ");
            email = Console.ReadLine();
            Console.Write("Enter your password : ");
            password = Console.ReadLine();
            if (email == null || password == null || fullName == null || role == null) {
                Console.WriteLine("Please Enter vaild data : ");
                Signup();
            }
            CurrentUser = users.Find(user => user.email == email && user.password == password);
            if (CurrentUser != null)
            {
                Console.WriteLine("This username is already created.");
                SignList();
            }
            else
            {
                User user = new User(fullName, email, password, role);
                users.Add(user);
                CurrentUser = user;
                Console.WriteLine("Signup successful!");
                MainList();
            }
           
        }
        
    }
}
