﻿using System.Windows.Input;

namespace TopShopClient.ViewModels.Product
{
    public class CreateEditViewModel : BaseViewModel
    {
        public ICommand PhotoUploadCommand { get; set; }

        public CreateEditViewModel()
        {
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