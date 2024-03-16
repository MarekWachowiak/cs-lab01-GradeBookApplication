using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            var grades = Students.Select(x => x.AverageGrade).OrderByDescending(x => x).ToList();
            var top20Count = grades.Count / 5f;
            var scoredHigherCount = 0f;
            var finalGrade = 5;
            foreach ( var currentGrade in grades )
            {
                if (averageGrade >= currentGrade) break;

                scoredHigherCount++;
                if (scoredHigherCount >= top20Count)
                {
                    scoredHigherCount -= top20Count;
                    finalGrade--;
                }
            }
            return finalGrade switch
            {
                5 => 'A',
                4 => 'B',
                3 => 'C',
                2 => 'D',
                _ => 'F'
            };
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
