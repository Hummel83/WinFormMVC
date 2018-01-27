using System;
using System.Collections;
using System.Collections.Generic;
using  WinFormMVC.Model;
using  WinFormMVC.View;
using  WinFormMVC.Controller;


namespace UseMVCApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UsersView view = new UsersView {Visible = false};

            // Add some dummy data
            IList users = new List<object>
            {
                new User("Vladimir", "Putin", "122", "Government of Russia", User.SexOfPerson.Male),
                new User("Barack", "Obama", "123", "Government of USA", User.SexOfPerson.Male),
                new User("Stephen", "Harper", "124", "Government of Canada", User.SexOfPerson.Male),
                new User("Jean", "Charest", "125", "Government of Quebec", User.SexOfPerson.Male),
                new User("David", "Cameron", "131", "Government of United Kingdom", User.SexOfPerson.Male),
                new User("Angela", "Merkel", "127", "Government of Germany", User.SexOfPerson.Female),
                new User("Nikolas", "Sarkozy", "128", "Government of France", User.SexOfPerson.Male),
                new User("Silvio", "Berlusconi", "129", "Government of Italy", User.SexOfPerson.Male),
                new User("Yoshihiko", "Noda", "130", "Government of Japan", User.SexOfPerson.Male)
            };

            UsersController controller = new UsersController(view, users);
            controller.LoadView();
            view.ShowDialog();
        }
    }
}
