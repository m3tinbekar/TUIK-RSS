using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Tulpep.NotificationWindow;


namespace tuikUygulama
{
    public partial class tuikHaberForm : Form
    {

        
        private DateTime EnsonHaberGeldigiTarih = DateTime.Now;
        private int selectedIndex;
        private string baslikUrl;
        private string kayitSayisi;
        private string selectedValue;
        private ContextMenu cMenu;
        private string sliderItem;
        private string contentName;
        public string [] titleName;
        private string sliderName;
        private string sliderCalendar;
        private string tarih;

        




        public tuikHaberForm()
        {
            
            InitializeComponent();

            
        }


        //public class ComboboxItem
        //{
        //    public string Text { get; set; }
        //    public string Value { get; set; }
        //    public override string ToString() { return Text; }
        //}
        //public class title
        //{
        //    public string titleContent { get; set; }
            

        //}

        public void getData()
        {
            String url = "https://data.tuik.gov.tr/";
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(new List<string>() {
            "--silent-launch",
            "--no-startup-window",
            "no-sandbox",
            "headless",
            });

            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
            driver.Navigate().GoToUrl(url);

            try
            {
                for (int i = 1; i <= 20; i++)
                {
                    istatistikKonu.Items.Add(driver.FindElement(By.XPath("/html/body/div[3]/div/div[" + i + "]/a")).Text);
                }

            }
            catch (Exception)
            {


            }
            driver.Close();
            driver.Dispose();
            
        }
        
        public void slider()
        {
            DateTime date1 = new DateTime();
            PopupNotifier popup = new PopupNotifier();
            //string sliderFirstItem;
            //var sliderTitle = new List<string>();
            String url = "https://www.tuik.gov.tr/";
            
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(new List<string>() {
                //"--silent-launch",
                //"--no-startup-window",
                "no-sandbox",
                "--disable-gpu",
                //"headless",
                //"--disable-extensions",
                //"--profile-directory=Default",
                //"--disable-plugins-discovery",
                //"--start-maximized",
                
                "--window-position=-32000,-32000",
            });
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            
            ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
            
            driver.Navigate().GoToUrl(url);

            if (url == "https://www.tuik.gov.tr/")
            {
                
                try
                {
                    for (int i = 1; i <= 20; i++)
                    {
                        
                        sliderCalendar = driver.FindElementByXPath("/html/body/div[3]/div/div[1]/div[3]/div/div[2]/div[" + i + "]/div/a/div[1]/div[1]").Text;
                        //Thread.Sleep(2000);
                        if (i % 2 == 0)
                        {
                            Thread.Sleep(250);
                            driver.FindElementByXPath("/html/body/div[3]/div/div[1]/div[3]/div/div[3]").Click();
                            
                            
                        }

                        
                        sliderItem = driver.FindElementByXPath("/html/body/div[3]/div/div[1]/div[3]/div/div[2]/div[" + i + "]/div/a").GetAttribute("href");
                        sliderName = driver.FindElementByXPath("/html/body/div[3]/div/div[1]/div[3]/div/div[2]/div[" + i + "]/div/a/div[1]/div[2]/div[2]/span").Text;
                        
                        ///html/body/div[3]/div/div[1]/div[3]/div/div[2]/div[1]/div/a/div[1]/div[1]/date/span[1]
                        ///html/body/div[3]/div/div[1]/div[3]/div/div[2]/div[2]/div/a/div[1]/div[1]/date/span[1]
                        ///html/body/div[3]/div/div[1]/div[3]/div/div[2]/div[4]/div/a/div[1]/div[1]/date/span[1]

                        //tarih = driver.FindElementByXPath("/html/body/div[3]/div/div[1]/div[3]/div/div[2]/div[1]/div/a/div[1]/div[1]/date/span["+i+"]").Text;
                        //contentName = driver.FindElementByXPath("/html/body/div[3]/div/div[1]/div[3]/div/div[2]/div["+i+"]/div/a/div[2]/div").Text;
                        
                        
                        //sliderTitle.Add(sliderItem);
                        dataGridView1.Rows.Add(sliderCalendar,sliderName,sliderItem);
                        

                    }
                    
                    


                }
                catch (Exception)
                {
                }
                
            }
            //url = "https://tuikweb.tuik.gov.tr/PreTabloArama.do?metod=search&araType=hb_x";
            
            //if (url == "https://tuikweb.tuik.gov.tr/PreTabloArama.do?metod=search&araType=hb_x")
            //{
                
            //    driver.Navigate().GoToUrl("https://tuikweb.tuik.gov.tr/PreTabloArama.do?metod=search&araType=hb_x");
                
            //    try
            //    {

            //        for (int i = 1; i <= 20; i++)
            //        {
            //            if (i==1)
            //            {
            //                contentName = driver.FindElementByXPath("/html/body/table/tbody/tr[2]/td[2]/table/tbody/tr/td[2]/table[3]/tbody/tr[2]/td[2]/form/fieldset/table[2]/tbody/tr[1]/td/table/tbody/tr[2]/td[1]/a").Text;

            //                tarih = driver.FindElementByXPath("/html/body/table/tbody/tr[2]/td[2]/table/tbody/tr/td[2]/table[3]/tbody/tr[2]/td[2]/form/fieldset/table[2]/tbody/tr[1]/td/table/tbody/tr[2]/td[2]").Text;
            //                dataGridView1.Rows.Add(tarih, contentName, sliderTitle[i - 1]);

            //            }
            //            else if (i==2)
            //            {
            //                contentName = driver.FindElementByXPath("/html/body/table/tbody/tr[2]/td[2]/table/tbody/tr/td[2]/table[3]/tbody/tr[2]/td[2]/form/fieldset/table[2]/tbody/tr[1]/td/table/tbody/tr[1]/td[1]/a").Text;

            //                tarih = driver.FindElementByXPath("/html/body/table/tbody/tr[2]/td[2]/table/tbody/tr/td[2]/table[3]/tbody/tr[2]/td[2]/form/fieldset/table[2]/tbody/tr[1]/td/table/tbody/tr[1]/td[2]").Text;
            //                dataGridView1.Rows.Add(tarih, contentName, sliderTitle[i - 1]);
            //            }
                       
            //            else
            //            {
            //                contentName = driver.FindElementByXPath("/html/body/table/tbody/tr[2]/td[2]/table/tbody/tr/td[2]/table[3]/tbody/tr[2]/td[2]/form/fieldset/table[2]/tbody/tr[1]/td/table/tbody/tr[" + i + "]/td[1]/a").Text;

            //                tarih = driver.FindElementByXPath("/html/body/table/tbody/tr[2]/td[2]/table/tbody/tr/td[2]/table[3]/tbody/tr[2]/td[2]/form/fieldset/table[2]/tbody/tr[1]/td/table/tbody/tr[" + i + "]/td[2]").Text;
            //                dataGridView1.Rows.Add(tarih, contentName, sliderTitle[i - 1]);
            //            }
                        



                        

            //        }
            //    }
            //    catch (Exception)
            //    {

                    
            //    }
            //}
            

            driver.Close();
            driver.Dispose();
            
        }
        
        private void tuikHaberForm_Load(object sender, EventArgs e)
        {
            
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
            
            slider();
            getData();
            timer1.Start();
            timer2.Start();


            try
            {
                  this.notifyIcon1.Text = "Tuik Haber Alarmı";
                  this.notifyIcon1.Visible = true;
                  this.cMenu = new ContextMenu();
                  this.cMenu.MenuItems.Add(0, new MenuItem("Göster", new EventHandler(this.Goster_Click)));
                  this.cMenu.MenuItems.Add(1, new MenuItem("Gizle", new EventHandler(this.Gizle_Click)));
                  this.cMenu.MenuItems.Add(2, new MenuItem("Kapat", new EventHandler(this.Kapat_Click)));
                  this.notifyIcon1.ContextMenu = this.cMenu;
                  this.timer1.Start();       
            }
            catch(Exception)
            {

            }
 
        }
      
        public void istatistikKonu_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
            selectedIndex = istatistikKonu.SelectedIndex;
            selectedValue = (string)istatistikKonu.Text;
            dataGridView1.Rows.Clear();
            
        }
        public void aramaButton_Click_1(object sender, EventArgs e)
        {
           
            dataGridView1.Rows.Clear();

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(new List<string>()
                {
                    "--silent-launch",
                    "--no-startup-window",
                    "no-sandbox",
                    "headless",

                });
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
            
            try
            {   

                if (selectedIndex == 0)
                {

                    
                    driver.Navigate().GoToUrl("https://data.tuik.gov.tr/Kategori/GetKategori?p=110");
                    Thread.Sleep(1000);
                    //MessageBox.Show("Aranan Konu : "+selectedValue);
                    kayitSayisi = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/nav/div/a[1]/span").Text;
                    //MessageBox.Show(kayitSayisi + " adet kayit bulundu.");
                    string listeItem = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a").Text;
                    int sayfaSayisi;
                   
                    if (((Convert.ToInt32(kayitSayisi) / 10) + 1) > 6)
                    {
                        

                        sayfaSayisi = 9;
                    }
                    else
                    {
                        
                        sayfaSayisi = ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 2;
                    }
                    for (int i = 1; i <= ((Convert.ToInt32(kayitSayisi) / 10) + 1); i++)
                    {

                        for (int j = 1; j <= 10; j++)
                        {

                            ///html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a/text()
                            //
                            tarih = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr["+j+"]/td[2]/div/div/div[1]/p/small/span").Text;
                            //contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr["+j+ "]/td[2]/div/div/div[3]/a/text()").ToString();
                            contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/p").Text;
                            baslikUrl = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/a")).GetAttribute("href");
                            dataGridView1.Rows.Add(tarih, contentName,baslikUrl);
                            
                            
                            


                        }
                        string sayfaNumara = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li[" + i + "]/a").Text;                  
                        driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li[" + sayfaSayisi + "]/a").Click();
                    }
                    driver.Close();
                    driver.Dispose();   
                }
                if (selectedIndex == 1)
                {

                    driver.Navigate().GoToUrl("https://data.tuik.gov.tr/Kategori/GetKategori?p=Bilim,-Teknoloji-ve-Bilgi-Toplumu-102");
                    Thread.Sleep(1000);
                    //MessageBox.Show("Aranan Konu : " + selectedValue);
                    kayitSayisi = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/nav/div/a[1]/span").Text;
                    //MessageBox.Show(kayitSayisi + " adet kayit bulundu.");
                    string listeItem = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a").Text;
                    int sayfaSayisi;
                    if (((Convert.ToInt32(kayitSayisi) / 10) + 1) > 6)
                    {
                        

                        sayfaSayisi = 9;
                    }
                    else
                    {
                        
                        sayfaSayisi = ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 2;
                        
                    }
                    for (int i = 1; i <= ((Convert.ToInt32(kayitSayisi) / 10) + 1); i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            tarih = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[1]/p/small/span").Text;
                            contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/p").Text;
                            baslikUrl = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/a")).GetAttribute("href");
                            dataGridView1.Rows.Add(tarih, contentName, baslikUrl);
                        }   
                        driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li[" + sayfaSayisi + "]/a").Click();
                        
                    }
                    driver.Close();
                    driver.Dispose();                 
                }
                if (selectedIndex == 2)
                {
                    driver.Navigate().GoToUrl("https://data.tuik.gov.tr/Kategori/GetKategori?p=Cevre-ve-Enerji-103");
                    Thread.Sleep(1000);
                    //MessageBox.Show("Aranan Konu : " + selectedValue);
                    kayitSayisi = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/nav/div/a[1]/span").Text;
                    //MessageBox.Show(kayitSayisi + " adet kayit bulundu.");
                    string listeItem = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a").Text;
                    int sayfaSayisi;
                    if (((Convert.ToInt32(kayitSayisi) / 10) + 1) > 6)
                    {
                        

                        sayfaSayisi = 9;
                    }
                    else
                    {
                        
                        sayfaSayisi = ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 2;

                    }
                    for (int i = 1; i <= ((Convert.ToInt32(kayitSayisi) / 10) + 1); i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            tarih = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[1]/p/small/span").Text;
                            contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/p").Text;
                            baslikUrl = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/a")).GetAttribute("href");
                            dataGridView1.Rows.Add(tarih, contentName, baslikUrl);
                        }
                        driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li[" + sayfaSayisi + "]/a").Click();
                    }
                    driver.Close();
                    driver.Dispose();                
                }
                if (selectedIndex == 3)
                {                    
                    driver.Navigate().GoToUrl("https://data.tuik.gov.tr/Kategori/GetKategori?p=Dis-Ticaret-104");
                    //MessageBox.Show("Aranan Konu : " + selectedValue);
                    Thread.Sleep(1000);
                    kayitSayisi = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/nav/div/a[1]/span").Text;
                    //MessageBox.Show(kayitSayisi + " adet kayit bulundu.");
                    string listeItem = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a").Text;
                    int sayfaSayisi;
                    if (((Convert.ToInt32(kayitSayisi) / 10) + 1) > 6)
                    {
                        

                        sayfaSayisi = 9;
                    }
                    else
                    {
                        
                        sayfaSayisi = ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 2;
                    }
                    for (int i = 1; i <= ((Convert.ToInt32(kayitSayisi) / 10) + 1); i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            tarih = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[1]/p/small/span").Text;
                            contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/p").Text;
                            baslikUrl = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/a")).GetAttribute("href");
                            dataGridView1.Rows.Add(tarih,contentName, baslikUrl);
                        }
                        driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li["+ sayfaSayisi + "]/a").Click();
                    }
                    driver.Close();
                    driver.Dispose();
                    
                }
                if (selectedIndex == 4)
                {
                    driver.Navigate().GoToUrl("https://data.tuik.gov.tr/Kategori/GetKategori?p=Egitim,-Kultur,-Spor-ve-Turizm-105");
                    //MessageBox.Show("Aranan Konu : " + selectedValue);
                    Thread.Sleep(1000);
                    kayitSayisi = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/nav/div/a[1]/span").Text;
                    //MessageBox.Show(kayitSayisi + " adet kayit bulundu.");
                    string listeItem = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a").Text;
                    int sayfaSayisi;
                    if (((Convert.ToInt32(kayitSayisi) / 10) + 1) > 6)
                    {
                        

                        sayfaSayisi = 9;
                    }
                    else
                    {
                        
                        sayfaSayisi = ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 2;
                    }
                    for (int i = 1; i <= ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 3; i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            tarih = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[1]/p/small/span").Text;
                            contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/p").Text;
                            baslikUrl = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/a")).GetAttribute("href");
                            dataGridView1.Rows.Add(tarih,contentName, baslikUrl);
                        }
                        
                        driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li[" + sayfaSayisi + "]/a").Click();
                    }
                    driver.Close();
                    driver.Dispose();
                }
                if (selectedIndex == 5)
                {

                    
                    driver.Navigate().GoToUrl("https://data.tuik.gov.tr/Kategori/GetKategori?p=Ekonomik-Guven-117");
                    Thread.Sleep(1000);
                    //MessageBox.Show("Aranan Konu : " + selectedValue);
                    kayitSayisi = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/nav/div/a[1]/span").Text;
                    //MessageBox.Show(kayitSayisi + " adet kayit bulundu.");
                    string listeItem = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a").Text;
                    int sayfaSayisi;
                    if (((Convert.ToInt32(kayitSayisi) / 10) + 1) > 6)
                    {
                        

                        sayfaSayisi = 9;
                    }
                    else
                    {
                        
                        sayfaSayisi = ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 2;
                    }
                    for (int i = 1; i <= ((Convert.ToInt32(kayitSayisi) / 10) + 1); i++)
                    {
                       
                        for (int j = 1; j <= 10; j++)
                        {
                                tarih = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[1]/p/small/span").Text;
                                contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/p").Text;
                                baslikUrl = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/a")).GetAttribute("href");
                                dataGridView1.Rows.Add(tarih, contentName,baslikUrl);                                
                        }
                        
                        driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li["+sayfaSayisi+"]/a").Click();
                        
                    }
                    driver.Close();
                    driver.Dispose();
                }
                if (selectedIndex == 6)
                {
                    driver.Navigate().GoToUrl("https://data.tuik.gov.tr/Kategori/GetKategori?p=Enflasyon-ve-Fiyat-106");
                    Thread.Sleep(1000);
                    //MessageBox.Show("Aranan Konu : " + selectedValue);
                    kayitSayisi = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/nav/div/a[1]/span").Text;
                    //MessageBox.Show(kayitSayisi + " adet kayit bulundu.");
                    string listeItem = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a").Text;
                    int sayfaSayisi;
                    if (((Convert.ToInt32(kayitSayisi) / 10) + 1) > 6)
                    {
                        

                        sayfaSayisi = 9;
                    }
                    else
                    {
                        
                        sayfaSayisi = ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 2;
                    }
                    for (int i = 1; i <= ((Convert.ToInt32(kayitSayisi) / 10) + 1); i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            tarih = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[1]/p/small/span").Text;
                            contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/p").Text;
                            baslikUrl = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/a")).GetAttribute("href");
                            dataGridView1.Rows.Add(tarih, contentName, baslikUrl);
                        }
                        driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li[" + sayfaSayisi + "]/a").Click();
                        
                    }
                    driver.Close();
                    driver.Dispose();
                }
                if (selectedIndex == 7)
                {
                    driver.Navigate().GoToUrl("https://data.tuik.gov.tr/Kategori/GetKategori?p=Gelir,-Yasam,-Tuketim-ve-Yoksulluk-107");
                    //MessageBox.Show("Aranan Konu : " + selectedValue);
                    Thread.Sleep(1000);
                    kayitSayisi = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/nav/div/a[1]/span").Text;
                    //MessageBox.Show(kayitSayisi + " adet kayit bulundu.");
                    string listeItem = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a").Text;
                    int sayfaSayisi;
                    if (((Convert.ToInt32(kayitSayisi) / 10) + 1) > 6)
                    {
                        

                        sayfaSayisi = 9;
                    }
                    else
                    {
                        
                        sayfaSayisi = ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 2;
                    }
                    for (int i = 1; i <= ((Convert.ToInt32(kayitSayisi) / 10) + 1); i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            tarih = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[1]/p/small/span").Text;
                            contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/p").Text;
                            baslikUrl = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/a")).GetAttribute("href");
                            dataGridView1.Rows.Add(tarih, contentName, baslikUrl);
                        }
                        driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li[" + sayfaSayisi + "]/a").Click();
                    }
                    driver.Close();
                    driver.Dispose();
                }
                if (selectedIndex == 8)
                {
                    driver.Navigate().GoToUrl("https://data.tuik.gov.tr/Kategori/GetKategori?p=Insaat-ve-Konut-116");
                    //MessageBox.Show("Aranan Konu : " + selectedValue);
                    Thread.Sleep(1000);
                    kayitSayisi = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/nav/div/a[1]/span").Text;
                    //MessageBox.Show(kayitSayisi + " adet kayit bulundu.");
                    string listeItem = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a").Text;
                    int sayfaSayisi;
                    if (((Convert.ToInt32(kayitSayisi) / 10) + 1) > 6)
                    {
                        sayfaSayisi = 9;
                    }
                    else
                    {
                        
                        sayfaSayisi = ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 2;
                    }
                    for (int i = 1; i <= ((Convert.ToInt32(kayitSayisi) / 10) + 1); i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            tarih = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[1]/p/small/span").Text;
                            contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/p").Text;
                            baslikUrl = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/a")).GetAttribute("href");
                            dataGridView1.Rows.Add(tarih, contentName, baslikUrl);
                        }
                        driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li[" + sayfaSayisi + "]/a").Click();
                    }
                    driver.Close();
                    driver.Dispose();
                }
                if (selectedIndex == 9)
                {
                    driver.Navigate().GoToUrl("https://data.tuik.gov.tr/Kategori/GetKategori?p=Istihdam,-Issizlik-ve-Ucret-108");
                    //MessageBox.Show("Aranan Konu : " + selectedValue);
                    Thread.Sleep(1000);
                    kayitSayisi = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/nav/div/a[1]/span").Text;
                    //MessageBox.Show(kayitSayisi + " adet kayit bulundu.");
                    string listeItem = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a").Text;
                    int sayfaSayisi;
                    if (((Convert.ToInt32(kayitSayisi) / 10) + 1) > 6)
                    {
                        

                        sayfaSayisi = 9;
                    }
                    else
                    {
                        
                        sayfaSayisi = ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 2;
                    }
                    for (int i = 1; i <= ((Convert.ToInt32(kayitSayisi) / 10) + 1); i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            tarih = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[1]/p/small/span").Text;
                            contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/p").Text;
                            baslikUrl = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/a")).GetAttribute("href");
                            dataGridView1.Rows.Add(tarih, contentName, baslikUrl);
                        }
                        driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li[" + sayfaSayisi + "]/a").Click();
                    }
                    driver.Close();
                    driver.Dispose();
                }
                if (selectedIndex == 10)
                {
                    driver.Navigate().GoToUrl("https://data.tuik.gov.tr/Kategori/GetKategori?p=Nufus-ve-Demografi-109");
                    //MessageBox.Show("Aranan Konu : " + selectedValue);
                    Thread.Sleep(1000);
                    kayitSayisi = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/nav/div/a[1]/span").Text;
                    //MessageBox.Show(kayitSayisi + " adet kayit bulundu.");
                    string listeItem = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a").Text;
                    int sayfaSayisi;
                    if (((Convert.ToInt32(kayitSayisi) / 10) + 1) > 6)
                    {
                        

                        sayfaSayisi = 9;
                    }
                    else
                    {
                        
                        sayfaSayisi = ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 2;
                    }
                    for (int i = 1; i <= ((Convert.ToInt32(kayitSayisi) / 10) + 1); i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        { 
                                tarih = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[1]/p/small/span").Text;
                                contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/p").Text;
                                baslikUrl = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/a")).GetAttribute("href");
                                dataGridView1.Rows.Add(tarih, contentName,baslikUrl);
                        }
                        driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li[" + sayfaSayisi + "]/a").Click();
                    }
                    driver.Close();
                    driver.Dispose();
                }
                if (selectedIndex == 11)
                {
                    driver.Navigate().GoToUrl("https://data.tuik.gov.tr/Kategori/GetKategori?p=Saglik-ve-Sosyal-Koruma-101");
                    //MessageBox.Show("Aranan Konu : " + selectedValue);
                    Thread.Sleep(1000);
                    kayitSayisi = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/nav/div/a[1]/span").Text;
                    //MessageBox.Show(kayitSayisi + " adet kayit bulundu.");
                    string listeItem = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a").Text;
                    int sayfaSayisi;
                    if (((Convert.ToInt32(kayitSayisi) / 10) + 1) > 6)
                    {
                        

                        sayfaSayisi = 9;
                    }
                    else
                    {
                        
                        sayfaSayisi = ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 2;
                    }
                    for (int i = 1; i <= ((Convert.ToInt32(kayitSayisi) / 10) + 1); i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            tarih = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[1]/p/small/span").Text;
                            contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/p").Text;
                            baslikUrl = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/a")).GetAttribute("href");
                            dataGridView1.Rows.Add(tarih,contentName, baslikUrl);
                        }
                        driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li[" + sayfaSayisi + "]/a").Click();
                    }
                    driver.Close();
                    driver.Dispose();
                }
                if (selectedIndex == 12)
                {
                    driver.Navigate().GoToUrl("https://data.tuik.gov.tr/Kategori/GetKategori?p=Sanayi-114");
                    //MessageBox.Show("Aranan Konu : " + selectedValue);
                    Thread.Sleep(1000);
                    kayitSayisi = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/nav/div/a[1]/span").Text;
                    //MessageBox.Show(kayitSayisi + " adet kayit bulundu.");
                    string listeItem = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a").Text;
                    int sayfaSayisi;
                    if (((Convert.ToInt32(kayitSayisi) / 10) + 1) > 6)
                    {
                        

                        sayfaSayisi = 9;
                    }
                    else
                    {
                        
                        sayfaSayisi = ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 2;
                    }
                    for (int i = 1; i <= ((Convert.ToInt32(kayitSayisi) / 10) + 1); i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            tarih = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[1]/p/small/span").Text;
                            contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/p").Text;
                            baslikUrl = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/a")).GetAttribute("href");
                            dataGridView1.Rows.Add(tarih,contentName, baslikUrl);
                        }
                        driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li[" + sayfaSayisi + "]/a").Click();
                    }
                    driver.Close();
                    driver.Dispose();
                }
                if (selectedIndex == 13)
                {
                    driver.Navigate().GoToUrl("https://data.tuik.gov.tr/Kategori/GetKategori?p=Tarim-111");
                    //MessageBox.Show("Aranan Konu : " + selectedValue);
                    Thread.Sleep(1000);
                    kayitSayisi = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/nav/div/a[1]/span").Text;
                    //MessageBox.Show(kayitSayisi + " adet kayit bulundu.");
                    string listeItem = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a").Text;
                    int sayfaSayisi;
                    if (((Convert.ToInt32(kayitSayisi) / 10) + 1) > 6)
                    {
                        

                        sayfaSayisi = 9;
                    }
                    else
                    {
                        
                        sayfaSayisi = ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 2;
                    }
                    for (int i = 1; i <= ((Convert.ToInt32(kayitSayisi) / 10) + 1); i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            tarih = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[1]/p/small/span").Text;
                            contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/p").Text;
                            baslikUrl = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/a")).GetAttribute("href");
                            dataGridView1.Rows.Add(tarih, contentName, baslikUrl);
                        }
                        driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li[" + sayfaSayisi + "]/a").Click();
                    }
                    driver.Close();
                    driver.Dispose();
                }
                if (selectedIndex == 14)
                {
                    driver.Navigate().GoToUrl("https://data.tuik.gov.tr/Kategori/GetKategori?p=Ticaret-ve-Hizmet-115");
                    Thread.Sleep(1000);
                    //MessageBox.Show("Aranan Konu : " + selectedValue);
                    kayitSayisi = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/nav/div/a[1]/span").Text;
                    //MessageBox.Show(kayitSayisi + " adet kayit bulundu.");
                    string listeItem = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a").Text;
                    int sayfaSayisi;
                    if (((Convert.ToInt32(kayitSayisi) / 10) + 1) > 6)
                    {
                        

                        sayfaSayisi = 9;
                    }
                    else
                    {
                        
                        sayfaSayisi = ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 2;
                    }
                    for (int i = 1; i <= ((Convert.ToInt32(kayitSayisi) / 10) + 1); i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            tarih = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[1]/p/small/span").Text;
                            contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/p").Text;
                            baslikUrl = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/a")).GetAttribute("href");
                            dataGridView1.Rows.Add(tarih,contentName, baslikUrl);
                        }
                        driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li[" + sayfaSayisi + "]/a").Click();
                    }
                    driver.Close();
                    driver.Dispose();
                }
                if (selectedIndex == 15)
                {
                    driver.Navigate().GoToUrl("https://data.tuik.gov.tr/Kategori/GetKategori?p=Ulastirma-ve-Haberlesme-112");
                    //MessageBox.Show("Aranan Konu : " + selectedValue);
                    Thread.Sleep(1000);
                    kayitSayisi = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/nav/div/a[1]/span").Text;
                    //MessageBox.Show(kayitSayisi + " adet kayit bulundu.");
                    string listeItem = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a").Text;
                    int sayfaSayisi;
                    if (((Convert.ToInt32(kayitSayisi) / 10) + 1) > 6)
                    {
                        

                        sayfaSayisi = 9;
                    }
                    else
                    {
                        
                        sayfaSayisi = ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 2;
                    }
                    for (int i = 1; i <= ((Convert.ToInt32(kayitSayisi) / 10) + 1); i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            tarih = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[1]/p/small/span").Text;
                            contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/p").Text;
                            baslikUrl = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/a")).GetAttribute("href");
                            dataGridView1.Rows.Add(tarih,contentName, baslikUrl);
                        }
                        driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li[" + sayfaSayisi + "]/a").Click();
                    }
                    driver.Close();
                    driver.Dispose();
                }
                if (selectedIndex == 16)
                {
                    driver.Navigate().GoToUrl("https://data.tuik.gov.tr/Kategori/GetKategori?p=Ulusal-Hesaplar-113");
                    //MessageBox.Show("Aranan Konu : " + selectedValue);
                    Thread.Sleep(1000);
                    kayitSayisi = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/nav/div/a[1]/span").Text;
                    //MessageBox.Show(kayitSayisi + " adet kayit bulundu.");
                    string listeItem = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[1]/td[2]/div/div/div[3]/a").Text;
                    int sayfaSayisi;
                    if (((Convert.ToInt32(kayitSayisi) / 10) + 1) > 6)
                    {
                        

                        sayfaSayisi = 9;
                    }
                    else
                    {
                        
                        sayfaSayisi = ((Convert.ToInt32(kayitSayisi) / 10) + 1) + 2;
                    }
                    for (int i = 1; i <= ((Convert.ToInt32(kayitSayisi) / 10) + 1); i++)
                    {
                        for (int j = 1; j <= 10; j++)
                        {
                            tarih = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[1]/p/small/span").Text;
                            contentName = driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/p").Text;
                            baslikUrl = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[2]/div/table/tbody/tr[" + j + "]/td[2]/div/div/div[3]/a")).GetAttribute("href");
                            dataGridView1.Rows.Add(tarih,contentName, baslikUrl);
                        }
                        driver.FindElementByXPath("/html/body/div[3]/div[2]/div[2]/div/div/div[1]/div/div/div/div/div[3]/div[2]/div/ul/li[" + sayfaSayisi + "]/a").Click();
                    }
                    driver.Close();
                    driver.Dispose();
                }
                driver.Close();
                driver.Dispose();
                
            }
            catch (Exception)
            {
                
            }
            
            driver.Dispose();
            

        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            Process.Start(this.dataGridView1.CurrentRow.Cells[2].Value.ToString());
        }

        private void tuikHaberForm_FormClosing(object sender, FormClosingEventArgs e)
        {
                if (e.CloseReason != CloseReason.UserClosing)
                return;
                this.notifyIcon1.Visible = true;
                this.notifyIcon1.BalloonTipText = "Program Çalışmaya Devam Ediyor...";
                this.notifyIcon1.BalloonTipTitle = "Tuik Haber Alarmı";
                this.notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                this.notifyIcon1.ShowBalloonTip(500);
                e.Cancel = true;
                this.Hide();
        }
        protected void Goster_Click(object sender, EventArgs e) => this.Show();

        protected void Gizle_Click(object sender, EventArgs e) => this.Hide();

        protected void Kapat_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            this.notifyIcon1.Dispose();
            this.Dispose();
            this.Close();
            Environment.Exit(0);

        }
        

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)  => this.Show();
        
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            PopupNotifier popup = new PopupNotifier();
            DateTime date = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            
            
            try
            {
                dataGridView1.Rows.Clear();
                slider();
                if (!(date < this.EnsonHaberGeldigiTarih))
                    return;
                
                popup.TitleText = "Yeni Haber";
                //popup.ContentText = dataGridView1.Rows[0].Cells[2].Value.ToString();
                popup.ContentText = dataGridView1.Rows[0].Cells[1].Value.ToString();
                
                MessageBox.Show(popup.TitleFont.Height.ToString());
                
                popup.Popup();
                
                this.EnsonHaberGeldigiTarih = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception)
            {
                //this.panel2.Visible = true;
                //this.label5.Text = "Hata";
                //this.label6.Text = ex.Message;
            }
        }

        private void bultenGetir_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            slider();
        }

       

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            var startDate = monthCalendar1.SelectionRange.Start.ToString("dd MMMMM yyyy");
            var endDate = monthCalendar1.SelectionRange.End.ToString("dd MMMMM yyyy");
            
            
        }

       
    }
}
