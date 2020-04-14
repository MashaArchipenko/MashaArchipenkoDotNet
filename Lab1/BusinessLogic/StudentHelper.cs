using Lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.BusinessLogic
{
	public static class StudentHelper
	{
        public static IEnumerable<Student> FindAverageMark(this IEnumerable<Student> students)
        {
            foreach (var student in students)
                student.AverageMark = Math.Round(student.Subjects.Average(e => e.Mark), 2);
            return students;
        }
        public static double FindAverageGroupRating(IEnumerable<Student> students)
        {
            return Math.Round(students.Average(e => e.AverageMark), 2);
        }
        public static IEnumerable<StudentAverageMark> StudentToStudentAverageMark(IEnumerable<Student> students)
        {
            var resultList = new List<StudentAverageMark>();
            foreach (var student in students)
            {
                resultList.Add(new StudentAverageMark(student.Name, student.Surname, student.Patronymic, student.AverageMark));
            }
            return resultList;
        }
        public static IEnumerable<Subject> FindAverageInAllSubjects(IEnumerable<Student> students)
        {
            var allMarks = new List<Subject>();
            var averageMarks = new List<Subject>();

            foreach (var student in students)
                allMarks.AddRange(student.Subjects);

            foreach (var subject in students.Last().Subjects)
                averageMarks.Add(new Subject(subject.SubjectName, Math.Round(allMarks.Where(e => e.SubjectName.Equals(subject.SubjectName)).Average(e => e.Mark), 2)));

            return averageMarks;
        }
    }
}
