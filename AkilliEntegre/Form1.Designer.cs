namespace AkilliEntegre
{
    partial class HBForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.prBtn = new System.Windows.Forms.Button();
            this.listBtn = new System.Windows.Forms.Button();
            this.ctgrBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.shipBtn = new System.Windows.Forms.Button();
            this.ordrBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // prBtn
            // 
            this.prBtn.BackColor = System.Drawing.Color.Transparent;
            this.prBtn.BackgroundImage = global::AkilliEntegre.Properties.Resources.cba82d3b4758b4ad5360f733083eb69a_icon;
            this.prBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.prBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.prBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prBtn.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.prBtn.Location = new System.Drawing.Point(12, 12);
            this.prBtn.Name = "prBtn";
            this.prBtn.Size = new System.Drawing.Size(135, 135);
            this.prBtn.TabIndex = 0;
            this.prBtn.Text = "ÜRÜNLER";
            this.prBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.prBtn.UseVisualStyleBackColor = false;
            // 
            // listBtn
            // 
            this.listBtn.BackColor = System.Drawing.Color.Transparent;
            this.listBtn.BackgroundImage = global::AkilliEntegre.Properties.Resources.cba82d3b4758b4ad5360f733083eb69a_icon;
            this.listBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.listBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.listBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listBtn.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBtn.Location = new System.Drawing.Point(12, 153);
            this.listBtn.Name = "listBtn";
            this.listBtn.Size = new System.Drawing.Size(135, 135);
            this.listBtn.TabIndex = 1;
            this.listBtn.Text = "LİSTELER";
            this.listBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.listBtn.UseVisualStyleBackColor = false;
            this.listBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctgrBtn
            // 
            this.ctgrBtn.BackColor = System.Drawing.Color.Transparent;
            this.ctgrBtn.BackgroundImage = global::AkilliEntegre.Properties.Resources.cba82d3b4758b4ad5360f733083eb69a_icon;
            this.ctgrBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ctgrBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ctgrBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ctgrBtn.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ctgrBtn.Location = new System.Drawing.Point(12, 294);
            this.ctgrBtn.Name = "ctgrBtn";
            this.ctgrBtn.Size = new System.Drawing.Size(135, 135);
            this.ctgrBtn.TabIndex = 2;
            this.ctgrBtn.Text = "KATEGORİ İŞLEMLERİ";
            this.ctgrBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ctgrBtn.UseVisualStyleBackColor = false;
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.Transparent;
            this.backBtn.BackgroundImage = global::AkilliEntegre.Properties.Resources.cba82d3b4758b4ad5360f733083eb69a_icon;
            this.backBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.backBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.backBtn.Location = new System.Drawing.Point(865, 294);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(135, 135);
            this.backBtn.TabIndex = 5;
            this.backBtn.Text = "MENU";
            this.backBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.backBtn.UseVisualStyleBackColor = false;
            // 
            // shipBtn
            // 
            this.shipBtn.BackColor = System.Drawing.Color.Transparent;
            this.shipBtn.BackgroundImage = global::AkilliEntegre.Properties.Resources.cba82d3b4758b4ad5360f733083eb69a_icon;
            this.shipBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.shipBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.shipBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shipBtn.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.shipBtn.Location = new System.Drawing.Point(865, 153);
            this.shipBtn.Name = "shipBtn";
            this.shipBtn.Size = new System.Drawing.Size(135, 135);
            this.shipBtn.TabIndex = 4;
            this.shipBtn.Text = "KARGOLAR";
            this.shipBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.shipBtn.UseVisualStyleBackColor = false;
            // 
            // ordrBtn
            // 
            this.ordrBtn.BackColor = System.Drawing.Color.Transparent;
            this.ordrBtn.BackgroundImage = global::AkilliEntegre.Properties.Resources.cba82d3b4758b4ad5360f733083eb69a_icon;
            this.ordrBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ordrBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ordrBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ordrBtn.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ordrBtn.Location = new System.Drawing.Point(865, 12);
            this.ordrBtn.Name = "ordrBtn";
            this.ordrBtn.Size = new System.Drawing.Size(135, 135);
            this.ordrBtn.TabIndex = 3;
            this.ordrBtn.Text = "SİPARİŞLER";
            this.ordrBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ordrBtn.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(153, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(706, 211);
            this.dataGridView1.TabIndex = 6;
            // 
            // HBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::AkilliEntegre.Properties.Resources.hepsiburada_yildiz_co;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1012, 593);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.shipBtn);
            this.Controls.Add(this.ordrBtn);
            this.Controls.Add(this.ctgrBtn);
            this.Controls.Add(this.listBtn);
            this.Controls.Add(this.prBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HBForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HepsiBurada.com";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HBForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HBForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HBForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button prBtn;
        private System.Windows.Forms.Button listBtn;
        private System.Windows.Forms.Button ctgrBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Button shipBtn;
        private System.Windows.Forms.Button ordrBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

