using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using GeometryApp.Models;
using GeometryApp.Models.GeometryShapes;

namespace GeometryApp
{
	/// <summary>
	///     Логика взаимодействия для CreateOrEdit.xaml
	/// </summary>
	public partial class CreateOrEdit : Window
	{
		private readonly Guid? _guid;
		private ShapeInfo.ShapeType _shapeType;

		public CreateOrEdit(Guid? guid, ShapeInfo.ShapeType shapeType = ShapeInfo.ShapeType.Circle)
		{
			using (var gc = new GeometryContext())
			{
				_guid = guid;
				_shapeType = shapeType;

				InitializeComponent();

				// заполняем выпадающий список с цветами
				ColorList.ItemsSource = gc.Colors.Select(x => x.Title).ToList();

				// Если GUID заполнен то включаем режим редактирования фигуры с таким guid
				if (_guid.HasValue)
				{
					ShapesList.IsEnabled = false;
					switch (shapeType)
					{
						// если редактируем круг
						case ShapeInfo.ShapeType.Circle:
							Label1.Content = "Radius";
							Label2.Content = "";
							TextBox1.IsEnabled = true;
							TextBox2.IsEnabled = false;

							Circle circle = gc.Circles.First(x => x.Id == guid.Value);
							TextBox1.Text = circle.Radius.ToString(CultureInfo.InvariantCulture);
							TextBoxCoordX.Text = circle.Position.CoordX.ToString(CultureInfo.InvariantCulture);
							TextBoxCoordY.Text = circle.Position.CoordY.ToString(CultureInfo.InvariantCulture);
							break;

						// если редактируем прямоугольник
						case ShapeInfo.ShapeType.Rectangle:
							Label1.Content = "Width";
							Label2.Content = "Height";
							TextBox1.IsEnabled = true;
							TextBox2.IsEnabled = true;

							Rectangle rectangle = gc.Rectangles.First(x => x.Id == guid.Value);
							TextBox1.Text = rectangle.Width.ToString(CultureInfo.InvariantCulture);
							TextBox2.Text = rectangle.Height.ToString(CultureInfo.InvariantCulture);
							TextBoxCoordX.Text = rectangle.Position.CoordX.ToString(CultureInfo.InvariantCulture);
							TextBoxCoordY.Text = rectangle.Position.CoordY.ToString(CultureInfo.InvariantCulture);
							break;
					}
				}
			}
		}

		/// <summary>
		///     Нажатие на кнопку ОК
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonOk_Click(object sender, RoutedEventArgs e)
		{
		}
	}
}