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
    public class Student : IComparable, IXmlSerializable
    {
        private string _name;

        private string _surname;

        private int _course;

        private string _idCard;

        private string _city;

        private string _street;

        private string _phoneNumber;


        public Student() { }
        public Student(string name, string surname)
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

        public void SetCourse(int course)
        {
            this._course = course;
        }

        public int GetCourse()
        {
            return _course;
        }

        public void SetIDcard(string idCard)
        {
            this._idCard = idCard;
        }

        public string GetIDcard()
        {
            return this._idCard;
        }

        public void SetCity(string city)
        {
            this._city = city;
        }

        public string GetCity()
        {
            return this._city;
        }

        public void SetStreet(string street)
        {
            this._street = street;
        }

        public string GetStreet()
        {
            return this._street;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            this._phoneNumber = phoneNumber;
        }

        public string GetPhoneNumber()
        {
            return this._phoneNumber;
        }

        //if objects are equal, method will return 0 and if not or given object is equal to null then will return 1
        public int CompareTo(object obj)
        {
            if (obj != null)
            {
                Student student = obj as Student;
                if (student._name != null && student._surname != null)
                {
                    if (this._name.CompareTo(student._name) == 0 && this._surname.CompareTo(student._surname) == 0)
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
            return "Name:" + _name + "\r\nSurname:" + _surname 
                + "\r\nStudent's ID:" + _idCard + "\r\nCourse:" + _course 
                + "\r\nCity:" + _city + "\r\nStreet:" + _street 
                + "\r\nPhone number:" + _phoneNumber + "\r\n#\r\n";
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Student")
            {
                _name = reader["Name"];
                _surname = reader["Surname"];
                _course = Int32.Parse(reader["Course"]);
                _idCard = reader["Gradebook"];
                _city = reader["City"];
                _street = reader["Street"];
                _phoneNumber = reader["Phone"];
                reader.Read();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Name", _name);
            writer.WriteAttributeString("Surname", _surname);
            writer.WriteAttributeString("Course", _course.ToString());
            writer.WriteAttributeString("Gradebook", _idCard);
            writer.WriteAttributeString("City", _city);
            writer.WriteAttributeString("Street", _street);
            writer.WriteAttributeString("Phone", _phoneNumber);
        }


        public XmlSchema GetSchema()
        {
            return null;
        }
    }
}
