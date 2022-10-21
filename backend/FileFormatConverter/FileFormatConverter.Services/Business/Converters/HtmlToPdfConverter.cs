using FileFormatConverter.Core.Utils;
using FileFormatConverter.Services.Interfaces.Business.Interfaces;
using FileFormatConverter.Services.Interfaces.Business.Models.Enums;
using FileFormatConverter.Services.Interfaces.Business.Models.Output;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileFormatConverter.Services.Business.Converters
{
    public class HtmlToPdfConverter : IFileConverter
    {
        public ConverterType ConverterType => ConverterType.HTML_TO_PDF;

        public async Task<OutputFileInfo> Convert(string originFilePath)
        {
            var output = new OutputFileInfo();

            var content = await File.ReadAllTextAsync(originFilePath);

            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();

            var options = new LaunchOptions
            {
                Headless = true,
            };

            var pdfOptions = new PdfOptions
            {
                Format = PaperFormat.A4,
                Landscape = true,
                PrintBackground = true,
                PreferCSSPageSize = false,
                Scale = 0.5M
            };

            using (var browser = await Puppeteer.LaunchAsync(options))
            using (var page = await browser.NewPageAsync())
            {
                await page.EmulateMediaTypeAsync(MediaType.Screen);
                await page.SetContentAsync(content);

                var fileName = $"html_to_pdf_{DateTime.Now.ToFullString()}.pdf";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "converted");

                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                var fullPath = Path.Combine(filePath, fileName);
                await page.PdfAsync(fullPath, pdfOptions);

                output.FilePath = fullPath;
            }

            return output;
        }
    }
}
