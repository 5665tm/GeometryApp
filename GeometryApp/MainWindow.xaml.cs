using System.Windows;

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
			Initializer.Fill();

			using (var gc = new GeometryContext())
			{
				var anonimousType = new {}
			}
		}
	}
}