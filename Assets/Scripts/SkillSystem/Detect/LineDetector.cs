using System.Collections.Generic;
using SkillSystem.Character;
using UnityEngine;

namespace SkillSystem.Detect
{
    public class LineDetector : ISkillDetector
    {

        private const int DetectSize = 20;

        private readonly RaycastHit[] _hits = new RaycastHit[DetectSize];
        private readonly GameObject[] _targets = new GameObject[DetectSize];

        private readonly List<SkillCharacter> _targetCharacters = new();

        private int FindByTag(Vector3 skillPos, Vector3 skillDirection, float detectDistance, string[] tags)
        {
            var total = 0;

            var count = Physics.RaycastNonAlloc(skillPos, skillDirection, _hits, detectDistance);
            for (var i = 0; i < count; i++)
            {
                foreach (var tag in tags)
                {
                    var hit = _hits[i];
                    if (!hit.collider.CompareTag(tag))
                    {
                        continue;
                    }
                    _targets[total] = hit.transform.gameObject;
                    total++;
                }
            }
            return total;
        }


        public List<SkillCharacter> DetectTargets(SkillRuntime skill)
        {
            _targetCharacters.Clear();

            var transform = skill.Controller.transform;
            var count = FindByTag(transform.position, transform.forward, skill.Skill.Base.detectDistance, skill.Skill.Base.detectTags);
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

                _targetCharacters.Add(targetCharacter);
            }

            return _targetCharacters;
        }
    }
}