﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            buttonZatrzymajMonitorowanie.Enabled = false;
            button1.Enabled = false;
            InitWatcher();
            pictureBox_Wskaznik.Visible = false;
            pictureBoxWskaznikOK.Visible = false;


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
        string _zmiennaTekstowa = @"C:\Roboczy";

        private void button1_Click(object sender, EventArgs e)
        {
            if (_monitor.EnableRaisingEvents == false)
            {
                FolderBrowserDialog _wybierzFolder = new FolderBrowserDialog();
                if (_wybierzFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK) MessageBox.Show("Wybrano: " + _wybierzFolder.SelectedPath);
                _zmiennaTekstowa = _wybierzFolder.SelectedPath;
                textBox_MonitorowanaSciezka.AppendText(_zmiennaTekstowa);
                button1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Trwa monitorowanie, przed zmianą zatrzymaj ten proces");
            }

        }

        private void InitWatcher()
        {

            _monitor = new FileSystemWatcher(@_zmiennaTekstowa);


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



        static bool mailSent = false;
        private void AddLog(string log)
        {
            
            if (InvokeRequired) //sprawdzenie czy do wykonania potrzeba być w wątku głównym
            {
                BeginInvoke((Action)(async () =>
                {
                    listBox_LogiZmian.Items.Insert(0, log);
                    pictureBoxWskaznikOK.Visible = false;
                    pictureBox_Wskaznik.Visible = true;
                    Task<bool> wysylanieEmaila = wyslijEmail(log) ;
                    
                    mailSent = await wysylanieEmaila;
                    if (mailSent == true)
                    {
                        pictureBoxWskaznikOK.Visible = true;
                        pictureBox_Wskaznik.Visible = false;

                    }
                    else
                    {
                        pictureBoxWskaznikOK.Visible = false;
                        pictureBox_Wskaznik.Visible = true;

                    }


                }
                    ));//lamda do przeniesienia sie do głównego wątku
            }
        }




        private Task<string> ToDo()
        {

            Task<string> zadanie = Task.Run(() =>
            {
                Thread.Sleep(2000);
                return "Don't worry be happy :) ";
            });
            return zadanie;


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            InitWatcher();
            _monitor.EnableRaisingEvents = true;
            textBox_MonitorowanaSciezka.BackColor = Color.LightGreen;
            buttonZatrzymajMonitorowanie.Enabled = true;
            button1.Enabled = false;
        }

        private void buttonZatrzymajMonitorowanie_Click(object sender, EventArgs e)
        {
            _monitor.EnableRaisingEvents = false;
            textBox_MonitorowanaSciezka.BackColor = Color.LightGoldenrodYellow;
            button1.Enabled = true;
            buttonZatrzymajMonitorowanie.Enabled = false;
        }
        async Task<bool> wyslijEmail(string tresc)
        {
            
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential()
            {
                UserName = Credentials.LOGIN,
                Password = Credentials.PASSWORD
            };
            smtpClient.EnableSsl = true;
            MailMessage messege = new MailMessage();
            messege.From = new MailAddress("balluffkurs@gmail.com", "Wiadomość od JB");
            messege.To.Add(new MailAddress("jaroslaw.burzawa@balluff.pl", "Jarek"));
            messege.Subject = "Wiadomość testowa";
            messege.Body = tresc;
            smtpClient.Send(messege);
            Thread.Sleep(2000);
            return true;

        }
        
        
        
    }
}
