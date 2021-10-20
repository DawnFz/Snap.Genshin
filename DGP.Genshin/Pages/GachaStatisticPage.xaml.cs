﻿using DGP.Genshin.Services.GachaStatistic;
using DGP.Snap.Framework.Extensions.System;
using Microsoft.Win32;
using ModernWpf.Controls;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Navigation;

namespace DGP.Genshin.Pages
{
    /// <summary>
    /// GachaStatisticPage.xaml 的交互逻辑
    /// </summary>
    public partial class GachaStatisticPage : Page
    {
        [NotNull]
        private GachaStatisticService? Service { get; set; }

        public GachaStatisticPage()
        {
            this.Service = new GachaStatisticService();
            this.DataContext = this.Service;
            this.InitializeComponent();
            this.Log("initialized");
        }

        private async void AutoFindAppBarButtonClick(object sender, RoutedEventArgs e) =>
            await this.Service.RefreshAsync(GachaLogUrlMode.GameLogFile);
        private async void ManualInputUrlAppBarButtonClick(object sender, RoutedEventArgs e) =>
            await this.Service.RefreshAsync(GachaLogUrlMode.ManualInput);

        private async void ImportFromGenshinGachaExportAppBarButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JS对象简谱文件|*.json",
                Title = "从 Genshin Gacha Export 记录文件导入",
                Multiselect = false,
                CheckFileExists = true
            };
            if (openFileDialog.ShowDialog() == true)
            {
                this.Log("try to import from genshin gacha export");
                await this.Service.ImportFromGenshinGachaExportAsync(openFileDialog.FileName);
            }
        }

        private async void ExportExcelAppBarButtonClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Excel 工作簿|*.xlsx",
                Title = "保存到表格",
                ValidateNames = true,
                CheckPathExists = true,
                FileName = $"{this.Service.SelectedUid.UnMaskedValue}.xlsx"
            };
            if (dialog.ShowDialog() == true)
            {
                this.Log("try to export to excel");
                await this.Service.ExportDataToExcelAsync(dialog.FileName);
                await new ContentDialog
                {
                    Title = "导出祈愿记录完成",
                    Content = $"祈愿记录已导出至 {dialog.SafeFileName}",
                    PrimaryButtonText = "确定",
                    DefaultButton = ContentDialogButton.Primary
                }.ShowAsync();
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            this.UnInitialize();
            base.OnNavigatingFrom(e);
        }
        private void UnInitialize()
        {
            this.Log("uninitialized");
            this.Service?.UnInitialize();
            this.Service = null;
        }
    }
}
