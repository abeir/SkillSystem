#pragma warning disable CS0414
using System;
using System.IO;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using SkillSystem.Data;
using UnityEditor;
using SerializationUtility = Sirenix.Serialization.SerializationUtility;

namespace SkillSystem.Editor
{
    public class SkillConfigMenu
    {
        [NonSerialized]
        private bool _done;
        [NonSerialized]
        private string _msg;
        
        [PropertySpace(SpaceBefore = 10, SpaceAfter = 10)]
        [BoxGroup("文件路径"), ReadOnly]
        public string JsonPath;

        [Title("技能配置")]
        [PropertySpace(SpaceBefore = 10, SpaceAfter = 20)]
        public SkillConfig Config;
        
        [PropertySpace(SpaceBefore = 10, SpaceAfter = 10)]
        [Button("生成技能配置", ButtonSizes.Large), GUIColor(0.4f, 0.8f, 1)]
        [InfoBox("$_msg", "_done")]
        private void GenerateButton()
        {
            if (File.Exists(JsonPath))
            {
                if (!EditorUtility.DisplayDialog("生成技能配置", "已存在文件，点击确定进行覆盖", "确定", "取消"))
                {
                    return;
                }
            }

            var json = SerializationUtility.SerializeValue(Config, DataFormat.JSON);
            File.WriteAllText(JsonPath, System.Text.Encoding.UTF8.GetString(json));
                
            _done = true;
            _msg = "已生成技能配置：" + JsonPath;
        }

        public SkillConfigMenu()
        {
            JsonPath = Path.GetFullPath("Assets/Resources/Skill/Configs/SkillConfig.json");

            if (!File.Exists(JsonPath))
            {
                return;
            }

            var json = File.ReadAllText(JsonPath);
            Config = SerializationUtility.DeserializeValue<SkillConfig>(System.Text.Encoding.UTF8.GetBytes(json),
                DataFormat.JSON);
        }
    }
}
#pragma warning restore CS0414
