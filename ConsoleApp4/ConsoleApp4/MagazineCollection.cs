using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CS_4
{

    public delegate TKey KeySelector<TKey>(Magazine mg);
    public class MagazineCollection<TKey>
    {
        #region Fields

        private Dictionary<TKey, Magazine> collection = new Dictionary<TKey, Magazine>();
        private KeySelector<TKey> ks;

        #endregion

        #region Constructors 
        
        public MagazineCollection(KeySelector<TKey> _ks)
        {
            ks = _ks;
        } 

        #endregion

        #region Properties
        
        public string CollectionName { get; set; }

        #endregion

        #region Methods

        public override string ToString()
        {
            string str = $"This magazine contains {collection.Count} magazines: \n";
            foreach (var mag in collection.Values)
            {
                str += mag.ToString();
            }

            return str;
        }

        public virtual string ToShortString()
        {
            string str = $"This magazine contains {collection.Count} magazines: \n";
            foreach (var mag in collection.Values)
            {
                str += mag.ToShortstring();
            }

            return str;
        }

        public bool Replace(Magazine mold, Magazine mnew)
        {
            var k = collection.FirstOrDefault(m => m.Value == mold).Key;
            if (k == null) return false;
            collection[k] = mnew;
            MagazinePropertyChanged(Update.Replace, "None", k);
            mold.PropertyChanged -= HandleEvent;
            mnew.PropertyChanged += HandleEvent;
            return true;
        }

        private void HandleEvent(object subject, EventArgs e)
        {
            var it = (PropertyChangedEventArgs) e;
            var mg = (Magazine) subject;
            var key = ks(mg);
            MagazinePropertyChanged(Update.Property, it.PropertyName, key);
        }

        public void AddMagazine(Magazine m)
        {
            var key = ks(m);
            collection.Add(key, m);
            MagazinePropertyChanged(Update.Add, "None", key);
            m.PropertyChanged += HandleEvent;
        }
        

        #endregion

        #region Events

        public MagazinesChangedHandler<TKey> MagazineChanged;

        private void MagazinePropertyChanged(Update update, string name, TKey key)
        {
            MagazineChanged?.Invoke(this, new MagazinesChangedEventArgs<TKey>(CollectionName, update, name, key));
        }

        #endregion
    }
}