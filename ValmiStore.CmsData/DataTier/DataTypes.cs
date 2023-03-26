using System;

namespace Data.DataTier.DataTypes
{
	/// <summary>
	/// ������������ ��� �������� ����� ������ ������������ � �������
	/// </summary>
	public enum DataType {
		/// <summary>
		/// �����
		/// </summary>
		ValueInt32,
		/// <summary>
		/// ������ �� "������"
		/// </summary>
		ValueNomenclature,
		/// <summary>
		/// ����� (HTML)
		/// </summary>
		ValueText,
		/// <summary>
		/// ����
		/// </summary>
		ValueDateTime,
		/// <summary>
		/// �������� ����
		/// </summary>
		ValueBinary,
		/// <summary>
		/// �����
		/// </summary>
		ValueNumeric,
		/// <summary>
		/// ������
		/// </summary>
		ValueString,
		ValueDictionary,
		ValueXNomenclature,
		ValueString0
	}
	/// <summary>
	/// ���� �������� ������
	/// </summary>
	public enum BinaryContentType {
		/// <summary>
		/// �����������
		/// </summary>
		Image,
		/// <summary>
		/// ����
		/// </summary>
		Flash
	}
}
