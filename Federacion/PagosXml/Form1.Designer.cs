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
            Label label3;
            label2 = new Label();
            nombre = new TextBox();
            apellidos = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            panel1 = new Panel();
            dni = new MaskedTextBox();
            iban = new MaskedTextBox();
            cantidad = new MaskedTextBox();
            panel2 = new Panel();
            label1 = new Label();
            saveFileDialog1 = new SaveFileDialog();
            panel3 = new Panel();
            button7 = new Button();
            btImportarExcel = new Button();
            openFile = new OpenFileDialog();
            listView1 = new ListView();
            colNombre = new ColumnHeader();
            colApellidos = new ColumnHeader();
            colDni = new ColumnHeader();
            colIban = new ColumnHeader();
            colCantidad = new ColumnHeader();
            panel4 = new Panel();
            panel6 = new Panel();
            label10 = new Label();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            panel5 = new Panel();
            ibanEmisor = new MaskedTextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            concepto = new TextBox();
            nif = new TextBox();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(3);
            label3.Size = new Size(443, 27);
            label3.TabIndex = 0;
            label3.Text = "Agregar todos los datos y una vez añadidos generar el fichero";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 272);
            label2.Name = "label2";
            label2.Size = new Size(95, 21);
            label2.TabIndex = 0;
            label2.Text = "Cantidad (€)";
            // 
            // nombre
            // 
            nombre.CharacterCasing = CharacterCasing.Upper;
            nombre.Location = new Point(135, 52);
            nombre.Name = "nombre";
            nombre.Size = new Size(325, 29);
            nombre.TabIndex = 1;
            // 
            // apellidos
            // 
            apellidos.CharacterCasing = CharacterCasing.Upper;
            apellidos.Location = new Point(135, 106);
            apellidos.Name = "apellidos";
            apellidos.Size = new Size(325, 29);
            apellidos.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 110);
            label4.Name = "label4";
            label4.Size = new Size(74, 21);
            label4.TabIndex = 0;
            label4.Text = "Apellidos";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 164);
            label5.Name = "label5";
            label5.Size = new Size(111, 21);
            label5.TabIndex = 0;
            label5.Text = "DNI (con letra)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 218);
            label6.Name = "label6";
            label6.Size = new Size(100, 21);
            label6.TabIndex = 0;
            label6.Text = "Nº de cuenta";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 255, 192);
            button1.Location = new Point(178, 6);
            button1.Name = "button1";
            button1.Size = new Size(156, 36);
            button1.TabIndex = 7;
            button1.Text = "Agregar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += addPersonNoClean_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(192, 255, 192);
            button2.Location = new Point(16, 6);
            button2.Name = "button2";
            button2.Size = new Size(147, 36);
            button2.TabIndex = 6;
            button2.Text = "Agregar y limpiar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += addPerson_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(255, 255, 192);
            button3.Location = new Point(350, 6);
            button3.Name = "button3";
            button3.Size = new Size(130, 36);
            button3.TabIndex = 8;
            button3.Text = "Limpiar";
            button3.UseVisualStyleBackColor = false;
            button3.Click += cleanData_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(dni);
            panel1.Controls.Add(iban);
            panel1.Controls.Add(cantidad);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(nombre);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(apellidos);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label6);
            panel1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(10, 110);
            panel1.Name = "panel1";
            panel1.Size = new Size(505, 382);
            panel1.TabIndex = 3;
            // 
            // dni
            // 
            dni.BeepOnError = true;
            dni.Location = new Point(135, 156);
            dni.Mask = "99999999L";
            dni.Name = "dni";
            dni.Size = new Size(325, 29);
            dni.TabIndex = 3;
            // 
            // iban
            // 
            iban.BeepOnError = true;
            iban.Location = new Point(135, 215);
            iban.Mask = "LL9999999999999999999999999";
            iban.Name = "iban";
            iban.Size = new Size(325, 29);
            iban.TabIndex = 4;
            // 
            // cantidad
            // 
            cantidad.BeepOnError = true;
            cantidad.Location = new Point(135, 269);
            cantidad.Mask = "####.00";
            cantidad.Name = "cantidad";
            cantidad.Size = new Size(325, 29);
            cantidad.TabIndex = 5;
            cantidad.ValidatingType = typeof(int);
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(button3);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 333);
            panel2.Name = "panel2";
            panel2.Size = new Size(501, 45);
            panel2.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 56);
            label1.Name = "label1";
            label1.Size = new Size(68, 21);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // panel3
            // 
            panel3.Controls.Add(button7);
            panel3.Controls.Add(btImportarExcel);
            panel3.Location = new Point(10, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(505, 92);
            panel3.TabIndex = 14;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button7.Location = new Point(10, 49);
            button7.Name = "button7";
            button7.Size = new Size(472, 36);
            button7.TabIndex = 1;
            button7.Text = "Importar excel pagos";
            button7.UseVisualStyleBackColor = true;
            button7.Click += importarExcelGeneral_Click;
            // 
            // btImportarExcel
            // 
            btImportarExcel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btImportarExcel.Location = new Point(10, 7);
            btImportarExcel.Name = "btImportarExcel";
            btImportarExcel.Size = new Size(472, 36);
            btImportarExcel.TabIndex = 0;
            btImportarExcel.Text = "Importar excel pagos arbitraje playa JJDD";
            btImportarExcel.UseVisualStyleBackColor = true;
            btImportarExcel.Click += btImportarExcel_Click;
            // 
            // openFile
            // 
            openFile.DefaultExt = "xlsx";
            openFile.FileName = "*.xlsx";
            openFile.InitialDirectory = ".";
            openFile.Title = "Seleccionar excel con datos de pagos";
            // 
            // listView1
            // 
            listView1.Activation = ItemActivation.OneClick;
            listView1.BackColor = SystemColors.InactiveCaption;
            listView1.BorderStyle = BorderStyle.None;
            listView1.CheckBoxes = true;
            listView1.Columns.AddRange(new ColumnHeader[] { colNombre, colApellidos, colDni, colIban, colCantidad });
            listView1.Dock = DockStyle.Top;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.HideSelection = true;
            listView1.HoverSelection = true;
            listView1.Location = new Point(2, 2);
            listView1.Name = "listView1";
            listView1.ShowGroups = false;
            listView1.Size = new Size(630, 338);
            listView1.Sorting = SortOrder.Ascending;
            listView1.TabIndex = 15;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // colNombre
            // 
            colNombre.Text = "Nombre";
            colNombre.Width = 120;
            // 
            // colApellidos
            // 
            colApellidos.Text = "Apellidos";
            colApellidos.TextAlign = HorizontalAlignment.Center;
            colApellidos.Width = 150;
            // 
            // colDni
            // 
            colDni.Text = "DNI";
            colDni.TextAlign = HorizontalAlignment.Center;
            colDni.Width = 80;
            // 
            // colIban
            // 
            colIban.Text = "IBAN";
            colIban.TextAlign = HorizontalAlignment.Center;
            colIban.Width = 110;
            // 
            // colCantidad
            // 
            colCantidad.Text = "Cantidad";
            colCantidad.TextAlign = HorizontalAlignment.Center;
            colCantidad.Width = 70;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.AppWorkspace;
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(listView1);
            panel4.Location = new Point(523, 12);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(2);
            panel4.Size = new Size(634, 540);
            panel4.TabIndex = 15;
            // 
            // panel6
            // 
            panel6.Controls.Add(label10);
            panel6.Controls.Add(button6);
            panel6.Controls.Add(button5);
            panel6.Controls.Add(button4);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(2, 430);
            panel6.Name = "panel6";
            panel6.Size = new Size(630, 108);
            panel6.TabIndex = 16;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(87, 42);
            label10.Name = "label10";
            label10.Size = new Size(412, 15);
            label10.TabIndex = 27;
            label10.Text = "El fichero generado se guardará en Mis Documentos con el nombre sepa.xml";
            // 
            // button6
            // 
            button6.Location = new Point(13, 60);
            button6.Name = "button6";
            button6.Size = new Size(166, 36);
            button6.TabIndex = 25;
            button6.Text = "Eliminar filas seleccionadas";
            button6.UseVisualStyleBackColor = true;
            button6.Click += removeItems_Click;
            // 
            // button5
            // 
            button5.Location = new Point(479, 60);
            button5.Name = "button5";
            button5.Size = new Size(152, 36);
            button5.TabIndex = 26;
            button5.Text = "Limpiar tabla";
            button5.UseVisualStyleBackColor = true;
            button5.Click += clearList_Click;
            // 
            // button4
            // 
            button4.Location = new Point(47, 3);
            button4.Name = "button4";
            button4.Size = new Size(532, 36);
            button4.TabIndex = 24;
            button4.Text = "Generar fichero SEPA";
            button4.UseVisualStyleBackColor = true;
            button4.Click += saveXml_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(ibanEmisor);
            panel5.Controls.Add(label9);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(label7);
            panel5.Controls.Add(concepto);
            panel5.Controls.Add(nif);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(2, 340);
            panel5.Name = "panel5";
            panel5.Size = new Size(630, 90);
            panel5.TabIndex = 16;
            // 
            // ibanEmisor
            // 
            ibanEmisor.BeepOnError = true;
            ibanEmisor.Location = new Point(145, 8);
            ibanEmisor.Mask = "LL9999999999999999999999999";
            ibanEmisor.Name = "ibanEmisor";
            ibanEmisor.Size = new Size(325, 23);
            ibanEmisor.TabIndex = 25;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(47, 63);
            label9.Name = "label9";
            label9.Size = new Size(89, 15);
            label9.TabIndex = 22;
            label9.Text = "Concepto Pago";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(47, 41);
            label8.Name = "label8";
            label8.Size = new Size(25, 15);
            label8.TabIndex = 23;
            label8.Text = "NIF";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(47, 11);
            label7.Name = "label7";
            label7.Size = new Size(73, 15);
            label7.TabIndex = 24;
            label7.Text = "IBAN Emisor";
            // 
            // concepto
            // 
            concepto.CharacterCasing = CharacterCasing.Upper;
            concepto.Location = new Point(145, 60);
            concepto.Name = "concepto";
            concepto.Size = new Size(325, 23);
            concepto.TabIndex = 20;
            // 
            // nif
            // 
            nif.CharacterCasing = CharacterCasing.Upper;
            nif.Location = new Point(145, 33);
            nif.Name = "nif";
            nif.Size = new Size(325, 23);
            nif.TabIndex = 21;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1170, 568);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Pagos Federación de Voleibol";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private TextBox nombre;
        private TextBox apellidos;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button1;
        private Button button2;
        private Button button3;
        private Panel panel1;
        private Panel panel2;
        private MaskedTextBox dni;
        private MaskedTextBox iban;
        private MaskedTextBox cantidad;
        private SaveFileDialog saveFileDialog1;
        private Panel panel3;
        private Button btImportarExcel;
        private OpenFileDialog openFile;
        private Label label1;
        private ListView listView1;
        private ColumnHeader colNombre;
        private ColumnHeader colApellidos;
        private ColumnHeader colDni;
        private ColumnHeader colIban;
        private ColumnHeader colCantidad;
        private Panel panel4;
        private Panel panel6;
        private Label label10;
        private Button button6;
        private Button button5;
        private Button button4;
        private Panel panel5;
        private MaskedTextBox ibanEmisor;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox concepto;
        private TextBox nif;
        private Button button7;
    }
}