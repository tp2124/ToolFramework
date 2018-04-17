namespace DemoWPFApplication
{
    using System;
    using System.Windows;

    using DemoWPFApplication.Views.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HelloWorld_button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Pressed Hello World!");
            ShapesWindow shapeWindow = new ShapesWindow();
            shapeWindow.Show();
        }
    }
}
