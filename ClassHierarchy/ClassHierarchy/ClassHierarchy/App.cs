using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ClassHierarchy
{
	public class App : Application
    {
		public App ()
        {
            MainPage = new ClassHierarchyPage();
        }
    }
}
