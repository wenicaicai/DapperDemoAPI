using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using ServiceLifeCycle;

namespace DapperDemoAPI.Controllers
{
    public class HomeController : Controller
    {
        public OperationService OperationService { get; }

        public IOperationSingleton OperationSingleton { get; }

        public IOperationScoped OperationScoped { get; }

        public IOperationTransient OperationTransient { get; }

        public string Result = string.Empty;
        public HomeController(OperationService operationService,
            IOperationTransient operationTransient,
            IOperationScoped operationScoped,
            IOperationSingleton operationSingleton)
        {
            OperationService = operationService;
            OperationTransient = operationTransient;
            OperationScoped = operationScoped;
            OperationSingleton = operationSingleton;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string txtQRCode)
        {
            QRCodeGenerator _qrCode = new QRCodeGenerator();
            QRCodeData _qrCodeData = _qrCode.CreateQrCode(txtQRCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(_qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return View(BitmapToBytesCode(qrCodeImage));
        }

        [NonAction]
        private static Byte[] BitmapToBytesCode(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }


        public IActionResult ServiceLifeCycle()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Hello.  .    .");
            stringBuilder.Append($"瞬时:{OperationTransient.OperationId}");
            stringBuilder.Append($"作用域:{OperationScoped.OperationId}");
            stringBuilder.Append($"单例:{OperationSingleton.OperationId}");
            stringBuilder.Append("-----------------------------------");
            stringBuilder.Append($"瞬时:{OperationService.OperationTransient.OperationId}");
            stringBuilder.Append($"作用域:{OperationService.OperationScoped.OperationId}");
            stringBuilder.Append($"单例:{OperationService.OperationSingleton.OperationId}");
            stringBuilder.Append("World.  .   .     .");
            Result = stringBuilder.ToString();
            return Content(Result);
        }

        public IActionResult UseFilter()
        {
            return Content("use F12 to see detail.");
        }
    }
}