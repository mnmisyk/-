using Alturos.Yolo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yolo
{
    class Program
    {
        static void Main(string[] args)
        {

            //The download takes some time depending on the internet connection.
            //var repository = new YoloPreTrainedDatasetRepository();
            //var task= repository.DownloadDatasetAsync("YOLOv3", ".");
            //task.Wait();

            var configurationDetector = new ConfigurationDetector();
            var config = configurationDetector.Detect();
            using (var yoloWrapper = new YoloWrapper(config))
            {
                var items = yoloWrapper.Detect(@"IMG_2072.JPG");
                //items[0].Type -> "Person, Car, ..."
                //items[0].Confidence -> 0.0 (low) -> 1.0 (high)
                //items[0].X -> bounding box
                //items[0].Y -> bounding box
                //items[0].Width -> bounding box
                //items[0].Height -> bounding box
            }
            Console.ReadKey();
        }
    }
}
