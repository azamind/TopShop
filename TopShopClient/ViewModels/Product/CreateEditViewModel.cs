using System.Windows.Input;
using TopShopClient.Models;

namespace TopShopClient.ViewModels.Product
{
    public class CreateEditViewModel : BaseViewModel
    {
        public ICommand PhotoUploadCommand { get; }
        public Category SelectedCategory { get; set; }
        public Brand SelectedBrand { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<Brand> Brands { get; set; }

        private ImageSource _productPhoto;
        public ImageSource ProductPhoto { 
            get => _productPhoto;
            set
            {
                _productPhoto = value;
                OnPropertyChanged("ProductPhoto");
            }
        }

        private string _productPhotoName;
        public string ProductPhotoName
        {
            get => _productPhotoName;
            set
            {
                _productPhotoName = value;
                OnPropertyChanged("ProductPhotoName");
            }
        }

        public CreateEditViewModel(IList<Category> categories, IList<Brand> brands)
        {
            Categories = categories ?? throw new ArgumentNullException(nameof(categories));
            Brands = brands ?? throw new ArgumentNullException(nameof(brands));
            PhotoUploadCommand = new Command(async () => await ExecutePhotoUploadCommand());
        }

        private async Task<FileResult> ExecutePhotoUploadCommand()
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(PickOptions.Default);

                if(result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                       result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        var stream = await result.OpenReadAsync();
                        ProductPhoto = ImageSource.FromStream(() => stream);
                        ProductPhotoName = result.FileName;
                    }

                    return result;
                }

            } 
            catch (Exception e)
            {

            }

            return null;
        }
    }
}
