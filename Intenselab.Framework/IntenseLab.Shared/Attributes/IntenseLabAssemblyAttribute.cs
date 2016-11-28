// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntenseLabAssemblyAttribute.cs" company="IntenseLab">
//   Unauthorized copying of this file, via any medium is strictly prohibited
//   Proprietary and confidential
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace IntenseLab.Shared.Attributes
{
    /// <summary>
    ///     Mark assembly, which may constains any Intenselab packet for sending via network.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class IntenseLabAssemblyAttribute : Attribute
    {
    }
}
