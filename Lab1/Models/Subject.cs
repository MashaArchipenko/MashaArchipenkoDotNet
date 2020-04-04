using System.Runtime.Serialization;

namespace Lab1.Models
{
    [DataContract]
    public class Subject
    {
        [DataMember]
        public string SubjectName { get; set; }
        [DataMember]
        public double Mark { get; set; }
        public Subject(string subjectName, double mark)
        {
            SubjectName = subjectName;
            Mark = mark;
        }
    }
}
