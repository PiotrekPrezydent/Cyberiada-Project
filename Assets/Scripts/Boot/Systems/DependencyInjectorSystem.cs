using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Boot.Systems
{
    public static class DependencyInjectorSystem
    {
        internal static void BindConfigs()
        {
            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Static;
            foreach(var assembly in GetAssemblies("Boot", "Core","GameLogic", "Presentation", "UI"))
            {
                foreach (var type in assembly.DefinedTypes)
                {
                    foreach(var field in type.GetFields(bindingFlags))
                    {
                        if (!field.FieldType.Name.EndsWith("Config"))
                            continue;
                        Object[] configs = Resources.LoadAll("Configs");
                        foreach (var config in configs)
                        {
                            if (!config.GetType().Equals(field.FieldType))
                                continue;
                            field.SetValue(null, config);
                            break;
                        }
                    }
                }
            }
        }

        static IEnumerable<Assembly> GetAssemblies(params string[] assemblies)
        {
            for (int i = 0; i < assemblies.Length; i++)
                yield return Assembly.Load(assemblies[i]);
        }
    }
}
