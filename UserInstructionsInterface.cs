using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramOperations;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CourseWork
{
    public class UserInstructionsInterface : IO<Student>
    {
        private void ShowMenu()
        {
            string option = "default";
            string tmp;
            int configuration = 9999;
            while (!option.ToLower().Equals("exit"))
            {
                configuration = DisplayMenu(option);
                tmp = option;
                option = Console.ReadLine().ToLower();
                GetUserChoice(configuration, option);

                if (!tmp.Equals("default") && !option.Equals("back")
                    && !option.Equals("groups") && !option.Equals("students") && !option.Equals("teachers") && !option.Equals("search") && !option.Equals("management"))
                {
                    option = tmp;
                }
                
            }
        }

        /** Method which output main menu
         */
        private int DisplayMenu(string option)
        {
            Console.Clear();
            if (option.Equals("default") || option.Equals("back"))
            {
                Console.WriteLine("Welcome to the informational system of the institution");
                Console.WriteLine("1. Enter command 'Students' to process Students information");
                Console.WriteLine("2. Enter command 'Teachers' to process Teachers information");
                Console.WriteLine("3. Enter command 'Groups' to process Groups information");
                Console.WriteLine("4. Enter command 'Management' to control management of educational process");
                Console.WriteLine("5. Enter command 'Search' to start searchind of needed thing");
                return 0;
                
            }
            else if(option.Equals("students"))
            {
                Console.WriteLine("1. To add new student enter 'Add' command");
                Console.WriteLine("2. To delete student enter 'Delete' command");
                Console.WriteLine("3. To edit student's data enter 'Edit' command");
                Console.WriteLine("4. To display all students data 'All' command");
                Console.WriteLine("5. To display choosen student's 'Chosen' command");
                Console.WriteLine("6. To go back to the previous menu enter 'Back' command");
                return 1;
            }
            else if (option.Equals("teachers"))
            {
                Console.WriteLine("1. To add new teacher enter 'Add' command");
                Console.WriteLine("2. To delete teacher enter 'Delete' command");
                Console.WriteLine("3. To edit teacher's data enter 'Edit' command");
                Console.WriteLine("4. To display all teacher data 'All' command");
                Console.WriteLine("5. To display choosen teacher's data 'Chosen' command");
                Console.WriteLine("6. To go back to the previous menu enter 'Back' command");
                return 2;
            }
            else if (option.Equals("groups"))
            {
                Console.WriteLine("1. To add new group enter 'Add' command");
                Console.WriteLine("2. To delete group enter 'Delete' command");
                Console.WriteLine("3. To edit group's data enter 'Edit' command");
                Console.WriteLine("4. To display all groups data 'All' command");
                Console.WriteLine("5. To display choosen group's data 'Chosen' command");
                Console.WriteLine("6. To go back to the previous menu enter 'Back' command");
                return 3;
            }
            else if (option.Equals("management"))
            {
                Console.WriteLine("1. To add new subject to the existed groups enter 'Add subject' command");
                Console.WriteLine("2. To delete subject from the existed groups enter 'Delete subject' command");
                Console.WriteLine("3. To add group to choosen subject enter 'Add group' command");
                Console.WriteLine("4. To edit teacher of the choosen subject enter 'Edit teacher' command");
                Console.WriteLine("5. To add new student to the existed group enter 'Add student' command");
                Console.WriteLine("6. To delete student from the existed group enter 'Delete student' command");
                Console.WriteLine("7. To display all subjects 'All' command");
                Console.WriteLine("8. To go back to the previous menu enter 'Back' command");
                return 4;
            }
            else if (option.Equals("search"))
            {
                Console.WriteLine("1. To find a student enter 'Student search' command");
                Console.WriteLine("2. To find students of the choosen group enter 'Search by group' command");
                Console.WriteLine("3. To find students of the choosen teacher enter 'Search by teacher' command");
                Console.WriteLine("4. To find students by subject to study enter 'Search by subject' command");
                Console.WriteLine("5. To go back to the previous menu enter 'Back' command");
            }

            return 0;
        }

        /** Method which analyse user's input
         */
        private void GetUserChoice(int configuration, string option)
        {
            if (option.Equals("exit"))
            {
                Environment.Exit(0);
            }
            else if (option.Equals("default"))
            {
                return;
            }
            
           
            if (configuration == 1)
            {
                
                IO<Student> io = new IO<Student>();
                io.SetConfiguration(1);
                if (option.Equals("add"))
                {
                    io.Create(CreateNewStudent(null));
                    return;
                }
                else if(option.Equals("all"))
                {
                    OutputOfStudents();
                    Console.WriteLine("Press 'Enter' button to continue...");
                    Console.ReadLine();
                    return;
                }
                else if(option.Equals("chosen"))
                {
                    OutputOfDefinedStudent();
                }
                else if (option.Equals("delete"))
                {
                    OutputOfStudents();
                    DeleteStudent();
                    
                }
                else if (option.Equals("edit"))
                {
                    //OutputOfStudents();
                    UpdateStudent();

                }

            }
            else if (configuration == 2)
            {
                IO<Teacher> io = new IO<Teacher>();
                io.SetConfiguration(2);
                if (option.Equals("add"))
                {
                    io.Create(CreateNewTeacher(null));

                    return;
                }
                else if (option.Equals("all"))
                {
                    OutputOfTeachers();
                    Console.WriteLine("Press 'Enter' button to continue...");
                    Console.ReadLine();
                    return;
                }
                else if (option.Equals("chosen"))
                {
                    OutputOfDefinedTeacher();
                }
                else if (option.Equals("delete"))
                {
                    OutputOfTeachers();
                    DeleteTeacher();
                }
                else if (option.Equals("edit"))
                {
                    OutputOfTeachers();
                    UpdateTeacher();
                }

                
            }
            else if (configuration == 3)
            {
                IO<Group> io = new IO<Group>();
                io.SetConfiguration(3);
                if (option.Equals("add"))
                {
                    io.Create(CreateNewGroup());

                    return;
                }
                else if (option.Equals("all"))
                {
                    OutputOfGroups();
                    Console.WriteLine("Press 'Enter' button to continue...");
                    Console.ReadLine();
                    return;
                }
                else if(option.Equals("chosen"))
                {
                    OutputOfDefinedGroup();
                }
                else if(option.Equals("delete"))
                {
                    OutputOfGroups();
                    DeleteGroup();
                }
                
            }
            else if (configuration == 4)
            {
                IO<Subject> io = new IO<Subject>();
                io.SetConfiguration(4);
                if (option.Equals("add subject"))
                {
                    io.Create(CreateNewSubject());

                    return;
                }
                else if (option.Equals("all"))
                {
                    OutputOfSubjects();
                    Console.WriteLine("Press 'Enter' button to continue...");
                    Console.ReadLine();
                    return;
                }
                else if (option.Equals("edit teacher"))
                {
                    OutputOfSubjects();
                    UpdateSubject();
                }
                else if (option.Equals("add group"))
                {
                    OutputOfSubjects();
                    AddGroupToSubject();
                }
                else if (option.Equals("add student"))
                {
                    AddStudentToGroup();
                }
                else if (option.Equals("delete student"))
                {
                    DeleteStudentFromGroup();
                }

                
            }



        }
        
        /** Method which call the private methods of the class
         */
        public void Run()
        {
            ShowMenu();
        }

        /**
        * Method for creating new student
        */
        private Student CreateNewStudent(Student student)
        {
            
            if (student == null)
            {
                student = new Student();
            }
            
            String input = "";
            Console.WriteLine("Enter student's name:");
            input = Console.ReadLine(); 
            if(!input.Contains("-u"))
            {
                student.SetName(input);
            }
            
            Console.WriteLine("Enter student's surname:");
            input = Console.ReadLine();
            if (!input.Contains("-u"))
            {
                student.SetSurname(input);
            }

            Console.WriteLine("Enter student's ID:");
            input = Console.ReadLine();
            if (!input.Contains("-u"))
            {
                student.SetIDcard(input);
            }

            Console.WriteLine("Enter student's course:");
            input = Console.ReadLine();
            if (!input.Contains("-u"))
            {
                student.SetCourse(Convert.ToInt32(input));
            }

            Console.WriteLine("Enter student's city of live:");
            input = Console.ReadLine();
            if (!input.Contains("-u"))
            {
                student.SetCity(input);
            }

            Console.WriteLine("Enter student's street of live:");
            input = Console.ReadLine();
            if (!input.Contains("-u"))
            {
                student.SetStreet(input);
            }

            Console.WriteLine("Enter student's phone number:");
            input = Console.ReadLine();
            if (!input.Contains("-u"))
            {
                student.SetPhoneNumber(input);
            }
            
            return student;
        }

        /**
        * Method for creating new teacher
        */
        private Teacher CreateNewTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                teacher = new Teacher();
            }

            String input = "";
            Console.WriteLine("Enter teacher's name:");
            input = Console.ReadLine();
            if (!input.Contains("-u"))
            {
                teacher.SetName(input);
            }

            Console.WriteLine("Enter teacher's surname:");
            input = Console.ReadLine();
            if (!input.Contains("-u"))
            {
                teacher.SetSurname(input);
            }
            return teacher;
        } 

        /**
        * Method for creating new group
        */
        private Group CreateNewGroup()
        {
            Group group = new Group();

            Console.WriteLine("Enter group's name:");
            group.SetGroupName(Console.ReadLine());
            Console.WriteLine("Enter number of students you want to add to the group:");
            int count = Convert.ToInt32(Console.ReadLine());

            List<Student> students = new List<Student>();
            for (int i = 0; i < count; i++)
            {
                Student st = CreateNewStudent(null);
                students.Add(st);
            }

            group.SetStudents(students);
            return group;
        } 

        /**
        * Method for creating new subject
        */
        private Subject CreateNewSubject()
        {
            Subject subject = new Subject();

            Console.WriteLine("Enter subject's name:");
            subject.Set_name(Console.ReadLine());

            Teacher teacher = CreateNewTeacher(null);
            subject.Set_teacher(teacher);

            Console.WriteLine("Enter number of groups you want to add for this subject studying:");
            int count = Convert.ToInt32(Console.ReadLine());
            List<String> groups = new List<String>();
            List<Group> gr = GetGroupList();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter name of group:");
                string name = Console.ReadLine();

                for (int j = 0; j < gr.Count; j++)
                {
                    if (name.CompareTo(gr[j].GetGroupName()) == 0)
                    {
                        groups.Add(name);
                    }
                    else
                    {
                        Console.WriteLine("Such group doesn't exist!");
                        Console.ReadLine();
                    }
                }
            }

            subject.Set_groups(groups);
            return subject;
        } 

        /**
        * Method which return list of all students
        */
        public static List<Student> GetStudentList()
        {
            List<Student> students = new List<Student>();
            IO<Student> io = new IO<Student>();
            io.SetConfiguration(1);
            List<string> lines = io.Review();
            ArrayList array = new ArrayList();

            for (int i = 0; i < lines.Count; i++)
            {
               
                if (lines[i].CompareTo("#") != 0)
                {

                    array.Add(lines[i]);
                    
                }
                else
                {
                    Student st = new Student();
                    st.SetName(((String)array[0]).Split(':')[1]);
                    st.SetSurname(((String)array[1]).Split(':')[1]);
                    st.SetIDcard(((String)array[2]).Split(':')[1]);
                    st.SetCourse(Convert.ToInt32(((String)array[3]).Split(':')[1]));
                    st.SetCity(((String)array[4]).Split(':')[1]);
                    st.SetStreet(((String)array[5]).Split(':')[1]);
                    st.SetPhoneNumber(((String)array[6]).Split(':')[1]);
                    students.Add(st);
                    
                    array = new ArrayList();
                }
            }

            return students;
        }

        /**
        * Method which return list of all teachers
        */
        public static List<Teacher> GetTeacherList()
        {
            List<Teacher> teachers = new List<Teacher>();
            IO<Teacher> io = new IO<Teacher>();
            io.SetConfiguration(2);
            List<string> lines = io.Review();
            ArrayList array = new ArrayList();

            for (int i = 0; i < lines.Count; i++)
            {

                if (lines[i].CompareTo("#") != 0)
                {

                    array.Add(lines[i]);

                }
                else
                {
                    Teacher teach = new Teacher();
                    teach.SetName(((String)array[0]).Split(':')[1]);
                    teach.SetSurname(((String)array[1]).Split(':')[1]);
                    teachers.Add(teach);

                    array = new ArrayList();
                }
            }

            return teachers;
        }

        /**
        * Method which return list of all groups
        */
        public static List<Group> GetGroupList()
        {
            List<Group> groups = new List<Group>();
            IO<Group> io = new IO<Group>();
            io.SetConfiguration(3);
            List<string> lines = io.Review();
            ArrayList array = new ArrayList();
            
            for (int i = 0; i < lines.Count; i++)
            {

                if (lines[i].CompareTo("*") != 0)
                {

                    array.Add(lines[i]);

                }
                else
                {
                    Group gr = new Group();
                    gr.SetGroupName(((String)array[0]).Split(':')[1]);
                    
                    List<Student> students = new List<Student>();
                    ArrayList ff = new ArrayList();
                    for(int j = 0; j < array.Count; j++)
                    {
                        if(array[j].ToString().CompareTo("#") != 0)
                        {
                            ff.Add(array[j]);
                        }
                        else
                        {
                            Student st = new Student();
                            st.SetName(((String)ff[2]).Split(':')[1]);
                            st.SetSurname(((String)ff[3]).Split(':')[1]);
                            st.SetIDcard(((String)ff[4]).Split(':')[1]);
                            st.SetCourse(Convert.ToInt32(((String)ff[5]).Split(':')[1]));
                            st.SetCity(((String)ff[6]).Split(':')[1]);
                            st.SetStreet(((String)ff[7]).Split(':')[1]);
                            st.SetPhoneNumber(((String)ff[8]).Split(':')[1]);
                            students.Add(st);

                            ff = new ArrayList();
                            array = new ArrayList();
                        }
                    }
                    
                    gr.SetStudents(students);
                    groups.Add(gr);
                    
                }
            }

            return groups;
        }

        /**
        * Method which return list of all subject
        */
        public static List<Subject> GetSubjectList()
        {
            List<Subject> subjects = new List<Subject>();
            IO<Subject> io = new IO<Subject>();
            io.SetConfiguration(4);
            List<string> lines = io.Review();
            ArrayList array = new ArrayList();

            for (int i = 0; i < lines.Count; i++)
            {

                if (lines[i].CompareTo("*") != 0)
                {

                    array.Add(lines[i]);

                }
                else
                {
                    Subject sb = new Subject();
                    sb.Set_name(((String)array[0]).Split(':')[1]);
                    Teacher teacher = new Teacher();
                    teacher.SetName(((String)array[2]).Split(':')[1]);
                    teacher.SetSurname(((String)array[3]).Split(':')[1]);
                    sb.Set_teacher(teacher);

                    sb.AddGroup((String)array[6]);
                    subjects.Add(sb);
                    array = new ArrayList();
                }
            }

            return subjects;
        }

        /**
        * Method for finding student by his name and surname
        */
        public Student findStudent(String name, String surname)
        {
            Student student = new Student();
            student.SetName(name);
            student.SetSurname(surname);
            List<Student> students = GetStudentList();
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].CompareTo(student) == 0)
                {
                    return students[i];
                }
            }
            return null;

        }

        /**
        * Method for finding all students who are in defined group
        */
        public List<Student> findStudentsByGroup(String name)
        {
            Group group = new Group();
            group.SetGroupName(name);
            List<Group> groups = GetGroupList();
            List<Student> students = GetStudentList();
            for (int i = 0; i < groups.Count; i++)
            {
                if (groups[i].CompareTo(group) == 0)
                {
                    return groups[i].GetStudents();
                }
            }
            return null;

        }

        /**
        * Method for finding all students who are students of defined teacher
        */
        public List<Student> findStudentsByTeacher(String name, String surname)
        {
            Teacher teacher = new Teacher();
            teacher.SetName(name);
            teacher.SetSurname(surname);
            List<Subject> subjects = GetSubjectList();
            List<Group> groups = GetGroupList();
            List<Student> students = GetStudentList();
            for (int i = 0; i < subjects.Count; i++)
            {
                if ((subjects[i].Get_teacher()).CompareTo(teacher) == 0)
                {
                    List<String> gr = subjects[i].Get_groups();
                    for (int j = 0; j < gr.Count; j++ )
                    {
                        if((gr[j]).CompareTo(groups[j].GetGroupName()) == 0)
                        {
                            return groups[j].GetStudents();
                        }
                    }
                }
            }
            return null;
        }

        /**
        * Method for finding all students who learn defined subject
        */
        public List<Student> findStudentsBySubject(String name)
        {
            Subject subject = new Subject();
            subject.Set_name(name);
            List<Subject> subjects = GetSubjectList();
            List<Group> groups = GetGroupList();
            for (int i = 0; i < subjects.Count; i++)
            {
                List<string> gr = subjects[i].Get_groups();   
                if (gr[i].CompareTo(groups[i].GetGroupName()) == 0)
                {

                    for (int j = 0; j < gr.Count; j++)
                    {
                        if (gr[j].CompareTo(groups[j].GetGroupName()) == 0)
                        {
                            return groups[j].GetStudents();
                        }
                    }
                }
            }
            return null;
        }

         /**
         * Method for finding defined teacher by his name and surname
         */
        public Teacher findTeacher(String name, String surname)
        {
            List<Teacher> teacher = GetTeacherList();
            Teacher t = new Teacher();
            t.SetName(name);
            t.SetSurname(surname);
            for (int i = 0; i < teacher.Count; i++)
            {

                if (teacher[i].CompareTo(t) == 0)
                {
                    return teacher[i];
                }
               
            }

            return null;
        }

        /**
        * Method for finding defined group by its name
        */
        public Group findGroup(String name)
        {
            List<Group> groups = GetGroupList();
            Group group = new Group();
            group.SetGroupName(name);
            for (int i = 0; i < groups.Count; i++)
            {

                if (groups[i].CompareTo(group) == 0)
                {
                    return groups[i];
                }

            }

            return null;

        }

        /**
        * Method for outputting all students list
        */
        public void OutputOfStudents()
        {
            List<Student> st = GetStudentList();

            Console.WriteLine("List of students:");
            for(int i = 0; i < st.Count; i++)
            {
                Console.WriteLine(st[i].ToString());
            }
        }

        /**
        * Method for outputting all teachers list
        */
        public void OutputOfTeachers()
        {
            List<Teacher> teacher = GetTeacherList();

            Console.WriteLine("List of teachers:");
            for (int i = 0; i < teacher.Count; i++)
            {
                Console.WriteLine(teacher[i].ToString());
            }
        }

        /**
        * Method for outputting all groups list 
        */
        public void OutputOfGroups()
        {
            List<Group> group = GetGroupList();

            Console.WriteLine("List of groups:");
            for (int i = 0; i < group.Count; i++)
            {
                Console.WriteLine(group[i].ToString());
            }
        }

       /**
       * Method for outputting all subjects list 
       */
        public void OutputOfSubjects()
        {
            List<Subject> subjects = GetSubjectList();

            Console.WriteLine("List of subjects:");
            for (int i = 0; i < subjects.Count; i++)
            {
                Console.WriteLine(subjects[i].ToString());
            }
        }

        /**
        * Method for outputting defined teacher by his name and surname
        */
        public void OutputOfDefinedTeacher()
        {
            Console.WriteLine("Enter teacher's name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter teacher's surname:");
            string surname = Console.ReadLine();

            if (findTeacher(name, surname) != null)
            {
                Console.WriteLine(findTeacher(name, surname).ToString());
            }
            else
            {
                Console.WriteLine("Such teacher doesn't exist!");
            }
            Console.ReadLine();
        }

        /**
        * Method for outputting defined student his name and surname
        */
        public void OutputOfDefinedStudent()
        {
            Console.WriteLine("Enter student's name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter student's surname:");
            string surname = Console.ReadLine();

            if (findStudent(name, surname) != null)
            {
                Console.WriteLine(findStudent(name, surname).ToString());
            }
            else
            {
                Console.WriteLine("Such students doesn't exist!");
            }
            Console.ReadLine();
        }
        
        /**
         * Method for outputting defined group by its name
         */
        public void OutputOfDefinedGroup()
        {
            Console.WriteLine("Enter group's name:");
            String name = Console.ReadLine();

            if (findGroup(name) != null)
            {
                Console.WriteLine(findGroup(name).ToString());
            }
            else
            {
                Console.WriteLine("Such group doesn't exist!");
            }
            Console.ReadLine();
        }

        public ArrayList DeleteStudent()
        {
            IO<Student> io = new IO<Student>();
            io.SetConfiguration(1);

            Console.WriteLine("Enter students name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter students surname:");
            string surname = Console.ReadLine();

            List<Student> list = GetStudentList();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(new Student(name, surname)) == 0)
                {
                    list.RemoveAt(i);
                }
            }

            io.Delete(list.Cast<Student>().ToList<Student>());
            Console.WriteLine("Student was deleted! Yeah !");
            return new ArrayList(list);
        }

        public ArrayList DeleteTeacher()
        {
            IO<Teacher> io = new IO<Teacher>();
            io.SetConfiguration(2);

            Console.WriteLine("Enter teachers name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter teachers surname:");
            string surname = Console.ReadLine();

            List<Teacher> list = GetTeacherList();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(new Teacher(name, surname)) == 0)
                {
                    list.RemoveAt(i);
                }
            }

            io.Delete(list.Cast<Teacher>().ToList<Teacher>());
            
            return new ArrayList(list);
        }

        public ArrayList DeleteGroup()
        {
            IO<Group> io = new IO<Group>();
            io.SetConfiguration(3);
            Console.WriteLine("Enter group's name:");
            string name = Console.ReadLine();

            List<Group> list = GetGroupList();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(new Group(name)) == 0)
                {
                    Group gr = list[i];
                    list.Remove(gr);
                }
            }

            Console.WriteLine("\n\nDelete Successfully! \n");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.ReadLine();
            io.Delete(list.Cast<Group>().ToList<Group>());
            return new ArrayList(list);
        }

        public void UpdateSubject()
        {
            IO<Subject> io = new IO<Subject>();
            io.SetConfiguration(4);
            Console.WriteLine("Enter name of editing subject:");
            string name = Console.ReadLine();
            List<Subject> list = GetSubjectList();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(new Subject(name)) == 0)
                {
                    Console.WriteLine("Enter name of teacher:");
                    string tname = Console.ReadLine();

                    Console.WriteLine("Enter surname of teacher:");
                    string tsurname = Console.ReadLine();

                    list[i].Set_teacher(new Teacher(tname, tsurname));
                    io.Update(list);
                }
            }

            io.Delete(list.Cast<Subject>().ToList<Subject>());
        }

        public void UpdateStudent()
        {
            IO<Student> io = new IO<Student>();
            io.SetConfiguration(1);
            Console.WriteLine("Enter name of editing student:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter surname of editing student:");
            string surname = Console.ReadLine();

            List<Student> list = GetStudentList();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(new Student(name, surname)) == 0)
                {
                    Student st = CreateNewStudent(list[i]);

                    list[i] = st;
                    io.Update(list);
                }
            }

            io.Delete(list.Cast<Student>().ToList<Student>());
        }

        public void UpdateTeacher()
        {
            IO<Teacher> io = new IO<Teacher>();
            io.SetConfiguration(2);
            Console.WriteLine("Enter name of editing teacher:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter surname of editing teacher:");
            string surname = Console.ReadLine();

            List<Teacher> list = GetTeacherList();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(new Teacher(name, surname)) == 0)
                {
                    Teacher st = CreateNewTeacher(list[i]);

                    list[i] = st;
                    io.Update(list);
                }
            }

            io.Delete(list.Cast<Teacher>().ToList<Teacher>());
        }

        public void AddGroupToSubject()
        {
            IO<Subject> io = new IO<Subject>();
            io.SetConfiguration(4);

            OutputOfSubjects();
            Console.WriteLine("Specify the name of subject:");
            string groupName = Console.ReadLine();

            List<Subject> list = GetSubjectList();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(new Subject(groupName)) == 0)
                {
                    Console.WriteLine("Specify the name of exists group:");
                    string grName = Console.ReadLine();

                    List<Group> gr = GetGroupList();
                    for (int j = 0; j < gr.Count; j++)
                    {
                        if (gr[j].CompareTo(new Group(grName.Trim())) == 0)
                        {
                            list[i].AddGroup(grName);
                        }
                      
                    }

                }
            }
            io.Update(list);


        }

        public void AddStudentToGroup() 
        {
            IO<Group> io = new IO<Group>();
            io.SetConfiguration(3);

            OutputOfGroups();
            Console.WriteLine("Specify the name of group:");
            string groupName = Console.ReadLine();

            List<Group> list = GetGroupList();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(new Group(groupName)) == 0)
                {
                    Student st = CreateNewStudent(null);
                    list[i].AddStudent(st);
                }
            }
            io.Update(list);

        }

        public void DeleteStudentFromGroup()
        {
            IO<Group> io = new IO<Group>();
            io.SetConfiguration(3);

            OutputOfGroups();
            Console.WriteLine("Specify the name of group:");
            string groupName = Console.ReadLine();

            Console.WriteLine("Specify the name of student:");
            string stName = Console.ReadLine();

            Console.WriteLine("Specify the name of student:");
            string stSurName = Console.ReadLine();

            List<Group> list = GetGroupList();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(new Group(groupName)) == 0)
                {
                    List<Student> students = list[i].GetStudents();
                    for (int j = 0; j < students.Count; j++)
                    {
                        if(students[j].CompareTo(new Student(stName, stSurName)) == 0)
                        {
                            students.RemoveAt(j);
                        }
                    }
                }
            }
            io.Delete(list);
        }
    }
}
