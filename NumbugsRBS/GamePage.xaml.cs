using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace NumbugsRBS
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class GamePage : NumbugsRBS.Common.LayoutAwarePage
    {
        String chosenBugs = null;
        private bool _isDragging;
        private Point panelOffset;
        public GamePage()
        {
            this.InitializeComponent();
            moveImage(stackImage1);
            moveImage(stackImage2);
            moveImage(stackImage3);
            moveImage(stackImage4);
            moveImage(stackImage5);
            moveImage(stackImage6);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            chosenBugs = e.Parameter.ToString();
            tbTest.Text = chosenBugs;
           // decodeBugs();
            
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

       /* private String checkBugs(char character)
        {
            Ant defaultAnt= new Ant();
            switch (character)
            {
                case 'a':
                   // Ant ant = new Ant();
                     
                    String path1 = @"Assets/ant.png";
                    return path1;    
                //img3.Source = new BitmapImage(new Uri(this.BaseUri, path));
                                
                    
                case 'r':
                    //Roach roach = new Roach();
                    String path2 = @"Assets/roach.png";
                    return path2;
                    
                case 'l':
                    //Ladybird ladybird = new Ladybird();
                    String path3 = @"Assets/ladybug.png";
                    return path3;
                    
                case 'm':
                    //Moth moth = new Moth();
                    String path4 = @"Assets/moth.png";
                    return path4;
                   
                case 'w':
                    //Wasp wasp = new Wasp();
                    String path5 = @"Assets/wasp.jpg";
                    return path5;
                    
                default:
                    return "";
               }
        }
        * */
        /*private int createValues(char character)
        {
            switch (character)
            {
                case 'a':
                    Ant ant = new Ant();
                    int value1 = ant.value_Renamed;
                    return value1;
                    
                case 'm':
                    Moth moth = new Moth();
                    int value2 = moth.value_Renamed;
                    return value2;
                    
                case 'l':
                    Ladybird ladybird = new Ladybird();
                    int value3 = ladybird.value_Renamed;
                    return value3;
                    
                case 'r':
                    Roach roach = new Roach();
                    int value4 = roach.value_Renamed;
                    return value4;
                    
                case 'w':
                    Wasp wasp = new Wasp();
                    int value5 = wasp.value_Renamed;
                    return value5;
                default:
                    return 0;
            }
        }
        private void decodeBugs()
        { 
            char[] arrayOfBugs = chosenBugs.ToCharArray();
            String path1 = checkBugs(arrayOfBugs[0]);
           img1.Source = new BitmapImage(new Uri(this.BaseUri, path1));
           String path2 = checkBugs(arrayOfBugs[1]);
           img2.Source = new BitmapImage(new Uri(this.BaseUri, path2));
           String path3 = checkBugs(arrayOfBugs[2]);
           img3.Source = new BitmapImage(new Uri(this.BaseUri, path3));
           String path4 = checkBugs(arrayOfBugs[3]);
           img4.Source = new BitmapImage(new Uri(this.BaseUri, path4));
           String path5 = checkBugs(arrayOfBugs[4]);
           img5.Source = new BitmapImage(new Uri(this.BaseUri, path5));
           String path6 = checkBugs(arrayOfBugs[5]);
           img6.Source = new BitmapImage(new Uri(this.BaseUri, path6));
           tbimg1.Text = createValues(arrayOfBugs[0]).ToString();
           tbimg2.Text = createValues(arrayOfBugs[1]).ToString();
           tbimg3.Text = createValues(arrayOfBugs[2]).ToString();
           tbimg4.Text = createValues(arrayOfBugs[3]).ToString();
           tbimg5.Text = createValues(arrayOfBugs[4]).ToString();
           tbimg6.Text = createValues(arrayOfBugs[5]).ToString();
                      
        }
         * */
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void moveImage(StackPanel stackImage)
        {            
            stackImage.PointerPressed += sp1_PointerPressed;
            stackImage.PointerReleased += sp1_PointerReleased;
            stackImage.PointerMoved += sp1_PointerMoved;
        }

        private void sp1_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            stackPanel.ReleasePointerCapture(e.Pointer);
            _isDragging = false;
        }
        private void checkPosition(double posX, double posY)
        {
            if ((posX > 80 && posX < 110) && (posY > 565 && posY < 585))
                tbX.Text = "In the area";
        }
        private void sp1_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (_isDragging)
            {
                var stackPanel = sender as StackPanel;

                
                var pos = e.GetCurrentPoint(canvas).Position;
                tbY.Text = ("onMoved Stack position: " + pos.Y.ToString());
                tbX.Text = ("onMoved Stack position: " + pos.X.ToString());
                checkPosition(pos.X, pos.Y);
           
                Canvas.SetLeft(stackPanel, pos.X - panelOffset.X);
                Canvas.SetTop(stackPanel, pos.Y - panelOffset.Y);
            }
        }

        private void sp1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            panelOffset = e.GetCurrentPoint(stackPanel).Position;
            tbY.Text = ("onStackPressed position: " + panelOffset.Y.ToString());
            tbX.Text = ("onStackPressed position: " + panelOffset.X.ToString());
            _isDragging = true;
            stackPanel.CapturePointer(e.Pointer);
            e.Handled = true;
        }

       

    }
}
