using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using QRCoder;
namespace CSAT.DAL.Helpers
{
    public class QRGenerator
    {
        /// <summary>
        /// Refer : https://github.com/codebude/QRCoder
        /// QR Code implementation class 
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public byte[] GenerateQRCode(string Code)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                    {
                        using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(Code, QRCodeGenerator.ECCLevel.Q))
                        {
                            using (QRCode qrCode = new QRCode(qrCodeData))
                            {
                                using (Bitmap bitMap = qrCode.GetGraphic(20))
                                {
                                    bitMap.Save(ms, ImageFormat.Png);
                                    return ms.ToArray();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
