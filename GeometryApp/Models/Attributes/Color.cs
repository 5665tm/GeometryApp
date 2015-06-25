using System.Collections.Generic;
using GeometryApp.Models.Base;

namespace GeometryApp.Models.Attributes
{
	public class Color : BaseModel
	{
		/// <summary>
		///     Название цвета
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		///     Цветовой индекс
		/// </summary>
		public string RgbIndex { get; set; }

		/// <summary>
		///     Список визуальных стилей
		/// </summary>
		public virtual ICollection<Visual> Visuals { get; set; }
	}
}