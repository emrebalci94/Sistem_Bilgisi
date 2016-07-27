using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;

namespace Sistem_Bilgisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher marka = new ManagementObjectSearcher("Select * From Win32_BIOS");//Pcnin Markası
            foreach (ManagementObject pcmarka in marka.Get())
            {
                textBox1.Text = pcmarka["version"].ToString();
            }

            RegistryKey islemci = Registry.LocalMachine;//İşlemci Markası
            islemci = islemci.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");
            textBox2.Text = (string)islemci.GetValue("ProcessorNameString").ToString();

            ManagementObjectSearcher ramara = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");//Ram Bilgileri
            foreach (ManagementObject ram in ramara.Get() )
            {
                double Ram_Bytes = (Convert.ToDouble(ram["TotalPhysicalMemory"]));
                double ramgb = Ram_Bytes / 1073741824;
                double islem = Math.Ceiling(ramgb);
                textBox3.Text = islem.ToString() + " GB";
               
            }

            ManagementObjectSearcher ekran = new ManagementObjectSearcher("Select * From Win32_VideoController");//Ekran Kartı
            foreach (ManagementObject ekrankarti in ekran.Get())
            {
                textBox4.Text = ekrankarti["name"].ToString()+" "+ekrankarti["AdapterRam"].ToString();
            }
            textBox5.Text= System.Environment.ProcessorCount.ToString()+" Çekirdek";
            textBox6.Text = System.Environment.OSVersion.ToString();
            textBox9.Text = "Pc Adı:"+System.Environment.UserName.ToString();

            ManagementObjectSearcher disk = new ManagementObjectSearcher("Select * From Win32_DiskDrive");//Hard Disk İşlemleri
            foreach (ManagementObject harddisk in disk.Get())
            {
              textBox7.Text= harddisk["Model"].ToString();//yada Caption
               double toplambyte=Convert.ToDouble(harddisk["Size"]);
                double hardgb=toplambyte/1073741824;
                double donustur=Math.Ceiling(hardgb);
                textBox8.Text =donustur.ToString()+" GB";
            }
           
        }

       
    }
}
