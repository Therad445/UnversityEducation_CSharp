using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CS_5
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

        public void AddMagazine(Magazine m)
        {
            collection.Add(ks(m), m);
        }
        

        #endregion
    }
}