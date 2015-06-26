using System.Collections.Generic;
using GeometryApp.Models.Base;
using GeometryApp.Models.GeometryShapes;

namespace GeometryApp.Models.Attributes
{
	/// <summary>
	///     Информация о позиции фигуры
	/// </summary>
	public class Position : BaseModel
	{
		/// <summary>
		///     Координата X
		/// </summary>
		public double CoordX { get; set; }

		/// <summary>
		///     Координата Y
		/// </summary>
		public double CoordY { get; set; }

		/// <summary>
		///     Возвращает строковое представление позиции
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return "X: " + CoordX + "; Y: " + CoordY;
		}

		/// <summary>
		///     Список кружков к которым применяется аттрибут
		/// </summary>
		public virtual ICollection<Circle> Circles { get; set; }

		/// <summary>
		///     Список прямоугольников к которым применяется аттрибут
		/// </summary>
		public virtual ICollection<Rectangle> Rectangles { get; set; }
	}
}