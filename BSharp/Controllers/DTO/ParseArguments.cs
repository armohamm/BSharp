﻿using BSharp.Controllers.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSharp.Controllers.DTO
{
    public class ParseArguments
    {
        [ChoiceList(new object[] { "Insert", "Update", "Merge" })]
        public string Mode { get; set; } = "Insert"; // Default
    }
}
