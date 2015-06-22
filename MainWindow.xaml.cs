/*  Copyright (C) 2015 BalancedMz

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.IO;
using winForm = System.Windows.Forms;
using System.Windows.Media.Animation;

namespace HishoKan_InDeskop
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        HourClock hourClock;
        IdleClock idleClock;
        FileOrganizer fo;
        VoicePlayer player = new VoicePlayer();
        MenuItem menuItem_CG;
        winForm.NotifyIcon ni;

        bool registered;
        static readonly string configFile = "config.txt";

        public MainWindow()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            System.ComponentModel.IContainer cnt = new System.ComponentModel.Container();
            ni = new winForm.NotifyIcon(cnt);
            ni.Icon = new System.Drawing.Icon("Icon.ico");
            ni.Visible = true;
            ni.MouseUp += new winForm.MouseEventHandler(nfyico_MouseUp);

            registered = false;

            ContextMenu contextmenu = (ContextMenu)this.Resources["cm"];
            menuItem_CG = (MenuItem)contextmenu.Items[1];

            ReadConfig();       // folderName should have been assigned in this method.
            changeCharacter(Parameter.folderNameOnLoad);
            this.MouseLeftButtonUp += sp_MouseLeftButtonUp;
        }

        public void changeCharacter(string charFolderName)
        {
            if (Parameter.charCgOnLoad != null)
                SaveCharConfig();
            Parameter.folderNameOnLoad = charFolderName;
            fo.ChangeCharPath(charFolderName);
            ReadCharConfig(charFolderName, out Parameter.charCgOnLoad);

            if (Parameter.charCgOnLoad == null || Parameter.charCgOnLoad == string.Empty || !File.Exists(fo.GetCharFolderPath()))
                Parameter.charCgOnLoad = fo.GetAllImageName()[0];

            loadImage(fo.GetCharFolderPath() + Parameter.charCgOnLoad);

            RebuildCgMenu();
            if (Parameter.isLaunchVoiceEnabled)
                player.Play(fo.GetRandomStartFile());
        }

        private void RebuildCgMenu()
        {
            menuItem_CG.Items.Clear();
            foreach (string imgName in fo.GetAllImageName())
            {
                MenuItem cgItem = new MenuItem();
                cgItem.Header = imgName;
                cgItem.Tag = imgName;
                cgItem.Click += MenuItem_ChooseCharCG_Click;
                menuItem_CG.Items.Add(cgItem);
            }
        }

        private void loadImage(string fullImgPath)
        {

            sp.Children.Clear();
            
            Image img = new Image();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(fullImgPath);
            src.CacheOption = BitmapCacheOption.OnLoad;             //  for the picture to be loaded immediately
            src.EndInit();
            AdjustMainSize(src.PixelHeight, src.PixelWidth);

            double h = (Parameter.maxImgHeight > src.PixelHeight ? src.PixelHeight : Parameter.maxImgHeight);
            double w = (Parameter.maxImgWidth > src.PixelWidth ? src.PixelWidth : Parameter.maxImgWidth);

            img.Name = "Image";
            img.UseLayoutRounding = true;
            img.SnapsToDevicePixels = true;
            img.MaxHeight = h;
            img.MaxWidth = w;
            img.Source = src;
            img.HorizontalAlignment = HorizontalAlignment.Center;
            img.Margin = new Thickness(5.0);

            sp.Children.Add(img);

            if (registered)
                this.UnregisterName(img.Name);

            this.RegisterName(img.Name, img);
            registered = true;

            FadeIn(img);

            if(Parameter.useAnimation)
                ApplyAnimation(img , CalcZoom(h));
        }

        private void AdjustMainSize(double h, double w)
        {

            if (w > Parameter.maxImgWidth)
                this.Width = Parameter.maxImgWidth + 5.0;
            else
                this.Width = w + 5.0;

            if (h > Parameter.maxImgHeight)
                this.Height = Parameter.maxImgHeight + 5.0;
            else
                this.Height = h + 5.0;
        }

        private void ApplyAnimation(Image img , double zoomLevel)
        {
            img.RenderTransformOrigin = new Point(0.5, 0.5);
            ScaleTransform scale = new ScaleTransform(1.0, 1.0);
            img.RenderTransform = scale;

            Storyboard storyboardh = new Storyboard();
            Storyboard storyboardv = new Storyboard();

            DoubleAnimation growAnimation = new DoubleAnimation();
            growAnimation.Duration = TimeSpan.FromMilliseconds(3000);
            growAnimation.From = 1.0;
            growAnimation.To = zoomLevel;
            storyboardh.Children.Add(growAnimation);
            storyboardv.Children.Add(growAnimation);

            DoubleAnimation shrinkAnimation = new DoubleAnimation();
            shrinkAnimation.BeginTime = new TimeSpan(0, 0, 4);
            shrinkAnimation.Duration = new Duration(TimeSpan.FromSeconds(3));
            shrinkAnimation.From = zoomLevel;
            shrinkAnimation.To = 1.0;
            storyboardh.Children.Add(shrinkAnimation);
            storyboardv.Children.Add(shrinkAnimation);

            Storyboard.SetTargetProperty(growAnimation, new PropertyPath("RenderTransform.ScaleX"));
            Storyboard.SetTargetProperty(shrinkAnimation, new PropertyPath("RenderTransform.ScaleX"));
            Storyboard.SetTarget(growAnimation, img);
            Storyboard.SetTarget(shrinkAnimation, img);
            storyboardh.RepeatBehavior = RepeatBehavior.Forever;
            storyboardh.Begin();

            Storyboard.SetTargetProperty(growAnimation, new PropertyPath("RenderTransform.ScaleY"));
            Storyboard.SetTargetProperty(shrinkAnimation, new PropertyPath("RenderTransform.ScaleY"));
            Storyboard.SetTarget(growAnimation, img);
            Storyboard.SetTarget(shrinkAnimation, img);
            storyboardv.RepeatBehavior = RepeatBehavior.Forever;
            storyboardv.Begin();
        }

        private double CalcZoom(double pixel)
        {
            return (pixel + 10.0) / pixel;
        }

        private void FadeIn(Image img)
        {
            img.Opacity = 0;
            DoubleAnimation animation = new DoubleAnimation(1, TimeSpan.FromSeconds(1));
            img.BeginAnimation(Image.OpacityProperty, animation);       //Not Image.OpacityMaskProperty
        }

        public void ReloadImage()
        {
            loadImage(fo.GetCharFolderPath() + Parameter.charCgOnLoad);
        }

        #region Config Related

        private void ReadConfig()
        {
            try
            {
                using (StreamReader sr = new StreamReader(configFile))
                {
                    var dict = new Dictionary<string, string>();
                    string line;

                    while (!string.IsNullOrEmpty((line = sr.ReadLine())))
                    {
                        dict = File.ReadAllLines(configFile)
                       .Select(l => l.Split(new[] { '=' }))
                       .ToDictionary(s => s[0].Trim(), s => s[1].Trim());
                    }
                    ApplyConfig(dict);
                }
            }
            catch (IOException e)
            {
                ApplyDefaultConfig();
            }
        }

        private void ApplyDefaultConfig()
        {
            Parameter.folderNameOnLoad = ChooseCharFolder();
            Parameter.isTopMost = false;
            Parameter.useAnimation = true;
            Parameter.maxImgHeight = 800;
            Parameter.maxImgWidth = 600;
            Parameter.isClickVoiceEnabled = true;
            Parameter.isLaunchVoiceEnabled = true;
            Parameter.isIdleVoiceEnabled = true;
            Parameter.isClockVoiceEnabled = true;

            fo = new FileOrganizer(Parameter.folderNameOnLoad);
            hourClock = new HourClock(player, fo);
            idleClock = new IdleClock(player, fo);
            player.Volume = 0.3;
            configIdleVoice(true, 600);
        }

        private string ChooseCharFolder()
        {
            bool ok = false;
            do
            {
                winForm.FolderBrowserDialog fbd = new winForm.FolderBrowserDialog();
                fbd.Reset();
                fbd.SelectedPath = Directory.GetCurrentDirectory() + @"\chars";
                winForm.DialogResult result = fbd.ShowDialog();
                if (result == winForm.DialogResult.Cancel || result == winForm.DialogResult.Abort)
                    Application.Current.MainWindow.Close();
                else if (!FileOrganizer.FolderContainsImage(fbd.SelectedPath))
                {
                    MessageBox.Show("此資料夾沒有人物圖片!");
                }
                 else return System.IO.Path.GetFileName(fbd.SelectedPath);
            } while (!ok);

            return null;
        }

        private void ApplyConfig(Dictionary<string, string> dict)
        {
            try
            {
                this.Left = Convert.ToDouble(dict["coordinateX"]);
                this.Top = Convert.ToDouble(dict["coordinateY"]);
                player.Volume = Convert.ToDouble(dict["volume"]);

                if (!dict.ContainsKey("charFolder") || dict["charFolder"].Equals(string.Empty))
                {
                    Parameter.folderNameOnLoad = ChooseCharFolder();
                    MessageBox.Show(Parameter.folderNameOnLoad);
                }
                else if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\chars\" + dict["charFolder"]))
                    Parameter.folderNameOnLoad = ChooseCharFolder();
                else
                    Parameter.folderNameOnLoad = dict["charFolder"];

                fo = new FileOrganizer(Parameter.folderNameOnLoad);
                hourClock = new HourClock(player, fo);
                idleClock = new IdleClock(player, fo);

                Parameter.isTopMost = Convert.ToBoolean(dict["isTopMost"]);
                ContextMenu contextmenu = (ContextMenu)this.Resources["cm"];
                MenuItem topMost = (MenuItem)contextmenu.Items[3];
                topMost.IsChecked = Parameter.isTopMost;
                this.Topmost = Parameter.isTopMost;


                configLaunchVoice(Convert.ToBoolean(dict["isLaunchVoiceEnabled"]));
                configClockVoice(Convert.ToBoolean(dict["isClockVoiceEnabled"]));
                configIdleVoice(Convert.ToBoolean(dict["isIdleVoiceEnabled"]), Convert.ToInt32(dict["idleInterval"]) / 1000);
                configClickVoice(Convert.ToBoolean(dict["isClickVoiceEnabled"]));

                Parameter.maxImgHeight = Convert.ToDouble(dict["maxImgHeight"]);
                Parameter.maxImgWidth = Convert.ToDouble(dict["maxImgWidth"]);
                Parameter.useAnimation = Convert.ToBoolean(dict["useAnimation"]);
            }
            catch (KeyNotFoundException e)
            {

            }

        }

        private void SaveGeneral()
        {
            StreamWriter sw = new StreamWriter(configFile, false);
            sw.WriteLine("coordinateX = " + Application.Current.MainWindow.Left);       //http://stackoverflow.com/questions/9580067/getting-position-width-height-of-mainwindow
            sw.WriteLine("coordinateY = " + Application.Current.MainWindow.Top);
            sw.WriteLine("volume = " + player.Volume);
            sw.WriteLine("charFolder = " + Parameter.folderNameOnLoad);
            sw.WriteLine("isTopMost = " + Parameter.isTopMost);
            sw.WriteLine("isLaunchVoiceEnabled = " + Parameter.isLaunchVoiceEnabled);
            sw.WriteLine("isClockVoiceEnabled = " + Parameter.isClockVoiceEnabled);
            sw.WriteLine("isIdleVoiceEnabled = " + Parameter.isIdleVoiceEnabled);
            sw.WriteLine("idleInterval = " + Parameter.idleInterval);
            sw.WriteLine("isClickVoiceEnabled = " + Parameter.isClickVoiceEnabled);
            sw.WriteLine("maxImgWidth = " + Parameter.maxImgWidth);
            sw.WriteLine("maxImgHeight = " + Parameter.maxImgHeight);
            sw.WriteLine("useAnimation = " + Parameter.useAnimation);

            sw.Close();
        }

        private void SaveCharConfig()
        {
            StreamWriter sw = new StreamWriter(fo.GetCharFolderPath() + "config.cfg", false);
            sw.WriteLine("cg = " + Parameter.charCgOnLoad);
            sw.Close();
        }

        private void ReadCharConfig(string charFolderName, out string cgName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fo.GetCharFolderPath() + "config.cfg"))
                {
                    var dict = new Dictionary<string, string>();
                    string line;

                    while (!string.IsNullOrEmpty((line = sr.ReadLine())))
                    {
                        dict = File.ReadAllLines(fo.GetCharFolderPath() + "config.cfg")
                       .Select(l => l.Split(new[] { '=' }))
                       .ToDictionary(s => s[0].Trim(), s => s[1].Trim());
                    }
                    cgName = dict["cg"];
                }
            }
            catch (IOException e)
            {
                cgName = null;
            }
            catch (KeyNotFoundException e)
            {
                cgName = null;
            }
        }

        #endregion

        #region Events---------------------------------------------------------

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //readConfig();
        }

        private void MenuItem_ChangeTopMost_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;

            this.Topmost = !Parameter.isTopMost;
            menuItem.IsChecked = !Parameter.isTopMost;
            Parameter.isTopMost = !Parameter.isTopMost;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //http://stackoverflow.com/questions/2470685/how-do-you-disable-aero-snap-in-an-application

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // this prevents win7 aerosnap
                if (this.ResizeMode != System.Windows.ResizeMode.NoResize)
                {
                    this.ResizeMode = System.Windows.ResizeMode.NoResize;
                    this.UpdateLayout();
                }

                DragMove();
            }
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.ResizeMode == System.Windows.ResizeMode.NoResize)
            {
                // restore resize grips
                this.ResizeMode = System.Windows.ResizeMode.CanResizeWithGrip;
                this.UpdateLayout();
            }
            if (Parameter.isClickVoiceEnabled)
                player.Play(fo.GetRandomOnClickFile());
        }

        private void openContextMenu(object sender, MouseButtonEventArgs args)
        {
            ContextMenu cm = this.FindResource("cm") as ContextMenu;
            cm.PlacementTarget = sp as StackPanel;
            cm.IsOpen = true;
        }

        private void sp_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Parameter.isClickVoiceEnabled)
                player.Play(fo.GetRandomOnClickFile());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveGeneral();
            SaveCharConfig();
        }

        private void MenuItem_exit_Click(object sender, RoutedEventArgs e)      // use Click , not MouseLeft...
        {
            hourClock.Stop();
            idleClock.Stop();
            Application.Current.MainWindow.Close();
        }

        private void MenuItem_ChooseChar_Click(object sender, RoutedEventArgs e)
        {
            CharSelectionForm csf = new CharSelectionForm(this, fo);
            csf.ShowDialog();
        }

        private void MenuItem_ChooseCharCG_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            string imgName = menuItem.Tag.ToString();
            string imgPath = fo.GetCharFolderPath() + imgName;
            Parameter.charCgOnLoad = imgName;
            loadImage(imgPath);
        }

        private void MenuItem_ChangeVolume_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            double newVolume = Convert.ToDouble(menuItem.Tag);
            player.Volume = newVolume;
        }

        private void MenuItem_Settings_Click(object sender, RoutedEventArgs e)
        {
            SettingForm sf = new SettingForm(this);
            sf.ShowDialog();
        }

        private void nfyico_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/8cdd4ef1-d31e-42ef-a30e-7b482c0fa163/wpf-contextmenu-for-notifyicon
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ContextMenu cm = this.FindResource("cm") as ContextMenu;
                cm.Placement = System.Windows.Controls.Primitives.PlacementMode.Mouse;
                cm.IsOpen = true;
            }

        }


        #endregion

        #region Clock and sound settings============================================

        public void configLaunchVoice(bool isEnable)
        {
            Parameter.isLaunchVoiceEnabled = isEnable;
        }

        public void configIdleVoice(bool isEnable, int intervalSec)
        {
            Parameter.idleInterval = intervalSec * 1000;
            Parameter.isIdleVoiceEnabled = isEnable;
            idleClock.SetIdleTime(Parameter.idleInterval);
            if (isEnable)
                this.idleClock.Start();
            else
                this.idleClock.Stop();
        }

        public void configClockVoice(bool isEnable)
        {
            Parameter.isClockVoiceEnabled = isEnable;
            if (isEnable)
                this.hourClock.Start();
            else
                this.hourClock.Stop();
        }

        public void configClickVoice(bool isEnable)
        {
            Parameter.isClickVoiceEnabled = isEnable;
        }

        #endregion

    }
}