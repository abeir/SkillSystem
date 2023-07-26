using System.Collections.Generic;
using SkillSystem.Character;

namespace SkillSystem.Impact
{
    public abstract class ASkillImpact
    {
        public float BaseValue;
        public float Percentage;

        public string Name { get; set; }
        
        public abstract void Impact(SkillRuntime skill, List<SkillCharacter> targets);
    }
}