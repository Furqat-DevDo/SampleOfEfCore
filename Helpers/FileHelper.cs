namespace EfCore.Helpers;

public static  class FileHelper
{
    private static string destination = "./Files/File";
    private static ILoggerFactory _logger = new LoggerFactory();
    public static async Task<(string,Guid)> SaveFormFileAsync(IFormFile formFile)
    {
        if (formFile == null)
        {
            var logger = _logger.CreateLogger(typeof(FormFile));
            logger.LogError($"Could not read the file for saving");
            throw new ArgumentNullException(nameof(formFile));
        }
            

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

    public async static Task<byte[]> ReadFileFromPathAsync(string filePath)
    { 
        if(filePath == null || !File.Exists(filePath)) 
        {
            var logger = _logger.CreateLogger(typeof(FormFile));
            logger.LogError($"Could not read the file from path : {filePath}, file does not exists !!!");
            throw new FileNotFoundException("An error occurred when reading the file");
        }

        byte[] byteArray = new byte[0];

        try
        {
            byteArray =  await File.ReadAllBytesAsync(filePath);
        }
        catch (Exception ex)
        {
            var logger = _logger.CreateLogger(typeof(FormFile));
            logger.LogError($"Could not read the file from path : {filePath}");
            throw new FileLoadException("An error occurred: " + ex.Message);
        }

        return byteArray;
        
    }
}
