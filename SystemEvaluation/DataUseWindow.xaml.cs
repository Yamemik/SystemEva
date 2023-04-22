using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace SystemEvaluation
{
    public partial class DataUseWindow : Window
    {
        string path = "mydoc.xaml";
        public DataUseWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = File.Open(path, FileMode.Create))
            {
                if (docViewer.Document != null)
                {
                    XamlWriter.Save(docViewer.Document, fs);
                    MessageBox.Show("Файл сохранен");
                }
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            docViewer.ClearValue(FlowDocumentScrollViewer.DocumentProperty);
        }
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                FlowDocument document = XamlReader.Load(fs) as FlowDocument;
                if (document != null)
                    docViewer.Document = document;
            }
        }
    }
}

