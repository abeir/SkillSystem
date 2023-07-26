using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using SkillSystem.Data;
using SkillSystem.Loader;
using UnityEngine;

namespace SkillSystem
{
    public class SkillPool : MonoBehaviour, IEnumerable<Skill>
    {
        private readonly List<Skill> _skills = new();
        private ISkillLoader _loader;
        private bool _needReload;

        private static SkillPool _skillPool;

        [ShowInInspector, ReadOnly]
        private static SkillConfig _config;

        public static SkillPool Instance
        {
            get { return _skillPool ??= CreateInstance(); }
        }

        private static SkillPool CreateInstance()
        {
            var o = new GameObject("SkillPool");
            _skillPool = o.AddComponent<SkillPool>();
            
            DontDestroyOnLoad(o);

            // 加载技能配置并设置技能加载器
            _config = SkillConfig.Load();
            _skillPool.SetLoader(_config.loaderType);
            
            return _skillPool;
        }

        private SkillPool()
        {
        }
        
        private void SetLoader(SkillLoader loader)
        {
            _needReload = true;
            _loader = SkillAssembler.CreateLoader(loader.ToString());
        }

        public void Load()
        {
            if (!_needReload)
            {
                return;
            }
            if (_loader == null)
            {
                throw new InvalidOperationException("Not setup ISkillLoader");
            }
            _skills.Clear();
            var skillBases = _loader.Load();
            foreach (var skillBase in skillBases)
            {
                _skills.Add(new Skill(skillBase));
            }
        }

        [CanBeNull]
        public Skill Get(int index)
        {
            return _skills[index];
        }

        public void Clear()
        {
            _skills.Clear();
        }
        

        public IEnumerator<Skill> GetEnumerator()
        {
            return _skills.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}