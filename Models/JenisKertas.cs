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
    public class JenisKertas
    {
        private string id, deskripsi_1, deskripsi_2, uom;

        public static void cekFile()
        {
            if (!File.Exists("jenis_tinta.dat"))
            {
                List<JenisKertas> jk = new List<JenisKertas>() {
                    new JenisKertas()
                    {
                        Id = "16591",
                        Deskripsi_1 = "Kertas, Airline Paper 41/18.5",
                        Deskripsi_2 = "White, 41 gr/18.5 cm",
                        Uom = "KG"
                    },
                    new JenisKertas()
                    {
                        Id = "1756",
                        Deskripsi_1 = "Kertas, Airline Paper 41/23.5",
                        Deskripsi_2 = "White, 41 gr/23.5 cm",
                        Uom = "KG"
                    },
                    new JenisKertas()
                    {
                        Id = "1743",
                        Deskripsi_1 = "Kertas, Art C2S 150/65x100",
                        Deskripsi_2 = "White, 150gr/65x100",
                        Uom = "RM"
                    },
                    new JenisKertas()
                    {
                        Id = "49067",
                        Deskripsi_1 = "KERTAS, PLANO ART PAPER C2S",
                        Deskripsi_2 = "WHITE, 150GR/63X74 CM",
                        Uom = "RM"
                    }
                };

                BinaryFormatter BF = new BinaryFormatter();
                using (Stream stream = File.Open("jenis_tinta.dat", FileMode.Create))
                {
                    BF.Serialize(stream, jk);
                }
            }
        }

        public static List<JenisKertas> getData()
        {
            List<JenisKertas> jk;
            BinaryFormatter BF = new BinaryFormatter();
            using (Stream stream = File.Open("jenis_tinta.dat", FileMode.Open))
            {
                jk = (List<JenisKertas>)BF.Deserialize(stream);
            }
            return jk;
        }

        public static void writeData(List<JenisKertas> jk)
        {
            BinaryFormatter BF = new BinaryFormatter();
            using (Stream stream = File.Open("jenis_tinta.dat", FileMode.Create))
            {
                BF.Serialize(stream, jk);
            }
        }

        public string Deskripsi_1
        {
            get
            {
                return deskripsi_1;
            }

            set
            {
                deskripsi_1 = value;
            }
        }

        public string Deskripsi_2
        {
            get
            {
                return deskripsi_2;
            }

            set
            {
                deskripsi_2 = value;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
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
    }
}
