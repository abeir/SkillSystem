using System.Collections.Generic;
using SkillSystem.Character;
using UnityEngine;


namespace SkillSystem.Detect
{
    public class SectorDetector : ISkillDetector
    {

        private const int DetectSize = 20;

        private readonly Collider[] _hitColliders = new Collider[DetectSize];
        private readonly GameObject[] _targets = new GameObject[DetectSize];

        private readonly List<SkillCharacter> _targetCharacters = new();

        private int FindByTag(Vector3 skillPos, SkillRuntime skill)
        {
            var total = 0;
            var count = Physics.OverlapSphereNonAlloc(skillPos, skill.Skill.Base.detectDistance, _hitColliders);
            for (var i = 0; i < count; i++)
            {
                foreach (var tag in skill.Skill.Base.detectTags)
                {
                    var hit = _hitColliders[i];
                    if (!hit.CompareTag(tag))
                    {
                        continue;
                    }

                    _targets[total] = hit.gameObject;
                    total++;
                }
            }

            return total;
        }


        public List<SkillCharacter> DetectTargets(SkillRuntime skill)
        {
            _targetCharacters.Clear();

            var position = skill.Controller.transform.position;

            var count = FindByTag(position, skill);
            for (var i = 0; i < count; i++)
            {
                var target = _targets[i];
                // 必须是有效的目标
                // 有效的目标：
                // 1. 包含 SkillCharacter 组件
                // 2. GameObject 为激活状态
                // 3. 技能对象所在位置满足检测距离
                if (!target.activeSelf || !target.TryGetComponent<SkillCharacter>(out var targetCharacter))
                {
                    continue;
                }

                if (DetectArea(position, target.transform.position, skill))
                {
                    _targetCharacters.Add(targetCharacter);
                }
            }

            return _targetCharacters;
        }
        
        private static bool DetectArea(Vector3 skillPos, Vector3 targetPos, SkillRuntime skill)
        {
            var angle = Vector3.Angle(skill.Controller.transform.forward, targetPos - skillPos);
            var sqrDistance = (targetPos - skillPos).sqrMagnitude;
            return skill.Skill.Base.detectAngle / 2 >= angle &&
                   sqrDistance <= Mathf.Sqrt(skill.Skill.Base.detectDistance);
        }
    }
}