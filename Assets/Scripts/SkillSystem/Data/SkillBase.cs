using System;
using UnityEngine;

namespace SkillSystem.Data
{
    
    [Serializable]
    public class SkillBase
    {
        /// <summary>
        /// ID，必须保证唯一
        /// </summary>
        public int id;
        /// <summary>
        /// 名称
        /// </summary>
        public string name;
        /// <summary>
        /// 图片，用于显示在 GUI 上
        /// </summary>
        public string icon;
        
        /// <summary>
        /// 描述
        /// </summary>
        [TextArea(4, 10)]
        public string description;
        /// <summary>
        /// 冷却时间
        /// </summary>
        public int cooldown;
        /// <summary>
        /// 能量消耗 
        /// </summary>
        public int cost;
        /// <summary>
        /// 技能的持续时间
        /// </summary>
        public float duration;

        /// <summary>
        /// 检测目标的 tag
        /// </summary>
        public string[] detectTags;
        /// <summary>
        /// 检测距离，DetectArea 为 Line 表示直线长度，为 Sector 表示半径
        /// </summary>
        public float detectDistance;
        /// <summary>
        /// 检测角度，仅 DetectArea 为 Sector 有效
        /// </summary>
        [Range(0, 360)]
        public float detectAngle;
        /// <summary>
        /// 检测区域的类型
        /// </summary>
        public DetectArea detectArea;
        /// <summary>
        /// 检查持续时间，到达时间后停止检测
        /// </summary>
        public float detectDuration;
        
        /// <summary>
        /// 技能效果，这里为实现类的类名前半部分，例如：ReduceHealth 对应实现类为 ReduceHealthImpact
        /// </summary>
        public ImpactType[] impacts;
        /// <summary>
        /// 技能的预制件
        /// </summary>
        public string prefab;
    }
}