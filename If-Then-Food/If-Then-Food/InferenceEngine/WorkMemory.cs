﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRES_console
{
    class WorkMemory: List<Fact>
    {
        public WorkMemory(List<Fact> facts)
        {
            foreach (var fact in facts)
                Add(fact);
        }
    }
}
