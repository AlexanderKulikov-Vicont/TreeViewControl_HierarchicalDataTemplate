using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Grid;

namespace HierarchicalTest
{
    public static class RND
    {
        private static Random rnd = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static string GetNewString(int length)
        {
            return new string(Enumerable.Repeat(chars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
        public static int GetNewInt(int i1, int i2)
        {
            return rnd.Next(i1, i2);
        }
    }

    //public class CustomChildrenSelector : IChildNodesSelector
    //{
    //    public IEnumerable SelectChildren(object item)
    //    {
    //        if (item is BaseClass) { return null; }
    //        else if (item is SubClass) { return (item as SubClass).Collection1; }
    //        else if (item is GeneralClass) { return (item as GeneralClass).Collection0; }
    //        return null;
    //    }
    //}

    public class BaseClass
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public BaseClass()
        {
            Name = RND.GetNewString(RND.GetNewInt(5,10));
            ID = RND.GetNewInt(-1000, 1000);
        }
    }

    public class SubClass : BaseClass
    {
        public ObservableCollection<BaseClass> Collection1 { get; set; } = new ObservableCollection<BaseClass>();
        public SubClass()
        {
            int cycles = RND.GetNewInt(5, 10);
            for (int i = 0; i < cycles; i++)
            {
                BaseClass insert_obj = new BaseClass();
                Collection1.Add(insert_obj);
            }
        }
    }

    public class GeneralClass : BaseClass
    {
        public ObservableCollection<SubClass> Collection0 { get; set; } = new ObservableCollection<SubClass>();
        public GeneralClass()
        {
            int cycles = RND.GetNewInt(5, 10);
            for (int i = 0; i < cycles; i++)
            {
                SubClass insert_obj = new SubClass();
                Collection0.Add(insert_obj);
            }
        }
    }
}
