using System;
using System.Collections.Generic;
using SkillSystem.Character;
using SkillSystem.Controller;
using SkillSystem.Data;
using SkillSystem.Detect;
using SkillSystem.Impact;
using UnityEngine;

namespace SkillSystem
{
    public class Skill
    {
        public readonly SkillBase Base;
        public List<ASkillImpact> Impacts;
        public ISkillDetector Detector;
        public SkillCharacter Owner;


        public Skill()
        {
        }

        public Skill(SkillBase skillBase)
        {
            Base = skillBase;
        }
    }
}