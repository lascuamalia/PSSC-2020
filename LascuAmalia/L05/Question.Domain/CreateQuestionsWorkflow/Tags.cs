using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.CreateQuestionsWorkflow
{
    public  class Tags
    {
        public string Tg1 { get; set; }
        public string Tg2 { get; set; }
        public string Tg3 { get; set; }



        public Tags(string tg1, string tg2, string tg3)
        {
            Tg1 = tg1;
            Tg2 = tg2;
            Tg3 = tg3;
        }

        
    }
}
