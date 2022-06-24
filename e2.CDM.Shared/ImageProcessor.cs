using System.Threading.Tasks;
using System.IO;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Csla;
using Csla.Data;
using System.Drawing;
//using Syncfusion.Drawing;

namespace e2.CDM.Lib
{

  [Serializable()]
  public class ImageProcessor
  {
    public ImageProcessor()
    {

    }

#if !NETFX_CORE
    public static async Task<System.Drawing.Size> GetImageSizeAsync(byte[] file)
    {
      var imageSize = System.Drawing.Image.FromStream(new System.IO.MemoryStream(file));
      var size = imageSize.Size;
      return size;
    }
#endif
  }

}