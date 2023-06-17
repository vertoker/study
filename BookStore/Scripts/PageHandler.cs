using BookStore.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BookStore.Scripts
{
    public static class PageHandler
    {
        private static readonly Dictionary<Type, Page> _pages = new Dictionary<Type, Page>
        {
            { typeof(Products), new Products() },
            { typeof(Cart), new Cart() }
        };
        private static Frame _frame;

        public static void Init(Frame frame)
        {
            _frame = frame;
        }

        public static void SwitchTo<T>() where T : Page
        {
            _frame.Navigate(_pages[typeof(T)]);
        }
    }
}
