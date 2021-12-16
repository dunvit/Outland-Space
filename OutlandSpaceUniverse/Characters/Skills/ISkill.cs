using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Universe.Characters.Skills
{
    public interface ISkill
    {
        public string Label { get; set; }

        public double Value { get; set; }
    }
}
