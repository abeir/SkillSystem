using SkillSystem.Controller;

namespace SkillSystem
{
    public class SkillRuntime
    {
        public readonly Skill Skill;
        public SkillController Controller;
        public float ReleaseTimeAt;

        public SkillStatus Status
        {
            get => _status;
            set => ChangeStatus(value);
        }

        private SkillStatus _status = SkillStatus.Default;
        private int _statusEndCount;
        

        public SkillRuntime(Skill skill)
        {
            Skill = skill;
        }


        private void ChangeStatus(SkillStatus status)
        {
            if (status == SkillStatus.End && _status != SkillStatus.End)
            {
                _statusEndCount++;
                if (_statusEndCount >= Skill.Impacts.Count)
                {
                    _status = SkillStatus.End;
                    _statusEndCount = 0;
                }
                return;
            }
            _status = status;
        }
        
    }
}