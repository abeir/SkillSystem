using System.Collections.Generic;
using SkillSystem.Character;
using UnityEngine;

namespace SkillSystem.Impact
{
    public class ReduceHealthImpact : ASkillImpact
    {
        public override void Impact(SkillRuntime skill, List<SkillCharacter> targets)
        {

            foreach (var target in targets)
            {
                ReduceHealth(skill, target);
            }
            skill.Controller.OnSkillImpactStart(skill, Name, targets);
            skill.Controller.OnSkillImpactEnd(skill, Name, targets);
        }

        private void ReduceHealth(SkillRuntime skill, SkillCharacter character)
        {
            // TODO 扣减生命
            Debug.Log(">>>> ReduceHealth -100");

            character.characterResource.ChangeCurrentHealth(-100);
        }
    }
}