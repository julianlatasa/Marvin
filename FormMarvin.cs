using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace Marvin
{
    public partial class FormMarvin : Form
    {
        private String strNumeroIncidente;
        private Boolean boolIgnorarSeleccion = false;
        private Int32 intFilaMostrada;

        private RCDQuery rcdQueryContratado;

        private Boolean showAlertMsg;
        private Int64 AlertMsgTime;

        private DateTime serverDateTime;
        private DateTime lastUpdate;
        private Int64 offLineTime;

        private FormAlertDialog formAlert;

        private Thread queryThread;

        public FormMarvin()
        {
            InitializeComponent();
            rcdQueryContratado = new RCDQuery(Properties.Resources.IncidentesContratadosDemorados);
            rcdQueryContratado.setQueryCallBack(new QueryCallBack(queryContratadosFinish));
            cbFiltroRegion.Text = "Todos";
            offLineTime = 0;
            serverDateTime = DateTime.Now;
            lastUpdate = DateTime.Now;
            showAlertMsg = false;
            AlertMsgTime = 10;
            getRegistryValues();
        }

        private void FormMarvin_Load(object sender, EventArgs e)
        {
            formAlert = new FormAlertDialog();

            timerConsultaSQL.Enabled = true;
            timerActualizarTiempo.Enabled = true;
            timerConsultaSQL_Tick(this, e);

        }

        public void setShowAlertMsg()
        {
            showAlertMsg = false;
        }

        private void getRegistryValues()
        {
            Object keyValue = null;
            RegistryKey key = null;
            using (key = Registry.CurrentUser.OpenSubKey("Software\\PAMI"))
            {
                if (key != null)
                {
                    keyValue = key.GetValue("mostrarAlerta");
                    if (keyValue != null)
                        showAlertMsg = Boolean.Parse((String)keyValue);
                    keyValue = key.GetValue("tiempoAlerta");
                    if (keyValue != null)
                        AlertMsgTime = Int64.Parse((String)keyValue);
                    key.Close();
                }
                else
                {
                    key = Registry.CurrentUser.CreateSubKey("Software\\PAMI");
                    key.SetValue("tiempoAlerta", ((Int64)AlertMsgTime).ToString());
                    key.SetValue("mostrarAlerta", ((Boolean)showAlertMsg).ToString());
                    key.Close();
                }
            }
        }

        private void showAlert()
        {
            if (formAlert.Visible == false)
            {
                formAlert.Left = ((Rectangle)Screen.FromControl(this).Bounds).Left; ;
                formAlert.Width = ((Rectangle)Screen.FromControl(this).Bounds).Width;
                if (showAlertMsg)
                    formAlert.Show(this);
            }
        }


        private void timerConsultaSQL_Tick(object sender, EventArgs e)
        {

            if (queryThread == null)
            {
                queryThread = new Thread(new ThreadStart(rcdQueryContratado.getDataTableThread));
                queryThread.Start();
            }
            else if (!queryThread.IsAlive)
            {
                queryThread = null;
                queryThread = new Thread(new ThreadStart(rcdQueryContratado.getDataTableThread));
                queryThread.Start();
            }

        }

        public void queryContratadosFinish(DataTable dtContratadosDemorados, Boolean queryResult)
        {
            if (queryResult)
            {
                offLineTime = 0;
                foreach (DataRow row in dtContratadosDemorados.Rows)
                {
                   /* foreach (DataGridViewRow rowGrid in dataGridViewCoVid19.Rows)
                    {
                        if (rowGrid.Cells[0].Value.ToString() == row[0].ToString())
                        {
                            if ((((int)rowGrid.Cells[6].Value - (int)row[6]) > 0)
                                && (((int)rowGrid.Cells[6].Value - (int)row[6]) <= 1))  // si toma un tiempo muy alto cuelga en el tiempo muy alto ej, 20 minutos contra 3
                                row[6] = rowGrid.Cells[6].Value;
                            break;
                        }
                    }*/
                }
                setDataGridDataSource(dtContratadosDemorados);
            }else
            {
                offLineTime++;
            }
        }

        private void showStatus()
        {
            if (offLineTime >= 2)
            {
                String tiempo = ((Int64)((offLineTime * (timerConsultaSQL.Interval / 1000)) / 60)).ToString();
                if (!labelStatus.Visible)
                {
                    labelStatus.Visible = true;
                    labelStatus.ForeColor = Color.White;
                }
                labelStatus.Text = "Sin conexion desde hace "+ tiempo +" minutos\nUltima actualizacion " + lastUpdate.ToString();
            }
            else
            {
                if (labelStatus.Visible)
                    labelStatus.Visible = false;
            }
        }

        delegate void SetDataGridDataSourceCallBack(DataTable dtContratados);

        private void setDataGridDataSource(DataTable dtContratados)
        {
            if (dgvContratados.InvokeRequired)
            {
                SetDataGridDataSourceCallBack dataGridCallback = new SetDataGridDataSourceCallBack(setDataGridDataSource);
                Invoke(dataGridCallback, new object[] { dtContratados });
            }
            else
            {
                boolIgnorarSeleccion = true;
                intFilaMostrada = dgvContratados.FirstDisplayedScrollingRowIndex;
                dtContratados.DefaultView.RowFilter = (dgvContratados.DataSource != null) ? (dgvContratados.DataSource as DataTable).DefaultView.RowFilter : "";
                dgvContratados.DataSource = dtContratados;
                serverDateTime = rcdQueryContratado.getServerTime();
                lastUpdate = serverDateTime;
                gridRefresh();
            }
        }

        private void timerActualizarTiempo_Tick(object sender, EventArgs e)
        {
            showStatus();
            if (labelStatus.Visible)
                labelStatus.ForeColor = labelStatus.ForeColor.Equals(Color.White) ? Color.Red : Color.White;

            if (dgvContratados.DataSource != null)
            {
                /*    DataTable dataTableCoVid19 = (DataTable)dataGridViewCoVid19.DataSource;
                    serverDateTime = serverDateTime.AddSeconds(1);
                    //var rows = dataTableCoVid19.Rows.Cast<DataRow>().Where(dr => (int)dr[6] > 0).Select(dr => dr);
                    foreach (DataRow row in dataTableCoVid19.Rows) {
                        int newMin = (int)(serverDateTime - ((DateTime)row[5])).TotalMinutes; //.TotalSeconds;// .TotalMinutes;
                        if (newMin >= (int)row[6])
                            row[6] = newMin;
                    }*/
               // gridRefresh();
            }
        }

        private void timeAlert()
        {
            /* 2021-09-24: Comentado para correrlo*/
            /*var oldest = dgvContratados.Rows.Cast<DataGridViewRow>().Where(dr => dr.Cells[4].Value.ToString().Trim() == "No").Select(dr => (int)dr.Cells[3].Value).DefaultIfEmpty().Max();
            var oldestServiceNumber = dgvContratados.Rows.Cast<DataGridViewRow>().Where(dr => dr.Cells[4].Value.ToString().Trim() == "No" && (int)dr.Cells[3].Value == oldest).Select(dr => dr.Cells[0].Value).FirstOrDefault();
            if (oldest >= AlertMsgTime)
            {
                formAlert.setServiceNumber(oldestServiceNumber.ToString());
                formAlert.setServiceTime(oldest);
                showAlert();
            }
            else
                formAlert.Hide();*/
        }

        private void gridRefresh()
        {
            foreach (DataGridViewColumn column in dgvContratados.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvContratados.Columns["Region"].Width = 50;
            dgvContratados.Columns["Partido"].Width = 100;
            dgvContratados.Columns["Nro.Incidente"].Width = 100;
            dgvContratados.Columns["Demora Total"].Width = 70;
            dgvContratados.Columns["Clasif.Inicial"].Width = 80;
            dgvContratados.Columns["Clasificacion"].Width = 80;
            dgvContratados.Columns["Tiempo en Clasif."].Width = 70;
            dgvContratados.Columns["Ultimo Estado"].Width = 100;
            dgvContratados.Columns["Demora Ult. Estado"].Width = 70;
            dgvContratados.Columns["Recurso Asignado"].Width = 100;
            dgvContratados.Columns["Demora desde Asignacion"].Width = 70;
            dgvContratados.Columns["Demora Asig. Anterior"].Width = 100;
            dgvContratados.Columns["Mas Asig."].Width = 50;
            dgvContratados.Columns["Ultima Observacion"].Width = dgvContratados.Width - (70*4 + 100*5 + 80*2 + 50 + 50 + 20);

            foreach (DataGridViewRow row in dgvContratados.Rows)
            {
                if (((String)row.Cells["Clasificacion"].Value).Contains("Amarillo") ||
                    (((String)row.Cells["Clasif.Inicial"].Value).Contains("Amarillo")
                        && ((String)row.Cells["Clasificacion"].Value).Contains("Rojo")
                        && row.Cells["Tiempo en Clasif."].Value.ToString().Length > 0
                        && (DateTime.Parse(row.Cells["Tiempo en Clasif."].Value.ToString()) <= DateTime.Parse("00:30:00")))) 
                {
                    if ((DateTime.Parse(row.Cells["Demora desde Asignacion"].Value.ToString()) >= DateTime.Parse("03:00:00")) 
                        && (DateTime.Parse(row.Cells["Demora desde Asignacion"].Value.ToString()) < DateTime.Parse("04:00:00")))
                    {
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    } else if (DateTime.Parse(row.Cells["Demora desde Asignacion"].Value.ToString()) >= DateTime.Parse("04:00:00"))
                    {
                        row.DefaultCellStyle.BackColor = Color.Gold;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                else if (((String)row.Cells["Clasificacion"].Value).Contains("Rojo"))
                {
                    if ( (((String)row.Cells["Clasif.Inicial"].Value).Contains("Rojo")) 
                        || (((String)row.Cells["Clasif.Inicial"].Value).Contains("Amarillo")
                        && row.Cells["Tiempo en Clasif."].Value.ToString().Length > 0
                        && (DateTime.Parse(row.Cells["Tiempo en Clasif."].Value.ToString()) > DateTime.Parse("00:30:00"))) )
                    {
                        if ((DateTime.Parse(row.Cells["Demora desde Asignacion"].Value.ToString()) >= DateTime.Parse("00:30:00"))
                            && (DateTime.Parse(row.Cells["Demora desde Asignacion"].Value.ToString()) < DateTime.Parse("01:00:00")))
                        {
                            row.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                            row.DefaultCellStyle.ForeColor = Color.White;
                        }
                        else if (DateTime.Parse(row.Cells["Demora desde Asignacion"].Value.ToString()) >= DateTime.Parse("01:00:00"))
                        {
                            row.DefaultCellStyle.BackColor = Color.DarkRed;
                            row.DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                }
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                linkCell.Value = row.Cells["Nro.Incidente"].Value.ToString();
                linkCell.LinkColor = row.DefaultCellStyle.ForeColor;
                row.Cells["Nro.Incidente"] = linkCell;
            }
            /* 2021-09-24: Comentado para correrlo*/

            /*            foreach (DataGridViewRow row in dgvContratados.Rows)
                        {
                            row.Cells[2].Style.Format = "HH:mm:ss";
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            linkCell.Value = row.Cells[0].Value.ToString();
                            linkCell.LinkColor = row.DefaultCellStyle.ForeColor;
                            row.Cells[0] = linkCell;
                        }
                        dgvContratados.ClearSelection();
                        dgvContratados.Refresh();
                        timeAlert();*/

        }

        private void dgvContratados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvContratados.Columns["Nro.Incidente"].Index) {
                FormDatosIncidente frmDatosIncidente = new FormDatosIncidente(dgvContratados.Rows[e.RowIndex].Cells["Nro.Incidente"].Value.ToString().Trim());
                frmDatosIncidente.ShowDialog();
                frmDatosIncidente = null;
            }
        }

        private void FormMarvin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((queryThread != null) && (queryThread.IsAlive))
            {
                queryThread.Abort();
                queryThread = null;
            }

        }

        private void dgvContratados_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int intIndiceSeleccionado = 0;
            boolIgnorarSeleccion = false;
            if (!String.IsNullOrEmpty(strNumeroIncidente) && e.ListChangedType == ListChangedType.Reset)
            {
                if (dgvContratados.Rows.Count > 0)
                {
                    DataGridViewRow[] rows = dgvContratados.Rows.Cast<DataGridViewRow>().Where(r => r.Cells["Nro.Incidente"].Value.ToString().Equals(strNumeroIncidente)).ToArray<DataGridViewRow>();
                    if (rows.Length > 0)
                        intIndiceSeleccionado = rows[0].Index;
                    if (intIndiceSeleccionado <= 0)
                        intIndiceSeleccionado = 0;
                    dgvContratados.Rows[intIndiceSeleccionado].Selected = true;
                    dgvContratados.CurrentCell = dgvContratados.Rows[intIndiceSeleccionado].Cells["Nro.Incidente"];

                    if (intFilaMostrada >= 0)
                        dgvContratados.FirstDisplayedScrollingRowIndex = intFilaMostrada;
                }
                else
                {
                    strNumeroIncidente = String.Empty;
                }
            }
        }

        private void dgvContratados_SelectionChanged(object sender, EventArgs e)
        {
            if (boolIgnorarSeleccion == true)
                return;

            if (dgvContratados.SelectedRows.Count > 0)
                strNumeroIncidente = dgvContratados.SelectedRows[0].Cells["Nro.Incidente"].Value.ToString();
        }

        private void cbFiltroRegion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dgvContratados.DataSource != null)
            {
                if (!cbFiltroRegion.Text.Equals("Todos"))
                    (dgvContratados.DataSource as DataTable).DefaultView.RowFilter = string.Format("Region = '{0}'", cbFiltroRegion.Text);
                else
                    (dgvContratados.DataSource as DataTable).DefaultView.RowFilter = "";
                gridRefresh();

            }
        }
    }
}
