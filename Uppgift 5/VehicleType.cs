﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This enum is intended to be used to tag vehicles with their
 * type. This will enable searches by type in the garage. These
 * fields does not exist yet in the vehicle subclasses.
 */

namespace Uppgift_5
{
    internal enum VehicleType
    {
        car,
        motorcycle,
        bus,
        airplane,
        boat
    }
}
