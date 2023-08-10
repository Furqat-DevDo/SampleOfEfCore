﻿using EfCore.Entities;
using EfCore.Models.Requests;
using EfCore.Models.Responses;

namespace EfCore.Mappers;

public static class StorageMapper
{
    public static void UpdateStorage(this Storage storage, UpdateStorageRequest request)
    {
        storage.Name = request.Name;
        storage.Adrress = request.Adrress;
    }

    public static GetStorageResponse ToResponseStorage(this Storage storage)
   => new GetStorageResponse
   {
       Name = storage.Name,
       Adress = storage.Adrress,
       ProductIds = storage.ProductIds,
       
   };

    public static Storage ToCreateStorage(this CreateStorageRequest storage)
    => new Storage
    {
       Name = storage.Name,
       Adrress = storage.Adrress,
       ProductIds = storage.ProductIds,
       
    };
}
