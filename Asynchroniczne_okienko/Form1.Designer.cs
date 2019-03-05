namespace Asynchroniczne_okienko
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_dwa = new System.Windows.Forms.Button();
            this.textBoxKomentarz = new System.Windows.Forms.TextBox();
            this.textBox_ZEGAR = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_WyborMonitorowanegoKatalogu = new System.Windows.Forms.Button();
            this.listBox_LogiZmian = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button_dwa
            // 
            this.button_dwa.Location = new System.Drawing.Point(535, 82);
            this.button_dwa.Name = "button_dwa";
            this.button_dwa.Size = new System.Drawing.Size(171, 54);
            this.button_dwa.TabIndex = 0;
            this.button_dwa.Text = "button1";
            this.button_dwa.UseVisualStyleBackColor = true;
            this.button_dwa.Click += new System.EventHandler(this.button_dwa_Click);
            // 
            // textBoxKomentarz
            // 
            this.textBoxKomentarz.Location = new System.Drawing.Point(535, 166);
            this.textBoxKomentarz.Multiline = true;
            this.textBoxKomentarz.Name = "textBoxKomentarz";
            this.textBoxKomentarz.Size = new System.Drawing.Size(253, 243);
            this.textBoxKomentarz.TabIndex = 1;
            // 
            // textBox_ZEGAR
            // 
            this.textBox_ZEGAR.Location = new System.Drawing.Point(535, 45);
            this.textBox_ZEGAR.Name = "textBox_ZEGAR";
            this.textBox_ZEGAR.Size = new System.Drawing.Size(187, 22);
            this.textBox_ZEGAR.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(532, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Zegar z datą";
            // 
            // button_WyborMonitorowanegoKatalogu
            // 
            this.button_WyborMonitorowanegoKatalogu.Location = new System.Drawing.Point(24, 27);
            this.button_WyborMonitorowanegoKatalogu.Name = "button_WyborMonitorowanegoKatalogu";
            this.button_WyborMonitorowanegoKatalogu.Size = new System.Drawing.Size(192, 58);
            this.button_WyborMonitorowanegoKatalogu.TabIndex = 4;
            this.button_WyborMonitorowanegoKatalogu.Text = "Wybierz monitorowany katalog";
            this.button_WyborMonitorowanegoKatalogu.UseVisualStyleBackColor = true;
            this.button_WyborMonitorowanegoKatalogu.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox_LogiZmian
            // 
            this.listBox_LogiZmian.FormattingEnabled = true;
            this.listBox_LogiZmian.ItemHeight = 16;
            this.listBox_LogiZmian.Location = new System.Drawing.Point(24, 106);
            this.listBox_LogiZmian.Name = "listBox_LogiZmian";
            this.listBox_LogiZmian.Size = new System.Drawing.Size(446, 292);
            this.listBox_LogiZmian.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox_LogiZmian);
            this.Controls.Add(this.button_WyborMonitorowanegoKatalogu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_ZEGAR);
            this.Controls.Add(this.textBoxKomentarz);
            this.Controls.Add(this.button_dwa);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_dwa;
        private System.Windows.Forms.TextBox textBoxKomentarz;
        private System.Windows.Forms.TextBox textBox_ZEGAR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_WyborMonitorowanegoKatalogu;
        private System.Windows.Forms.ListBox listBox_LogiZmian;
    }
}

