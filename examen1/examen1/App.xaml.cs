using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using examen1.controllers;
using examen1.models;
using System.IO;
using Examen1.controllers;

namespace examen1
{
    public partial class App : Application
    {
        
        static database DataBa;

        public static database DataBase
        {
            get
            {
                var dbpath= string .Empty;
                var  namedb=string .Empty;
                var fullpath= string .Empty;


                dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                namedb = "bdcontactos.bd3";
                fullpath = Path.Combine (dbpath, namedb);

                if (DataBa == null)
                {
                    DataBa = new database(fullpath);
                }
                return DataBa;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new views.Pageinicial());

            //MainPage = new NavigationPage(new views.Pagecontacto());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
