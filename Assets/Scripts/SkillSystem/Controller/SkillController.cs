using System.Collections.Generic;
using SkillSystem.Character;
using UnityEngine;

namespace SkillSystem.Controller
{
    public class SkillController : MonoBehaviour
    {
        
        public virtual void OnSkillImpactStart(SkillRuntime skill, string impactName, List<SkillCharacter> targets)
        {
        }

        public virtual void OnSkillImpactEnd(SkillRuntime skill, string impactName, List<SkillCharacter> targets)
        {
        }

        public virtual void OnDetectStart(SkillRuntime skill)
        {
        }

        public virtual void OnDetectExpired()
        {
        }
    }
}