// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FrameworkSafeDirectoryCatalog.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.Shared.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace IntenseLab.Shared
{
    /// <summary>
    ///     Represents class for collecting all exported types from assemblies marked by <see cref="IntenseLabAssemblyAttribute"/>.
    /// </summary>
    internal class FrameworkSafeDirectoryCatalog : ComposablePartCatalog
    {
        private readonly AggregateCatalog Catalog;

        /// <summary>
        ///     Create new instance of <see cref="FrameworkSafeDirectoryCatalog"/> with specified collection of assemblies.
        /// </summary>
        /// <param name="assemblies">
        ///     Collection of assemblies for searching exported types.
        /// </param>
        public FrameworkSafeDirectoryCatalog(IEnumerable<Assembly> assemblies)
        {
            var filteredLibraries =
                assemblies.Where(
                    assembly => assembly.GetCustomAttributes(typeof(IntenseLabAssemblyAttribute), false).Any()).ToList();

            Catalog = new AggregateCatalog();
            ProcessAssemblies(filteredLibraries);
        }

        private void ProcessAssemblies(IEnumerable<Assembly> assemblies)
        {
            Parallel.ForEach(
               assemblies,
               assembly =>
               {
                   try
                   {
                       var asmCat = new AssemblyCatalog(assembly);

                       //Force MEF to load the plugin and figure out if there are any exports
                       // good assemblies will not throw the RTLE exception and can be added to the catalog
                       if (asmCat.Parts.ToList().Count > 0)
                       {
                           Catalog.Catalogs.Add(asmCat);
                       }
                   }
                   catch (ReflectionTypeLoadException)
                   {
                   }
                   catch (BadImageFormatException)
                   {
                   }
               });
        }

        /// <summary>
        ///     <see cref="ComposablePartCatalog.Parts"/>
        /// </summary>
        public override IQueryable<ComposablePartDefinition> Parts => Catalog.Parts;
    }
}