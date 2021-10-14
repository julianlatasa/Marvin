namespace Marvin
{
    partial class FormMarvin
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvContratados = new System.Windows.Forms.DataGridView();
            this.timerActualizarTiempo = new System.Windows.Forms.Timer(this.components);
            this.timerConsultaSQL = new System.Windows.Forms.Timer(this.components);
            this.labelStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbFiltroRegion = new System.Windows.Forms.ComboBox();
            this.labelDemoraPrestadores = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratados)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvContratados
            // 
            this.dgvContratados.AllowUserToAddRows = false;
            this.dgvContratados.AllowUserToDeleteRows = false;
            this.dgvContratados.AllowUserToResizeRows = false;
            this.dgvContratados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContratados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvContratados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContratados.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvContratados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvContratados.Location = new System.Drawing.Point(0, 44);
            this.dgvContratados.MultiSelect = false;
            this.dgvContratados.Name = "dgvContratados";
            this.dgvContratados.RowHeadersVisible = false;
            this.dgvContratados.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContratados.RowTemplate.Height = 44;
            this.dgvContratados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContratados.ShowCellToolTips = false;
            this.dgvContratados.ShowEditingIcon = false;
            this.dgvContratados.Size = new System.Drawing.Size(807, 363);
            this.dgvContratados.TabIndex = 0;
            this.dgvContratados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContratados_CellContentClick);
            this.dgvContratados.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvContratados_DataBindingComplete);
            this.dgvContratados.SelectionChanged += new System.EventHandler(this.dgvContratados_SelectionChanged);
            // 
            // timerActualizarTiempo
            // 
            this.timerActualizarTiempo.Interval = 1000;
            this.timerActualizarTiempo.Tick += new System.EventHandler(this.timerActualizarTiempo_Tick);
            // 
            // timerConsultaSQL
            // 
            this.timerConsultaSQL.Interval = 5000;
            this.timerConsultaSQL.Tick += new System.EventHandler(this.timerConsultaSQL_Tick);
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelStatus.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.White;
            this.labelStatus.Location = new System.Drawing.Point(1, 197);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(3);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(806, 210);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Sin conexion desde hace xx minutos\r\nUltima actualizacion xx/xx/xx xx:xx:xx";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelStatus.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cbFiltroRegion);
            this.panel1.Controls.Add(this.labelDemoraPrestadores);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 38);
            this.panel1.TabIndex = 2;
            // 
            // cbFiltroRegion
            // 
            this.cbFiltroRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFiltroRegion.BackColor = System.Drawing.SystemColors.Control;
            this.cbFiltroRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltroRegion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFiltroRegion.FormattingEnabled = true;
            this.cbFiltroRegion.Items.AddRange(new object[] {
            "Todos",
            "CABA",
            "Norte",
            "Sur",
            "Oeste"});
            this.cbFiltroRegion.Location = new System.Drawing.Point(674, 8);
            this.cbFiltroRegion.Name = "cbFiltroRegion";
            this.cbFiltroRegion.Size = new System.Drawing.Size(121, 30);
            this.cbFiltroRegion.TabIndex = 20;
            this.cbFiltroRegion.SelectedValueChanged += new System.EventHandler(this.cbFiltroRegion_SelectedValueChanged);
            // 
            // labelDemoraPrestadores
            // 
            this.labelDemoraPrestadores.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDemoraPrestadores.Location = new System.Drawing.Point(0, 0);
            this.labelDemoraPrestadores.Name = "labelDemoraPrestadores";
            this.labelDemoraPrestadores.Size = new System.Drawing.Size(873, 32);
            this.labelDemoraPrestadores.TabIndex = 19;
            this.labelDemoraPrestadores.Text = "Demoras en Prestadores";
            this.labelDemoraPrestadores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormMarvin
            // 
            this.ClientSize = new System.Drawing.Size(807, 408);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.dgvContratados);
            this.Name = "FormMarvin";
            this.ShowIcon = false;
            this.Text = "Monitoreo de Amarillos y Rojos Visualmente Indicando Novedades";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMarvin_FormClosed);
            this.Load += new System.EventHandler(this.FormMarvin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContratados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.DataGridView dgvContratados;
        private System.Windows.Forms.Timer timerActualizarTiempo;
        private System.Windows.Forms.Timer timerConsultaSQL;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDemoraPrestadores;
        private System.Windows.Forms.ComboBox cbFiltroRegion;
    }
}

