// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BigNumbersFormatHelper.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.ReflectionModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace IntenseLab.Shared.Utils
{
    /// <summary>
    ///     Class represents some helper functionality for operation with assemblies and their types.
    /// </summary>
    public static class AssemblyHelper
    {
        /// <summary>
        ///     Property which represents catalog of loaded exported types from assemblies, 
        ///     marked by attribute <see cref="Attributes.IntenseLabPacketAttribute"/>
        /// </summary>
        private static FrameworkSafeDirectoryCatalog Catalog { get; set; }
        public static bool IsInitialized { get; private set; }

        /// <summary>
        ///     Initialize instance of <see cref="AssemblyHelper"/> and load all exported types 
        ///     from assemblies marked by <see cref="Attributes.IntenseLabPacketAttribute"/>.      
        /// </summary>
        /// <param name="initializationType">
        ///     Type of initialization.
        /// </param>
        /// <param name="assemblies">
        ///     Collection of assemblies where to search types.
        /// </param>
        public static void Initialize(FrameworkInitializationType initializationType, IEnumerable<Assembly> assemblies)
        {
            if(IsInitialized)
                return;

            switch (initializationType)
            {
                case FrameworkInitializationType.Desktop:
                    InitializeDesktopSession(assemblies);
                    break;
                case FrameworkInitializationType.Mobile:
                    InializeMobileSession(assemblies);
                    break;
            }

            IsInitialized = true;
        }

        /// <summary>
        ///     Initialize session for desktop program using folder of executing assembly to search assemblies with exported types.
        /// </summary>
        /// <param name="additionalAssemblies">
        ///     Some additionals assemblies that are not in specified folder.
        /// </param>
        private static void InitializeDesktopSession(IEnumerable<Assembly> additionalAssemblies)
        {
            // this approach is used instead of AppDomain.CurrentDomain.BaseDirectory
            // because it doesn't work with Xamarin.
            var executingAssemblyLocation = Assembly.GetExecutingAssembly().Location;
            var directoryName = Path.GetDirectoryName(executingAssemblyLocation);

            if (string.IsNullOrEmpty(directoryName))
                throw new InvalidOperationException("Null or empty executing assembly location for desktop session");

            var files = Directory.EnumerateFiles(directoryName, "*.dll", SearchOption.AllDirectories);
            var assemblies = new List<Assembly>();

            foreach (var file in files)
            {
                try
                {
                    var assembly = Assembly.LoadFile(file);
                    assemblies.Add(assembly);
                }
                catch (BadImageFormatException)
                {

                }
            }

            if(additionalAssemblies != null)
                assemblies.AddRange(additionalAssemblies);

            Catalog = new FrameworkSafeDirectoryCatalog(assemblies);
        }

        /// <summary>
        ///     Initialize session for desktop program using assemblies of IntenseLab NuGet package and maybe some additional from user.
        /// </summary>
        /// <param name="assemblies">
        ///     Assemblies that may contain exported types.
        /// </param>
        private static void InializeMobileSession(IEnumerable<Assembly> assemblies)
        {
            if(assemblies == null)
                throw new InvalidOperationException("Initializing mobile session with no message's assemblies");

            Catalog = new FrameworkSafeDirectoryCatalog(assemblies);
        }

        /// <summary>
        ///     Check if class is initialized before using.
        /// </summary>
        private static void CheckInitialization()
        {
            if(!IsInitialized)
                throw new InvalidOperationException($"{nameof(AssemblyHelper)} is not initialized. Please call {nameof(Initialize)} method before using.");
        }

        /// <summary>
        ///     Search all exported types marked by attribute of type <see cref="attributeType"/> 
        ///     in assemblies marked by <see cref="Attributes.IntenseLabAssemblyAttribute"/>.
        /// </summary>
        /// <param name="attributeType">
        ///     Type of attribute which is used as template for searching.
        /// </param>
        /// <returns>
        ///     Collection of found types.
        /// </returns>
        public static IEnumerable<Type> GetExportedTypesByAttribute(Type attributeType)
        {
            CheckInitialization();
            return
                Catalog.Parts.Select(t => ReflectionModelServices.GetPartType(t).Value)
                    .Where(t => t.GetCustomAttributes(attributeType, false).Any())
                    .ToList();
        }

        /// <summary>
        ///     Search all types in specified assembly.
        /// </summary>
        /// <param name="attributeType">
        ///     Type of attribute which is used as template for searching.
        /// </param>
        /// <param name="assembly">
        ///     Assembly where to search types.
        /// </param>
        /// <returns>
        ///     Collection of found types.
        /// </returns>
        private static IEnumerable<Type> GetAllTypesByAttribute(Type attributeType, Assembly assembly)
        {
            return assembly?.GetTypes().Where(t => t.GetCustomAttributes(attributeType, false).Any());
        }

        /// <summary>
        ///     Search exported type in all assemblies marked by <see cref="Attributes.IntenseLabAssemblyAttribute"/>.
        ///     If type with specified name was found - instance will be created via <see cref="Activator"/>
        ///     using default constructor.
        ///     If type with specified name was not found - <see cref="ArgumentException"/> will be thrown.
        /// </summary>
        /// <typeparam name="TReturnType">
        ///     Type to which created object try to be casted. If casting fail then exception will be thrown.
        /// </typeparam>
        /// <typeparam name="TAttribute">
        ///     Type of attribute by which specified class is marked.
        /// </typeparam>
        /// <param name="typeName">
        ///     Name of type which must be created.
        /// </param>
        /// <returns>
        ///     Instance of type with specified name casted to <see cref="TReturnType"/> type.
        /// </returns>
        public static TReturnType CreateInstanceByAttribute<TReturnType, TAttribute>(string typeName)
        {
            CheckInitialization();
            var typesList = GetExportedTypesByAttribute(typeof(TAttribute));

            return GetInstanceByType<TReturnType>(typesList, typeName);
        }

        /// <summary>
        ///     Search type in specified assembly.
        ///     If type with specified name was found - instance will be created via <see cref="Activator"/>
        ///     using default constructor.
        ///     If type with specified name was not found - <see cref="ArgumentException"/> will be thrown.
        /// </summary>
        /// <typeparam name="TReturnType">
        ///     Type to which created object try to be casted. If casting fail then exception will be thrown.
        /// </typeparam>
        /// <typeparam name="TAttribute">
        ///     Type of attribute by which specified class is marked.
        /// </typeparam>
        /// <param name="typeName">
        ///     Name of type which must be created.
        /// </param>
        /// <param name="assembly">
        ///     Assembly where to search specified type.
        /// </param>
        /// <returns>
        ///     Instance of type with specified name casted to <see cref="TReturnType"/> type.
        /// </returns>
        public static TReturnType CreateInstanceByAttribute<TReturnType, TAttribute>(string typeName, Assembly assembly)
        {
            CheckInitialization();
            var typesList = GetAllTypesByAttribute(typeof(TAttribute), assembly);

            return GetInstanceByType<TReturnType>(typesList, typeName);
        }

        /// <summary>
        ///     Create instance of specified type, using <see cref="Activator"/>. 
        ///     If creation is successful then instance will be casted to <see cref="TReturnType"/>
        /// </summary>
        /// <typeparam name="TReturnType">
        ///     Type to which created object try to be casted. If casting fail then exception will be thrown.
        /// </typeparam>
        /// <param name="type">
        ///     Type which must be created.
        /// </param>
        public static TReturnType CreateInstanceByType<TReturnType>(Type type)
        {
            CheckInitialization();
            return (TReturnType)Activator.CreateInstance(type);
        }

        private static TReturnType GetInstanceByType<TReturnType>(IEnumerable<Type> typesList, string typeName)
        {
            var type = typesList.FirstOrDefault(typeItem => string.Equals(typeItem.Name, typeName));

            if (type != null)
            {
                return (TReturnType)Activator.CreateInstance(type);
            }

            throw new ArgumentException("Invalid type name");
        }
    }
}