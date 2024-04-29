﻿using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ex02_wpf_control
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void FrmMain_Loaded(object sender, RoutedEventArgs e)
        {
            var fonts = Fonts.SystemFontFamilies;

            foreach (var font in fonts)
            {
                CboFonts.Items.Add(font);
            }
        }

        #region 콤보박스 선택시 폰트 변경 
        private void CboFonts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeFont();
        }

        void ChangeFont()
        {
            if (CboFonts.SelectedIndex < 0) return;
            Debug.WriteLine(CboFonts.SelectedItem.ToString());

            TxtSampleText.FontFamily = CboFonts.SelectedItem as FontFamily;
            if (ChkItalic.IsChecked == true) TxtSampleText.FontStyle = FontStyles.Italic;
            else TxtSampleText.FontStyle = FontStyles.Normal;

            if (ChkBold.IsChecked == true) TxtSampleText.FontWeight = FontWeights.Bold;
            else TxtSampleText.FontWeight = FontWeights.Normal;
        }
        #endregion

        private void ChkBold_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ChkItalic_Checked(object sender, RoutedEventArgs e)
        {

        }

    }
}