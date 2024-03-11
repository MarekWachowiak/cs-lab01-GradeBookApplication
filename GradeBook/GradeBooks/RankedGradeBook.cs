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
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var grades = Students.Select(x => x.AverageGrade).ToList();
            grades = grades.OrderByDescending(x => x).ToList();
            for ( var i = 0 ; i < grades.Count; i++ )
            {
                if (grades[i] <= averageGrade)
                {
                    return i switch
                    {
                        0 => 'A',
                        1 => 'B',
                        2 => 'C',
                        3 => 'D',
                        _ => 'F'
                    };
                }
            }
            return 'F';
        }
    }
}
