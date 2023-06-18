using BookStore.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BookStore.Scripts
{
    public static class AppHandler
    {
        private static readonly Dictionary<Type, IPage> _pages = new Dictionary<Type, IPage>
        {
            { typeof(Products), new Products() },
            { typeof(Cart), new Cart() }
        };

        private static IPage _activePage;
        private static Frame _frame;

        public static readonly CartHandler Cart = new CartHandler();

        public static void Init(Frame frame)
        {
            _frame = frame;
        }

        public static void SwitchTo<T>() where T : IPage
        {
            _activePage?.Close();
            _activePage = _pages[typeof(T)];
            _activePage.Open();
            _frame.Navigate(_activePage);
        }
    }
}
