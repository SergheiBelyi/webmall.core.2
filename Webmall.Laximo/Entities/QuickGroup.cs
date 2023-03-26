using System.Collections.Generic;
using System.Linq;

namespace Webmall.Laximo.Entities
{
    public class QuickGroup
    {

        /*
categoryid	+	Внутренний номер категории
name	+	Наименование категории, по возможности, на запрашиваемом языке
code	-	
Код категории

childrens	-	Наличие вложенных категорий
parentcategoryid	-	ID родительского элемента
         */

        /// <summary>
        /// Внутренний номер категории
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Наименование категории, по возможности, на запрашиваемом языке
        /// </summary>
        public string Name { get; set; }

        public List<QuickGroup> Children { get; set; }

        public bool IsLink { get; set; }

        public QuickGroup()
        {
            Children = new List<QuickGroup>();
        }

        public QuickGroup(global::Laximo.Guayaquil.Data.Entities.t_row group)
        {
            Id = group.quickgroupid;
            Name = group.name;
            IsLink = group.link;

            Children = group.row != null ? group.row.Select(i => new QuickGroup(i)).ToList() : new List<QuickGroup>();
        }
    }
}
