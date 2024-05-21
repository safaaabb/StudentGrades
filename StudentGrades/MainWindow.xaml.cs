using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.Win32;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentGrades
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataTable studentDataTable;
        public MainWindow()
        {
            InitializeComponent();
        }
        private DataTable LoadCsvData(string filePath)
        {
            DataTable dataTable = new DataTable();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)))
            {
                using (var dr = new CsvDataReader(csv))
                {
                    dataTable.Load(dr);
                }
            }

            return dataTable;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                string csvFilePath = openFileDialog.FileName;
                studentDataTable = LoadCsvData(csvFilePath);
                StudentDataGrid.ItemsSource = studentDataTable.DefaultView;
            }

        }

        private void StudentDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}