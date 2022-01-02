using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Purchase
    {
        public long Id { get; set; }
        public long? CardId { get; set; }
        public decimal? PurchaseSum { get; set; }

        public PersonalCard PersonalCard { get; set; }
    }
}
