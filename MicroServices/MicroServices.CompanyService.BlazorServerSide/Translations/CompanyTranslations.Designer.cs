﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MicroServices.CompanyService.BlazorServerSide.Translations {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class CompanyTranslations {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CompanyTranslations() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MicroServices.CompanyService.BlazorServerSide.Translations.CompanyTranslations", typeof(CompanyTranslations).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Building.
        /// </summary>
        public static string Building {
            get {
                return ResourceManager.GetString("Building", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Name.
        /// </summary>
        public static string CompanyName {
            get {
                return ResourceManager.GetString("CompanyName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Manage Companies.
        /// </summary>
        public static string CompanyOverview {
            get {
                return ResourceManager.GetString("CompanyOverview", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Floor.
        /// </summary>
        public static string Floor {
            get {
                return ResourceManager.GetString("Floor", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Phone.
        /// </summary>
        public static string PhoneNumber {
            get {
                return ResourceManager.GetString("PhoneNumber", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to VAT Number.
        /// </summary>
        public static string VatNumber {
            get {
                return ResourceManager.GetString("VatNumber", resourceCulture);
            }
        }
    }
}
