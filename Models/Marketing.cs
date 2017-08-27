using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;

namespace Models
{
    [Serializable]
    public class Marketing
    {
        private bool isForSalesOrder = true, isForForecast = true;

        private List<string> kertas = new List<string>();

        private string kodeProduk = "", namaPelanggan = "", namaProduk = "", ukuranPanjang = "", jumlahPly = "", ukuranLebar = "", isiPerBox = "", folding, uom = "", jenisCollating = "", jenisNomerator = "", jenisBarcode = "", infoPacking = "", jilidBuku = "", posisiNomerator = "", digitNomerator = "", jenisBox = "";

        private string tanggalPesanan_so = "", alamatPengiriman = "", jumlahPesanan_so = "", uom_so = "", jenisOrder = "", namaSales = "", statusSO_so = "", approved_so = "";

        private string tanggalPesanan_fo = "", jenisOrder_fo = "", jumlahPesanan_fo = "", uom_fo = "", namaSales_fo = "", statusSO_fo = "", approved_fo = "";

        public static void cekFile()
        {
            if (!File.Exists("marketing.dat"))
            {
                BinaryFormatter BF = new BinaryFormatter();
                using (Stream stream = File.Open("marketing.dat", FileMode.Create))
                {
                    BF.Serialize(stream, new List<Marketing>());
                }
            }
        }

        public static List<Marketing> getData()
        {
            cekFile();
            List<Marketing> marketing;
            BinaryFormatter BF = new BinaryFormatter();
            using (Stream stream = File.Open("marketing.dat", FileMode.Open))
            {
                marketing = (List<Marketing>)BF.Deserialize(stream);
            }
            return marketing;
        }

        public static void writeData(List<Marketing> marketing)
        {
            cekFile();
            BinaryFormatter BF = new BinaryFormatter();
            using (Stream stream = File.Open("marketing.dat", FileMode.Open))
            {
                BF.Serialize(stream, marketing);
            }
        }

        public bool IsForSalesOrder
        {
            get
            {
                return isForSalesOrder;
            }

            set
            {
                isForSalesOrder = value;
            }
        }

        public bool IsForForecast
        {
            get
            {
                return isForForecast;
            }

            set
            {
                isForForecast = value;
            }
        }

        public List<string> Kertas
        {
            get
            {
                return kertas;
            }

            set
            {
                kertas = value;
            }
        }

        public string KodeProduk
        {
            get
            {
                return kodeProduk;
            }

            set
            {
                kodeProduk = value;
            }
        }

        public string NamaPelanggan
        {
            get
            {
                return namaPelanggan;
            }

            set
            {
                namaPelanggan = value;
            }
        }

        public string NamaProduk
        {
            get
            {
                return namaProduk;
            }

            set
            {
                namaProduk = value;
            }
        }

        public string UkuranPanjang
        {
            get
            {
                return ukuranPanjang;
            }

            set
            {
                ukuranPanjang = value;
            }
        }

        public string JumlahPly
        {
            get
            {
                return jumlahPly;
            }

            set
            {
                jumlahPly = value;
            }
        }

        public string UkuranLebar
        {
            get
            {
                return ukuranLebar;
            }

            set
            {
                ukuranLebar = value;
            }
        }

        public string IsiPerBox
        {
            get
            {
                return isiPerBox;
            }

            set
            {
                isiPerBox = value;
            }
        }

        public string Folding
        {
            get
            {
                return folding;
            }

            set
            {
                folding = value;
            }
        }

        public string Uom
        {
            get
            {
                return uom;
            }

            set
            {
                uom = value;
            }
        }

        public string JenisCollating
        {
            get
            {
                return jenisCollating;
            }

            set
            {
                jenisCollating = value;
            }
        }

        public string JenisNomerator
        {
            get
            {
                return jenisNomerator;
            }

            set
            {
                jenisNomerator = value;
            }
        }

        public string JenisBarcode
        {
            get
            {
                return jenisBarcode;
            }

            set
            {
                jenisBarcode = value;
            }
        }

        public string InfoPacking
        {
            get
            {
                return infoPacking;
            }

            set
            {
                infoPacking = value;
            }
        }

        public string JilidBuku
        {
            get
            {
                return jilidBuku;
            }

            set
            {
                jilidBuku = value;
            }
        }

        public string PosisiNomerator
        {
            get
            {
                return posisiNomerator;
            }

            set
            {
                posisiNomerator = value;
            }
        }

        public string DigitNomerator
        {
            get
            {
                return digitNomerator;
            }

            set
            {
                digitNomerator = value;
            }
        }

        public string JenisBox
        {
            get
            {
                return jenisBox;
            }

            set
            {
                jenisBox = value;
            }
        }

        public string TanggalPesanan_so
        {
            get
            {
                return tanggalPesanan_so;
            }

            set
            {
                tanggalPesanan_so = value;
            }
        }

        public string AlamatPengiriman
        {
            get
            {
                return alamatPengiriman;
            }

            set
            {
                alamatPengiriman = value;
            }
        }

        public string JumlahPesanan_so
        {
            get
            {
                return jumlahPesanan_so;
            }

            set
            {
                jumlahPesanan_so = value;
            }
        }

        public string Uom_so
        {
            get
            {
                return uom_so;
            }

            set
            {
                uom_so = value;
            }
        }

        public string JenisOrder
        {
            get
            {
                return jenisOrder;
            }

            set
            {
                jenisOrder = value;
            }
        }

        public string NamaSales
        {
            get
            {
                return namaSales;
            }

            set
            {
                namaSales = value;
            }
        }

        public string StatusSO_so
        {
            get
            {
                return statusSO_so;
            }

            set
            {
                statusSO_so = value;
            }
        }

        public string Approved_so
        {
            get
            {
                return approved_so;
            }

            set
            {
                approved_so = value;
            }
        }

        public string TanggalPesanan_fo
        {
            get
            {
                return tanggalPesanan_fo;
            }

            set
            {
                tanggalPesanan_fo = value;
            }
        }

        public string JenisOrder_fo
        {
            get
            {
                return jenisOrder_fo;
            }

            set
            {
                jenisOrder_fo = value;
            }
        }

        public string JumlahPesanan_fo
        {
            get
            {
                return jumlahPesanan_fo;
            }

            set
            {
                jumlahPesanan_fo = value;
            }
        }

        public string Uom_fo
        {
            get
            {
                return uom_fo;
            }

            set
            {
                uom_fo = value;
            }
        }

        public string NamaSales_fo
        {
            get
            {
                return namaSales_fo;
            }

            set
            {
                namaSales_fo = value;
            }
        }

        public string StatusSO_fo
        {
            get
            {
                return statusSO_fo;
            }

            set
            {
                statusSO_fo = value;
            }
        }

        public string Approved_fo
        {
            get
            {
                return approved_fo;
            }

            set
            {
                approved_fo = value;
            }
        }
        
    }
}
