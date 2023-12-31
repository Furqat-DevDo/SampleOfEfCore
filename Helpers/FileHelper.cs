﻿namespace EfCore.Helpers;

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

    public async static Task<byte[]> ReadFileFromPathAsync(string filePath)
    {
        
        // TODO Check FilePath IsExist and is not null

        byte[] byteArray = new byte[0];

        try
        {
            byteArray =  await File.ReadAllBytesAsync(filePath);
        }
        catch (Exception ex)
        {
            // TODO inside of catch block do not hide exception throw it untill controller
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        return byteArray;
        
    }
}
