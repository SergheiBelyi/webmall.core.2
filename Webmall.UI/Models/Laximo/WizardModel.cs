using System.Collections.Generic;
using System.Linq;
using Webmall.Laximo.Entities;

namespace Webmall.UI.Models.Laximo
{
    public class WizardModel : BaseModel
    {
        public List<WizardRow> Rows { get; set; }

        public bool AllowShowAutos => Rows?.Any(i => i.AllowListVehicles && !string.IsNullOrEmpty(i.Value)) ?? false;
    }
}