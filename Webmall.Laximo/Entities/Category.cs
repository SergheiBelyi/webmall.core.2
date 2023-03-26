using System.Collections.Generic;
using System.Linq;
using Laximo.Guayaquil.Data.Entities;

namespace Webmall.Laximo.Entities
{
    public class Category
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
        public string Id { get; set; }
        /// <summary>
        /// Наименование категории, по возможности, на запрашиваемом языке
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Код категории
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Наличие вложенных категорий
        /// </summary>
        public bool HasChildrens { get; set; }
        /// <summary>
        /// ID родительского элемента
        /// </summary>
        public string ParentCategoryId { get; set; }

        /// <summary>
        /// Признак выбранной категории
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// Код категории родителя
        /// </summary>
        public Category Parent { get; set; }

        /// <summary>
        /// Узлы при поиске по группам
        /// </summary>
        public List<UnitInfo> Units { get; set; }

        /// <summary>
        /// Данные сервера
        /// </summary>
        public string Ssd { get; set; }

        public List<Category> Children { get; set; }

        public Category()
        {
            Children = new List<Category>();
        }

        public Category(global::Laximo.Guayaquil.Data.Entities.Category cat)
        {
            Id = cat.categoryid;
            Name = cat.name;
            //Code = cat.
            HasChildrens = cat.childrens;
            ParentCategoryId = cat.parentid;
            Ssd = cat.ssd;

            Children = new List<Category>();
        }

        public Category(ListQuickDetailCategory cat)
        {
            Id = cat.categoryid;
            Name = cat.name;
            HasChildrens = cat.childrens;
            Units = cat.Unit.Select(i => new UnitInfo(i)).ToList();
        }
    }
}
