﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Batchery.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Batchery.Properties.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///                                 Apache License
        ///                           Version 2.0, January 2004
        ///                        http://www.apache.org/licenses/
        ///
        ///   TERMS AND CONDITIONS FOR USE, REPRODUCTION, AND DISTRIBUTION
        ///
        ///   1. Definitions.
        ///
        ///      &quot;License&quot; shall mean the terms and conditions for use, reproduction,
        ///      and distribution as defined by Sections 1 through 9 of this document.
        ///
        ///      &quot;Licensor&quot; shall mean the copyright owner or entity authorized by
        ///      the copyright owner that  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Font_License {
            get {
                return ResourceManager.GetString("Font_License", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Roboto Mono Variable Font
        ///=========================
        ///
        ///This download contains Roboto Mono as both variable fonts and static fonts.
        ///
        ///Roboto Mono is a variable font with this axis:
        ///  wght
        ///
        ///This means all the styles are contained in these files:
        ///  RobotoMono-VariableFont_wght.ttf
        ///  RobotoMono-Italic-VariableFont_wght.ttf
        ///
        ///If your app fully supports variable fonts, you can now pick intermediate styles
        ///that aren’t available as static fonts. Not all apps support variable fonts, and
        ///in those cases you can use the st [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Font_Readme {
            get {
                return ResourceManager.GetString("Font_Readme", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon muffin {
            get {
                object obj = ResourceManager.GetObject("muffin", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Batchery written very quickly by Bryan Turkelson
        ///
        ///Icon by http://www.icons101.com/icon/id_28481/setid_825/Breakfast_by_Andrea_Austoni/muffin
        ///Do not click on the author website link listed on that page as it took me to an adult website for some reason.
        ///All I wanted to do was provide proper attribution. Sigh.
        ///.
        /// </summary>
        internal static string Readme {
            get {
                return ResourceManager.GetString("Readme", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] RobotoMono_Regular {
            get {
                object obj = ResourceManager.GetObject("RobotoMono_Regular", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] WelcomeMessage {
            get {
                object obj = ResourceManager.GetObject("WelcomeMessage", resourceCulture);
                return ((byte[])(obj));
            }
        }
    }
}
