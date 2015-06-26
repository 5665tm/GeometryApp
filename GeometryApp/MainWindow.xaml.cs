using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using GeometryApp.Models;
using GeometryApp.Models.GeometryShapes;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace GeometryApp
{
	/// <summary>
	///     Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		/// <summary>
		///     Фигура которая выбрана в данный момент пользователем
		/// </summary>
		private ShapeInfo _activeShape;

		public MainWindow()
		{
			InitializeComponent();
			// начальная инициализация базы данных
			Initializer.Fill();
			RefreshAll();
		}

		private void RefreshAll()
		{

			using (var gc = new GeometryContext())
			{
				// очищаем канвас
				FieldCanvas.Children.Clear();
				// создаем новый лист с фигурами
				var shapeInfos = new List<ShapeInfo>();

				// добавляем круги
				foreach (var circle in gc.Circles)
				{
					// добавляем в DataGrid
					shapeInfos.Add(new ShapeInfo(
						circle.Id,
						ShapeInfo.ShapeType.Circle,
						circle.GetInfo(),
						circle.Position.ToString(),
						circle.Color.Title
						));

					// рисуем фигуру
					Ellipse ellipse = new Ellipse
					{
						Height = circle.Radius*2,
						Width = circle.Radius*2,
						Fill = circle.Color.GetBrush()
					};

					// устанавливаем на канвасе с указанными координатами
					ellipse.SetValue(Canvas.LeftProperty, circle.Position.CoordX);
					ellipse.SetValue(Canvas.TopProperty, circle.Position.CoordY);
					FieldCanvas.Children.Add(ellipse);
				}

				// добавляем прямоугольники
				foreach (var rec in gc.Rectangles)
				{
					// добавляем в DataGrid
					shapeInfos.Add(new ShapeInfo(
						rec.Id,
						ShapeInfo.ShapeType.Rectangle,
						rec.GetInfo(),
						rec.Position.ToString(), rec.Color.Title
						));

					// рисуем фигуру
					Rectangle recShape = new Rectangle
					{
						Width = rec.Width,
						Height = rec.Height,
						Fill = rec.Color.GetBrush()
					};

					// устанавливаем на канвасе с указанными координатами
					recShape.SetValue(Canvas.LeftProperty, rec.Position.CoordX);
					recShape.SetValue(Canvas.TopProperty, rec.Position.CoordY);
					FieldCanvas.Children.Add(recShape);
				}

				_activeShape = null;
				BtDelete.IsEnabled = false;
				BtEdit.IsEnabled = false;
				DataView.ItemsSource = shapeInfos;
			}
		}

		/// <summary>
		///     Срабатывает когда пользователь изменил выделение в DataGrid
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DataView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				_activeShape = (ShapeInfo) e.AddedItems[0];
				BtDelete.IsEnabled = true;
				BtEdit.IsEnabled = true;
			}
			catch (Exception)
			{
			}
		}

		private void BtCreate_Click(object sender, RoutedEventArgs e)
		{
			CreateOrEditWindow createOrEditWindow = new CreateOrEditWindow(null);
			createOrEditWindow.ShowDialog();
			RefreshAll();
		}

		private void BtEdit_Click(object sender, RoutedEventArgs e)
		{
			CreateOrEditWindow createOrEditWindow = new CreateOrEditWindow(_activeShape.Guid, _activeShape.Type);
			createOrEditWindow.ShowDialog();
			RefreshAll();
		}

		/// <summary>
		///     Нажатие на кнопку удаления элемента
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtDelete_Click(object sender, RoutedEventArgs e)
		{
			using (var gc = new GeometryContext())
			{
				if (_activeShape.Type == ShapeInfo.ShapeType.Circle)
				{
					var item = new Circle {Id = _activeShape.Guid};
					gc.Circles.Attach(item);
					gc.Circles.Remove(item);
					gc.SaveChanges();
				}
				if (_activeShape.Type == ShapeInfo.ShapeType.Rectangle)
				{
					var item = new Models.GeometryShapes.Rectangle {Id = _activeShape.Guid};
					gc.Rectangles.Attach(item);
					gc.Rectangles.Remove(item);
					gc.SaveChanges();
				}
			}
			RefreshAll();
		}
	}
}