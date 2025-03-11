using MauiApp6.ViewModels;
namespace MauiApp6;

public partial class NotionsListPage : ContentPage
{
    
        public NotionsListPage()
        {
            InitializeComponent();
            BindingContext = new NotionsListViewModel() { Navigation = this.Navigation };
        }

}
