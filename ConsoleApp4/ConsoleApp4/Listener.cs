using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CS_4
{
    public class Listener
    {
        private List<ListEntry> changes = new List<ListEntry>();

        public void NewEntryForCollection(object subject, EventArgs e)
        {
            var it = e as MagazinesChangedEventArgs<string>;
            changes.Add(new ListEntry(it.CollectionName, it.What, it.PropertyName, it.ChangedElemKey));
        }

        /*public void NewEntryForProperty(object subject, EventArgs e)
        {
            var it = e as PropertyChangedEventArgs;
            changes.Add(new ListEntry("None", Update.Property, it.PropertyName, ""));
        }*/

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (var change in changes)
            {
                str.Append(change + "\n");
            }

            return str.ToString();
        }
    }
}