using System;
using Sirenix.Serialization;
using UnityEngine;

namespace SkillSystem.Data
{
    
    [Serializable]
    public class SkillConfig
    {

        public SkillLoader loaderType = SkillLoader.Code;



        private static SkillConfig _instance;

        public static SkillConfig Load()
        {
            if (_instance == null)
            {
                var json = Resources.Load<TextAsset>("Skill/Configs/SkillConfig");
                _instance = SerializationUtility.DeserializeValue<SkillConfig>(System.Text.Encoding.UTF8.GetBytes(json.text),
                    DataFormat.JSON);
                Resources.UnloadAsset(json);
            }
            return _instance;
        }
    }
}