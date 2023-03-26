using System;

namespace Data.DataTier.DataTypes
{
	/// <summary>
	/// Используется для описания типов данных используемых в бэкенде
	/// </summary>
	public enum DataType {
		/// <summary>
		/// Число
		/// </summary>
		ValueInt32,
		/// <summary>
		/// Данные из "дерева"
		/// </summary>
		ValueNomenclature,
		/// <summary>
		/// Текст (HTML)
		/// </summary>
		ValueText,
		/// <summary>
		/// Дата
		/// </summary>
		ValueDateTime,
		/// <summary>
		/// Двоичный блок
		/// </summary>
		ValueBinary,
		/// <summary>
		/// Число
		/// </summary>
		ValueNumeric,
		/// <summary>
		/// Строка
		/// </summary>
		ValueString,
		ValueDictionary,
		ValueXNomenclature,
		ValueString0
	}
	/// <summary>
	/// Типы бинарных данных
	/// </summary>
	public enum BinaryContentType {
		/// <summary>
		/// Изображение
		/// </summary>
		Image,
		/// <summary>
		/// Флэш
		/// </summary>
		Flash
	}
}
