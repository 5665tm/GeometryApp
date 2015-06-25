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
		public string GetShapeInfo()
		{
			return "Width " + Width.ToString(CultureInfo.InvariantCulture) + " Height " + Height.ToString(CultureInfo.InvariantCulture);
		}
		public string GetShapeName()
		{
			return "Rectangle";
		}

		/// <summary>
		///     Характеристика геометрической фигуры
		/// </summary>
		public Guid CharacterId { get; set; }

		/// <summary>
		///     Характеристика геометрической фигуры
		/// </summary>
		public virtual Character Character { get; set; }
	}
}