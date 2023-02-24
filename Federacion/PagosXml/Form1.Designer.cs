namespace PagosXml
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label3;
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.apellidos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dni = new System.Windows.Forms.MaskedTextBox();
            this.iban = new System.Windows.Forms.MaskedTextBox();
            this.cantidad = new System.Windows.Forms.MaskedTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colNombre = new System.Windows.Forms.ColumnHeader();
            this.colApellidos = new System.Windows.Forms.ColumnHeader();
            this.colDni = new System.Windows.Forms.ColumnHeader();
            this.colIban = new System.Windows.Forms.ColumnHeader();
            this.colCantidad = new System.Windows.Forms.ColumnHeader();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ibanEmisor = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nif = new System.Windows.Forms.TextBox();
            this.concepto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Top;
            label3.Location = new System.Drawing.Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new System.Windows.Forms.Padding(3);
            label3.Size = new System.Drawing.Size(443, 27);
            label3.TabIndex = 0;
            label3.Text = "Agregar todos los datos y una vez añadidos generar el fichero";
            label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cantidad (€)";
            // 
            // nombre
            // 
            this.nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nombre.Location = new System.Drawing.Point(135, 52);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(325, 29);
            this.nombre.TabIndex = 1;
            // 
            // apellidos
            // 
            this.apellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.apellidos.Location = new System.Drawing.Point(135, 106);
            this.apellidos.Name = "apellidos";
            this.apellidos.Size = new System.Drawing.Size(325, 29);
            this.apellidos.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Apellidos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "DNI (con letra)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nº de cuenta";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(178, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button2.Location = new System.Drawing.Point(16, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 36);
            this.button2.TabIndex = 6;
            this.button2.Text = "Agregar y limpiar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button3.Location = new System.Drawing.Point(350, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 36);
            this.button3.TabIndex = 8;
            this.button3.Text = "Limpiar";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(657, 441);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(532, 36);
            this.button4.TabIndex = 9;
            this.button4.Text = "Generar fichero SEPA";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dni);
            this.panel1.Controls.Add(this.iban);
            this.panel1.Controls.Add(this.cantidad);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.nombre);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.apellidos);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 382);
            this.panel1.TabIndex = 3;
            // 
            // dni
            // 
            this.dni.BeepOnError = true;
            this.dni.Location = new System.Drawing.Point(135, 156);
            this.dni.Mask = "99999999L";
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(325, 29);
            this.dni.TabIndex = 3;
            // 
            // iban
            // 
            this.iban.BeepOnError = true;
            this.iban.Location = new System.Drawing.Point(135, 215);
            this.iban.Mask = "LL9999999999999999999999999";
            this.iban.Name = "iban";
            this.iban.Size = new System.Drawing.Size(325, 29);
            this.iban.TabIndex = 4;
            // 
            // cantidad
            // 
            this.cantidad.BeepOnError = true;
            this.cantidad.Location = new System.Drawing.Point(135, 269);
            this.cantidad.Mask = "####.00";
            this.cantidad.Name = "cantidad";
            this.cantidad.Size = new System.Drawing.Size(325, 29);
            this.cantidad.TabIndex = 5;
            this.cantidad.ValidatingType = typeof(int);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 333);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(501, 45);
            this.panel2.TabIndex = 6;
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNombre,
            this.colApellidos,
            this.colDni,
            this.colIban,
            this.colCantidad});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = true;
            this.listView1.HoverSelection = true;
            this.listView1.Location = new System.Drawing.Point(657, 92);
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(532, 338);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // colNombre
            // 
            this.colNombre.Text = "Nombre";
            this.colNombre.Width = 120;
            // 
            // colApellidos
            // 
            this.colApellidos.Text = "Apellidos";
            this.colApellidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colApellidos.Width = 150;
            // 
            // colDni
            // 
            this.colDni.Text = "DNI";
            this.colDni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDni.Width = 80;
            // 
            // colIban
            // 
            this.colIban.Text = "IBAN";
            this.colIban.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colIban.Width = 110;
            // 
            // colCantidad
            // 
            this.colCantidad.Text = "Cantidad";
            this.colCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colCantidad.Width = 70;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1037, 506);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(152, 36);
            this.button5.TabIndex = 10;
            this.button5.Text = "Limpiar tabla";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(657, 506);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(166, 36);
            this.button6.TabIndex = 10;
            this.button6.Text = "Eliminar filas seleccionadas";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(665, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "IBAN Emisor";
            // 
            // ibanEmisor
            // 
            this.ibanEmisor.BeepOnError = true;
            this.ibanEmisor.Location = new System.Drawing.Point(763, 11);
            this.ibanEmisor.Mask = "LL9999999999999999999999999";
            this.ibanEmisor.Name = "ibanEmisor";
            this.ibanEmisor.Size = new System.Drawing.Size(325, 23);
            this.ibanEmisor.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(665, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "NIF";
            // 
            // nif
            // 
            this.nif.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nif.Location = new System.Drawing.Point(763, 36);
            this.nif.Name = "nif";
            this.nif.Size = new System.Drawing.Size(325, 23);
            this.nif.TabIndex = 2;
            // 
            // concepto
            // 
            this.concepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.concepto.Location = new System.Drawing.Point(763, 63);
            this.concepto.Name = "concepto";
            this.concepto.Size = new System.Drawing.Size(325, 23);
            this.concepto.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(665, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 15);
            this.label9.TabIndex = 11;
            this.label9.Text = "Concepto Pago";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(733, 480);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(412, 15);
            this.label10.TabIndex = 13;
            this.label10.Text = "El fichero generado se guardará en Mis Documentos con el nombre sepa.xml";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 548);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ibanEmisor);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.concepto);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.nif);
            this.Name = "Form1";
            this.Text = "Pagos Federación de Voleibol";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox nombre;
        private TextBox apellidos;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Panel panel1;
        private Panel panel2;
        private ListView listView1;
        private ColumnHeader colNombre;
        private ColumnHeader colApellidos;
        private ColumnHeader colDni;
        private ColumnHeader colIban;
        private ColumnHeader colCantidad;
        private Button button5;
        private MaskedTextBox dni;
        private MaskedTextBox iban;
        private MaskedTextBox cantidad;
        private Button button6;
        private MaskedTextBox ibanEmisor;
        private Label label7;
        private Label label8;
        private TextBox nif;
        private TextBox concepto;
        private Label label9;
        private Label label10;
        private SaveFileDialog saveFileDialog1;
    }
}