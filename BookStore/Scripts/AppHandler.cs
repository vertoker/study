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
            { typeof(Orders), new Orders() },
            { typeof(Cart), new Cart() }
        };

        private static Type _activeType;
        private static IPage _activePage;
        private static Frame _frame;

        public static Type ActiveType => _activeType;
        public static IPage ActivePage => _activePage;

        public static readonly CartHandler Cart = new CartHandler();

        public static void Init(Frame frame)
        {
            _frame = frame;
        }

        public static void SwitchTo<T>() where T : IPage
        {
            _activePage?.Close();
            _activeType = typeof(T);
            _activePage = _pages[typeof(T)];
            _activePage.Open();
            _frame.Navigate(_activePage);
        }
    }
}
