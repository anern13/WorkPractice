using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.IO.Pipelines;

namespace FIrstWebApplication
{

    public class Todo
    {
        const string fs_root = "C:\\projects\\FIrstWebApplication\\Attachments\\";
        const string download_path = "C:";

        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? FileName { get; set; }
        public string? guid { get; set; }
        public string ServFilePath
        {
            get => Path.Combine(fs_root, guid + Path.GetExtension(FileName));
        }

        /*****************************************************************************/

        ~Todo() { Delete(); }
        /*****************************************************************************/

        public async Task Upload(PipeReader file)
        {
            guid = Guid.NewGuid().ToString();
            using var stream = File.OpenWrite(ServFilePath);
            await file.CopyToAsync(stream);
        }
        /*****************************************************************************/

        public bool IsOnServer()
        {
            return File.Exists(ServFilePath);
        }
        /*****************************************************************************/

        public void Delete()
        {
            File.Delete(ServFilePath);
            guid = null;
        }
        /*****************************************************************************/
    }
}
