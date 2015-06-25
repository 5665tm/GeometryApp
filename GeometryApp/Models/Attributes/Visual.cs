using System;
using System.Collections.Generic;
using GeometryApp.Models.Base;

namespace GeometryApp.Models.Attributes
{
	/// <summary>
	///     Визуальное оформление фигуры
	/// </summary>
	public class Visual : BaseModel
	{
		public Guid ColorId { get; set; }

		public virtual Color Color { get; set; }

		public int ThicknessStroke { get; set; }

		/// <summary>
		///     Список геометрических фигур к которым применяется стиль
		/// </summary>
		public virtual ICollection<Character> Characters { get; set; }
	}
}