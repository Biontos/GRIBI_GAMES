using MauiApp6.Models;
using Microsoft.Maui.Storage;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MauiApp6.ViewModels
{
    public class NotionViewModel : BindableObject
    {
        private NotionModel notion;

        public NotionModel Notion
        {
            get => notion;
            set
            {
                notion = value;
                OnPropertyChanged();
            }
        }

        public ICommand PickImageCommand { get; }
        public ICommand SaveNotionCommand { get; }
        public ICommand DeleteNotionCommand { get; }
        public ICommand BackCommand { get; }

        public NotionViewModel()
        {
            Notion = new NotionModel();
            PickImageCommand = new Command(OnPickImage);
            SaveNotionCommand = new Command(OnSaveNotion);
            DeleteNotionCommand = new Command(OnDeleteNotion);
            BackCommand = new Command(OnBack);
        }

        private async void OnPickImage()
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Выберите изображение",
                    FileTypes = FilePickerFileType.Images
                });

                if (result != null)
                {
                    Notion.ImagePath = result.FullPath;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при выборе изображения: {ex.Message}");
            }
        }

        private void OnSaveNotion()
        {
            Console.WriteLine($"Добавлено: {Notion.Title}, {Notion.Description}, {Notion.ImagePath}");
        }

        private void OnDeleteNotion()
        {
            Notion.Title = string.Empty;
            Notion.Description = string.Empty;
            Notion.ImagePath = string.Empty;
            Console.WriteLine("Объект удален");
        }

        private async void OnBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
