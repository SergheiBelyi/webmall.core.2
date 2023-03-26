using System;
using System.Collections.Generic;

namespace ValmiStore.Model.Entities.Order
{
    public class WareAvailabilityWrapper
    {
        /// <summary>
        /// Список доступности по складам
        /// </summary>
        public List<WareAvailability> list = new List<WareAvailability> ();

        /// <summary>
        /// Общее доступное количество
        /// </summary>
        public decimal Total {get;set;}

        /// <summary>
        /// Максимальный срок доступности 
        /// </summary>
        public DateTime MaxTerm {get;set;} 

        /// <summary>
        /// Код товара
        /// </summary>
        public string WareId { get; set; }

        /// <summary>
        /// Расчитанная достаточность товара
        /// </summary>
        public bool IsEnough { get; set; }

        public WareAvailabilityWrapper()
        {
            Total = 0;
            MaxTerm = DateTime.Now;
            IsEnough = false;
        }

    }
}
