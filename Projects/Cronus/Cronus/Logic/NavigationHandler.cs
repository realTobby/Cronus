using Cronus.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cronus.Logic
{
    public class NavigationHandler
    {
        private Dictionary<int, Page> _pageList = new Dictionary<int, Page>();

        public NavigationHandler(ViewModels.ViewModel vm)
        {
            Page home = new PageHome();
            Page newPage = new PageNew();
            Page load = new PageLoad();
            Page edit = new PageEdit();
            Page print = new PagePrint();

            home.DataContext = vm;
            newPage.DataContext = vm;
            load.DataContext = vm;
            edit.DataContext = vm;
            print.DataContext = vm;

            _pageList.Add(0, home);
            _pageList.Add(1, newPage);
            _pageList.Add(2, load);
            _pageList.Add(3, edit);
            _pageList.Add(4, print);
        }

        public Page GetPageAtIndex(int index)
        {
            return _pageList[index];
        }




    }
}
