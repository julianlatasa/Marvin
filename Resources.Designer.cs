﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Marvin.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Marvin.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to SELECT pend.DesRegion &apos;Region&apos;
        ///	, pend.NomDivisionAdminPrimaria &apos;Partido&apos;
        ///	, TRIM(pend.NumIncidente) &apos;Nro.Incidente&apos;
        ///	, ISNULL(CONVERT(VARCHAR,CONVERT(DATETIME,CONVERT(FLOAT,DATEDIFF(SECOND, pend.InstanteRecepcion, CURRENT_TIMESTAMP))/86400),108),&apos;&apos;) &apos;Demora Total&apos;
        ///	, ISNULL((SELECT TOP 1 DesClasifIncidente FROM ClasifsIncidente INNER JOIN IncidClasifIncidClaseRecurso ON IncidClasifIncidClaseRecurso.PunClasifIncidenteAutomatico = ClasifsIncidente.PunClasifIncidente WHERE IncidClasifIncidClaseRecurso.Pun [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string IncidentesContratadosDemorados {
            get {
                return ResourceManager.GetString("IncidentesContratadosDemorados", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT TOP (1000) 
        ///	                                       CONVERT(CHAR(10),incid.NumIncidente)  &apos;Numero Incid.&apos;
        ///	                                      , incidpac.NomPaciente &apos;Afiliado&apos;
        ///                                          /*, CONVERT(CHAR(11),llam.Instante,108) &apos;Instante Llamado&apos;*/
        ///                                          , ISNULL(instantecambioclasif.instante,llam.Instante) &apos;Instante Clasif&apos;
        ///	                                      , ISNULL(estados.DesEstado, &apos;En Despacho&apos;) &apos;Ultimo Evento&apos;
        ///      [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string queryCoVid19_old2 {
            get {
                return ResourceManager.GetString("queryCoVid19_old2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 	CONVERT(CHAR(10),incid.NumIncidente)  &apos;Numero Incid.&apos;,
        ///		incidpac.NomPaciente &apos;Afiliado&apos;,
        ///		ISNULL(instantecambioclasif.instante,llam.Instante) &apos;Instante Clasif&apos;,
        ///		ISNULL(estados.DesEstado, &apos;En Despacho&apos;) &apos;Ultimo Evento&apos;,
        ///		CONVERT(CHAR(11),ISNULL(asigincid.Instante,llam.Instante),108) &apos;Instante Evento&apos;,
        ///		ISNULL(instantedesp.Instante,llam.Instante) &apos;Instante Recepcion&apos;,
        ///		DATEDIFF(mi, ISNULL(instantedesp.Instante,llam.Instante) , CURRENT_TIMESTAMP) &apos;Tiempo Transc.&apos;,
        ///		clasif.CodClasifIncide [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string queryCoVid19old {
            get {
                return ResourceManager.GetString("queryCoVid19old", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT 
        ///	CONVERT(CHAR(10),incidpend.NumIncidente)  &apos;Numero Incid.&apos;
        ///	, incidpend.NomPaciente &apos;Afiliado&apos;
        ///    , CONVERT(CHAR(11),incidpend.InstanteRecepcion,108) &apos;H.Recibido&apos;
        ///	, DATEDIFF(mi, incidpend.InstanteRecepcion, CURRENT_TIMESTAMP) &apos;Tiempo Transc.&apos;
        ///	,  ISNULL(CONVERT(CHAR(11),incidcronoevaluado.Instante,108), &apos;No&apos;) &apos;Evaluado&apos;
        ///	FROM IncidentesPendientes incidpend
        ///		LEFT JOIN 
        ///		(SELECT PunIncidente, MAX(InstanteAlta) Instante
        ///			FROM [RyD].[dbo].[IncidenteObservacionesCronologicas]
        ///			WHERE Pun [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string queryServicios {
            get {
                return ResourceManager.GetString("queryServicios", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT TOP (500) 
        ///	                                       CONVERT(CHAR(10),incid.NumIncidente)  &apos;Numero Incid.&apos;
        ///	                                      , incidpac.NomPaciente &apos;Afiliado&apos;
        ///                                          , CONVERT(CHAR(11),ISNULL(inciddesp.InstantePasoDespacho, llam.Instante),108) &apos;H.Recibido&apos;
        ///	                                      , DATEDIFF(mi, ISNULL(inciddesp.InstantePasoDespacho, llam.Instante), CURRENT_TIMESTAMP) &apos;Tiempo Transc.&apos;
        ///										  ,  ISNULL(CONVERT(CHAR(11),incid [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string queryServicios_OLD {
            get {
                return ResourceManager.GetString("queryServicios_OLD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Server=10.5.20.67;Database=RyD;User Id=UsrExtraccion;Password=Fw98ty72;.
        /// </summary>
        internal static string RyDConn {
            get {
                return ResourceManager.GetString("RyDConn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT TOP (500) 
        ///	                                       CONVERT(CHAR(10),incid.NumIncidente)  &apos;Numero Incid.&apos;
        ///	                                      , incidpac.NomPaciente &apos;Afiliado&apos;
        ///                                          , CONVERT(CHAR(11),ISNULL(inciddesp.InstantePasoDespacho, llam.Instante),108) &apos;H.Recibido&apos;
        ///	                                      , DATEDIFF(mi, ISNULL(inciddesp.InstantePasoDespacho, llam.Instante), CURRENT_TIMESTAMP) &apos;Tiempo Transc.&apos;
        ///										  ,  ISNULL(CONVERT(CHAR(11),incid [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Verdes_OLD {
            get {
                return ResourceManager.GetString("Verdes_OLD", resourceCulture);
            }
        }
    }
}