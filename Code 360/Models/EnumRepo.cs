using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_360.Models
{
        public enum Gender
        {
            Male = 1,
            Female
        }

        public enum AddmissionType
        {
            Paid = 1,
            Income_Sharing
        }

        public enum MaritalStatus
        {
            Single = 1,
            Married,
            Divorced,
            Complicated
        }


        public enum Level
        {
            Beginer = 1,
            Intermidiate,
            Expert
        }

        public enum CourseName
        {
            Html = 1,
            Css,
            C,
            xamarin,
            AspNet
        }

        public enum ProgramName
        {

        DotNet = 1,
        Fullstack,
        Frontend

        }

        public enum ProjectStatus
        {

        Completed = 1,
        Incomplete,
        Abandoned

        }

        public enum StudentInBatchStatus
        {

        Graduated = 1,
        Left,
        On,
        Disqualified

        }

        public enum Grades
        {
        A1 = 1,
        A,
        B,
        C,
        D
        }

        public enum PaymentMethod
        {
        BankTransfer = 1,
        Cheques,
        POS,
        Cash,
        Paypal
        }

       

    //enums containing the choice which are to picked in a drop down in the UI view

}
