﻿namespace _9
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cargarImagen = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.deteccionBordes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(393, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cargarImagen
            // 
            this.cargarImagen.Location = new System.Drawing.Point(13, 358);
            this.cargarImagen.Name = "cargarImagen";
            this.cargarImagen.Size = new System.Drawing.Size(94, 23);
            this.cargarImagen.TabIndex = 1;
            this.cargarImagen.Text = "Cargar Imagen";
            this.cargarImagen.UseVisualStyleBackColor = true;
            this.cargarImagen.Click += new System.EventHandler(this.cargarImagen_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(463, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(393, 300);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // deteccionBordes
            // 
            this.deteccionBordes.Location = new System.Drawing.Point(463, 357);
            this.deteccionBordes.Name = "deteccionBordes";
            this.deteccionBordes.Size = new System.Drawing.Size(121, 23);
            this.deteccionBordes.TabIndex = 3;
            this.deteccionBordes.Text = "Deteccion de Bordes";
            this.deteccionBordes.UseVisualStyleBackColor = true;
            this.deteccionBordes.Click += new System.EventHandler(this.deteccionBordes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 418);
            this.Controls.Add(this.deteccionBordes);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cargarImagen);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button cargarImagen;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button deteccionBordes;
    }
}

