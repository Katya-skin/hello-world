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
    public class Subject : IXmlSerializable
    {
        private string _name;

        private Teacher _teacher;

         [XmlIgnore]
        private List<String> _groups  = new List<String>();

        public Subject() { }
        public Subject(String name)
        {
            _name = name;
        }

        /*
         * Getters and Setters for private properties
         */

        public void Set_name(string name)
        {
            this._name = name;
        }

        public string Get_name()
        {
            return _name;
        }

        public void Set_teacher(Teacher teacher)
        {
            this._teacher = teacher;
        }

        public Teacher Get_teacher()
        {
            return _teacher;
        }


        public void AddGroup(String groupName)
        {
            this._groups.Add(groupName);
        }

        public void Set_groups(List<String> groups)
        {
            this._groups = groups;
        }

        public List<String> Get_groups()
        {
            return _groups;
        }

        public int CompareTo(object obj)
        {
            if (obj != null)
            {
                Subject subject = obj as Subject;
                if (subject._name != null)
                {
                    if (this._name.CompareTo(subject._name) == 0)
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
            string result = "Subject name:" + _name + "\r\nTeacher:\r\n" + _teacher + "Groups:\r\n";

            if (this._groups != null)
            {
                for (int i = 0; i < this._groups.Count; i++)
                {
                    result += this._groups[i];
                }
            }


            return result + "\r\n*\r\n";
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Subject")
            {
                _name = reader["Name"];
                reader.Read();
                if (reader.ReadToDescendant("Teacher"))
                {
                      _teacher.ReadXml(reader);
                }
                reader.Read();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Name", _name);
            writer.WriteStartElement("Teacher");
            _teacher.WriteXml(writer);
            writer.WriteEndElement();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }
    }
}
