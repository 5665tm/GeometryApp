using System;
using System.Collections.Generic;
using GeometryApp.Models.Base;
using GeometryApp.Models.GeometryShapes;

namespace GeometryApp.Models.Attributes
{
	/// <summary>
	///     Аттрибут геометрической фигуры
	/// </summary>
	public class Character : BaseModel
	{
		public Guid VisualId { get; set; }

		public virtual Visual Visual { get; set; }

		public Guid PositionId { get; set; }

		public virtual Position Position { get; set; }

		/// <summary>
		///     Список кружков к которым применяется аттрибут
		/// </summary>
		public virtual ICollection<Circle> Circles { get; set; }

		/// <summary>
		///     Список прямоугольников к которым применяется аттрибут
		/// </summary>
		public virtual ICollection<Rectangle> Rectangles { get; set; }

		/// <summary>
		///     Список треугольников к которым применяется аттрибут
		/// </summary>
		public virtual ICollection<Triangle> Triangles { get; set; }
	}
}