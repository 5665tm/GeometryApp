using System.Data.Entity;
using GeometryApp.Models.Attributes;
using GeometryApp.Models.GeometryShapes;

namespace GeometryApp
{
	public class GeometryContext : DbContext

	{
		public GeometryContext() : base("GeometryEntities")
		{
		}

		/// <summary>
		///     Переопредление при создании базы данных
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}

		#region Attributes

		public DbSet<Character> Characters { get; set; }

		/// <summary>
		///     Цвета
		/// </summary>
		public DbSet<Color> Colors { get; set; }

		/// <summary>
		///     Позиции
		/// </summary>
		public DbSet<Position> Positions { get; set; }

		/// <summary>
		///     Визуальные стили
		/// </summary>
		public DbSet<Visual> Visuals { get; set; }

		#endregion

		#region GeometryShape

		/// <summary>
		///     Круги
		/// </summary>
		public DbSet<Circle> Circles { get; set; }

		/// <summary>
		///     Прямоугольники
		/// </summary>
		public DbSet<Rectangle> Rectangles { get; set; }

		/// <summary>
		///     Треугольники
		/// </summary>
		public DbSet<Triangle> Triangles { get; set; }

		#endregion
	}
}