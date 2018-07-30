//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Blob;

//namespace PuffyAmiYumi.Models
//{
//    public class Blob
//    {
//        public CloudStorageAccount CloudStorageAccount { get; set; }
//        public CloudBlob CloudBlobClient { get; set; }
//        public async void GetContainer(string containerName)
//        {
//            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName)
//            await cbc.createIfNotExistsAsync();
//        }


//        public Blob(string storageAccountName, string accessKey)
//        {

//        }
//    }
//}
