using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyPhoneList
{
    interface IContactRepository
    {
        DataTable SellectAll();
        DataTable SellectRow(int contactID);
        DataTable search(string parameter);
        bool Add(string name, string family, int age, string phonenumber, string email, string addres);
        bool Update(int contactID, string name, string family, int age, string phonenumber, string email, string addres);
        bool Delete(int contactID);
    }
}
