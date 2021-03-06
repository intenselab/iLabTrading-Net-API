﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntenseLabPacketCompressorAttribute.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace IntenseLab.Shared.Attributes
{
    /// <summary>
    ///     IS NOT USED NOW.
    ///     
    ///     Mark classes which can compress Intenselab packets before sending via network.
    ///     Only when compressor is marked by this attribute, than framework can find it and make accessible for using.     
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class IntenseLabPacketCompressorAttribute : Attribute
    {
    }
}