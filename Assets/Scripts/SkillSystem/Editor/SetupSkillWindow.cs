

using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace SkillSystem.Editor
{
    
    
    public class SetupSkillWindow : OdinMenuEditorWindow
    {

        [MenuItem("Tools/技能系统/配置技能")]
        public static void CreateSetupSkillWindow()
        {
            var win = GetWindow<SetupSkillWindow>();
            win.titleContent = new GUIContent("配置技能");
            win.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 600);
        }


        protected override OdinMenuTree BuildMenuTree()
        {

            var tree = new OdinMenuTree();
            tree.MenuItems.Add(new OdinMenuItem(tree, "配置", new SkillConfigMenu()));
            tree.MenuItems.Add(new OdinMenuItem(tree, "技能", new SkillListMenu()));

            return tree;
        }

        
    }
}
