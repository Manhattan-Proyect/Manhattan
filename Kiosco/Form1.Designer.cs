namespace Kiosco
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dgvGeneral = new System.Windows.Forms.DataGridView();
            this.btnProducto = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnEliminarProd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.button1.Location = new System.Drawing.Point(80, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "Mostrar nombre BD";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvGeneral
            // 
            this.dgvGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGeneral.Location = new System.Drawing.Point(13, 280);
            this.dgvGeneral.Name = "dgvGeneral";
            this.dgvGeneral.Size = new System.Drawing.Size(544, 224);
            this.dgvGeneral.TabIndex = 1;
            // 
            // btnProducto
            // 
            this.btnProducto.Location = new System.Drawing.Point(13, 151);
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Size = new System.Drawing.Size(110, 39);
            this.btnProducto.TabIndex = 2;
            this.btnProducto.Text = "Tabla Producto";
            this.btnProducto.UseVisualStyleBackColor = true;
            this.btnProducto.Click += new System.EventHandler(this.btnProducto_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(130, 152);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(118, 38);
            this.btnInsertar.TabIndex = 3;
            this.btnInsertar.Text = "Insertar Producto";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(254, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 38);
            this.button2.TabIndex = 4;
            this.button2.Text = "Ver Tabla Producto con Manejador";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEliminarProd
            // 
            this.btnEliminarProd.Location = new System.Drawing.Point(378, 152);
            this.btnEliminarProd.Name = "btnEliminarProd";
            this.btnEliminarProd.Size = new System.Drawing.Size(118, 38);
            this.btnEliminarProd.TabIndex = 5;
            this.btnEliminarProd.Text = "Eliminar Producto";
            this.btnEliminarProd.UseVisualStyleBackColor = true;
            this.btnEliminarProd.Click += new System.EventHandler(this.btnEliminarProd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 516);
            this.Controls.Add(this.btnEliminarProd);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.btnProducto);
            this.Controls.Add(this.dgvGeneral);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvGeneral;
        private System.Windows.Forms.Button btnProducto;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnEliminarProd;
    }
}

