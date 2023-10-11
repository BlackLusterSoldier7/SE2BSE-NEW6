﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class NoDiscount : IDiscountStrategy
    {


        public double ApplyDiscount(double originalPrice)
        {
            return originalPrice;
        }

    }
}
