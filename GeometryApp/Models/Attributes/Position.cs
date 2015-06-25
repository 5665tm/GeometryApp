using System.Collections.Generic;
using GeometryApp.Models.Base;

namespace GeometryApp.Models.Attributes
{
	/// <summary>
	///     Информация о позиции фигуры
	/// </summary>
	public class Position : BaseModel
	{
		public int CoordX { get; set; }
		public int CoordY { get; set; }
		public int ZIndex { get; set; }
		public int Rotate { get; set; }

		/// <summary>
		///     Список геометрических фигур к которым применяется расположение в пространстве
		/// </summary>
		public virtual ICollection<Character> Characters { get; set; }
	}
}