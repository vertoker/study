using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PovarenokApp.Data.Enum;

namespace PovarenokApp.Data
{
    public class ProductEntity
    {
        public int id;
        public int type;
        public float cost;
        public int discount_amount;
        public int quantity_in_stock;
        public string title;
        public byte[] image;

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(title);
        }

        public string DiscountText
        {
            get
            {
                if (discount_amount == 0)
                    return string.Empty;
                else
                    return $"* скидка {discount_amount}%";
            }
        }

        public string Title => string.Join(" ", title, ":", quantity_in_stock.ToString());
        public string Cost => cost.ToString("0.00") + " ";

        public string TotalCost
        {
            get
            {
                if (discount_amount == 0)
                    return cost.ToString("0.00") + " рублей";
                else
                    return (cost * (1 - (float)discount_amount / 100)).ToString("0.00") + " рублей";
            }
        }

        public Visibility DiscountVisibility
        {
            get
            {
                if (discount_amount == 0)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }

        public string BackColor
        {
            get
            {
                if (discount_amount == 0)
                    return "#FFFFE1";
                else
                    return "#D1FFD1";
            }
        }

        public ProductEntity DeepCopy()
        {
            return new ProductEntity()
            {
                id = id,
                type = type,
                cost = cost,
                discount_amount = discount_amount,
                quantity_in_stock = quantity_in_stock,
                title = title,
                image = image
            };
        }
    }
}
