using System.Windows.Input;
using TopShopClient.Models;
using TopShopClient.Services;

namespace TopShopClient.ViewModels.Product
{
    public class CreateEditViewModel : BaseViewModel
    {
        public ICommand SaveCommand { get; set; }
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

        private Models.Product _productData;

        public Models.Product ProductData
        {
            get => _productData;
            set
            {
                _productData = value;
                OnPropertyChanged(nameof(ProductData));
            }
        }

        private ProductsService _productService = new ProductsService();

        public CreateEditViewModel(IList<Category> categories, IList<Brand> brands)
        {
            Categories = categories ?? throw new ArgumentNullException(nameof(categories));
            Brands = brands ?? throw new ArgumentNullException(nameof(brands));
            PhotoUploadCommand = new Command(async () => await ExecutePhotoUploadCommand());
            SaveCommand = new Command(SaveProductDataCommand);
            ProductData = new Models.Product();
        }

        public override void Initialize(object parameter)
        {
            if (parameter == null)
                ProductData = new Models.Product();
            else
                ProductData = parameter as Models.Product;
        }   

        private async void SaveProductDataCommand()
        {
            await _productService.AddProductAsync(ProductData);
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
