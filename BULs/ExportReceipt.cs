using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.pdf.parser;

namespace BULs
{
    public class ExportReceipt
    {
        AccountBUL accountBUL = new AccountBUL();
        MoneyBUL moneyBUL = new MoneyBUL();
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
            imgURL = @"E:\NAM 4 KY 1\WIN_FORM\BAI TAP LON\BTL_WIN\YÊUCẦU + BIÊNLAI\BIÊN LAI\mẫu\rut tien.jpg";
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
    }
}
