using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XRent
{
    public partial class AddNewCarDetailsDialog: Form
    {

        public int NewCarId { get; private set; } = -1;

        public AddNewCarDetailsDialog()
        {
            InitializeComponent();
        }

         private void ChkIsElectricHybridDialog_CheckedChanged(object sender, EventArgs e)
         {
                txtElectricRangeDialog.Enabled = chkIsElectricHybridDialog.Checked;
             if (!chkIsElectricHybridDialog.Checked)
            {
                txtElectricRangeDialog.Clear();
            }
        }

        private void AddNewCarDetailsDialog_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelDialog_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOkDialog_Click(object sender, EventArgs e)
        {
            string brand = txtBrandDialog.Text.Trim();
            string model = txtModelDialog.Text.Trim();
            string transmission = txtTransmissionDialog.Text.Trim();
            string engineCapacityStr = txtEngineCapacityDialog.Text.Trim();
            string fuelType = txtFuelTypeDialog.Text.Trim();
            string horsepowerStr = txtHorsepowerDialog.Text.Trim();
            string driveType = txtDriveTypeDialog.Text.Trim();
            string acceleration = txtAccelerationDialog.Text.Trim();
            string engineType = txtEngineTypeDialog.Text.Trim();
            string fuelConsumptionStr = txtFuelConsumptionDialog.Text.Trim();
            string electricRangeStr = txtElectricRangeDialog.Text.Trim();
            bool isElectricOrHybrid = chkIsElectricHybridDialog.Checked;

            if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model) ||
                string.IsNullOrWhiteSpace(transmission) || string.IsNullOrWhiteSpace(fuelType) ||
                string.IsNullOrWhiteSpace(horsepowerStr) || string.IsNullOrWhiteSpace(driveType) ||
                string.IsNullOrWhiteSpace(acceleration) || string.IsNullOrWhiteSpace(engineType))
            {
                MessageBox.Show("Lütfen tüm temel alanları doldurun (marka, model, şanzıman vb.).", "Doğrulama hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isElectricOrHybrid && string.IsNullOrWhiteSpace(engineCapacityStr))
            {
                MessageBox.Show("Elektrikli olmayan araçlar için motor hacmini belirtmeniz gerekir.", "Doğrulama hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isElectricOrHybrid && string.IsNullOrWhiteSpace(fuelConsumptionStr))
            {
                MessageBox.Show("Yakıt tüketimi, elektrikli olmayan otomobiller için zorunludur.", "Doğrulama hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isElectricOrHybrid && string.IsNullOrWhiteSpace(electricRangeStr))
            {
                MessageBox.Show("Elektrikli araç/hibrit araç için elektrikle menzil belirtilmelidir.", "Doğrulama hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int horsepower = 0;
            if (!string.IsNullOrWhiteSpace(horsepowerStr) && !int.TryParse(horsepowerStr, out horsepower))
            {
                MessageBox.Show("Güç (bg) tam sayı olmalıdır.", "Biçim hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal engineCapacity = 0;
            if (!string.IsNullOrWhiteSpace(engineCapacityStr) &&
                !decimal.TryParse(engineCapacityStr.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out engineCapacity))
            {
                MessageBox.Show("Motor hacmi yanlış sayısal formatta belirtilmiştir (örneğin, 1.6 veya 2.0).", "Biçim hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal fuelConsumption = 0;
            if (!string.IsNullOrWhiteSpace(fuelConsumptionStr) &&
               !decimal.TryParse(fuelConsumptionStr.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out fuelConsumption))
            {
                MessageBox.Show("Yakıt tüketimi yanlış sayı formatında belirtilmiştir.", "Biçim hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int electricRange = 0;
            if (!string.IsNullOrWhiteSpace(electricRangeStr) && !int.TryParse(electricRangeStr, out electricRange))
            {
                MessageBox.Show("Elektrikle çalışabilme süresi tam sayı olmalıdır.", "Biçim hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO cars 
                             (brand, model, transmission, engine_capacity, fuel_type, horsepower, 
                              drive_type, acceleration, engine_type, fuel_consumption, electric_range, 
                              status, reserved_by, image_path) 
                             VALUES 
                             (@brand, @model, @transmission, @engine_capacity, @fuel_type, @horsepower, 
                              @drive_type, @acceleration, @engine_type, @fuel_consumption, @electric_range, 
                              0, NULL, NULL);
                             SELECT LAST_INSERT_ID();";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@brand", brand);
                        cmd.Parameters.AddWithValue("@model", model);
                        cmd.Parameters.AddWithValue("@transmission", transmission);
                        cmd.Parameters.AddWithValue("@fuel_type", fuelType);
                        cmd.Parameters.AddWithValue("@horsepower", horsepower);
                        cmd.Parameters.AddWithValue("@drive_type", driveType);
                        cmd.Parameters.AddWithValue("@acceleration", acceleration);
                        cmd.Parameters.AddWithValue("@engine_type", engineType);

                        if (isElectricOrHybrid && string.IsNullOrWhiteSpace(engineCapacityStr))
                            cmd.Parameters.AddWithValue("@engine_capacity", DBNull.Value);
                        else if (!string.IsNullOrWhiteSpace(engineCapacityStr))
                            cmd.Parameters.AddWithValue("@engine_capacity", engineCapacity);
                        else
                            cmd.Parameters.AddWithValue("@engine_capacity", DBNull.Value);

                        if (isElectricOrHybrid && string.IsNullOrWhiteSpace(fuelConsumptionStr))
                            cmd.Parameters.AddWithValue("@fuel_consumption", DBNull.Value);
                        else if (!string.IsNullOrWhiteSpace(fuelConsumptionStr))
                            cmd.Parameters.AddWithValue("@fuel_consumption", fuelConsumption);
                        else
                            cmd.Parameters.AddWithValue("@fuel_consumption", DBNull.Value);


                        if (string.IsNullOrWhiteSpace(electricRangeStr))
                            cmd.Parameters.AddWithValue("@electric_range", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@electric_range", electricRange);

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            this.NewCarId = Convert.ToInt32(result);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Araç eklenemedi (ID alınamadı).", "Veritabanı hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Sütun için veriler kesildi"))
                {
                    MessageBox.Show($"Veri kaydetme hatası: {ex.Message}\nTüm sayısal değerlerin doğru girildiğinden ve veritabanı formatına uygun olduğundan emin olun (örneğin, kesirli sayılar için nokta ayırıcı kullanın).", "Veri hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Araç eklerken veritabanı hatası: " + ex.Message, "Veritabanı hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Araç eklerken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtElectricRangeDialog_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelElectricRange_Click(object sender, EventArgs e)
        {

        }

        private void chkIsElectricHybridDialog_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtFuelConsumptionDialog_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelFuelConsuption_Click(object sender, EventArgs e)
        {

        }

        private void txtEngineTypeDialog_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelEngineType_Click(object sender, EventArgs e)
        {

        }

        private void txtAccelerationDialog_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelAcceleration_Click(object sender, EventArgs e)
        {

        }

        private void txtDriveTypeDialog_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelDriveType_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtHorsepowerDialog_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelHorsePower_Click(object sender, EventArgs e)
        {

        }

        private void txtFuelTypeDialog_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelFuelType_Click(object sender, EventArgs e)
        {

        }

        private void txtEngineCapacityDialog_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelEngineCapacity_Click(object sender, EventArgs e)
        {

        }

        private void txtModelDialog_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelModel_Click(object sender, EventArgs e)
        {

        }

        private void txtTransmissionDialog_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelTransmission_Click(object sender, EventArgs e)
        {

        }

        private void txtBrandDialog_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelBrand_Click(object sender, EventArgs e)
        {

        }
    }
}
