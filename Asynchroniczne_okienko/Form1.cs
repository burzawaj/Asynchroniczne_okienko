using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Asynchroniczne_okienko

{
    delegate void StringArgReturningVoidDelegate(string text);
    

    public partial class Form1 : Form
    {
        private FileSystemWatcher _monitor;
        private static System.Timers.Timer mojTimer;
        public Form1()
        {
            InitializeComponent();
            InitWatcher();
            _monitor.EnableRaisingEvents = true;
            Thread watekpoboczny = new Thread(SprawdzCzas);
            watekpoboczny.Start();
            
            
        }

        private void SprawdzCzas()
        {
            mojTimer = new System.Timers.Timer(1000);
            mojTimer.Elapsed += OnTimedEvent;
            mojTimer.AutoReset = true;
            mojTimer.Enabled = true;
            
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            
            SetText(e.SignalTime.ToString()); 
        }

        private void SetText(string text)
        {
            if (this.textBox_ZEGAR.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox_ZEGAR.Text = text;
            }
        }
                          
        private async void button_dwa_Click(object sender, EventArgs e)
        {
            string tekst = await ToDo();  //await powoduje zwrócenie od razu rezultatu zadania które jest wynikiem funkcji
            textBoxKomentarz.AppendText(tekst + "\r\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog _wybierzFolder = new FolderBrowserDialog();
            if (_wybierzFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK) MessageBox.Show(_wybierzFolder.SelectedPath);
        }
        
        private void InitWatcher()
        {
            _monitor = new FileSystemWatcher(@"C:\Roboczy");

            _monitor.Changed += _watcher_Changed;
            _monitor.Created += _watcher_Changed;
            _monitor.Deleted += _watcher_Changed;
            _monitor.Renamed += _watcher_Changed;
        }

        private void _watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string log = " ";
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Created:
                    log = $"Utworzono plik: {e.Name}";
                    break;
                case WatcherChangeTypes.Deleted:
                    log = $"Usunieto plik: {e.Name}";

                    break;
                case WatcherChangeTypes.Changed:
                    log = $"Zmieniono plik: {e.Name}";
                    log = log + DateTime.Now.ToString();

                    break;
                case WatcherChangeTypes.Renamed:

                    log = $"Zmieniono nazwę pliku: {e.Name}";


                    break;
                case WatcherChangeTypes.All:
                    break;
                default:
                    break;
            }

            AddLog(log); //wywołanie funcji dodającej wpis do ListBox



        }




        private void AddLog(string log)
        {
            if (InvokeRequired) //sprawdzenie czy do wykonania potrzeba być w wątku głównym
            {
                BeginInvoke((Action)(() =>
                {
                    listBox_LogiZmian.Items.Insert(0, log);
                    //wyslijEmail(log);

                }
                    ));//lamda do przeniesienia sie do głównego wątku
            }
        }

    


        private Task<string> ToDo()
        {

            Task<string> zadanie = Task.Run(() =>
            {
                Thread.Sleep(3000);
                return "Nacisnąłeś przycisk 3s temu";
            });
            return zadanie;
                       

        }

        

        
    }
}
