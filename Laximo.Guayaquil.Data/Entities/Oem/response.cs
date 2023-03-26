using System.Xml;

namespace Laximo.Guayaquil.Data.Entities
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    [System.Xml.Serialization.XmlRoot("response")]
    public partial class response
    {

        private ListCatalogs[] listCatalogs;
        private GetCatalogInfo[] getCatalogInfo;
        private FindVehicleByVIN[] findVehicleByVin;
        private FindVehicleByFrame[] findVehicleByFrame;
        private FindVehicleByWizard2[] findVehicleByWizard2;
        private ExecCustomOperation[] execCustomOperation;
        private GetVehicleInfo[] getVehicleInfo;
        private ListCategories[] listCategories;
        private ListUnits[] listUnits;
        private GetUnitInfo[] getUnitInfo;
        private ListImageMapByUnit[] listImageMapByUnit;
        private ListDetailsByUnit[] listDetailsByUnit;
        private GetWizard2[] getWizard2;
        private GetFilterByUnit[] getFilterByUnit;
        private GetFilterByDetail[] getFilterByDetail;
        private ListQuickGroups[] listQuickGroups;
        private ListQuickDetail[] listQuickDetail;

        [System.Xml.Serialization.XmlElementAttribute]
        public ExecCustomOperation[] ExecCustomOperation
        {
            get { return execCustomOperation; }
            set { execCustomOperation = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public ListQuickDetail[] ListQuickDetail
        {
            get { return listQuickDetail; }
            set { listQuickDetail = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public ListQuickGroups[] ListQuickGroups
        {
            get { return listQuickGroups; }
            set { listQuickGroups = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public GetFilterByDetail[] GetFilterByDetail
        {
            get { return getFilterByDetail; }
            set { getFilterByDetail = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public GetFilterByUnit[] GetFilterByUnit
        {
            get { return getFilterByUnit; }
            set { getFilterByUnit = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public GetWizard2[] GetWizard2
        {
            get { return getWizard2; }
            set { getWizard2 = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public ListDetailsByUnit[] ListDetailsByUnit
        {
            get { return listDetailsByUnit; }
            set { listDetailsByUnit = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public ListImageMapByUnit[] ListImageMapByUnit
        {
            get { return listImageMapByUnit; }
            set { listImageMapByUnit = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public GetUnitInfo[] GetUnitInfo
        {
            get { return getUnitInfo; }
            set { getUnitInfo = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public ListCategories[] ListCategories
        {
            get { return listCategories; }
            set { listCategories = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public ListUnits[] ListUnits
        {
            get { return listUnits; }
            set { listUnits = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public GetVehicleInfo[] GetVehicleInfo
        {
            get { return getVehicleInfo; }
            set { getVehicleInfo = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public FindVehicleByWizard2[] FindVehicleByWizard2
        {
            get { return findVehicleByWizard2; }
            set { findVehicleByWizard2 = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public FindVehicleByFrame[] FindVehicleByFrame
        {
            get { return findVehicleByFrame; }
            set { findVehicleByFrame = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("FindVehicleByVIN")]
        public FindVehicleByVIN[] FindVehicleByVin
        {
            get { return findVehicleByVin; }
            set { findVehicleByVin = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute]
        public GetCatalogInfo[] GetCatalogInfo
        {
            get { return getCatalogInfo; }
            set { getCatalogInfo = value; }
        }


        [System.Xml.Serialization.XmlElementAttribute]
        public ListCatalogs[] ListCatalogs
        {
            get { return listCatalogs; }
            set { listCatalogs = value; }
        }


    }
}