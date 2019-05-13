using System;
using System.Collections.Generic;
using System.Linq;

namespace Editting.Plugins
{
    public static class PluginsExt 
    {
        public static IList<IEditorPlugin> AddFromAppDomain(this IList<IEditorPlugin> plugins)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var pluginInterface = typeof(IEditorPlugin);

            var pluginTypes = assemblies
                .Where((assembly, i) => !assembly.GetName().Name.StartsWith("UnityEngine"))
                .Where((assembly, i) => !assembly.GetName().Name.StartsWith("UnityEditor"))
                .Where((assembly, i) => !assembly.GetName().Name.StartsWith("Unity."))
                .Where((assembly, i) => !assembly.GetName().Name.StartsWith("System"))
                .Where((assembly, i) => !assembly.IsDynamic)
                .SelectMany(a => a.GetTypes())
                .Where(t => !t.IsAbstract)
                .Where(t => pluginInterface.IsAssignableFrom(t))
                .Where(t =>
                {
                    var ctors = t.GetConstructors();
                    return ctors.Length == 1 && ctors[0].GetParameters().Length == 0;
                })
                .ToList();

            foreach (var pluginType in pluginTypes)
            {
                plugins.Add((IEditorPlugin) Activator.CreateInstance(pluginType));
            }

            return plugins;
        }
    }
}
