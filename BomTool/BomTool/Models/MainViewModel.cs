﻿
using NooneUI.Core;
using Qml.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BomTool.Models
{
    [AutoRegisterType]
    public class MainViewModel : Dispatchable
    {
        private string statusText = string.Empty;
        private bool isBusy = false;

        [NotifySignal]
        public bool IsBusy
        {
            get => isBusy;

            set
            {
                if (isBusy == value)
                {
                    return;
                }
                Dispatch(() =>
                {
                    isBusy = value;
                    this.ActivateNotifySignal("IsBusy");
                });
            }
        }

        [NotifySignal]
        public string StatusText
        {
            get => statusText;

            set
            {
                if (statusText == value)
                {
                    return;
                }


                Dispatch(() =>
                {
                    statusText = value;
                    this.ActivateNotifySignal("StatusText");
                });
            }
        }

        public MainViewModel()
        {
            this.Paths = HistoryEntries.Read().ToList();
        }

        public List<string> Paths { get; } = new List<string>();

        public IEnumerable<ExcelData> DataRead { get; private set; } = new List<ExcelData>();

        public IEnumerable<ExcelGrouppedData> GrouppedData { get; private set; } = new List<ExcelGrouppedData>();

        public Task ReadAsync(string path) => Task.Factory.StartNew(() =>
        {
            try
            {
                var uri = new Uri(path);
                path = uri.LocalPath;
                this.IsBusy = true;
                WaitSometime();
                var reader = new ExcelReader(path, msg => this.StatusText = msg);
                this.DataRead = reader.Read();
                if (this.DataRead.Count() == 0)
                {
                    this.StatusText = "No suitable data present";
                    return;
                }
                AddPath(path);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                this.StatusText = $"Open {path} failed";
            }

        });

        public Task WriteAsync(string path) => Task.Factory.StartNew(() =>
        {
            if (this.DataRead.Count() == 0)
            {
                this.StatusText = "No data present, please choose a bom xls first.";
                return;
            }
            try
            {
                var uri = new Uri(path);
                path = uri.LocalPath;
                this.IsBusy = true;
                WaitSometime();
                var writer = new ExcelWriter(DataRead, path, msg => this.StatusText = msg);
                writer.Write();
                this.GrouppedData = writer.GrouppedData;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                this.StatusText = "Generate BOM failed";
            }
        });

        public void AddPath(string path)
        {

            if (!Paths.Contains(path))
            {
                Paths.Add(path);
                HistoryEntries.Write(Paths);
            }
        }

        public void ClearHistory()
        {
            this.Paths.Clear();
            HistoryEntries.Write(Paths);
        }

        void WaitSometime() => Thread.Sleep((int)(new Random().NextDouble() * 1500));
    }
}
