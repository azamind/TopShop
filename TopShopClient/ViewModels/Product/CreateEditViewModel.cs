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

        private List<ProductPhoto> _productPhotos;
        public List<ProductPhoto> ProductPhotos
        {
            get => _productPhotos;
            set
            {
                _productPhotos = value;
                OnPropertyChanged("ProductPhotos");
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
                var results = await FilePicker.PickMultipleAsync(new PickOptions
                {
                    FileTypes = FilePickerFileType.Images,
                    PickerTitle = "Select Product Photos"
                });

                var uploadPhotos = new List<ProductPhoto>();
                if (results != null)
                {
                    foreach(var result in results)
                    {
                        var stream = await result.OpenReadAsync();
                        var path = ImageSource.FromStream(() => stream);
                        uploadPhotos.Add(new ProductPhoto { Path = path });
                    }
                    ProductPhotos = (List<ProductPhoto>)uploadPhotos;
                }
            } 
            catch (Exception e)
            {

            }

            return null;
        }
    }
}
