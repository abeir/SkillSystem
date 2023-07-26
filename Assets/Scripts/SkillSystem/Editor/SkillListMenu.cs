#pragma warning disable CS0414
using System;
using System.Collections.Generic;
using System.IO;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using SkillSystem.Data;
using UnityEditor;
using SerializationUtility = Sirenix.Serialization.SerializationUtility;

namespace SkillSystem.Editor
{
    public class SkillListMenu
    {
        [PropertySpace(SpaceBefore = 10, SpaceAfter = 10)]
        [BoxGroup("文件路径"), ReadOnly]
        public string JsonPath;
            
        [Title("技能列表")]
        [PropertySpace(SpaceBefore = 10, SpaceAfter = 20)]
        public List<SkillBase> Skills;
            
        [NonSerialized]
        private bool _done;
        [NonSerialized]
        private string _msg;
            
        [PropertySpace(SpaceBefore = 10, SpaceAfter = 10)]
        [Button("生成技能数据", ButtonSizes.Large), GUIColor(0.4f, 0.8f, 1)]
        [InfoBox("$_msg", "_done")]
        private void GenerateButton()
        {
            if (File.Exists(JsonPath))
            {
                if (!EditorUtility.DisplayDialog("生成技能数据", "已存在文件，点击确定进行覆盖", "确定", "取消"))
                {
                    return;
                }
            }

            var json = SerializationUtility.SerializeValue(Skills, DataFormat.JSON);
            File.WriteAllText(JsonPath, System.Text.Encoding.UTF8.GetString(json));
                
            _done = true;
            _msg = "已生成技能数据：" + JsonPath;
        }
            
        public SkillListMenu()
        {
            JsonPath = Path.GetFullPath("Assets/Resources/Skill/Configs/Skills.json");

            if (!File.Exists(JsonPath))
            {
                return;
            }

            var json = File.ReadAllText(JsonPath);
            Skills = SerializationUtility.DeserializeValue<List<SkillBase>>(System.Text.Encoding.UTF8.GetBytes(json),
                DataFormat.JSON);
        }
    }
}
#pragma warning restore CS0414
