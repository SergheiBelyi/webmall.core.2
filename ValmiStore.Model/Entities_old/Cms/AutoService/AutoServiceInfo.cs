using System.Collections.Generic;

namespace ValmiStore.Model.Entities.Cms.AutoService
{
    public class AutoServiceInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public List<AutoServiceDetail> Items { get; set; }
    }
}