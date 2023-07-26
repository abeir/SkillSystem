using System.Collections;
using System.Collections.Generic;
using SkillSystem.Character;
using UnityEngine;

namespace SkillSystem.Releaser
{
    public partial class SkillReleaser
    {
        public string Error { get; private set; }


        private readonly Dictionary<int, float> _lastSkillReleaseTime = new();

        
        private bool Prepare(Skill skill, SkillCharacter owner, out SkillRuntime rt)
        {
            rt = null;
            if (IsCoolingDown(skill))
            {
                Error = "Skill cooling down";
                return false;
            }
            if (skill.Base.cost > owner.characterResource.currentEnergy)
            {
                Error = "Not enough energy";
                return false;
            }

            if (!_lastSkillReleaseTime.ContainsKey(skill.Base.id))
            {
                skill.Impacts = CreateImpacts(skill.Base);
                skill.Detector = CreateDetector(skill.Base);
                skill.Owner = owner;
            }
            
            var now = Time.time;
            _lastSkillReleaseTime[skill.Base.id] = now;

            rt = new SkillRuntime(skill)
            {
                Controller = CreateController(skill.Base, owner),
                ReleaseTimeAt = now,
                Status = SkillStatus.Release
            };
            return true;
        }

        public bool Release(Skill skill, SkillCharacter owner)
        {
            if (!Prepare(skill, owner, out var skillRuntime))
            {
                return false;
            }
            owner.characterResource.ChangeCurrentEnergy(-skill.Base.cost);

            owner.StartCoroutine(ReleaseCoroutine(skillRuntime));
            return true;
        }


        private bool DetectTargets(SkillRuntime skill, out List<SkillCharacter> targets)
        {
            var list = skill.Skill.Detector.DetectTargets(skill);
            if (list == null || list.Count == 0)
            {
                targets = default;
                return false;
            }
            targets = list;
            return true;
        }

        private void ImpactTargets(SkillRuntime skill, List<SkillCharacter> targets)
        {
            skill.Status = SkillStatus.Impact;
            
            foreach (var impact in skill.Skill.Impacts)
            {
                impact.Impact(skill, targets);
            }
        }


        private IEnumerator ReleaseCoroutine(SkillRuntime skill)
        {
            skill.Status = SkillStatus.Detect;
            skill.Controller.gameObject.SetActive(true);
            
            skill.Controller.OnDetectStart(skill);
            
            List<SkillCharacter> targets;
            float time = 0;
            var detectDuration = skill.Skill.Base.detectDuration;
            do
            {
                yield return new WaitForFixedUpdate();
                time += Time.fixedDeltaTime;
            } while (!DetectTargets(skill, out targets) && time <= detectDuration);
            // 达到检测时间后，回调检测过期方法
            if (time > detectDuration)
            {
                skill.Controller.OnDetectExpired();
            }
            if (targets?.Count > 0)
            {
                ImpactTargets(skill, targets);
            }
        }


        private bool IsCoolingDown(Skill skill)
        {
            if(!_lastSkillReleaseTime.TryGetValue(skill.Base.id, out var lastReleaseTime))
            {
                return false;
            }
            return skill.Base.cooldown > (Time.time - lastReleaseTime);
        }
    }
}