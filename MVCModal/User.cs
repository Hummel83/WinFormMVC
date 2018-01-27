using System;

namespace WinFormMVC.Model
{
    public class User
    {
        public enum SexOfPerson
        {
            Male   = 1,
            Female = 2
        }

        private string    _FirstName;
        public string FirstName 
        {
            get { return _FirstName; } 
            set 
            { 
                 if (value.Length > 50)
                     Console.WriteLine("Error! FirstName must be less than 51 characters!"); 
                 else
                     _FirstName = value; 
            } 
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (value.Length > 50)
                    Console.WriteLine("Error! LastName must be less than 51 characters!");
                else
                    _LastName = value;
            }
        }

        private string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                if (value.Length > 9)
                    Console.WriteLine("Error! ID must be less than 10 characters!");
                else
                    _id = value;
            }
        }

        public string Department { get; set; }

        public SexOfPerson Sex { get; set; }


        public User(string firstname, string lastname, string id, string department, SexOfPerson sex)
        {
            FirstName   = firstname;
            LastName    = lastname;
            Id          = id;
            Department  = department;
            Sex         = sex;
        }

       
    } 

}
