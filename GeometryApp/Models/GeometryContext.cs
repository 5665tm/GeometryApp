using System.Data.Entity;
using GeometryApp.Models.Attributes;
using GeometryApp.Models.GeometryShapes;

namespace GeometryApp.Models
{
	/// <summary>
	///     Сущность для работы с базой данных
	/// </summary>
	public class GeometryContext : DbContext

	{
		/// <summary>
		///     Конструктор для создания объекта
		/// </summary>
		public GeometryContext() : base("GeometryEntities")
		{
		}

		/// <summary>
		///     Цвета
		/// </summary>
		public DbSet<Color> Colors { get; set; }

		/// <summary>
		///     Позиции
		/// </summary>
		public DbSet<Position> Positions { get; set; }

		/// <summary>
		///     Круги
		/// </summary>
		public DbSet<Circle> Circles { get; set; }

		/// <summary>
		///     Прямоугольники
		/// </summary>
		public DbSet<Rectangle> Rectangles { get; set; }
	}
}