using System;
using System.Globalization;
using GeometryApp.Models.Attributes;
using GeometryApp.Models.Base;
using GeometryApp.Models.GeometryShapes.Interface;

namespace GeometryApp.Models.GeometryShapes
{
	/// <summary>
	///     Сущность описывающая прямоугольник
	/// </summary>
	public class Rectangle : BaseModel, IShape
	{
		/// <summary>
		///     Ширина
		/// </summary>
		public float Width { get; set; }

		/// <summary>
		///     Высота
		/// </summary>
		public float Height { get; set; }

		/// <summary>
		///     Возвращает информацию касательно прямоугольника
		/// </summary>
		/// <returns></returns>
		public string GetInfo()
		{
			return "Width " + Width.ToString(CultureInfo.InvariantCulture) + " Height " + Height.ToString(CultureInfo.InvariantCulture);
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