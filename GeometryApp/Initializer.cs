using System.Collections.Generic;
using GeometryApp.Models.Attributes;
using GeometryApp.Models.GeometryShapes;

namespace GeometryApp
{
	public static class Initializer
	{
		public static void Fill()
		{
			using (var gc = new GeometryContext())
			{
				// добавляем цвета
				var colorList = new List<Color>
				{
					new Color {Title = "Red", RgbIndex = "ff0000"},
					new Color {Title = "Green", RgbIndex = "00ff00"},
					new Color {Title = "Blue", RgbIndex = "0000ff"}
				};
				colorList.ForEach(item => gc.Colors.Add(item));
				gc.SaveChanges();

				// добавляем визуальные оформления
				var visualList = new List<Visual>
				{
					new Visual {Color = colorList[0], ThicknessStroke = 2},
					new Visual {Color = colorList[0], ThicknessStroke = 3},
					new Visual {Color = colorList[2], ThicknessStroke = 0},
					new Visual {Color = colorList[1], ThicknessStroke = 9}
				};
				visualList.ForEach(item => gc.Visuals.Add(item));
				gc.SaveChanges();

				// добавляем координаты
				var positionList = new List<Position>
				{
					new Position {CoordX = 200, CoordY = 100, ZIndex = 0, Rotate = 0},
					new Position {CoordX = 500, CoordY = 400, ZIndex = 2, Rotate = 30},
					new Position {CoordX = 700, CoordY = 500, ZIndex = 1, Rotate = 20},
					new Position {CoordX = 200, CoordY = 100, ZIndex = 0, Rotate = 0},
					new Position {CoordX = 500, CoordY = 430, ZIndex = 2, Rotate = 30},
					new Position {CoordX = 700, CoordY = 560, ZIndex = 1, Rotate = 20},
					new Position {CoordX = 240, CoordY = 100, ZIndex = 0, Rotate = 0},
					new Position {CoordX = 10, CoordY = 40, ZIndex = 2, Rotate = 30},
					new Position {CoordX = 600, CoordY = 450, ZIndex = 1, Rotate = 20}
				};
				positionList.ForEach(item => gc.Positions.Add(item));
				gc.SaveChanges();

				// добавляем характеристики
				var characterList = new List<Character>
				{
					new Character {Position = positionList[0], Visual = visualList[0]},
					new Character {Position = positionList[1], Visual = visualList[1]},
					new Character {Position = positionList[2], Visual = visualList[2]},
					new Character {Position = positionList[3], Visual = visualList[3]},
					new Character {Position = positionList[4], Visual = visualList[0]},
					new Character {Position = positionList[5], Visual = visualList[1]},
					new Character {Position = positionList[6], Visual = visualList[2]},
					new Character {Position = positionList[7], Visual = visualList[3]},
					new Character {Position = positionList[8], Visual = visualList[0]}
				};

				// добавляем круги
				var circleList = new List<Circle>
				{
					new Circle {Character = characterList[0], Radius = 40},
					new Circle {Character = characterList[1], Radius = 50},
					new Circle {Character = characterList[2], Radius = 60}
				};
				circleList.ForEach(item => gc.Circles.Add(item));
				gc.SaveChanges();

				// добавляем треугольники
				var triangleList = new List<Triangle>
				{
					new Triangle {Character = characterList[3], SideA = 30, SideB = 40, SideC = 50},
					new Triangle {Character = characterList[4], SideA = 30, SideB = 25, SideC = 60},
					new Triangle {Character = characterList[5], SideA = 40, SideB = 40, SideC = 50}
				};
				triangleList.ForEach(item => gc.Triangles.Add(item));
				gc.SaveChanges();

				// добавляем прямоугольники
				var rectangleList = new List<Rectangle>
				{
					new Rectangle {Character = characterList[6], Width = 100, Height = 100},
					new Rectangle {Character = characterList[7], Width = 10, Height = 20},
					new Rectangle {Character = characterList[8], Width = 400, Height = 30}
				};
				rectangleList.ForEach(item => gc.Rectangles.Add(item));
				gc.SaveChanges();
			}
		}
	}
}