using System.Collections.Generic;
using JetBrains.Annotations;
using SkillSystem.Character;
using UnityEngine;

namespace SkillSystem.Detect
{
    public interface ISkillDetector
    {
        [CanBeNull] public List<SkillCharacter> DetectTargets(SkillRuntime skill);
    }
}