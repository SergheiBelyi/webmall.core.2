﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:2.0.50727.3053
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Xml.Serialization;

namespace Laximo.Guayaquil.Data.Entities
{ // 
// This source code was auto-generated by xsd, Version=2.0.50727.42.
// 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class GetVehicleInfo {

        private VehicleInfo[] rowField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("row")]
        public VehicleInfo[] row {
            get {
                return this.rowField;
            }
            set {
                this.rowField = value;
            }
        }
    }
   }