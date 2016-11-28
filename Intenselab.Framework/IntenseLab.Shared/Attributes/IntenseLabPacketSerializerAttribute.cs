// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntenseLabPacketSerializerAttribute.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace IntenseLab.Shared.Attributes
{
    /// <summary>
    ///     Mark classes which can serialize Intenselab packets before sending via network.
    ///     Only when serializer is marked by this attribute, than framework can find it and make accessible for using.     
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IntenseLabPacketSerializerAttribute : Attribute
    {
    }
}