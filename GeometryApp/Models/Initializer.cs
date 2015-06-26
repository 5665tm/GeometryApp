using System.Collections.Generic;
using System.Linq;
using GeometryApp.Models.Attributes;
using GeometryApp.Models.GeometryShapes;

namespace GeometryApp.Models
{
	/// <summary>
	///     Инициализатор базы данных
	/// </summary>
	public static class Initializer
	{
		/// <summary>
		///     Заполняет базу данных демо даннными
		/// </summary>
		public static void Fill()
		{
			using (var gc = new GeometryContext())
			{
				// очищаем старую базу данных
				foreach (var id in gc.Colors.Select(e => e.Id))
				{
					var item = new Color {Id = id};
					gc.Colors.Attach(item);
					gc.Colors.Remove(item);
				}
				gc.SaveChanges();

				foreach (var id in gc.Positions.Select(e => e.Id))
				{
					var item = new Position {Id = id};
					gc.Positions.Attach(item);
					gc.Positions.Remove(item);
				}
				gc.SaveChanges();

				foreach (var id in gc.Circles.Select(e => e.Id))
				{
					var item = new Circle {Id = id};
					gc.Circles.Attach(item);
					gc.Circles.Remove(item);
				}
				gc.SaveChanges();

				foreach (var id in gc.Rectangles.Select(e => e.Id))
				{
					var item = new Rectangle {Id = id};
					gc.Rectangles.Attach(item);
					gc.Rectangles.Remove(item);
				}
				gc.SaveChanges();

				// добавляем цвета
				var colorList = new List<Color>
				{
					new Color {Title = "Red"},
					new Color {Title = "Green"},
					new Color {Title = "Blue"}
				};
				colorList.ForEach(item => gc.Colors.Add(item));
				gc.SaveChanges();

				// добавляем координаты
				var positionList = new List<Position>
				{
					new Position {CoordX = 200, CoordY = 100},
					new Position {CoordX = 390, CoordY = 170},
					new Position {CoordX = 230, CoordY = 380},
					new Position {CoordX = 290, CoordY = 120},
					new Position {CoordX = 170, CoordY = 130},
					new Position {CoordX = 170, CoordY = 160},
					new Position {CoordX = 140, CoordY = 100},
					new Position {CoordX = 105, CoordY = 340},
					new Position {CoordX = 200, CoordY = 450}
				};
				positionList.ForEach(item => gc.Positions.Add(item));
				gc.SaveChanges();

				// добавляем круги
				var circleList = new List<Circle>
				{
					new Circle {Radius = 40, Color = colorList[0], Position = positionList[0]},
					new Circle {Radius = 50, Color = colorList[1], Position = positionList[1]},
					new Circle {Radius = 60, Color = colorList[2], Position = positionList[2]},
					new Circle {Radius = 70, Color = colorList[0], Position = positionList[3]},
					new Circle {Radius = 80, Color = colorList[1], Position = positionList[4]}
				};
				circleList.ForEach(item => gc.Circles.Add(item));
				gc.SaveChanges();

				// добавляем прямоугольники
				var rectangleList = new List<Rectangle>
				{
					new Rectangle {Width = 40, Height = 70, Color = colorList[0], Position = positionList[5]},
					new Rectangle {Width = 20, Height = 20, Color = colorList[1], Position = positionList[6]},
					new Rectangle {Width = 30, Height = 30, Color = colorList[2], Position = positionList[7]},
					new Rectangle {Width = 70, Height = 50, Color = colorList[0], Position = positionList[8]}
				};
				rectangleList.ForEach(item => gc.Rectangles.Add(item));
				gc.SaveChanges();
			}
		}
	}
}