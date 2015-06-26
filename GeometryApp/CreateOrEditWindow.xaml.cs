using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using GeometryApp.Models;
using GeometryApp.Models.Attributes;
using GeometryApp.Models.GeometryShapes;

namespace GeometryApp
{
	/// <summary>
	///     Окно создания и редактирования фигуры
	/// </summary>
	public partial class CreateOrEditWindow
	{
		/// <summary>
		///     Guid элемента с которым мы работаем
		///     Вопросительный знак указывает на то что он может быть NULL
		/// </summary>
		private readonly Guid? _guid;

		/// <summary>
		///     Тип фигуры с которой мы работаем
		/// </summary>
		private ShapeInfo.ShapeType _shapeType;

		/// <summary>
		///     Конструктор окна
		/// </summary>
		/// <param name="guid">Guid фигуры которую нужно редактировать, если NULL - режим создания новой фигуры</param>
		/// <param name="shapeType">Тип фигуры</param>
		public CreateOrEditWindow(Guid? guid, ShapeInfo.ShapeType shapeType = ShapeInfo.ShapeType.Circle)
		{
			_guid = guid;
			_shapeType = shapeType;

			InitializeComponent();

			// заполняем выпадающий список с цветами
			ColorList.ItemsSource = new List<string> {"Red", "Green", "Blue"};
			ColorList.SelectedIndex = 0;

			// Если GUID заполнен то включаем режим редактирования фигуры с таким guid
			if (_guid.HasValue)
			{
				InitEditMode();
			}
			// иначе включаем режим добавления новой фигуры
			else
			{
				InitCreateMode();
			}
		}

		/// <summary>
		///     Инициализирует режим редактирования фигуры
		/// </summary>
		private void InitEditMode()
		{
			using (var gc = new GeometryContext())
			{
				ShapesList.IsEnabled = false;
				switch (_shapeType)
				{
					// если редактируем круг
					case ShapeInfo.ShapeType.Circle:
						Label1.Content = "Radius";
						Label2.Content = "";
						TextBox1.IsEnabled = true;
						TextBox2.IsEnabled = false;

						// заполняем все поля информацией о редактируемой фигуре
						Circle circle = gc.Circles.First(x => x.Id == _guid.Value);
						TextBox1.Text = circle.Radius.ToString(CultureInfo.InvariantCulture);
						TextBoxCoordX.Text = circle.Position.CoordX.ToString(CultureInfo.InvariantCulture);
						TextBoxCoordY.Text = circle.Position.CoordY.ToString(CultureInfo.InvariantCulture);

						int colorIndex;
						switch (circle.Color.Title)
						{
							case "Red":
								colorIndex = 0;
								break;
							case "Green":
								colorIndex = 1;
								break;
							default:
								colorIndex = 2;
								break;
						}
						ColorList.SelectedIndex = colorIndex;
						break;

					// если редактируем прямоугольник
					case ShapeInfo.ShapeType.Rectangle:
						Label1.Content = "Width";
						Label2.Content = "Height";
						TextBox1.IsEnabled = true;
						TextBox2.IsEnabled = true;

						// заполняем все поля информацией о редактируемой фигуре
						Rectangle rectangle = gc.Rectangles.First(x => x.Id == _guid.Value);
						TextBox1.Text = rectangle.Width.ToString(CultureInfo.InvariantCulture);
						TextBox2.Text = rectangle.Height.ToString(CultureInfo.InvariantCulture);
						TextBoxCoordX.Text = rectangle.Position.CoordX.ToString(CultureInfo.InvariantCulture);
						TextBoxCoordY.Text = rectangle.Position.CoordY.ToString(CultureInfo.InvariantCulture);

						int colorRecIndex;
						switch (rectangle.Color.Title)
						{
							case "Red":
								colorRecIndex = 0;
								break;
							case "Green":
								colorRecIndex = 1;
								break;
							default:
								colorRecIndex = 2;
								break;
						}
						ColorList.SelectedIndex = colorRecIndex;
						break;
				}
			}
		}

		/// <summary>
		///     Инициализирует режим создания новой фигуры
		/// </summary>
		private void InitCreateMode()
		{
			try
			{
				ShapesList.IsEnabled = true;
				switch (_shapeType)
				{
					// если создаем круг
					case ShapeInfo.ShapeType.Circle:
						Label1.Content = "Radius";
						Label2.Content = "";
						TextBox1.IsEnabled = true;
						TextBox2.IsEnabled = false;
						break;

					// если создаем прямоугольник
					case ShapeInfo.ShapeType.Rectangle:
						Label1.Content = "Width";
						Label2.Content = "Height";
						TextBox1.IsEnabled = true;
						TextBox2.IsEnabled = true;
						break;
				}
			}
			catch (Exception)
			{
			}
		}

		/// <summary>
		///     Нажатие на кнопку ОК
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonOk_Click(object sender, RoutedEventArgs e)
		{
			using (var gc = new GeometryContext())
			{
				// блок исключающий возникновение чрезвычайных ситуаций
				// например конвертация неподходящей строки в число
				try
				{
					// вначале удаляем старую запись, если такая имела место быть
					if (_guid.HasValue)
					{
						if (_shapeType == ShapeInfo.ShapeType.Circle)
						{
							var item = new Circle {Id = _guid.Value};
							gc.Circles.Attach(item);
							gc.Circles.Remove(item);
						}
						if (_shapeType == ShapeInfo.ShapeType.Rectangle)
						{
							var item = new Rectangle {Id = _guid.Value};
							gc.Rectangles.Attach(item);
							gc.Rectangles.Remove(item);
						}
						gc.SaveChanges();
					}

					// затем создаем новую запись о координате
					Position position = new Position
					{
						CoordX = Convert.ToDouble(TextBoxCoordX.Text),
						CoordY = Convert.ToDouble(TextBoxCoordY.Text)
					};
					gc.Positions.Add(position);
					gc.SaveChanges();

					// определяем какой цвет выбран
					string colorName;
					switch (ColorList.SelectedIndex)
					{
						case 0:
							colorName = "Red";
							break;
						case 1:
							colorName = "Green";
							break;
						default:
							colorName = "Blue";
							break;
					}
					var color = gc.Colors.First(x => x.Title == colorName);
					gc.SaveChanges();

					// и создаем нужную фигуру
					if (_shapeType == ShapeInfo.ShapeType.Circle)
					{
						Circle circle = new Circle
						{
							Position = position,
							Radius = Convert.ToSingle(TextBox1.Text),
							Color = color
						};
						gc.Circles.Add(circle);
					}
					else
					{
						Rectangle rec = new Rectangle
						{
							Position = position,
							Width = Convert.ToSingle(TextBox1.Text),
							Height = Convert.ToSingle(TextBox2.Text),
							Color = color
						};
						gc.Rectangles.Add(rec);
					}
					gc.SaveChanges();
					Close();
				}
				catch (Exception)
				{
				}
			}
		}

		/// <summary>
		///     Изменение режима создания новой фигуры (круг либо прямоугольник)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ShapesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// если GUID == null, а значит включен режим редактирования
			if (!_guid.HasValue)
			{
				// если выбрали круг - создаем круг
				if (ShapesList.SelectedIndex == 0)
				{
					_shapeType = ShapeInfo.ShapeType.Circle;
				}
				// иначе создаем прямоугольник
				else
				{
					_shapeType = ShapeInfo.ShapeType.Rectangle;
				}
				InitCreateMode();
			}
		}
	}
}