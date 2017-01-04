using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Pdf;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MainUI_UWP.Yair
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class pdfViewerPage : Page
    {

        public ObservableCollection<BitmapImage> PdfPages
        {
            get;
            set;
        } = new ObservableCollection<BitmapImage>();


        public async System.Threading.Tasks.Task<PdfDocument> OpenLocal()
        {
            StorageFolder sf = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile storageFile = await StorageFile.GetFileFromPathAsync(sf.Path+"\\pdf.pdf");
            PdfDocument pdfDoc = await PdfDocument.LoadFromFileAsync(storageFile);
            return pdfDoc;
        }

        public async void Load(PdfDocument pdfDoc)
        {
            PdfPages.Clear();

            for (uint i = 0; i < pdfDoc.PageCount; i++)
            {
                BitmapImage image = new BitmapImage();

                var page = pdfDoc.GetPage(i);

                using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                {
                    await page.RenderToStreamAsync(stream);
                    await image.SetSourceAsync(stream);
                }

                PdfPages.Add(image);
            }
        }


        public pdfViewerPage()
        {
            this.InitializeComponent();
            try
            {
                PdfDocument pdf = OpenLocal().Result;
                Load(pdf);
            }
            catch (Exception ex)
            {

            }

        }
    }
}
