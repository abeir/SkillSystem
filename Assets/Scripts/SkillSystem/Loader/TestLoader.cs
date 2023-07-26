using System.Collections.Generic;
using SkillSystem.Data;

namespace SkillSystem.Loader
{
    public class TestLoader : ISkillLoader
    {
        public SkillLoader LoaderType => SkillLoader.Test;

        public List<SkillBase> Load()
        {
            var list = new List<SkillBase>
            {
                new()
                {
                    id = 1001,
                    name = "Test Skill",
                    description = "This is a test skill",
                    cooldown = 3,
                    cost = 50,
                    duration = 5,
                    detectTags = new []{"Enemy"},
                    detectDistance = 2,
                    detectAngle = 0,
                    detectArea = DetectArea.Line,
                    impacts = new [] { ImpactType.ReduceHealth },
                    prefab = "Cube"
                }
            };

            return list;
        }
    }
}