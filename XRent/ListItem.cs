using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRent
{
    public class ListItem
    {

            public string Text { get; set; }
            public int Value { get; set; }

            public ListItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString() => Text;
        }
  
}
