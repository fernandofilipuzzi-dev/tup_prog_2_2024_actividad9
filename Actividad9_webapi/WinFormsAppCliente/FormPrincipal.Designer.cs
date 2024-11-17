namespace WinFormsAppCliente
{
    partial class FormPrincipal
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
            btnAgregarTicket = new Button();
            rbCompra = new RadioButton();
            rbPago = new RadioButton();
            btnAtenderCliente = new Button();
            tbCC = new TextBox();
            checkBox1 = new CheckBox();
            tbDNI = new TextBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            listBox1 = new ListBox();
            groupBox2 = new GroupBox();
            btnExportarTicketsAtendidos = new Button();
            button4 = new Button();
            label2 = new Label();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnAgregarTicket
            // 
            btnAgregarTicket.Location = new Point(320, 74);
            btnAgregarTicket.Margin = new Padding(4);
            btnAgregarTicket.Name = "btnAgregarTicket";
            btnAgregarTicket.Size = new Size(96, 82);
            btnAgregarTicket.TabIndex = 0;
            btnAgregarTicket.Text = "Ticket";
            btnAgregarTicket.UseVisualStyleBackColor = true;
            btnAgregarTicket.Click += btnAgregarTicket_Click;
            // 
            // rbCompra
            // 
            rbCompra.AutoSize = true;
            rbCompra.Location = new Point(14, 19);
            rbCompra.Margin = new Padding(4);
            rbCompra.Name = "rbCompra";
            rbCompra.Size = new Size(91, 25);
            rbCompra.TabIndex = 1;
            rbCompra.TabStop = true;
            rbCompra.Text = "Compras";
            rbCompra.UseVisualStyleBackColor = true;
            // 
            // rbPago
            // 
            rbPago.AutoSize = true;
            rbPago.Location = new Point(14, 52);
            rbPago.Margin = new Padding(4);
            rbPago.Name = "rbPago";
            rbPago.Size = new Size(69, 25);
            rbPago.TabIndex = 2;
            rbPago.TabStop = true;
            rbPago.Text = "Pagos";
            rbPago.UseVisualStyleBackColor = true;
            // 
            // btnAtenderCliente
            // 
            btnAtenderCliente.Location = new Point(144, 347);
            btnAtenderCliente.Margin = new Padding(4);
            btnAtenderCliente.Name = "btnAtenderCliente";
            btnAtenderCliente.Size = new Size(108, 57);
            btnAtenderCliente.TabIndex = 3;
            btnAtenderCliente.Text = "Atender cliente";
            btnAtenderCliente.UseVisualStyleBackColor = true;
            btnAtenderCliente.Click += btnAtenderCliente_Click;
            // 
            // tbCC
            // 
            tbCC.Location = new Point(155, 46);
            tbCC.Margin = new Padding(4);
            tbCC.Name = "tbCC";
            tbCC.Size = new Size(117, 29);
            tbCC.TabIndex = 4;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(15, 46);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(133, 25);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Nro Cuenta cte";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // tbDNI
            // 
            tbDNI.Location = new Point(88, 20);
            tbDNI.Margin = new Padding(4);
            tbDNI.Name = "tbDNI";
            tbDNI.Size = new Size(127, 29);
            tbDNI.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ControlLight;
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(tbCC);
            groupBox1.Location = new Point(26, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(286, 100);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Pagos";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 21);
            label1.Name = "label1";
            label1.Size = new Size(37, 21);
            label1.TabIndex = 8;
            label1.Text = "DNI";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 21;
            listBox1.Location = new Point(26, 192);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(272, 130);
            listBox1.TabIndex = 9;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.ControlLight;
            groupBox2.Controls.Add(rbCompra);
            groupBox2.Controls.Add(rbPago);
            groupBox2.Location = new Point(12, 328);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(125, 86);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            // 
            // btnExportarTicketsAtendidos
            // 
            btnExportarTicketsAtendidos.Location = new Point(320, 205);
            btnExportarTicketsAtendidos.Margin = new Padding(4);
            btnExportarTicketsAtendidos.Name = "btnExportarTicketsAtendidos";
            btnExportarTicketsAtendidos.Size = new Size(96, 59);
            btnExportarTicketsAtendidos.TabIndex = 11;
            btnExportarTicketsAtendidos.Text = "Exportar tickets";
            btnExportarTicketsAtendidos.UseVisualStyleBackColor = true;
            btnExportarTicketsAtendidos.Click += btnExportarTicketsAtendidos_Click;
            // 
            // button4
            // 
            button4.Location = new Point(320, 272);
            button4.Margin = new Padding(4);
            button4.Name = "button4";
            button4.Size = new Size(96, 50);
            button4.TabIndex = 12;
            button4.Text = "Importar Ctas Ctes";
            button4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 159);
            label2.Name = "label2";
            label2.Size = new Size(58, 21);
            label2.TabIndex = 13;
            label2.Text = "Turnos";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(433, 419);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(btnAtenderCliente);
            Controls.Add(btnExportarTicketsAtendidos);
            Controls.Add(groupBox2);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(tbDNI);
            Controls.Add(btnAgregarTicket);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FormPrincipal";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregarTicket;
        private RadioButton rbCompra;
        private RadioButton rbPago;
        private Button btnAtenderCliente;
        private TextBox tbCC;
        private CheckBox checkBox1;
        private TextBox tbDNI;
        private GroupBox groupBox1;
        private Label label1;
        private ListBox listBox1;
        private GroupBox groupBox2;
        private Button btnExportarTicketsAtendidos;
        private Button button4;
        private Label label2;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
    }
}
