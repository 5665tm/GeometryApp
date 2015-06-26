using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using GeometryApp.Models;

namespace GeometryApp
{
	/// <summary>
	///     Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
//			Initializer.Fill();
			Refresh();
		}

		/// <summary>
		///     Фигура которая выбрана в данный момент пользователем
		/// </summary>
		private ShapeInfo _activeShape;

		public void Refresh()
		{
			using (var gc = new GeometryContext())
			{
				// новый лист с фигурами
				var shapeInfos = new List<ShapeInfo>();

				// добавляем круги
				foreach (var circle in gc.Circles)
				{
					// добавляем в DataGrid
					shapeInfos.Add(new ShapeInfo(
						circle.Id,
						ShapeInfo.ShapeType.Circle,
						circle.GetInfo(),
						circle.Position.ToString())
						);

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
					Field.Children.Add(ellipse);
				}
				// добавляем прямоугольники
				foreach (var rec in gc.Rectangles)
				{
					// добавляем в DataGrid
					shapeInfos.Add(new ShapeInfo(
						rec.Id,
						ShapeInfo.ShapeType.Rectangle,
						rec.GetInfo(),
						rec.Position.ToString())
						);

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
					Field.Children.Add(recShape);
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
			_activeShape = (ShapeInfo) e.AddedItems[0];
			BtDelete.IsEnabled = true;
			BtEdit.IsEnabled = true;
		}

		private void BtCreate_Click(object sender, RoutedEventArgs e)
		{
		}

		private void BtEdit_Click(object sender, RoutedEventArgs e)
		{
			CreateOrEdit createOrEdit = new CreateOrEdit(_activeShape.Guid, _activeShape.Type);
			createOrEdit.ShowDialog();
		}

		private void BtDelete_Click(object sender, RoutedEventArgs e)
		{
		}
	}
}