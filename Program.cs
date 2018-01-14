using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
             UserInstructionsInterface menu = new UserInstructionsInterface();
             menu.Run();
            
        }
    }
}
