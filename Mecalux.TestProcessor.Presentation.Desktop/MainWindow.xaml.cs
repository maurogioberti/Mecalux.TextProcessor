using Mecalux.TestProcessor.CrossCutting.Enums;
using Mecalux.TestProcessor.CrossCutting.Globalization;
using Mecalux.TestProcessor.ResourceAccess.Contracts;
using Mecalux.TestProcessor.Services.Abstractions;
using System.Windows;

namespace Mecalux.TestProcessor.Presentation.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ITextService textService;
        private readonly ITextSortService textSortService;

        public ITextSortService TextSortService => textSortService;

        public MainWindow(ITextService textService, ITextSortService textSortService)
        {
            this.textService = textService;
            this.textSortService = textSortService;

            InitializeComponent();
            FillSortOptions();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsInputValid())
                return;

            var selectedOption = SortOptions.SelectedItem as Sort;
            var selectedOptionEnum = (SortOption)Enum.Parse(typeof(SortOption), selectedOption.Option);
            var sortedText = textSortService.Sort(TextInput.Text, selectedOptionEnum);
            MessageBox.Show(sortedText);
        }

        private void CountButton_Click(object sender, RoutedEventArgs e)
        {
            var statistics = textService.GetStatistics(TextInput.Text);
            var message = $"Hyphens: {statistics.Hypens}, Words: {statistics.Words}, Spaces: {statistics.Spaces}";
            MessageBox.Show(message);
        }

        private void RandomTextButton_Click(object sender, RoutedEventArgs e)
        {
            var text = textService.GetRandom();
            TextInput.Text = text.Content;
        }

        private void FillSortOptions()
        {
            var orderOptions = textSortService.List();
            SortOptions.ItemsSource = orderOptions.Items;
            SortOptions.DisplayMemberPath = "Option";
        }

        private bool IsInputValid()
        {
            if (string.IsNullOrWhiteSpace(TextInput.Text))
            {
                MessageBox.Show(Messages.InputFieldEmpty);
                return false;
            }

            if (!(SortOptions.SelectedItem is Sort))
            {
                MessageBox.Show(Messages.SortFieldEmpty);
                return false;
            }

            return true;
        }
    }
}