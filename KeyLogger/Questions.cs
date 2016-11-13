using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyLogger
{

    class Questions
    {
        //questionType: 
        // 0--Easy
        // 1--Intermediate
        // 2--Hard
        private int questionType;

        private string question;

        //modelIn:
        //0--Using ROWL
        //1--Bare protege
        private int modelIn;

        public Questions(int type, string question, int useTooltoModel)
        {
            this.QuestionType = type;
            this.Question = question;
            this.ModelIn = useTooltoModel;
        }


        public int ModelIn
        {
            get
            {
                return modelIn;
            }

            set
            {
                modelIn = value;
            }
        }

        public int QuestionType
        {
            get
            {
                return questionType;
            }

            set
            {
                questionType = value;
            }
        }

        public string Question
        {
            get
            {
                return question;
            }

            set
            {
                question = value;
            }
        }
    }
}
