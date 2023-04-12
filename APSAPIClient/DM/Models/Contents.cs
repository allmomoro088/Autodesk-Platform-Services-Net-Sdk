using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

using Version = Autodesk.PlatformServices.DM.Version;

namespace Autodesk.PlatformServices.DM
{
    public class Contents : Tuple<List<Folder>, List<Item>, List<Version>>
    {
        public Contents() : base (new List<Folder>(), new List<Item>(), new List<Version>())
        {

        }
        public Contents(List<Folder> item1, List<Item> item2, List<Version> item3) : base(item1, item2, item3)
        {
        }
        public IEnumerable<Folder> Folders
        {
            get
            {
                return Item1;
            }
        }
        public IEnumerable<Item> Items
        {
            get 
            {
                return Item2;
            }
        }
        public IEnumerable<Version> Versions
        {
            get
            {
                return Item3;
            }
        }
    }
}
