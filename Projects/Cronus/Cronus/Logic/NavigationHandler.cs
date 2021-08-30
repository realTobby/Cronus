using Cronus.Pages;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cronus.Logic
{
    public static class NavigationHandler
    {
        private static ViewModels.ViewModel viewModelRef;
        private static Dictionary<int, Page> _pageList = new Dictionary<int, Page>();
        private static Frame mainFrame;

        public static void InitNavigation(ViewModels.ViewModel vm, Frame frm)
        {
            viewModelRef = vm;


            Page home = new PageHome();
            Page newPage = new PageNew(vm);
            Page load = new PageLoad(vm);
            Page edit = new PageEdit(vm);
            Page print = new PagePrint(vm);

            _pageList.Add(0, home);
            _pageList.Add(1, newPage);
            _pageList.Add(2, load);
            _pageList.Add(3, edit);
            _pageList.Add(4, print);

            mainFrame = frm;


        }

        public static void ChangePage(int index)
        {
            viewModelRef.CurrentView = GetPageAtIndex(index);
            mainFrame.Navigate(viewModelRef.CurrentView);
        }

        public static Page GetPageAtIndex(int index)
        {
            return _pageList[index];
        }




    }
}
