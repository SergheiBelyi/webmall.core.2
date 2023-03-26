﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:2.0.50727.3053
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Security.Policy;
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
    public partial class FindVehicleByVIN {
    
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

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class VehicleInfo {
    
        private int vehicleId;
    
        private string brand;
    
        private string nameField;
    
        private string catalogField;
    
        private string ssdField;

        private DataAttribute[] attributes;
        private IDictionary<string, string> attributesMap;

        public string getAttribute(string key)
        {
            if (attributesMap == null)
            {
                attributesMap = new Dictionary<string, string>();

                foreach (DataAttribute attribute in Attributes)
                {
                    attributesMap.Add(attribute.Key.ToLower(), attribute.Value);
                }
            }

            string value;
            return attributesMap.TryGetValue(key.ToLower(), out value) ? value : name == "brand" ? brand : name == "name" ? nameField : null;
        }

        [System.Xml.Serialization.XmlAttributeAttribute("brand")]
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int vehicleid {
            get {
                return this.vehicleId;
            }
            set {
                this.vehicleId = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("attribute")]
        public DataAttribute[] Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("name")]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string catalog {
            get {
                return this.catalogField;
            }
            set {
                this.catalogField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ssd {
            get {
                return this.ssdField;
            }
            set {
                this.ssdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class FindVehicleByFrame
    {

        private VehicleInfo[] rowField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("row")]
        public VehicleInfo[] row
        {
            get
            {
                return this.rowField;
            }
            set
            {
                this.rowField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class DataAttribute
    {
        private string key;
        private string name;
        private string value;

        [System.Xml.Serialization.XmlAttributeAttribute("key")]
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        [System.Xml.Serialization.XmlAttributeAttribute("name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [System.Xml.Serialization.XmlAttributeAttribute("value")]
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class FindVehicleByWizard2 {
    
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

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class ExecCustomOperation
    {
    
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