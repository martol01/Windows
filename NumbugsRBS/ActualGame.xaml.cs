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
    public sealed partial class ActualGame : NumbugsRBS.Common.LayoutAwarePage
    {

        private int targetToMake;
        private int[] targets;
        private bool _isDragging;
        private Point panelOffset;
        private bool firstBug = false;
        private bool secondBug = false;
        private bool signChosen = false;
        String chosenBugs = null;
        private String sign=null;
        int number1;
        int number2;
        Random rand = new Random();
 
        public ActualGame()
        {
            this.InitializeComponent();
 //           chosenBugs = e.Pararmeter.ToString();
   //         tbTest.Text = chosenBugs;
            createTargets();
            setTarget();
            decodeBugs();
            checkMe();
            moveImage(stackImage1);
            moveImage(stackImage2);
            moveImage(stackImage3);
            moveImage(stackImage4);
            moveImage(stackImage5);
            moveImage(stackImage6);
            moveImage(stackPlus);
            moveImage(stackMinus);
            moveImage(stackTimes);
            moveImage(stackDivision);





        }
        private void createTargets()
        {
            
            targets = new int[15];
            for (int i = 0; i < targets.Length; i++)
            {
                targets[i] = rand.Next(101, 999);
            }
            
       }
        private void setTarget()
        { 
            int index = 0;
            index = rand.Next(0, 14);
            targetToMake = targets[index];
            tbTarget.Text = targets[index].ToString();
            

        }
        private void checkMe()
        {
            if (stackImage1.Children.Contains(img1))
                tbX.Text = "YES IT IS";
            
        }
        private bool checkSignPosition(double x, double y)
        {
            if ((x > 305 && x < 335) && (y > 450 && y < 480))
                //tbX.Text = "Sign in the area";
                return true;
            else return false;
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
        private bool checkPositionOne(double posX, double posY)
        {
            if ((posX > 155 && posX < 230) && (posY > 420 && posY < 480))
                return true;
            else
                return false;
        }
        private bool checkPositionTwo(double posX, double posY)
        {
            if ((posX > 470 && posX < 535) && (posY > 420 && posY < 480))
                return true;
            else
                return false;
        }
        private void sp1_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            int result=0;
            if (_isDragging)
            {
                var stackPanel = sender as StackPanel;
                var pos = e.GetCurrentPoint(canvas).Position;
                tbY.Text = ("onMoved Stack position: " + pos.Y.ToString());
                tbX.Text = ("onMoved Stack position: " + pos.X.ToString());
                tbString.Text = stackPanel.Name;

                firstBug = checkPositionOne(pos.X, pos.Y);
                if (firstBug == true)
                {
                    number1 = int.Parse(stackImageChosen(stackPanel.Name));
                    tbResult.Text = "first here";
                }
                    secondBug = checkPositionTwo(pos.X, pos.Y);
                    if (secondBug == true)
                    {
                        number2 = int.Parse(stackImageChosen(stackPanel.Name));
                        tbResult.Text = "second here";
                    }
                signChosen = checkSignPosition(pos.X, pos.Y);
                if (signChosen == true)
                {
                    sign = checkChosenSign(stackPanel.Name);
                    //result = calculateResult(stackPanel.Name);
                    tbResult.Text = sign;
                }
                result = calculateResult(sign);
                
                    tbResult.Text = result.ToString();
                Canvas.SetLeft(stackPanel, pos.X - panelOffset.X);
                Canvas.SetTop(stackPanel, pos.Y - panelOffset.Y);
            }
        }

       
        private void sp1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            var stacky = sender as StackPanel;
            panelOffset = e.GetCurrentPoint(stacky).Position;
            tbY.Text = ("onStackPressed position: " + panelOffset.Y.ToString());
            tbX.Text = ("onStackPressed position: " + panelOffset.X.ToString());
            _isDragging = true;
            stacky.CapturePointer(e.Pointer);
            e.Handled = true;
        }
        private String checkChosenSign(String name)
        {
            switch (name)
            {
                case "stackPlus":
                    return "+";
                case "stackMinus":
                    return "-";
                case "stackTimes":
                    return "*";
                case "stackDivision":
                    return "/";
                default:
                    return "";
            }
        }
        private String stackImageChosen(String name)
        {
            switch (name)
            {
                case "stackImage1":
                    return tb1.Text;
                case "stackImage2":
                    return tb2.Text;
                case "stackImage3":
                    return tb3.Text;
                case "stackImage4":
                    return tb4.Text;
                case "stackImage5":
                    return tb5.Text;
                case "stackImage6":
                    return tb6.Text;
                default:
                    return "";
            }
        }
        private int calculateResult(String signOperator)
        {
            switch (signOperator)
            {
                case "+":
                    if (number1 != 0 && number2 != 0)
                        return (number1 + number2);
                    else return 0;
                case "-":
                    if (number1 != 0 && number2 != 0)
                        return (number1 - number2);
                    else return 0;
                case "*":
                    if (number1 != 0 && number2 != 0)
                        return (number1 * number2);
                    else return 0;
                case "/":
                    if (number1 != 0 && number2 != 0 && (number1 % number2 == 0))
                        return (number1 / number2);
                    else
                        
                        return 0;
                default:
                    return 0;
            }


            
        }
        private String checkBugs(char character)
        {
            Ant defaultAnt = new Ant();
            switch (character)
            {
                case 'a':
                    String path1 = @"Assets/ant.png";
                    return path1;
                case 'r':
                    String path2 = @"Assets/roach.png";
                    return path2;
                case 'l':
                    String path3 = @"Assets/ladybug.png";
                    return path3;
                case 'm':
                    String path4 = @"Assets/moth.png";
                    return path4;
                case 'w':
                    String path5 = @"Assets/wasp.jpg";
                    return path5;
                default:
                    return "";
            }
        }
        private int createValues(char character)
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
            char[] arrayOfBugs = tbString.Text.ToCharArray();
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
            tb1.Text = createValues(arrayOfBugs[0]).ToString();
            tb2.Text = createValues(arrayOfBugs[1]).ToString();
            tb3.Text = createValues(arrayOfBugs[2]).ToString();
            tb4.Text = createValues(arrayOfBugs[3]).ToString();
            tb5.Text = createValues(arrayOfBugs[4]).ToString();
            tb6.Text = createValues(arrayOfBugs[5]).ToString();

        }
       













        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }
    }
}

