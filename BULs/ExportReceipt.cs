﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.pdf.parser;
using DTOs;

namespace BULs
{
    public class ExportReceipt
    {
        AccountBUL accountBUL = new AccountBUL();
        MoneyBUL moneyBUL = new MoneyBUL();
        LogBUL logBUL = new LogBUL();
        CustomerBUL customerBUL = new CustomerBUL();

        private static int indexName = 0;
        public void exportReceiptWithdraw(string cardNo, int moneyForReceipt)
        {
            string atmID = "ATM001";
            string accountID = accountBUL.getAccountID(cardNo);
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("h:mm tt");
            string money = moneyBUL.formatMoney(moneyForReceipt);
            string balance = accountBUL.getBalance(cardNo);
            string fees = "";
            string vat = "";

            // Tạo 1 document
            iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(400, 600);
            rect.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);
            Document doc = new Document(rect, 50, 50, 50, 50);

            string imgURL = "", path = "";
            iTextSharp.text.Image img = null;

            // đường đẫn đọc ảnh mẫu
            imgURL = @"C:\Users\Admin\Desktop\BTL_WIN\YÊUCẦU + BIÊNLAI\BIÊN LAI\mẫu\rut tien.jpg";
            img = iTextSharp.text.Image.GetInstance(imgURL);

            // đường dẫn ghi file pdf
            indexName++;
            path = @"E:\NAM 4 KY 1\WIN_FORM\BAI TAP LON\BTL_WIN\YÊUCẦU + BIÊNLAI\BIÊN LAI\rut tien" + indexName + ".pdf";
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

            fees = "1.000";
            vat = "100";

            doc.Open();

            img.ScaleAbsolute(300f, 500f);
            img.Border = iTextSharp.text.Rectangle.BOX;
            img.BorderColor = BaseColor.BLUE;
            img.BorderWidth = 3f;
            Paragraph paragraph = new Paragraph();
            Phrase phrase = new Phrase("\n\n\n\n\n\n\n\n\n\n");
            Phrase phrase1 = new Phrase("   NGAY                          GIO                        MAY ATM\n\n");
            Phrase phrase2 = new Phrase("   " + date + "                 " + time + "                 " + atmID + "\n\n");
            Phrase phrase3 = new Phrase("   SO THE  :  " + cardNo + "\n\n");
            Phrase phrase4 = new Phrase("   SO GD             SO TAI KHOAN                  SO TIEN\n");
            Phrase phrase5 = new Phrase("   9922                " + accountID + "                   " + money + " VND\n\n");
            Phrase phrase6 = new Phrase("   SO DU   :   " + balance + " VND\n");
            Phrase phrase7 = new Phrase("   LE PHI   :   " + fees + " VND\n");
            Phrase phrase8 = new Phrase("   VAT       :   " + vat + " VND\n");

            paragraph.Add(phrase);
            paragraph.Add(phrase1);
            paragraph.Add(phrase2);
            paragraph.Add(phrase3);
            paragraph.Add(phrase4);
            paragraph.Add(phrase5);
            paragraph.Add(phrase6);
            paragraph.Add(phrase7);
            paragraph.Add(phrase8);
            paragraph.Add(new Chunk(img, 0, -125));

            doc.Add(paragraph);
            doc.Close();
        }

        public void exportBalance(string cardNo, string status)
        {
            string atmID = "ATM001";
            string accountID = accountBUL.getAccountID(cardNo);
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("h:mm tt");
            string balance = accountBUL.getBalance(cardNo);

            // Tạo 1 document
            iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(400, 600);
            rect.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);
            Document doc = new Document(rect, 50, 50, 50, 50);

            string imgURL = "", path = "";
            iTextSharp.text.Image img = null;

            // đường đẫn đọc ảnh mẫu
            imgURL = @"E:\NAM 4 KY 1\WIN_FORM\BAI TAP LON\BTL_WIN\YÊUCẦU + BIÊNLAI\BIÊN LAI\mẫu\bien lai.jpg";
            img = iTextSharp.text.Image.GetInstance(imgURL);

            // đường dẫn ghi file pdf
            indexName++;
            path = @"E:\NAM 4 KY 1\WIN_FORM\BAI TAP LON\BTL_WIN\YÊUCẦU + BIÊNLAI\BIÊN LAI\bien lai" + indexName + ".pdf";
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

            doc.Open();

            img.ScaleAbsolute(300f, 500f);
            img.Border = iTextSharp.text.Rectangle.BOX;
            img.BorderColor = BaseColor.BLUE;
            img.BorderWidth = 3f;
            Paragraph paragraph = new Paragraph();
            Phrase phrase = new Phrase("\n\n\n\n\n\n\n\n\n\n");
            Phrase phrase1 = new Phrase("   NGAY                          GIO                        MAY ATM\n\n");
            Phrase phrase2 = new Phrase("   " + date + "                 " + time + "                 " + atmID + "\n\n");
            Phrase phrase3 = new Phrase("   SO THE  :  " + cardNo + "\n\n");
            Phrase phrase4 = new Phrase("   SO GD   : 9918 \n\n");
            Phrase phrase5 = new Phrase("   SO TAI KHOAN  :   " + accountID + "\n\n");
            Phrase phrase6 = new Phrase("   SO DU   :   " + balance + " VND\n");

            paragraph.Add(phrase);
            paragraph.Add(phrase1);
            paragraph.Add(phrase2);
            paragraph.Add(phrase3);
            paragraph.Add(phrase4);
            paragraph.Add(phrase5);
            paragraph.Add(phrase6);

            paragraph.Add(new Chunk(img, 0, -125));

            doc.Add(paragraph);
            doc.Close();
        }

        //in sao kê
        public void exportReceipt1(string cardNo, string status)
        {
            string atmID = "ATM001";
            string accountID = accountBUL.getAccountID(cardNo);
            string date1 = DateTime.Now.ToString("yyyy-MM-dd");
            string time1 = DateTime.Now.ToString("h:mm tt");
            string balance = accountBUL.getBalance(cardNo);
            List<LogDTO> loglist = logBUL.LoadLogList(cardNo);

            // Tạo 1 document
            iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(400, 600);
            rect.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);
            Document doc = new Document(rect, 50, 50, 50, 50);

            string imgURL = "", path = "";
            iTextSharp.text.Image img = null;

            // đường đẫn đọc ảnh mẫu
            imgURL = @"E:\NAM 4 KY 1\WIN_FORM\BAI TAP LON\BTL_WIN\YÊUCẦU + BIÊNLAI\BIÊN LAI\mẫu\in sao ke.jpg";
            img = iTextSharp.text.Image.GetInstance(imgURL);

            // đường dẫn ghi file pdf
            string fileName = "bienlai" + indexName++;
            path = @"E:\NAM 4 KY 1\WIN_FORM\BAI TAP LON\BTL_WIN\YÊUCẦU + BIÊNLAI\BIÊN LAI\in sao ke" + indexName + ".pdf";
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

            doc.Open();

            img.ScaleAbsolute(300f, 500f);
            img.Border = iTextSharp.text.Rectangle.BOX;
            img.BorderColor = BaseColor.BLUE;
            img.BorderWidth = 3f;
            Paragraph paragraph = new Paragraph();
            Phrase phrase = new Phrase("\n\n\n\n\n\n\n\n\n\n");
            Phrase phrase1 = new Phrase("   NGAY                          GIO                        MAY ATM\n\n");
            Phrase phrase2 = new Phrase("   " + date1 + "                 " + time1 + "                 " + atmID + "\n\n");
            Phrase phrase3 = new Phrase("   SO THE  :  " + cardNo + "\n\n");
            Phrase phrase4 = new Phrase("   SO GD   : 9918 \n\n");
            Phrase phrase5 = new Phrase("   SO TAI KHOAN  :   " + accountID + "\n\n");
            Phrase phrase6 = new Phrase("   SO DU   :   " + balance + " VND\n");
            Phrase phrase7 = new Phrase("   NGAY                GIO               GD +/-           SOTIEN\n");
            paragraph.Add(phrase);
            paragraph.Add(phrase1);
            paragraph.Add(phrase2);
            paragraph.Add(phrase3);
            paragraph.Add(phrase4);
            paragraph.Add(phrase5);
            paragraph.Add(phrase6);
            paragraph.Add(phrase7);
            foreach (var item in loglist)
            {
                string date = item.LogDate.ToString("yyyy-MM-dd");
                string time = item.LogDate.ToString("h:mm tt");
                string logtype = item.LogTypeID;
                string amount = moneyBUL.formatMoney(int.Parse(item.Amount.ToString()));
                Phrase phrase8 = new Phrase("   " + date + "        " + time + "            " + logtype + "                " + amount + "\n");
                paragraph.Add(phrase8);
            }
            paragraph.Add(new Chunk(img, 0, -80));

            doc.Add(paragraph);
            doc.Close();
        }

        public void exportReceiptCashTransfer(string cardNo, string nameCardNo, string cardNoTo, string nameCardTo, int money)
        {
            string atmID = "ATM001";
            string accountID = accountBUL.getAccountID(cardNo);
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string time = DateTime.Now.ToString("h:mm tt");
            string balance = accountBUL.getBalance(cardNo);
            string fees = "";
            string vat = "";

            // Tạo 1 document
            iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(500, 700);
            rect.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);

            Document doc = new Document(rect, 50, 50, 50, 50);

            string imgURL = "", path = "";
            iTextSharp.text.Image img = null;

            Paragraph paragraph = new Paragraph();


            imgURL = @"D:\C#\BTL_WIN\YÊUCẦU + BIÊNLAI\BIÊN LAI\mẫu\ChuyenTien.png";
            img = iTextSharp.text.Image.GetInstance(imgURL);

            // đường dẫn ghi file pdf
            indexName++;
            path = @"D:\C#\BTL_WIN\YÊUCẦU + BIÊNLAI\BIÊN LAI\chuyen tien" + indexName + ".pdf";
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            fees = "3.000";
            vat = "300";

            doc.Open();

            img.ScaleAbsolute(300f, 500f);
            img.Border = iTextSharp.text.Rectangle.BOX;
            img.BorderColor = BaseColor.BLUE;
            img.BorderWidth = 3f;

            Phrase phrase = new Phrase("\n\n\n\n\n\n\n\n\n\n\n");
            Phrase phrase1 = new Phrase("   NGAY                          GIO                        MAY ATM\n\n");
            Phrase phrase2 = new Phrase("   " + date + "                 " + time + "                " + atmID + "\n\n");
            Phrase phrase3 = new Phrase("   SO THE  :  " + 4013 + "\n\n");
            Phrase phrase4 = new Phrase("   SO GD   :  " + 15 + "\n\n");
            Phrase phrase5 = new Phrase("   Tai Khoan Nguon : " + cardNo + "\n");
            Phrase phrase6 = new Phrase("   Ten TK Nguon    : " + nameCardNo + "\n");
            Phrase phrase7 = new Phrase("   Tai Khoan Dich  : " + cardNoTo + "\n");
            Phrase phrase8 = new Phrase("   Ten TK Dich     : " + nameCardTo + "\n\n");
            Phrase phrase9 = new Phrase("   So tien chuyen  : " + money + "\n");
            Phrase phrase10 = new Phrase("  So Du           : " + balance + "\n");
            Phrase phrase11 = new Phrase("  LE PHI          : " + fees + " VND\n");
            Phrase phrase12 = new Phrase("  VAT             : " + vat + " VND\n");

            paragraph.Add(phrase);
            paragraph.Add(phrase1);
            paragraph.Add(phrase2);
            paragraph.Add(phrase3);
            paragraph.Add(phrase4);
            paragraph.Add(phrase5);
            paragraph.Add(phrase6);
            paragraph.Add(phrase7);
            paragraph.Add(phrase8);
            paragraph.Add(phrase9);
            paragraph.Add(phrase10);
            paragraph.Add(phrase11);
            paragraph.Add(phrase12);

            paragraph.Add(new Chunk(img, 0, -40));

            doc.Add(paragraph);
            doc.Close();
        }
    }
}
