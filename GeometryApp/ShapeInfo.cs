using System;

namespace GeometryApp
{
	/// <summary>
	///     Информационный блок о каждой фигуре,
	///     используется для вывода данных в DataGrid
	/// </summary>
	public class ShapeInfo
	{
		public Guid Guid { get; set; }
		public ShapeType Type { get; set; }
		public string Info { get; set; }
		public string Coordinates { get; set; }
		public string Color { get; set; }

		/// <summary>
		///     Конструктор
		/// </summary>
		/// <param name="guid">GUID</param>
		/// <param name="type">Тип фигуры</param>
		/// <param name="info">Информация о фигуре</param>
		/// <param name="coordinates">Координаты</param>
		/// <param name="color">Цвет</param>
		public ShapeInfo(Guid guid, ShapeType type, string info, string coordinates, string color)
		{
			Guid = guid;
			Type = type;
			Info = info;
			Coordinates = coordinates;
			Color = color;
		}

		/// <summary>
		///     Перечисление описывающее возможные фигуры
		/// </summary>
		public enum ShapeType
		{
			Circle,
			Rectangle
		}
	}
}