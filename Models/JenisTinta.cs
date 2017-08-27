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
    public class JenisTinta
    {
        private string id, deskripsi;

        public static void cekFile()
        {
            if (!File.Exists("jenis_tinta.dat"))
            {
                List<JenisTinta> jenis_tinta = new List<JenisTinta>() {
                    new JenisTinta()
                    {
                        Id = "2626",
                        Deskripsi = "FD1040 IR Black Ink Kodak"
                    },
                    new JenisTinta()
                    {
                        Id = "15996",
                        Deskripsi = "KODAK PROS S-SERIES PIGMENT"
                    },
                    new JenisTinta()
                    {
                        Id = "15997",
                        Deskripsi = "KODAK PROS S-SERIES REPLEN"
                    }
                };

                BinaryFormatter BF = new BinaryFormatter();
                using (Stream stream = File.Open("jenis_tinta.dat", FileMode.Create))
                {
                    BF.Serialize(stream, jenis_tinta);
                }
            }
        }

        public static List<JenisTinta> getData()
        {
            List<JenisTinta> jenis_tinta;
            BinaryFormatter BF = new BinaryFormatter();
            using (Stream stream = File.Open("jenis_tinta.dat", FileMode.Open))
            {
                jenis_tinta = (List<JenisTinta>)BF.Deserialize(stream);
            }
            return jenis_tinta;
        }

        public static void writeData(List<JenisTinta> jenis_tinta)
        {
            BinaryFormatter BF = new BinaryFormatter();
            using (Stream stream = File.Open("jenis_tinta.dat", FileMode.Create))
            {
                BF.Serialize(stream, jenis_tinta);
            }
        }

        public string Deskripsi
        {
            get
            {
                return deskripsi;
            }

            set
            {
                deskripsi = value;
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
    }
}
