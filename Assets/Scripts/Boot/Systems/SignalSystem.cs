using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Boot.Systems
{
    static class SignalSystem
    {
        internal static void BindSignals()
        {
            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Static;

            HashSet<Type> signals = new HashSet<Type>();
            //try to simplify this, maybe move this method to core
            foreach (var type in GetAssemblies("Core").First().DefinedTypes)
                if (type.BaseType!.Name.StartsWith("AbstractSignal"))
                    signals.Add(type);
            //td add gamelogic here
            foreach (var assembly in GetAssemblies("Boot", "Core","GameLogic", "Presentation", "UI"))
            {
                foreach (var type in assembly.DefinedTypes)
                {
                    if (type.IsInterface)
                        continue;

                    var methods = type.GetMethods(bindingFlags);
                    foreach (var method in methods)
                    {
                        foreach (var signal in signals)
                        {
                            if (method.Name != "On" + signal.Name)
                                continue;

                            Type baseType = signal.BaseType!;
                            Type tDelegate = baseType.GetEvent("_onSignal", bindingFlags)!.EventHandlerType!;
                            FieldInfo field = baseType.GetField("_onSignal", bindingFlags)!;
                            try
                            {
                                Delegate methodDelegate = Delegate.CreateDelegate(tDelegate, method);
                                Delegate declaredDelegate = (Delegate)field.GetValue(null)!;

                                field.SetValue(null, Delegate.Combine(declaredDelegate, methodDelegate));
                            }
                            catch (Exception e)
                            {
                                Debug.LogError($"Error when trying to bind method {method.Name} in {type.Name} to {signal.Name}\nerror message:\n{e.Message}");
                            }

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
