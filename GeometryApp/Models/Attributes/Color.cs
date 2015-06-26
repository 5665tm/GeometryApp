using System.Collections.Generic;
using System.Windows.Media;
using GeometryApp.Models.Base;
using GeometryApp.Models.GeometryShapes;

namespace GeometryApp.Models.Attributes
{
	/// <summary>
	///     Цвет фигуры
	/// </summary>
	public class Color : BaseModel
	{
		/// <summary>
		///     Название цвета
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		///     Список кружков к которым применяется аттрибут
		/// </summary>
		public virtual ICollection<Circle> Circles { get; set; }

		/// <summary>
		///     Список прямоугольников к которым применяется аттрибут
		/// </summary>
		public virtual ICollection<Rectangle> Rectangles { get; set; }

		/// <summary>
		///     Конвертирует запись БД в цвет используемый элементами управления WPF
		/// </summary>
		/// <returns></returns>
		public SolidColorBrush GetBrush()
		{
			// В зависимости от название цвета возвращается нужная кисть
			switch (Title)
			{
				case "Green":
					return Brushes.Green;
				case "Red":
					return Brushes.Red;
				default:
					return Brushes.Blue;
			}
		}
	}
}