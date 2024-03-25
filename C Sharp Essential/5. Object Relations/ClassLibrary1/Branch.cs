using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College
{
    public class Branch
    {
        public string? BranchName { get; set; }

        public int NoOfSem {  get; set; }
    }

    public class Examination
    {
        public string? ExamName { get; set; }
        public int Month {   get; set; }
        public int Year { get; set; }
        public int MaxMarks {  get; set; }
        public int SecuredMarks {  get; set; }
    }
}
