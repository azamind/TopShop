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
                var FileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] {"public.product.images"} },
                    { DevicePlatform.Android, new[] {"product/images"} },
                    { DevicePlatform.WinUI, new[] {".jpg", ".png"} },
                    { DevicePlatform.Tizen, new[] {"*/*"} },
                    { DevicePlatform.macOS, new[] {"jpg", "png"} },
                });
                var options = new PickOptions
                {
                    PickerTitle = "Please select a product file",
                    FileTypes = FileType,
                };
                var result = await FilePicker.PickAsync(options);

                if(result != null)
                {
                    var Text = $"File Name: {result.FileName}";
                    if(result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                       result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase))
                    {
                        var stream = await result.OpenReadAsync();
                        var Image = ImageSource.FromStream(() => stream);
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
