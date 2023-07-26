using System.Collections.Generic;
using JetBrains.Annotations;
using Sirenix.OdinInspector;

namespace SkillSystem
{
    public class SkillManager
    {
        [ShowInInspector]
        public int Current { get; private set; }
        
        [ShowInInspector]
        private Dictionary<int, Skill> _skills = new();


        public SkillManager()
        {
            SkillPool.Instance.Load();
            foreach (var skill in SkillPool.Instance)
            {
                _skills[skill.Base.id] = skill;
            }
        }
        

        [CanBeNull]
        public Skill Select(int id)
        {
            var skill = _skills[id];
            if (skill != null)
            {
                Current = skill.Base.id;
            }
            return skill;
        }


        public void Add(Skill skill)
        {
            _skills[skill.Base.id] = skill;
        }

        public void AddRange(IEnumerable<Skill> skills)
        {
            foreach (var skill in skills)
            {
                _skills[skill.Base.id] = skill;
            }
        }

        public void Remove(int id)
        {
            _skills.Remove(id);
        }

        public void Change(int id, Skill newSkill)
        {
            _skills[id] = newSkill;
        }

        [CanBeNull]
        public Skill CurrentSkill()
        {
            return _skills[Current];
        }
    }
}