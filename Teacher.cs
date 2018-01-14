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
    public class Teacher : IXmlSerializable
    {
        private string _name;

        private string _surname;


        public Teacher() { }
        public Teacher(string name, string surname)
        {
            _name = name;
            _surname = surname;
        }

        /*
         * Getters and Setters for private properties
         */

        public void SetName(string name)
        {
            this._name = name;
        }

        public string GetName()
        {
            return this._name;
        }

        public void SetSurname(string surname)
        {
            this._surname = surname;
        }

        public string GetSurname()
        {
            return this._surname;
        }

        //if objects are equal, method will return 0 and if not or given object is equal to null then will return 1
        public int CompareTo(object obj)
        {
            if(obj != null)
            {
                Teacher teacher = obj as Teacher;
                if (teacher._name != null && teacher._surname != null)
                {
                    if (this._name.CompareTo(teacher._name) == 0 && this._surname.CompareTo(teacher._surname) == 0)
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
            return "Name:" + _name + "\r\nSurname:" + _surname + "\r\n#\r\n";
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Teacher")
            {
                _name = reader["Name"];
                _surname = reader["Surname"];

                reader.Read();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Name", _name);
            writer.WriteAttributeString("Surname", _surname);
            writer.WriteEndElement();
        }


        public XmlSchema GetSchema()
        {
            return null;
        }
    }
}
