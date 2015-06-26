using System;
using System.Globalization;
using GeometryApp.Models.Attributes;
using GeometryApp.Models.Base;
using GeometryApp.Models.GeometryShapes.Interface;

namespace GeometryApp.Models.GeometryShapes
{
	/// <summary>
	///     Сущность описывающая круг
	/// </summary>
	public class Circle : BaseModel, IShape
	{
		/// <summary>
		///     Радиус
		/// </summary>
		public float Radius { get; set; }

		/// <summary>
		///     Возвращает общую информацию о круге
		/// </summary>
		/// <returns></returns>
		public string GetInfo()
		{
			return "Radius " + Radius.ToString(CultureInfo.InvariantCulture);
		}

		/// <summary>
		///     ID цвета фигуры
		/// </summary>
		public Guid ColorId { get; set; }

		/// <summary>
		///     Цвет фигуры
		/// </summary>
		public virtual Color Color { get; set; }

		/// <summary>
		///     ID позиции фигуры
		/// </summary>
		public Guid PositionId { get; set; }

		/// <summary>
		///     Позиция фигуры
		/// </summary>
		public virtual Position Position { get; set; }
	}
}