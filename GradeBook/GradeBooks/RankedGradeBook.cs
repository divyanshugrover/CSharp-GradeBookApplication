﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

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
            List<double> studentGrades = new List<double>();
            Students.ForEach(s => studentGrades.Add(s.AverageGrade));
            studentGrades.Sort();
            studentGrades.Reverse();
            var index = studentGrades.FindIndex(val => val < averageGrade);
            int bucket = (index * 5) / studentGrades.Count;
            switch (bucket)
            {
                case 1:
                    return 'A';
                case 2:
                    return 'B';
                case 3:
                    return 'C';
                case 4:
                    return 'D';
            }
            return 'F';
        }
    }
}
