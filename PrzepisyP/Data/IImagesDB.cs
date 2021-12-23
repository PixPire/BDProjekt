using PrzepisyP.Models;

namespace PrzepisyP.Data
{
    public interface IImagesDB
    {
        //Returns an image of a given id from database
        public Image GetImage(string imageId);

        //Adds an image to the database
        public void Add(Image image);

        //Updates an image, the image to update is based on the id of image given as parameter
        public void Update(Image image);

        //Deletes an image with a given id string
        public void Delete(string imageId);
    }
}
