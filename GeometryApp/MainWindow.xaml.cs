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
		///     Фигура которая выбрана в данный момент пользователем в DataGrid
		/// </summary>
		private ShapeInfo _activeShape;

		/// <summary>
		///     Конструктор главного окна
		/// </summary>
		public MainWindow()
		{
			// инициализация элементов управления
			InitializeComponent();
			// начальная инициализация базы данных
			Initializer.Fill();
			// обновляем рабочую область
			RefreshAll();
		}

		/// <summary>
		///     Выполняет обновление рабочей области
		/// </summary>
		private void RefreshAll()
		{
			using (var gc = new GeometryContext())
			{
				// очищаем канвас
				FieldCanvas.Children.Clear();
				// создаем новый лист/список с фигурами
				var shapeInfoList = new List<ShapeInfo>();

				// обрабатываем круги
				foreach (var circle in gc.Circles)
				{
					// добавляем в DataGrid
					shapeInfoList.Add(new ShapeInfo(
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

				// обрабатываем прямоугольники
				foreach (var rec in gc.Rectangles)
				{
					// добавляем в DataGrid
					shapeInfoList.Add(new ShapeInfo(
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
				ButtonDelete.IsEnabled = false;
				ButtonEdit.IsEnabled = false;
				// Закидываем в DataGrid информацию о всех фигурах
				DataView.ItemsSource = shapeInfoList;
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
				ButtonDelete.IsEnabled = true;
				ButtonEdit.IsEnabled = true;
			}
			catch (Exception)
			{
			}
		}

		/// <summary>
		///     Срабатыват при нажатии на кнопку "Создать"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonCreate_Click(object sender, RoutedEventArgs e)
		{
			CreateOrEditWindow createOrEditWindow = new CreateOrEditWindow(null);
			createOrEditWindow.ShowDialog();
			RefreshAll();
		}

		/// <summary>
		/// Срабатывает при нажатии на кнопку "Редактировать"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonEdit_Click(object sender, RoutedEventArgs e)
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