﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Domain.Entities
{
    public abstract class BaseTimestampEntity: BaseEntity
    {
        public DateTime CreatedAt { get; set; }
    }
}
