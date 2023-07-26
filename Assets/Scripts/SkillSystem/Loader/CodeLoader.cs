
using System.Collections.Generic;
using Sirenix.Serialization;
using SkillSystem.Data;
using UnityEngine;

namespace SkillSystem.Loader
{
    public class CodeLoader : ISkillLoader
    {
        public SkillLoader LoaderType => SkillLoader.Code;
        
        public List<SkillBase> Load()
        {
            var jsonFile = Resources.Load<TextAsset>("Skill/Configs/Skills");
            var list = SerializationUtility.DeserializeValue<List<SkillBase>>(System.Text.Encoding.UTF8.GetBytes(jsonFile.text), DataFormat.JSON);
            Resources.UnloadAsset(jsonFile);
            return list;
        }
    }
}
