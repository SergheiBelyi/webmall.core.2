using System;
using System.Collections.Generic;

namespace ValmiStore.Model.Entities.User
{
    public class ComparisionAct
    {
        private decimal? docSum;

        public string Id => DocId; // + "@" + ((DocDate?.Year ?? 0) % 100).ToString();

        /// <summary>
        /// Код документа
        /// </summary>
        public string DocId { get; set; }

        /// <summary>
        /// Номер учтенного документа
        /// </summary>
        public string DocNumber { get; set; }

        /// <summary>
        /// Код типа документа
        /// </summary>
        public string DocTypeId { get; set; }

        /// <summary>
        /// Тип документа
        /// </summary>
        public string DocType { get; set; }

        /// <summary>
        /// Дата документа
        /// </summary>
        public DateTime? DocDate { get; set; }
        public DateTime? Date { get => DocDate; set => DocDate = value; }

        /// <summary>
        /// Дата, когда надо оплатить документ или дата платежа
        /// </summary>
        public DateTime? PaymentDate { get; set; }

        /// <summary>
        /// Сумма по документу
        /// </summary>
        public decimal? DocSum { get => docSum ?? DebetSum - CreditSum; set => docSum = value; }

        /// <summary>
        /// Cумма выровнено
        /// </summary>
        public decimal? LeveledSum { get; set; }

        /// <summary>
        /// Задолженность в указанной валюте
        /// </summary>
        public decimal? DebdSum { get; set; }

        /// <summary>
        /// Просрочено в указанной валюте
        /// </summary>
        public decimal? OverdueSum { get; set; }

        /// <summary>
        /// Просрочено дней
        /// </summary>
        public int? OverdueDays { get; set; }

        /// <summary>
        /// Форма оплаты
        /// </summary>
        public string PaymentForm { get; set; }

        /// <summary>
        /// Тип продажи
        /// </summary>
        public string TradeType { get; set; }

        /// <summary>
        /// Вид хозяйственной операции
        /// </summary>
        public string OperationType { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Признак наличия деталировки
        /// </summary>
        public bool HasDetail { get; set; }

        /// <summary>
        /// Признак полной таблицы в расшифровке
        /// </summary>
        public bool FullForm => DocTypeId == "5";

        //public string OrderNumber { get; set; }

        public Dictionary<string, string> CustomValues { get; set; } = new Dictionary<string, string>();

        public decimal? DebetSum { get; set; }
        public decimal? CreditSum { get; set; }

        public bool Initial { get; set; }
        public bool Final { get; set; }
    }
}