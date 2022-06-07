using NativeMedia;
using System.Text.Json;
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

        public string _productPhotoName;
        public string ProductPhotoName
        {
            get => _productPhotoName;
            set
            {
                _productPhotoName = value;
                OnPropertyChanged("ProductPhotoName");
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

        public int? SelectedBrandId
        {
            get => null;
            set
            {
                if(Product.BrandId != value)
                {
                    Product.BrandId = value;
                    OnPropertyChanged("SelectedBrandId");
                }
            }
        }

        public int? SelectedCategoryId
        {
            get => null;
            set
            {
                if (Product.CategoryId != value)
                {
                    Product.CategoryId = value;
                    OnPropertyChanged("SelectedCategoryId");
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

        public ImageSource _path;
        public ImageSource Path
        {
            get => _path;
            set
            {
                _path = value;
                OnPropertyChanged("Path");
            }
        }

        public CreateEditViewModel(IList<Category> categories, IList<Brand> brands)
        {
            Product = new Models.Product();
            Categories = categories ?? throw new ArgumentNullException(nameof(categories));
            Brands = brands ?? throw new ArgumentNullException(nameof(brands));
            PhotoUploadCommand = new Command(ExecutePhotoUploadCommand);
            SaveCommand = new Command(SaveProductDataCommand);
        }  

        private async void SaveProductDataCommand()
        {
            Models.Product ProductData = new Models.Product
            {
                Title = Product.Title,
                BrandId = Product.BrandId,
                CategoryId = Product.CategoryId,
                Code = Product.Code,
                Article = Product.Article,
                Price = Product.Price,
                Description = Product.Description,
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
