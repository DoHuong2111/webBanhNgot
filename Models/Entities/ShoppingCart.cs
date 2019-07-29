using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_banh_ngot.Models.Entities
{
    public class ShoppingCart
    {
        public List<Item> lst = new List<Item>();
        
        public void InsertItem(int id, string name, double price,string image)
        {
            bool check = false;
            foreach(Item item in lst)
            {
                if(item.id == id)
                {
                    check = true;
                    item.amount += 1;
                    break;
                }  
            }
            if(!check)
            {
                Item item = new Item();
                item.id = id;
                item.name = name;
                item.price = price;
                item.amount = 1;
                item.image = image;
                lst.Add(item);
            }
        }
        public void UpdateAmount(int id,int amount)
        {
            foreach(Item item in lst)
            {
                if(item.id == id)
                {
                    if(amount >  0)
                    {
                        item.amount = amount;
                    }
                    else
                    {
                        lst.Remove(item);
                    }
                }
            }
        }
        public void RemoveItem(int id)
        {
            for(int i=lst.Count-1; i>=0;i-- )
            {
                if (lst.ElementAt(i).id == id)
                {
                    lst.RemoveAt(i);
                }
            }
        }
        public int GetTotal()
        {
            int total = 0;
            foreach(Item item in lst)
            {
                total += item.amount;
            }
            return total;
        }
        public double GetTotalMoney()
        {
            double total = 0;
            foreach (Item item in lst)
            {
                total += item.amount * item.price;
            }
            return total;
        }
    }
}