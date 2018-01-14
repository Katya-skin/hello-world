using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CourseWork
{
    public class Group : IXmlSerializable
    {
        private string _groupName;

        private List<Student> _students;

        public Group() { }
        public Group(string name)
        {
            _groupName = name;
        }

        /*
         * Getters and Setters for private properties
         */

        public void SetGroupName(string numberOfGroup)
        {
            this._groupName = numberOfGroup;
        }

        public string GetGroupName()
        {
            return this._groupName;
        }

        public void SetStudents(List<Student> students)
        {
            this._students = students;
        }

        public List<Student> GetStudents()
        {
            return _students;
        }

        public void AddStudent(Student student)
        {
            this._students.Add(student);
        }

        //if objects are equal, method will return 0 and if not or given object is equal to null then will return 1
        public int CompareTo(object obj)
        {
            if (obj != null)
            {
                Group group = obj as Group;
                if (group._groupName != null)
                {
                    if (this._groupName.CompareTo(group._groupName) == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            return 1;
        }

        public override string ToString()
        {
            string result = "Group name :" + _groupName + "\r\nList:\r\n";

            if (this._students != null)
            {
                for (int i = 0; i < this._students.Count; i++)
                {
                    result += this._students[i].ToString();
                }
            }
            

            return result + "*\r\n";
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {


            if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Group")
            {
                _groupName = reader["Number"];
                if (reader.ReadToDescendant("Student"))
                {
                    while (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Student")
                    {
                        var student = new Student();
                        student.ReadXml(reader);
                        _students.Add(student);
                    }
                }
                reader.Read();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Number", _groupName);
            foreach (var student in _students)
            {
                writer.WriteStartElement("Student");
                student.WriteXml(writer);
                writer.WriteEndElement();
            }
        }

    }
    }

