namespace EfCore.Helpers;

public static  class FileHelper
{
    private static string destination = "./Files/File";
    public static async Task<(string,Guid)> SaveFormFileAsync(IFormFile formFile)
    {
        if (formFile == null)
            throw new ArgumentNullException(nameof(formFile));

        if (!Directory.Exists(destination))
        {
            Directory.CreateDirectory(destination);
        }

        var fileId = Guid.NewGuid();
        string fileExtension = Path.GetExtension(formFile.FileName);
        string fileName = fileId.ToString("N") + fileExtension;
        string destinationFilePath = Path.Combine(destination, fileName);

        using FileStream destinationStream = File.Create(destinationFilePath);
        await formFile.CopyToAsync(destinationStream);
        

        return (destinationFilePath,fileId);
    }
}
