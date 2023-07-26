using Sirenix.OdinInspector;
using SkillSystem.Releaser;
using UnityEngine;

namespace SkillSystem.Character
{
    public class SkillCharacter : MonoBehaviour
    {
        [ShowInInspector, Required] 
        public CharacterResource characterResource;

        [ShowInInspector, ReadOnly] 
        public SkillManager SkillManager;

        #region 内部变量

        private SkillReleaser _skillReleaser;

        #endregion
        
        
        protected virtual void Awake()
        {
            SkillManager = new SkillManager();
            _skillReleaser = new SkillReleaser();
            
        }


        protected void ReleaseSkill()
        {
            // TODO 使用测试的技能
            var skill = SkillManager.CurrentSkill();
            if (!_skillReleaser.Release(skill, this))
            {
                Debug.Log($"Release skill failed: {_skillReleaser.Error}");
            }
        }

    }
}