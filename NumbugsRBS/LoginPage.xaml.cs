using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Security.Cryptography;
using System.Text;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace NumbugsRBS
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class LoginPage : NumbugsRBS.Common.LayoutAwarePage
    {
        StorageFolder storageFolder = KnownFolders.DocumentsLibrary;
        public const string filename = "sample.dat";
        public StorageFile sampleFile = null;
        int difficulty = 0;
        int gamesPlayed = 0;
        public Player player;
        String name;
        int age;
        public LoginPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }
        private int determineDifficulty()
        {

            if (age < 8)
                return 1;     
            if (age < 12)
                return 2;
            if (age < 15)
                return 3;
            else return 0;
        }
       /* private async void writeToFile()
        {
            try
            {
                sampleFile = await Windows.Storage.KnownFolders.DocumentsLibrary.GetFileAsync(filename);
            }
            catch (FileNotFoundException)
            {
                // sample file doesn't exist so scenario one must be run
            }
                try
            {
              
                StorageFile file = sampleFile;
                if (file != null)
                {
                    

                    if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(age.ToString()))
                    {
                        using (StorageStreamTransaction transaction = await file.OpenTransactedWriteAsync())
                        {
                            using (DataWriter dataWriter = new DataWriter(transaction.Stream))
                            {
                                dataWriter.WriteString(name);
                                dataWriter.WriteString(age.ToString());
                                transaction.Stream.Size = await dataWriter.StoreAsync(); // reset stream size to override the file
                                await transaction.CommitAsync();
                                //OutputTextBlock.Text = "The following text was written to '" + file.Name + "' using a stream:" + Environment.NewLine + Environment.NewLine + userContent;
                            }
                        }
                    }
                    else
                    {
                        //OutputTextBlock.Text = "The text box is empty, please write something and then click 'Write' again.";
                    }
                }
            }
            catch (FileNotFoundException)
            {
               
            }
        }
        */

        public static async void WriteMe(string filename, string contents)
        {
            var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var folder = await localFolder.CreateFolderAsync("DataCache", Windows.Storage.CreationCollisionOption.OpenIfExists);
            var file = await folder.CreateFileAsync(filename, Windows.Storage.CreationCollisionOption.ReplaceExisting);
            var fs = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
            var outStream = fs.GetOutputStreamAt(0);
            var dataWriter = new Windows.Storage.Streams.DataWriter(outStream);
            Player player = new Player();
            //dataWriter.WriteBytes(player);
            await dataWriter.StoreAsync();
            dataWriter.DetachStream();
            await outStream.FlushAsync();
        }
       

        private async void AppendSaveClicked()
        {
            try
            {
                sampleFile = await Windows.Storage.KnownFolders.DocumentsLibrary.GetFileAsync(filename);
            }
            catch (FileNotFoundException)
            {
                // sample file doesn't exist so scenario one must be run
            }

            StorageFile file = sampleFile;
            if (file != null)
            {
                string userContent = "" + name + ";" + age + ";" + difficulty + ";" + gamesPlayed + ".\n";
                if (!String.IsNullOrEmpty(userContent))
                {
                    using (IRandomAccessStream sessionRandomAccess =
                        await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        Stream stream = sessionRandomAccess.AsStreamForWrite();
                        if (stream.Length > 0)
                        {
                            stream.Seek(stream.Length, SeekOrigin.Begin);
                        }
                        byte[] array = Encoding.UTF8.GetBytes(userContent);
                        stream.SetLength(stream.Length + array.Length);

                        await stream.WriteAsync(array, 0, array.Length);
                        await stream.FlushAsync();

                        await sessionRandomAccess.FlushAsync();
                    }

                }

            }

        }
        private void btnLevel_Click(object sender, RoutedEventArgs e)
        {
            name = tBoxName.Text;
            age = int.Parse(tBoxAge.Text);
           difficulty= determineDifficulty();
           player = new Player(name, age, difficulty, gamesPlayed);
            AppendSaveClicked();
           if (this.Frame != null)
            {
               this.Frame.Navigate(typeof(LevelPage));
            }
        }
        
        private void tBoxName_GotFocus(object sender, RoutedEventArgs e)
        {
            tBoxName.Text = "";
            tBoxName.FontStyle = Windows.UI.Text.FontStyle.Normal;       
        }

        private void tBoxAge_GotFocus(object sender, RoutedEventArgs e)
        {
            tBoxAge.Text = "";
            tBoxAge.FontStyle = Windows.UI.Text.FontStyle.Normal;
        }

        private void tBoxAge_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(e.Key.ToString(), "[0-9]"))
                e.Handled = false;
            else e.Handled = true;
        }



        
      

       
  
        

        
    }
}

