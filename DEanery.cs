using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CourseWork
{
    class DEanery:IXmlSerializable
    {
        List<Student> students = UserInstructionsInterface.GetStudentList();
        List<Group> groups = UserInstructionsInterface.GetGroupList();
        List<Teacher> teachers = UserInstructionsInterface.GetTeacherList();
        List<Subject> subjects = UserInstructionsInterface.GetSubjectList();

        public bool SaveDeaneryIntoFile()
        {
            try
            {
                using (var stream = new FileStream("Students.xml", FileMode.OpenOrCreate))
                {
                    var writer = new StreamWriter(stream);
                    var serializer = new XmlSerializer(typeof(DEanery));
                    serializer.Serialize(writer, this);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void ReadDeaneryFromFile()
        {
            using (XmlTextReader r = new XmlTextReader("Students.xml"))
            {
                this.ReadXml(r);
            }
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }


        public void ReadXml(XmlReader reader)
        {
            if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Deanery")
            {
                if (reader.ReadToDescendant("Group"))
                {
                    while (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Group")
                    {
                        Group group = new Group();
                        group.ReadXml(reader);
                        groups.Add(group);
                       
                        if (group.GetStudents() != null)
                        {
                            foreach (var student in group.GetStudents())
                            {
                                students.Add(student);
                            }
                        }
                        reader.Read();
                    }
                    reader.Read();
                }
                reader.Read();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (var group in groups)
            {
                writer.WriteStartElement("Group");
                group.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
    }
}
