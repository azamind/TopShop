using System.Windows.Input;
using TopShopClient.Models;
using TopShopClient.Services;

namespace TopShopClient.ViewModels.Product
{
    public class CreateEditViewModel : BaseViewModel
    {
        public Models.Product Product { get; private set; }
        private ProductsService _productService = new ProductsService();
        public ICommand SaveCommand { get; set; }
        public ICommand PhotoUploadCommand { get; }
        public IList<Category> Categories { get; set; }
        public IList<Brand> Brands { get; set; }
        public IList<Models.Size> Sizes { get; set; }
        public Brand SelectedBrand { get; set; }
        public Category SelectedCategory { get; set; }

        private IList<ProductPhoto> _productPhotos;
        public IList<ProductPhoto> ProductPhotos
        {
            get => _productPhotos;
            set
            {
                _productPhotos = value;
                OnPropertyChanged("ProductPhotos");
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

        private ImageSource _path;
        public ImageSource Path
        {
            get => _path;
            set
            {
                _path = value;
                OnPropertyChanged("Path");
            }
        }

        public string Title
        {
            get => Product.Title;
            set
            {
                if (Product.Title != value)
                {
                    Product.Title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        public string Code
        {
            get => Product.Code;
            set
            {
                if (Product.Code != value)
                {
                    Product.Code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        public string Article
        {
            get => Product.Article;
            set
            {
                if (Product.Article != value)
                {
                    Product.Article = value;
                    OnPropertyChanged("Article");
                }
            }
        }

        public decimal? Price
        {
            get => Product.Price;
            set
            {
                if (Product.Price != value)
                {
                    Product.Price = value;
                    OnPropertyChanged("Price");
                }
            }
        }

        public string Description
        {
            get => Product.Description;
            set
            {
                if (Product.Description != value)
                {
                    Product.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public string ShortDescription
        {
            get => Product.ShortDescription;
            set
            {
                if (Product.ShortDescription != value)
                {
                    Product.ShortDescription = value;
                    OnPropertyChanged("ShortDescription");
                }
            }
        }

        private IList<object> _selectedSizes;
        public IList<object> SelectedSizes
        {
            get => _selectedSizes;
            set
            {
                _selectedSizes = value;
                OnPropertyChanged("SelectedSizes");
            }
        }

        public CreateEditViewModel(IList<Category> categories, IList<Brand> brands, IList<Models.Size> sizes)
        {
            Product = new Models.Product();
            Categories = categories ?? throw new ArgumentNullException(nameof(categories));
            Brands = brands ?? throw new ArgumentNullException(nameof(brands));
            Sizes = sizes ?? throw new ArgumentNullException(nameof(sizes));
            PhotoUploadCommand = new Command(ExecutePhotoUploadCommand);
            SaveCommand = new Command(SaveProductDataCommand);
        }  

        private async void SaveProductDataCommand()
        {
            var selectedSizes = SelectedSizes.Cast<Models.Size>().Select(s => s.Id).ToArray();

            Models.Product ProductData = new Models.Product
            {
                Title = Product.Title,
                BrandId = SelectedBrand.Id,
                CategoryId = SelectedCategory.Id,
                Code = Product.Code,
                Article = Product.Article,
                Price = Product.Price,
                Description = Product.Description,
                ShortDescription = Product.ShortDescription,
                Sizes = selectedSizes,
            };

            await _productService.AddProductAsync(ProductData, ProductPhotoName);

            await Shell.Current.GoToAsync("..");
        }

        private async void ExecutePhotoUploadCommand()
        {
            try
            {
                PickOptions options = new PickOptions { FileTypes = FilePickerFileType.Images, PickerTitle = "Select Product Photos"};
                FileResult result = await FilePicker.PickAsync(options);

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    Path = ImageSource.FromStream(() => stream);
                    ProductPhotoName = await _productService.UploadPhoto(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }

}
