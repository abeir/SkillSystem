using System;
using System.Collections.Generic;
using SkillSystem.Character;
using SkillSystem.Controller;
using SkillSystem.Data;
using SkillSystem.Detect;
using SkillSystem.Impact;
using Object = UnityEngine.Object;

namespace SkillSystem.Releaser
{
    public partial class SkillReleaser
    {
        
        
        private ISkillDetector CreateDetector(SkillBase skill)
        {
            return SkillAssembler.CreateDetector(skill.detectArea.ToString());
        }

        private List<ASkillImpact> CreateImpacts(SkillBase skill)
        {
            var impacts = new List<ASkillImpact>();
            foreach (var impact in skill.impacts)
            {
                impacts.Add(SkillAssembler.CreateImpact(impact.ToString()));
            }
            return impacts;
        }
        
        
        private SkillController CreateController(SkillBase skill, SkillCharacter owner)
        {
            var skillGo = Object.Instantiate(SkillAssembler.CreateFromPrefab(skill.prefab), owner.transform);
            skillGo.SetActive(false);
            return skillGo.GetComponent<SkillController>() ?? throw new InvalidOperationException($"Cannot GetComponent SkillController");
        }

        
    }
}