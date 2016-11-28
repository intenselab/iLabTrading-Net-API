namespace IntenseLab.Shared
{
    /// <summary>
    ///     Represents type of initialization and searching assemblies marked by <see cref="Attributes.IntenseLabAssemblyAttribute"/>
    /// </summary>
    public enum FrameworkInitializationType
    {
        /// <summary>
        ///     Initialization for desktop programs using executing assembly folder for searching assemblies marked by <see cref="Attributes.IntenseLabAssemblyAttribute"/>
        /// </summary>
        Desktop,

        /// <summary>
        ///     Initialization for mobile programs only specified collection of assemblies for searching assemblies marked by <see cref="Attributes.IntenseLabAssemblyAttribute"/>
        /// </summary>
        Mobile
    }
}
