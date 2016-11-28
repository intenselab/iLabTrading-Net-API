// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntenseLabPacketAttribute.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace IntenseLab.Shared.Attributes
{
    /// <summary>
    ///     Mark classes which can be sent via network using Intenselab framework.
    ///     Framework can send class only if it is marked by current attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IntenseLabPacketAttribute : Attribute
    {
    }
}