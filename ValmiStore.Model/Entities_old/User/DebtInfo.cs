using Newtonsoft.Json;

namespace ValmiStore.Model.Entities.User
{
    public class DebtInfo
    {
        /// <summary>
        /// Сообщение о задолженности
        /// </summary>
        [JsonProperty("DebtMessage")]
        public string Message { get; set; }

        /// <summary>
        /// Сумма оставшегося лимита
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Сумма задолженности
        /// </summary>
        public int Debt { get; set; }
    }
}
