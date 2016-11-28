// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntenseLabFrameworkInitializer.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using IntenseLab.NetworkCommunication.Serializers;
using IntenseLab.Shared.Attributes;
using IntenseLab.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntenseLab.NetworkCommunication.Helpers
{
    /// <summary>
    ///     Represents IntenseLab Framework initializer. It must be invoked only once at framework start.
    ///     This class collect and create instances of all availables serializers.
    ///     Serializers are finding among exported types of assemblies marked by <see cref="IntenseLabAssemblyAttribute"/>.
    ///     Also serializer class must be marked by <see cref="IntenseLabPacketSerializerAttribute"/>.
    /// </summary>
    public static class IntenseLabFrameworkInitializer
    {
        private static bool IsInitialized { get; set; }

        /// <summary>
        ///     Initialize instance of <see cref="IntenseLabFrameworkInitializer"/>.
        /// </summary>
        public static void Initialize()
        {
            if (IsInitialized)
                return;
            if (!AssemblyHelper.IsInitialized)
                throw new InvalidOperationException($"{nameof(AssemblyHelper)} is not initialized");

            var exportedSerializerTypes = AssemblyHelper.GetExportedTypesByAttribute(typeof(IntenseLabPacketSerializerAttribute));
            foreach (var serializerType in exportedSerializerTypes)
            {
                var serializer = AssemblyHelper.CreateInstanceByType<IPacketSerializer>(serializerType);
                Serializers.Add(serializerType.Name, serializer);
            }

            IsInitialized = true;
        }

        /// <summary>
        ///     Check if class is initialized before using.
        /// </summary>
        private static void CheckInitialization()
        {
            if (!IsInitialized)
                throw new InvalidOperationException($"{nameof(IntenseLabFrameworkInitializer)} is not initialized. Please call {nameof(Initialize)} method before using.");
        }

        /// <summary>
        ///     Names of packet serializers
        /// </summary>
        public static List<string> SerializerNameList
        {
            get
            {
                CheckInitialization();
                return Serializers.Keys.ToList();
            }
        } 
        private static Dictionary<string, IPacketSerializer> Serializers { get; } = new Dictionary<string, IPacketSerializer>();


        /// <summary>
        ///     Gets instance of <see cref="IPacketSerializer"/> by name of serializer's type.
        /// </summary>
        /// <param name="serializerName">
        ///     Name of serializer's type.
        /// </param>
        /// <returns>
        ///     Instance of <see cref="IPacketSerializer"/> with specified name.
        /// </returns>
        /// <exception cref="KeyNotFoundException">
        ///     Will be thrown in case of not existing instance of serializer with specified name.
        /// </exception>
        public static IPacketSerializer GetPacketSerializerByName(string serializerName)
        {
            CheckInitialization();
            return Serializers[serializerName];
        }
    }
}
