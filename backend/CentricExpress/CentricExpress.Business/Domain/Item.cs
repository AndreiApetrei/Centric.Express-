﻿using System;

namespace CentricExpress.Business.Domain
{
    public class Item : Aggregate
    {
        public string Description { get; set; }
        public Money Price { get; set; }
        public byte[] Picture { get; set; }
    }
}
