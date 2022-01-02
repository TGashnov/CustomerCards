using System;
using System.Collections.Generic;

namespace Model
{
    public class PersonalCard
    {
        public long Id { get; set; }
        public float? Discount { get; set; }

        public UserProfile UserProfile { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}
