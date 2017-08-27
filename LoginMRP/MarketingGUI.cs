using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace LoginMRP
{
    public partial class MarketingGUI : Form
    {
        private Control parent;
        private List<ArrayList> dataKertas = new List<ArrayList>();

        public MarketingGUI(Control parent)
        {
            this.parent = parent;
            InitializeComponent();
            this.FormClosed += MarketingGUI_FormClosed;

            jenisCollComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            uomComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            jilidBukuComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            jenisBarcodeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            infoPackingComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            jenisNumeratorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            posisiNumeratorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            digitNumeratorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            jenisBoxComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            satuanLebarComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            satuanPanjangComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            kertasMasterPanel.VerticalScroll.Visible = true;
            kertasMasterPanel.HorizontalScroll.Visible = false;
            kertasMasterPanel.AutoScroll = true;
            kertasMasterPanel.ResumeLayout();
            kertasMasterPanel.Controls.Add(new Label() { Text = "ply" });
            kertasMasterPanel.Controls.Add(new Label() { Text = "jenis kertas" });
            kertasMasterPanel.Controls.Add(new Label() { Text = "warna kertas" });
            kertasMasterPanel.Controls.Add(new Label() { Text = "jumlah warna" });

            kertasPanelSO.VerticalScroll.Visible = true;
            kertasPanelSO.HorizontalScroll.Visible = false;
            kertasPanelSO.AutoScroll = true;
            kertasPanelSO.ResumeLayout();
            kertasPanelSO.Controls.Add(new Label() { Text = "ply" });
            kertasPanelSO.Controls.Add(new Label() { Text = "kode item kertas" });
            kertasPanelSO.Controls.Add(new Label() { Text = "warna kertas" });
            kertasPanelSO.Controls.Add(new Label() { Text = "jumlah warna" });

            kertasPanelFO.VerticalScroll.Visible = true;
            kertasPanelFO.HorizontalScroll.Visible = false;
            kertasPanelFO.AutoScroll = true;
            kertasPanelFO.ResumeLayout();
            kertasPanelFO.Controls.Add(new Label() { Text = "ply" });
            kertasPanelFO.Controls.Add(new Label() { Text = "kode item kertas" });
            kertasPanelFO.Controls.Add(new Label() { Text = "warna kertas" });
            kertasPanelFO.Controls.Add(new Label() { Text = "jumlah warna" });

            generateForKertasPanel();
            generateForFolding();
            generateForJilidBuku();
            generateForJenisCollating();
            generateForJenisBarcode();
            generateForInfoPacking();
            generateForJenisNumerator();
            generateForPosisiNumerator();
            generateForDigitNumerator();
            generateForJenisBox();
            generateForUOM();
            generateforSatuanlebar();
            generateforSatuanpanjang();

            jumlahPlyTextBox.KeyPress += textboxNumber_KeyPress;
            ukuranPanjangTextBox.KeyPress += textboxNumber_KeyPress;
            ukuranLebarTextBox.KeyPress += textboxNumber_KeyPress;
            isiBoxTextBox.KeyPress += textboxNumber_KeyPress;

            refreshListKodeProduk();
        }
        private void generateforSatuanlebar()
        {
            satuanLebarComboBox.Items.Add("cm");
            satuanLebarComboBox.Items.Add("inch");
            satuanLebarComboBox.Items.Add("mm");
        }
        private void generateforSatuanpanjang()
        {
            satuanPanjangComboBox.Items.Add("cm");
            satuanPanjangComboBox.Items.Add("inch");
            satuanPanjangComboBox.Items.Add("mm");
        }
        private void generateForUOM()
        {
            uomComboBox.Items.Add("BK");
            uomComboBox.Items.Add("EA");
            uomComboBox.Items.Add("ROLL");
            uomSOComboBox.Items.Add("BK");
            uomSOComboBox.Items.Add("EA");
            uomSOComboBox.Items.Add("ROLL");
            uomFCComboBox.Items.Add("BK");
            uomFCComboBox.Items.Add("EA");
            uomFCComboBox.Items.Add("ROLL");
        }

        private void generateForJenisBox()
        {
            jenisBoxComboBox.Items.Add("Printing");
            jenisBoxComboBox.Items.Add("Polos");
        }

        private void generateForDigitNumerator()
        {
            for (int c = 1; c <= 20; c++)
                digitNumeratorComboBox.Items.Add("" + c);
        }

        private void generateForPosisiNumerator()
        {
            posisiNumeratorComboBox.Items.Add("Kiri atas");
            posisiNumeratorComboBox.Items.Add("Kanan Atas");
            posisiNumeratorComboBox.Items.Add("Tengah Atas");
            posisiNumeratorComboBox.Items.Add("kiri atas dan kanan atas");
            posisiNumeratorComboBox.Items.Add("kanan atas dan tengah atas");
            posisiNumeratorComboBox.Items.Add("kiri tengah");
            posisiNumeratorComboBox.Items.Add("kanan tengah");
            posisiNumeratorComboBox.Items.Add("tengah");
            posisiNumeratorComboBox.Items.Add("kiri bawah");
            posisiNumeratorComboBox.Items.Add("tengah bawah");
            posisiNumeratorComboBox.Items.Add("kanan bawah");
            posisiNumeratorComboBox.Items.Add("kiri bawah dan kanan bawah");
            posisiNumeratorComboBox.Items.Add("kanan bawah dan tengah bawah");
        }

        private void generateForJenisNumerator()
        {
            jenisNumeratorComboBox.Items.Add("Hitam Mekanis");
            jenisNumeratorComboBox.Items.Add("Black Penatrating Red");
            jenisNumeratorComboBox.Items.Add("Black Fluoresence Green Panetrating red");
        }

        private void generateForInfoPacking()
        {
            infoPackingComboBox.Items.Add("Bandel kertas Samson");
            infoPackingComboBox.Items.Add("Bandel Karet");
            infoPackingComboBox.Items.Add("Bungkus pack Shrink");
            infoPackingComboBox.Items.Add("Bungkus Plastik Seal");
            infoPackingComboBox.Items.Add("Bungkus Sebelum masuk Box");
            infoPackingComboBox.Items.Add("Box dibungkus Plastik");
            infoPackingComboBox.Items.Add("Bungkus plastik luar dan dalam box");
        }

        private void generateForJenisBarcode()
        {
            jenisBarcodeComboBox.Items.Add("CODE 39");
            jenisBarcodeComboBox.Items.Add("EAN 128");
            jenisBarcodeComboBox.Items.Add("QR CODE");
        }

        private void generateForJenisCollating()
        {
            jenisCollComboBox.Items.Add("Single Crimping");
            jenisCollComboBox.Items.Add("Double Crimping");
        }

        private void generateForJilidBuku()
        {
            jilidBukuComboBox.Items.Add("Lem buku sisi atas");
            jilidBukuComboBox.Items.Add("Lem buku sisi kiri");
            jilidBukuComboBox.Items.Add("Lem buku sisi bawah");
            jilidBukuComboBox.Items.Add("Bandel lepasan");
            jilidBukuComboBox.Items.Add("Staching lakban");
            jilidBukuComboBox.Items.Add("softcover Hardcover");
        }

        private void generateForFolding()
        {
            foldingComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int c = 8; c <= 24; c++)
            {
                foldingComboBox.Items.Add(c + "");
                if (c == 8 || c==9)
                {
                    foldingComboBox.Items.Add(c + ",5");
                }
            }
        }

        private void generateForKertas(int c)
        {
            kertasMasterPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            kertasMasterPanel.Controls.Add(new Label() { Text = "" + (c + 1) });
            dataKertas.Add(new ArrayList());

            dataKertas[c].Add(new ComboBox());
            ((ComboBox)dataKertas[c][0]).Items.Add("CB");
            ((ComboBox)dataKertas[c][0]).Items.Add("CFB");
            ((ComboBox)dataKertas[c][0]).Items.Add("CF");
            ((ComboBox)dataKertas[c][0]).Items.Add("HVS");
            ((ComboBox)dataKertas[c][0]).Items.Add("SECURITY");
            ((ComboBox)dataKertas[c][0]).Items.Add("SAMSON");
            ((ComboBox)dataKertas[c][0]).Items.Add("BC");
            ((ComboBox)dataKertas[c][0]).Items.Add("CHIP");
            ((ComboBox)dataKertas[c][0]).Items.Add("AIRLINE");
            ((ComboBox)dataKertas[c][0]).Items.Add("ART");
            ((ComboBox)dataKertas[c][0]).Items.Add("PLANO");
            ((ComboBox)dataKertas[c][0]).Items.Add("POSW");
            ((ComboBox)dataKertas[c][0]).Items.Add("THERMAL");
            ((ComboBox)dataKertas[c][0]).DropDownStyle = ComboBoxStyle.DropDownList;
            ((ComboBox)dataKertas[c][0]).Dock = DockStyle.Fill;
            kertasMasterPanel.Controls.Add(((ComboBox)dataKertas[c][0]));

            dataKertas[c].Add(new ComboBox());
            ((ComboBox)dataKertas[c][1]).Items.Add("White");
            ((ComboBox)dataKertas[c][1]).Items.Add("Red");
            ((ComboBox)dataKertas[c][1]).Items.Add("Yellow");
            ((ComboBox)dataKertas[c][1]).Items.Add("Blue");
            ((ComboBox)dataKertas[c][1]).Items.Add("Green");
            ((ComboBox)dataKertas[c][1]).DropDownStyle = ComboBoxStyle.DropDownList;
            ((ComboBox)dataKertas[c][1]).Dock = DockStyle.Fill;
            kertasMasterPanel.Controls.Add(((ComboBox)dataKertas[c][1]));

            dataKertas[c].Add(new TextBox());
            ((TextBox)dataKertas[c][2]).KeyPress += textboxNumber_KeyPress;
            ((TextBox)dataKertas[c][2]).Dock = DockStyle.Fill;
            kertasMasterPanel.Controls.Add((TextBox)dataKertas[c][2]);

            kertasMasterPanel.RowCount++;
        }

        private void generateForKertasPanel()
        {
            for (int c = 0; c < 15; c++)
                generateForKertas(c);
        }

        private void textboxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
            if (e.KeyChar.ToString() == "," && (sender as TextBox).Text.IndexOf(',') == -1 && (sender as TextBox).Text != "")
            {
                e.Handled = false;
            }
        }

        private void MarketingGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<Marketing> marketing = Marketing.getData();

                Marketing mrk = new Marketing();
                mrk.KodeProduk = kodeProdukComboBox.Text;
                mrk.UkuranPanjang = ukuranPanjangTextBox.Text;
                mrk.UkuranLebar = ukuranLebarTextBox.Text;
                mrk.Folding = foldingComboBox.Text;
                mrk.JumlahPly = jumlahPlyTextBox.Text;
                Convert.ToInt32(mrk.JumlahPly);
                mrk.IsiPerBox = isiBoxTextBox.Text;
                Convert.ToInt32(mrk.IsiPerBox);
                mrk.Uom = uomComboBox.Text;
                mrk.NamaProduk = namaProdukTextBox.Text;
                mrk.NamaPelanggan = namaPelangganTextBox.Text;
                foreach (ArrayList kertas in dataKertas)
                {
                    if (((ComboBox)kertas[0]).Text == "" || ((ComboBox)kertas[0]).Text == null)
                    {
                        break;
                    }
                    else
                    {
                        mrk.Kertas.Add(((ComboBox)kertas[0]).Text);
                        mrk.Kertas.Add(((ComboBox)kertas[1]).Text);
                        mrk.Kertas.Add(((TextBox)kertas[2]).Text);
                    }
                }
                mrk.JenisCollating = jenisCollComboBox.Text;
                mrk.JilidBuku = jilidBukuComboBox.Text;
                mrk.JenisBarcode = jenisBarcodeComboBox.Text;
                mrk.InfoPacking = infoPackingComboBox.Text;
                mrk.JenisNomerator = jenisNumeratorComboBox.Text;
                mrk.PosisiNomerator = posisiNumeratorComboBox.Text;
                mrk.DigitNomerator = digitNumeratorComboBox.Text;
                mrk.JenisBox = jenisBoxComboBox.Text;

                marketing.Add(mrk);

                Marketing.writeData(marketing);

                refreshListKodeProduk();
                clearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pastikan semua data telah terisi dengan benar!");
            }
        }

        private void refreshListKodeProduk()
        {
            kodeProdukSOComboBox.Items.Clear();
            kodeProdukFCComboBox.Items.Clear();

            List<Marketing> marketing = Marketing.getData();
            foreach (Marketing mrk in marketing)
            {
                if (mrk.IsForSalesOrder)
                    kodeProdukSOComboBox.Items.Add(mrk.KodeProduk);
                if (mrk.IsForForecast)
                    kodeProdukFCComboBox.Items.Add(mrk.KodeProduk);
            }
        }

        private void clearForm()
        {
            kodeProdukComboBox.Text = "";
            ukuranPanjangTextBox.Text = "";
            ukuranLebarTextBox.Text = "";
            foldingComboBox.SelectedIndex = -1;
            namaPelangganTextBox.Text = "";
            jumlahPlyTextBox.Text = "";
            isiBoxTextBox.Text = "";
            uomComboBox.SelectedIndex = -1;
            namaProdukTextBox.Text = "";
            isiBoxTextBox.Text = "";
            foreach (ArrayList kertas in dataKertas)
            {
                ((ComboBox)kertas[0]).SelectedIndex = -1;
                ((ComboBox)kertas[1]).SelectedIndex = -1;
                ((TextBox)kertas[2]).Text = "";
            }
            jenisCollComboBox.SelectedIndex = -1;
            jilidBukuComboBox.SelectedIndex = -1;
            jenisBarcodeComboBox.SelectedIndex = -1;
            infoPackingComboBox.SelectedIndex = -1;
            jenisNumeratorComboBox.SelectedIndex = -1;
            posisiNumeratorComboBox.SelectedIndex = -1;
            digitNumeratorComboBox.SelectedIndex = -1;
            jenisBoxComboBox.SelectedIndex = -1;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void tambahKolomButton_Click(object sender, EventArgs e)
        {
            generateForKertas(kertasMasterPanel.RowCount - 1);
        }

        private void kodeProdukSOComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            statusSOLabel_so.Text = "";
            approvedLabel_so.Text = "";

            List<Marketing> marketing = Marketing.getData();
            Marketing mrk = marketing.Find(kd => kd.KodeProduk == kodeProdukSOComboBox.Text);

            noSOTextBox.Text = "" + marketing.Count;
            noWOSOTextBox.Text = "" + marketing.Count;
            namaPelangganSOTextBox.Text = mrk.NamaPelanggan;
            namaProdukSOTextBox.Text = mrk.NamaProduk;
            ukuranSOTextBox.Text = "" + (Convert.ToInt32(mrk.UkuranLebar) +" X "+ Convert.ToInt32(mrk.UkuranPanjang));
            jumlahPlySOTextBox.Text = mrk.JumlahPly;
            foldingSOComboBox.Text = mrk.Folding;
            isiSOTextBox.Text = mrk.IsiPerBox;

            kertasPanelSO.Controls.Clear();
            kertasPanelSO.RowStyles.Clear();
            kertasPanelSO.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            kertasPanelSO.Controls.Add(new Label() { Text = "ply" });
            kertasPanelSO.Controls.Add(new Label() { Text = "kode item kertas" });
            kertasPanelSO.Controls.Add(new Label() { Text = "warna kertas" });
            kertasPanelSO.Controls.Add(new Label() { Text = "jumlah warna" });

            for (int c = 1; c <= mrk.Kertas.Count / 3; c++)
            {
                kertasPanelSO.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                kertasPanelSO.Controls.Add(new Label() { Text = "" + c });
                kertasPanelSO.Controls.Add(new Label() { Text = mrk.Kertas[(c * 3) - 3] });
                kertasPanelSO.Controls.Add(new Label() { Text = mrk.Kertas[(c * 3) - 2] });
                kertasPanelSO.Controls.Add(new Label() { Text = mrk.Kertas[(c * 3) - 1] });
            }

            alamatSOTextBox.Text = mrk.AlamatPengiriman;
            jumlahPesananTextBox.Text = mrk.JumlahPesanan_so;
            uomSOComboBox.Text = mrk.Uom_so;
            jenisOrdertextBox.Text = mrk.JenisOrder;
            namaSalesTextBox.Text = mrk.NamaSales;
            statusSOLabel_so.Text = mrk.StatusSO_so;
            approvedLabel_so.Text = mrk.Approved_so;
            isiSOTextBox.Text = mrk.IsiPerBox;
        }

        private void saveSoButton_Click(object sender, EventArgs e)
        {
            List<Marketing> marketing = Marketing.getData();
            marketing.Where(kd => kd.KodeProduk == kodeProdukSOComboBox.Text).First().AlamatPengiriman = alamatSOTextBox.Text;
            marketing.Where(kd => kd.KodeProduk == kodeProdukSOComboBox.Text).First().JumlahPesanan_so = jumlahPesananTextBox.Text;
            marketing.Where(kd => kd.KodeProduk == kodeProdukSOComboBox.Text).First().Uom_so = uomSOComboBox.Text;
            marketing.Where(kd => kd.KodeProduk == kodeProdukSOComboBox.Text).First().JenisOrder = jenisOrdertextBox.Text;
            marketing.Where(kd => kd.KodeProduk == kodeProdukSOComboBox.Text).First().NamaSales = namaSalesTextBox.Text;
            marketing.Where(kd => kd.KodeProduk == kodeProdukSOComboBox.Text).First().StatusSO_so = statusSOTextBox1.Text + "-" + statusSOTextBox2.Text;
            marketing.Where(kd => kd.KodeProduk == kodeProdukSOComboBox.Text).First().Approved_so = aprrovedSoTextBox1.Text + "-" + aprrovedSoTextBox2.Text;
            marketing.Where(kd => kd.KodeProduk == kodeProdukSOComboBox.Text).First().TanggalPesanan_so = tanggalPesanDateTimePicker.Text;
            marketing.Where(kd => kd.KodeProduk == kodeProdukSOComboBox.Text).First().IsForForecast = false;
            Marketing.writeData(marketing);

            refreshListKodeProduk();
        }

        private void closeSOButton_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Close();
        }

        private void closeFCButton_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Close();
        }

        private void kodeProdukFCComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            statusSOLabel_fo.Text = "";
            approvedLabel_fo.Text = "";

            List<Marketing> marketing = Marketing.getData();
            Marketing mrk = marketing.Find(kd => kd.KodeProduk == kodeProdukFCComboBox.Text);

            noSOTextBox_fo.Text = "" + marketing.Count;
            noWOTextBox_fo.Text = "" + marketing.Count;
            namaPelangganFCTextBox.Text = mrk.NamaPelanggan;
            namaProdukFCTextBox.Text = mrk.NamaProduk;
            ukuranFCTextBox.Text = "" + mrk.UkuranLebar +" X "+ mrk.UkuranPanjang;
            jumlahPlyFCTextBox.Text = mrk.JumlahPly;
            foldingFCComboBox.Text = mrk.Folding;
            isiFCTextBox.Text = mrk.IsiPerBox;

            kertasPanelFO.Controls.Clear();
            kertasPanelFO.RowStyles.Clear();
            kertasPanelFO.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            kertasPanelFO.Controls.Add(new Label() { Text = "ply" });
            kertasPanelFO.Controls.Add(new Label() { Text = "kode item kertas" });
            kertasPanelFO.Controls.Add(new Label() { Text = "warna kertas" });
            kertasPanelFO.Controls.Add(new Label() { Text = "jumlah warna" });

            for (int c = 1; c <= mrk.Kertas.Count / 3; c++)
            {
                kertasPanelFO.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                kertasPanelFO.Controls.Add(new Label() { Text = "" + c });
                kertasPanelFO.Controls.Add(new Label() { Text = mrk.Kertas[(c * 3) - 3] });
                kertasPanelFO.Controls.Add(new Label() { Text = mrk.Kertas[(c * 3) - 2] });
                kertasPanelFO.Controls.Add(new Label() { Text = mrk.Kertas[(c * 3) - 1] });
            }

            tanggalPesanFCDateTimePicker.Text = mrk.TanggalPesanan_fo;
            jenisOrderFCTextBox.Text = mrk.JenisOrder_fo;
            jumlahPesananFCTextBox.Text = mrk.JumlahPesanan_fo;
            uomFCComboBox.Text = mrk.Uom_fo;
            namaSalesFCTextBox.Text = mrk.NamaSales_fo;
            statusSOLabel_fo.Text = mrk.StatusSO_fo;
            approvedLabel_fo.Text = mrk.Approved_fo;
        }

        private void saveFCButton_Click(object sender, EventArgs e)
        {
            List<Marketing> marketing = Marketing.getData();
            marketing.Where(kd => kd.KodeProduk == kodeProdukFCComboBox.Text).First().JumlahPesanan_fo = jumlahPesananFCTextBox.Text;
            marketing.Where(kd => kd.KodeProduk == kodeProdukFCComboBox.Text).First().Uom_fo = uomFCComboBox.Text;
            marketing.Where(kd => kd.KodeProduk == kodeProdukFCComboBox.Text).First().JenisOrder_fo = jenisOrderFCTextBox.Text;
            marketing.Where(kd => kd.KodeProduk == kodeProdukFCComboBox.Text).First().NamaSales = namaSalesTextBox.Text;
            marketing.Where(kd => kd.KodeProduk == kodeProdukFCComboBox.Text).First().StatusSO_fo = statusSOTextBox1_fo.Text + "-" + statusSOTextBox2_fo.Text;
            marketing.Where(kd => kd.KodeProduk == kodeProdukFCComboBox.Text).First().Approved_fo = approvedTextBox1_fo.Text + "-" + aprrovedSoTextBox2.Text;
            marketing.Where(kd => kd.KodeProduk == kodeProdukFCComboBox.Text).First().TanggalPesanan_so = tanggalPesanFCDateTimePicker.Text;
            marketing.Where(kd => kd.KodeProduk == kodeProdukFCComboBox.Text).First().IsForSalesOrder = false;
            Marketing.writeData(marketing);

            refreshListKodeProduk();
        }

        private void isiBoxTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void jenisCollComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void foldingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void noSOTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void kodeProdukComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
