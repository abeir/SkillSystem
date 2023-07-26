using System.Collections.Generic;
using SkillSystem.Data;

namespace SkillSystem.Loader
{
    public interface ISkillLoader
    {

        public SkillLoader LoaderType { get;}

        public List<SkillBase> Load();
    }
}