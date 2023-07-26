using System;
using System.Collections.Generic;
using SkillSystem.Detect;
using SkillSystem.Impact;
using SkillSystem.Loader;
using UnityEngine;


namespace SkillSystem
{
    
    /// <summary>
    /// 创建技能预制件时，查找的目录为 Assets/Resources/Prefabs/Prefab
    /// </summary>
    public static class SkillAssembler
    {
        private static readonly Dictionary<string, ISkillDetector> DetectorCache = new();
        private static readonly Dictionary<string, GameObject> PrefabCache = new();

        public static ISkillLoader CreateLoader(string name)
        {
            var typeName = $"SkillSystem.Loader.{name}Loader";
            var type = Type.GetType(typeName);
            return Activator.CreateInstance(type ?? throw new InvalidOperationException($"Cannot instance ISkillLoader: {typeName}")) as ISkillLoader;
        }

        public static ASkillImpact CreateImpact(string name)
        {
            var typeName = $"SkillSystem.Impact.{name}Impact";
            var type = Type.GetType(typeName);
            var instance = Activator.CreateInstance(type ?? throw new InvalidOperationException($"Cannot instance ASkillImpact: {typeName}")) as ASkillImpact;
            if (instance != null)
            {
                instance.Name = name;
            }
            return instance;
        }

        public static ISkillDetector CreateDetector(string name)
        {
            if (DetectorCache.TryGetValue(name, out var detector))
            {
                return detector;
            }
            var typeName = $"SkillSystem.Detect.{name}Detector";
            var type = Type.GetType(typeName);
            detector = Activator.CreateInstance(type ?? throw new InvalidOperationException($"Cannot instance ISkillDetector: {typeName}")) as ISkillDetector;
            DetectorCache[name] = detector;
            return detector;
        }

        public static GameObject CreateFromPrefab(string name)
        {
            if (PrefabCache.TryGetValue(name, out var go))
            {
                return go;
            }
            var prefabName = $"Skill/Prefabs/{name}";
            go = Resources.Load<GameObject>(prefabName);
            PrefabCache[name] = go;
            return go;
        }

    }
}