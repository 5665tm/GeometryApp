using System;
using System.Globalization;
using GeometryApp.Models.Attributes;
using GeometryApp.Models.Base;
using GeometryApp.Models.GeometryShapes.Interface;

namespace GeometryApp.Models.GeometryShapes
{
	/// <summary>
	///     Треугольник
	/// </summary>
	public class Triangle : BaseModel, IShape
	{
		/// <summary>
		///     Сторона А
		/// </summary>
		public float SideA { get; set; }

		/// <summary>
		///     Сторона Б
		/// </summary>
		public float SideB { get; set; }

		/// <summary>
		///     Сторона С
		/// </summary>
		public float SideC { get; set; }

		public string GetShapeInfo()
		{
			return "Side A " + SideA.ToString(CultureInfo.InvariantCulture) + " Side B " + SideB.ToString(CultureInfo.InvariantCulture) + " Side C " + SideC.ToString(CultureInfo.InvariantCulture);
		}

		public string GetShapeName()
		{
			return "Triangle";
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