using System;
using System.Globalization;
using GeometryApp.Models.Attributes;
using GeometryApp.Models.Base;
using GeometryApp.Models.GeometryShapes;
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
		public string GetShapeInfo()
		{
			return "Radius " + Radius.ToString(CultureInfo.InvariantCulture);
		}

		public string GetShapeName()
		{
			return "Circle";
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