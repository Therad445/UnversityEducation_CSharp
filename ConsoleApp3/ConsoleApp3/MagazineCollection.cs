using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_3
{
    public delegate TKey KeySelector<TKey>(Magazine mg);
    
    public class MagazineCollection<TKey>
    {
        #region Fields

        private Dictionary<TKey, Magazine> collection = new Dictionary<TKey, Magazine>();
        private KeySelector<TKey> ks;
        
        #endregion

        #region Properties

        public double MaxAverageRate
        {
            get
            {
                /*if (collection.Count == 0) return 0;
                double[] rates = new double[0];
                foreach (Magazine magazine in collection.Values)
                {
                    rates.Append(magazine.GetAverageRate);
                }

                return Enumerable.Max(rates);*/

                if (collection.Count > 0) return collection.Values.Max(m => m.GetAverageRate);
                return 0;
            }
        }

        public IEnumerable<IGrouping<Frequency, KeyValuePair<TKey, Magazine>>> GroupCollection
        {
            get
            {
                return collection.GroupBy(mag => mag.Value.OutputFrequency);
            }
        }

        #endregion

        #region Constructors

        public MagazineCollection(KeySelector<TKey> _ks)
        {
            ks = _ks;
        }  // TODO: need to finish it 

        #endregion

        #region Methods

        public void AddMagazines(params Magazine[] magazines)
        {
            foreach (var magazine in magazines)
            {
                collection.Add(ks(magazine), magazine);
            }
        }

        public void AddDefaults()
        {
            var mg = new Magazine();
            collection.Add(ks(mg), mg);
        }

        public IEnumerable<KeyValuePair<TKey, Magazine>> FrequencyGroup(Frequency value)
        {
            return collection.Where(cElem => cElem.Value.OutputFrequency == value);
        }

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

        #endregion
    }
}