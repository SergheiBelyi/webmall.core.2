using System;

namespace Webmall.UI.Models
{
    public class PinCode
    {
        /// <summary>
        /// Для кого сгенерирован код
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Валиден до
        /// </summary>
        public DateTime ValidTo { get; set; }

        /// <summary>
        /// Осталось попыток для проверки
        /// </summary>
        public int AttemptsRemain { get; set; } = 3;

    }
}