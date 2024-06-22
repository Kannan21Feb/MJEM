using CSAT.DTO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;

namespace CSAT.WebAPI.Helpers
{
    public class ExportHelper
    {
        /// <summary>
        /// PDF export method 
        /// </summary>
        /// <param name="objBytes"></param>
        /// <returns></returns>
        public static HttpResponseMessage PdfExport(byte[] objBytes,string strBaseImgSrc)
        {
            //string _basePath = HttpContext.Current.Server.MapPath(@"~\images\logo.png");
            //byte[] logoByte = File.ReadAllBytes(_basePath);
             byte[] logoByte = Convert.FromBase64String(strBaseImgSrc); 

            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                Document document = new Document(PageSize.A4);//, 4f, 4f, 3f, 3f);
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(logoByte);// Converting bytes to Image

                

                PdfPTable table = new PdfPTable(1);
                table.AddCell(image);
                document.Add(table);

                table = new PdfPTable(1);
                table.DefaultCell.Border = Rectangle.ALIGN_CENTER;
                table.AddCell("MJEM");
                document.Add(table);

                image = iTextSharp.text.Image.GetInstance(objBytes);
                image.ScaleAbsolute(10f, 10f);

                table = new PdfPTable(1);
                table.DefaultCell.Border = Rectangle.ALIGN_CENTER;
                table.AddCell(image);
                document.Add(table);

                document.Close();
                objBytes = memoryStream.ToArray();
                memoryStream.Close();
            }

            var fileName = "Sample" + "_" + DateTime.Now.ToString("dd_MMM_yyyy") + ".pdf";
            var responseObject = new HttpResponseMessage
            {
                Content = new ByteArrayContent(objBytes)
            };
            responseObject.Content = new ByteArrayContent(objBytes);
            responseObject.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = fileName };
            responseObject.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            return responseObject;

        }


        public static HttpResponseMessage PdfExportForList( DataSet ds)
        {
            
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                

                var Headertable = ds.Tables[0];
                var Detailtable =ds.Tables[1];


            

                var ClassProperties = new Dictionary<string, string>();
                for (int i = 0; i <= Headertable.Columns.Count-1; i++)
                {
                  ClassProperties.Add(Headertable.Columns[i].ToString(), Headertable.Rows[0][i].ToString());
                }


                Dictionary<string, string> _HeaderInfo = ClassProperties;


                Document doc = new Document(iTextSharp.text.PageSize.A4);
                doc.SetMargins(doc.LeftMargin, doc.RightMargin, doc.TopMargin, doc.BottomMargin + 10f);

                PdfWriter w = PdfWriter.GetInstance(doc, memoryStream);
                w.ViewerPreferences = PdfWriter.PageModeUseOutlines;
                // Our custom Header and Footer is done using Event Handler
                var PageEventHandler = new TwoColumnHeaderFooter();
                w.PageEvent = PageEventHandler;
                // Define the page header

                string path = HttpContext.Current.Server.MapPath(@"~\images\TipperTata.jpg");
                var photoLeft = File.ReadAllBytes(path);
                string path1 = HttpContext.Current.Server.MapPath(@"~\images\JCB.jpg");
                var photoRight = File.ReadAllBytes(path1);


                PageEventHandler.Title = "Magarajothi Earth Movers-Kotagiri".Replace("_", " ");
                PageEventHandler.SubTitle = "Mobile - 9442961053,9786370053";
                PageEventHandler.SubTitle1 = "Bill Summary";

                PageEventHandler.HeaderFont = FontFactory.GetFont(BaseFont.HELVETICA_BOLD, 10);
                PageEventHandler.HeaderValueFont = FontFactory.GetFont(BaseFont.HELVETICA, 8);
                PageEventHandler.MohLogo = photoLeft;
                PageEventHandler.CompanyLogo = photoRight;
                PageEventHandler.PdfExportType = 1;
                //PageEventHandler.HeaderInfoRight = _HeaderInfo;
                PageEventHandler.HeaderInfoLeft = _HeaderInfo;
                doc.Open();


                var HeadTbl = new PdfPTable(Detailtable.Columns.Count)
                {
                    WidthPercentage = 100
                };
                HeadTbl.HeaderRows = 1;
                HeadTbl.SpacingBefore = 1;
                var cell1 = new PdfPCell
                {
                    Colspan = Detailtable.Columns.Count
                };





                var tableHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.ORANGE);
                var font6 = FontFactory.GetFont(FontFactory.HELVETICA, 8);

                PdfPTable table = new PdfPTable(Detailtable.Columns.Count);
                
                for (int j = 0; j < Detailtable.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell(); //create object from the pdfpcell class
                
                    cell.Border = Rectangle.BOTTOM_BORDER;
                    cell.BorderColor = BaseColor.ORANGE;
                    cell.AddElement(new Chunk(Detailtable.Columns[j].ColumnName.ToUpper(), tableHeader));
                    table.AddCell(cell);
                    
                }


                var columnCount = Detailtable.Columns.Count;
                var rowCount = Detailtable.Rows.Count;
                var RowNumber = 0;
                foreach (DataRow myRow in Detailtable.Rows)
                {
                    var i = 1;
                    RowNumber = RowNumber+1;
                                       
                    table.WidthPercentage = 100; //set width of the table
                    
                    foreach (string ColumnData in myRow.ItemArray.Select(o => QuoteValue(o.ToString())))
                    {

                        var _data = ColumnData.TrimStart('"');
                        _data = _data.TrimEnd('"');
                        PdfPCell rowCells = new PdfPCell();
                        rowCells.Border = Rectangle.NO_BORDER;
                        //rowCells.BorderColor = BaseColor.BLACK;

                        if (_data != null)
                            // get the value of   each cell in the dataTable tblemp
                            if (RowNumber==rowCount)
                            {                               
                                rowCells.AddElement(new Chunk(_data, (FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9))));
                                
                            }
                            else
                            {
                                rowCells.AddElement(new Chunk(_data, font6));
                            }
                        
                        table.AddCell(rowCells);

                        i++;
                        if (i > columnCount) break;

                    }

                    

                }

                 PdfContentByte content = w.DirectContent;
                
                //add the table to document
                doc.Add(table);
                doc.Close();


                var objBytes = memoryStream.ToArray();
                memoryStream.Close();
                var fileName = "MagarajothiEarthMoversJobSheet-" + "_" + DateTime.Now.ToString("dd_MMM_yyyy") + ".pdf";


                var responseObject = new HttpResponseMessage
                {
                    Content = new ByteArrayContent(objBytes)
                };
                //responseObject.Content = new ByteArrayContent(emptyArray);
                responseObject.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = fileName };
                responseObject.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                return responseObject;
            }

            

        }


        byte[] ImageToByte(System.Drawing.Image img)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Close();
                byteArray = stream.ToArray();
            }
            return byteArray;
        }



        public string BuildHtmlTable(DataTable table)
        {
            try
            {
                var stringBuilder = new StringBuilder();


                stringBuilder.Append("<table width='100%' style='border: solid 1px black; border-collapse:collapse;' cellpadding='10'>");

                stringBuilder.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Job Sheet</b></td></tr>");
                stringBuilder.Append("<tr><td colspan = '5'></td></tr>");
                stringBuilder.Append("<tr><td><b>Customer Name: </b>");
                stringBuilder.Append("Customer 1");//Dynamic
                stringBuilder.Append("</td><td align = 'right'><b>Billing Date: </b>");
                stringBuilder.Append(DateTime.Now);
                stringBuilder.Append(" </td></tr>");

                stringBuilder.Append("<tr><td colspan = '2'><b>Mobile Number: </b>");
                stringBuilder.Append("12345678");
                stringBuilder.Append("</td></tr>");

                stringBuilder.Append("<tr><td colspan = '2'><b>Customer Address: </b>");
                stringBuilder.Append("12345678");
                stringBuilder.Append("</td><td align = 'right'><b>Site : </b>");
                stringBuilder.Append("</td></tr>");

               

                stringBuilder.Append("</table>");

                stringBuilder.Append("<br />");

                stringBuilder.Append("<tr>");
              
                foreach (DataColumn Column in table.Columns)
                {
                    var _data = Column.ColumnName.TrimStart('"');
                    _data = _data.TrimEnd('"');
                    stringBuilder.Append("<th  style='border: solid 1px black;' align='center'>");
                    stringBuilder.Append(_data);
                    stringBuilder.Append("</th>");
                }
                stringBuilder.Append("</tr>");
                var columnCount = table.Columns.Count;
                foreach (DataRow myRow in table.Rows)
                {
                    var i = 1;
                    stringBuilder.Append("<tr>");
                    foreach (string ColumnData in myRow.ItemArray.Select(o => QuoteValue(o.ToString())))
                    {

                        var _data = ColumnData.TrimStart('"');
                        _data = _data.TrimEnd('"');

                        stringBuilder.Append("<td  style='border: solid 1px black;'>");
                        stringBuilder.Append(_data);
                        stringBuilder.Append("</td>");
                        i++;
                        if (i > columnCount) break;

                    }
                    stringBuilder.Append("</tr>");
                }
                stringBuilder.Append("</table>");


                table.Dispose();
                return stringBuilder.ToString();
            }

            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static StringBuilder CreateExcelTable(DataSet ds)
        {
            try
            {
                var sb = new StringBuilder();
                DataTable table0 = ds.Tables[0];
                DataTable table = ds.Tables[1];


                sb.Append("<table width='100%' style='border: solid 1px black; border-collapse:collapse;' cellpadding='10'>");
                                
                sb.Append("<tr><td align='center' style='background-color:  #ffff66' colspan = '5'><b>Magarajothi Earth Movers-Kotagiri-Bill Summary</b></td></tr>");

                sb.Append("<tr><td colspan = '5'></td></tr>");


                for (int j = 0; j <= table0.Columns.Count-1; j++)
                {
                    var colvalue = j % 2;

                    if (colvalue==0 && j!=0)
                    {

                        sb.Append("<tr><td colspan = '2'><b>" + table0.Columns[j].ToString() + " : </b>");
                    }
                    
                    else
                    {
                        sb.Append("</td><td align = 'right' colspan = '2'><b>" + table0.Columns[j].ToString() + " : </b>");
                       
                    }

                    for (int i = 0; i <= table0.Rows.Count-1; i++)
                    {
                        sb.Append(table0.Rows[i][j].ToString());
                        
                    }
                }
                sb.Append("</table>");

                sb.Append("<br />");

                sb.Append("<table border='1px' table-layout:fixed; margin-left:4%; border:solid 1px black; cellpadding ='1' cellspacing='1'>");
                sb.Append("<tr>");
                   foreach (DataColumn Column in table.Columns)
                    {
                        var _data = Column.ColumnName.TrimStart('"');
                        _data = _data.TrimEnd('"');
                        sb.Append("<td align=\"center\">");
                        sb.Append(_data);
                        sb.Append("</td>");
                    }

              

                var columnCount = table.Columns.Count; 
                foreach (DataRow myRow in table.Rows)
                {
                    var i = 1;
                    sb.Append("<tr>");
                    foreach (string ColumnData in myRow.ItemArray.Select(o => QuoteValue(o.ToString())))
                    {

                        var _data = ColumnData.TrimStart('"');
                        _data = _data.TrimEnd('"');

                        sb.Append("<td style='mso-number-format:\\@'>");
                        sb.Append(_data);
                        sb.Append("</td>");
                        i++;
                        if (i > columnCount) break;

                    }
                    sb.Append("</tr>");
                }
                sb.Append("</table>");

                table.Dispose();

                //Byte[] byteArray = Encoding.UTF8.GetBytes(sb.ToString());
                return sb;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        static string QuoteValue(string value)
        {
            return String.Concat("\"", value.Replace("\"", ""), "\"");
            //return String.Concat("\"", value, "\"");
        }
        public DataTable ConvertIntoDataTable<T>(List<T> List)
        {
            try
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties by using reflection   
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names  
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in List)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {

                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }

                return dataTable;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }



        public class TwoColumnHeaderFooter : PdfPageEventHelper
        {
            
        
            // This is the contentbyte object of the writer
            PdfContentByte cb;
            // we will put the final number of pages in a template
            PdfTemplate template;
            // this is the BaseFont we are going to use for the header / footer
            BaseFont bf = null;
            BaseFont bfNormal = null;
            // This keeps track of the creation time


            BaseFont Decoration = null;
            BaseFont WithUnderLine = null;
            BaseFont SubBf = null;

            DateTime PrintTime = DateTime.Now;
            #region Properties
            public string Title { get; set; }
            public string SubTitle { get; set; }
            public string SubTitle1 { get; set; }
            public string HeaderLeft { get; set; }
            public string HeaderRight { get; set; }
            public Font HeaderFont { get; set; }
            public Font HeaderValueFont { get; set; }
            public Font FooterFont { get; set; }
            public byte[] CompanyLogo { get; set; }
            public byte[] MohLogo { get; set; }
            public int PdfExportType { get; set; }

            public  Dictionary<string, string> HeaderInfoRight ;
            public Dictionary<string, string> HeaderInfoLeft;



            #endregion
            // we override the onOpenDocument method


            public override void OnOpenDocument(PdfWriter writer, Document document)
            {
                try
                {
                    PrintTime = DateTime.Now;
                    bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    bfNormal = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                    Decoration = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1257, BaseFont.NOT_EMBEDDED);


                    WithUnderLine = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    SubBf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);


                    cb = writer.DirectContent;
                    template = cb.CreateTemplate(50, 50);
                }
                catch (DocumentException de)
                {
                }
                catch (System.IO.IOException ioe)
                {
                }
            }
            public static bool IsValidImage(byte[] bytes)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream(bytes))
                        System.Drawing.Image.FromStream(ms);
                }
                catch (ArgumentException)
                {
                    return false;
                }
                return true;
            }
            public override void OnStartPage(PdfWriter writer, Document document)
            {

                base.OnStartPage(writer, document);
                if (PdfExportType == 1)
                {

                    if (writer.PageNumber == 1)
                    {
                        var pageSize = document.PageSize;
                        if (MohLogo != null && IsValidImage(MohLogo))
                        {
                            var mohLogo = iTextSharp.text.Image.GetInstance(MohLogo); // Converting bytes to Image
                            mohLogo.SetAbsolutePosition(40, 750);

                            if (mohLogo.ScaledHeight > mohLogo.ScaledWidth)
                            {
                                mohLogo.ScaleAbsoluteHeight(90);
                                mohLogo.ScaleAbsoluteWidth(70);
                            }
                            else if (mohLogo.ScaledHeight == mohLogo.ScaledWidth)
                            {
                                mohLogo.ScaleAbsoluteHeight(70);
                                mohLogo.ScaleAbsoluteWidth(70);
                            }
                            else
                            {
                                mohLogo.ScaleAbsoluteHeight(70);
                                mohLogo.ScaleAbsoluteWidth(100);
                            }
                            document.Add(mohLogo);


                        }
                        if (CompanyLogo != null && IsValidImage(CompanyLogo))
                        {
                            var CompanyLogoImage = iTextSharp.text.Image.GetInstance(CompanyLogo); // Converting bytes to Image
                            CompanyLogoImage.SetAbsolutePosition(440, 750);
                            if (CompanyLogoImage.ScaledHeight > CompanyLogoImage.ScaledWidth)
                            {
                                CompanyLogoImage.ScaleAbsoluteHeight(90);
                                CompanyLogoImage.ScaleAbsoluteWidth(70);
                            }
                            else if (CompanyLogoImage.ScaledHeight == CompanyLogoImage.ScaledWidth)
                            {
                                CompanyLogoImage.ScaleAbsoluteHeight(70);
                                CompanyLogoImage.ScaleAbsoluteWidth(70);
                            }
                            else
                            {
                                CompanyLogoImage.ScaleAbsoluteHeight(70);
                                CompanyLogoImage.ScaleAbsoluteWidth(100);
                            }
                            document.Add(CompanyLogoImage);

                        }
                        var HeaderTable = new PdfPTable(2) { WidthPercentage = 100 };
                        HeaderTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        if (HeaderInfoLeft!=null)
                        {
                            foreach (var pr in HeaderInfoLeft)
                            {

                                var key = pr.Key;
                                var Value = pr.Value;

                                if (key != null )
                                {

                                    var phrase = new Phrase();
                                    phrase.Add(new Chunk(key + " : ", HeaderFont));
                                    phrase.Add(new Chunk(Value, HeaderValueFont));
                                    var HeaderLeftCell = new PdfPCell(phrase);
                                    HeaderLeftCell.Padding = 5;
                                    HeaderLeftCell.PaddingBottom = 10;
                                    HeaderLeftCell.BorderWidthRight = 0;
                                    HeaderLeftCell.Border = Rectangle.NO_BORDER;

                                    //HeaderLeftCell.Border = 0;
                                    HeaderTable.AddCell(HeaderLeftCell);
                                }


                            }

                        }




                        document.Add(new Paragraph(" "));
                        HeaderTable.SpacingBefore = 50;
                        HeaderTable.SpacingAfter = 10;
                        document.Add(HeaderTable);

                        var cb = writer.DirectContent;
                        var cb1 = writer.DirectContent;
                        var cb2 = writer.DirectContent;


                        // select the font properties
                        var bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.SetFontAndSize(bf, 15);
                        // write the text in the pdf content
                        cb.BeginText();
                        // put the alignment and coordinates heres
                        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Title, 280, 775, 0);
                        
                        cb.EndText();

                       
                        
                        
                        var bf1 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        cb1.SetColorFill(BaseColor.BLACK);
                        cb1.SetFontAndSize(bf1, 11);
                        cb1.BeginText();
                        cb1.ShowTextAligned(PdfContentByte.ALIGN_CENTER, SubTitle, 280, 760, 0);
                        cb1.EndText();



                        var bf2 = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        cb2.SetColorFill(BaseColor.BLUE);
                        cb2.SetFontAndSize(bf2, 10);
                        cb2.BeginText();
                        cb2.ShowTextAligned(PdfContentByte.ALIGN_CENTER, SubTitle1, 280, 745, 0);
                        cb2.EndText();






                    }
                }
                
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);
                var pageN = writer.PageNumber;
                var Pagetext = "Page " + pageN + " of ";



                var Datetext0 = "Thank You";
                var len0 = bfNormal.GetWidthPoint(Pagetext, 8);
                var pageSize0 = document.PageSize;
                cb.SetRGBColorFill(100, 100, 100);
                cb.SetColorFill(BaseColor.BLACK);
                cb.MoveTo(70, pageSize0.GetBottom(40));
                cb.LineTo(pageSize0.Width - 35, pageSize0.GetBottom(40));
                cb.Stroke();
                cb.BeginText();
                cb.SetFontAndSize(Decoration, 12);
                cb.SetTextMatrix(pageSize0.GetLeft(300), pageSize0.GetBottom(25));
                cb.ShowText(Datetext0);
                cb.EndText();

                var Datetext1 = "Our Services:";
                var len1 = bfNormal.GetWidthPoint(Pagetext, 8);
                var pageSize1 = document.PageSize;
                cb.SetRGBColorFill(100, 100, 100);
                cb.SetColorFill(BaseColor.ORANGE);
                
                cb.MoveTo(35, pageSize1.GetBottom(40));
                cb.LineTo(pageSize1.Width - 35, pageSize1.GetBottom(40));
                cb.Stroke();
                cb.BeginText();
                cb.SetFontAndSize(WithUnderLine, 9);
                cb.SetTextMatrix(pageSize1.GetLeft(40), pageSize1.GetBottom(25));
                cb.ShowText(Datetext1);
                cb.EndText();

                var Datetext = "JCB Service,Tipper Service,Building Materials(Sand,Bricks,Blue Metal[Jalli]) Supply";
                var len = bfNormal.GetWidthPoint(Pagetext, 8);
                var pageSize = document.PageSize;
                cb.SetRGBColorFill(100, 100, 100);
                cb.SetColorFill(BaseColor.BLUE);
                cb.MoveTo(35, pageSize.GetBottom(40));
                cb.LineTo(pageSize.Width - 35, pageSize.GetBottom(40));
                cb.Stroke();
                cb.BeginText();
                cb.SetFontAndSize(SubBf, 8);
                cb.SetTextMatrix(pageSize.GetLeft(40), pageSize.GetBottom(10));
                cb.ShowText(Datetext);
                cb.EndText();
                var PageMarginRgt = pageN >= 10 ? pageSize.GetRight(90) + len : (pageSize.GetRight(85) + len);
                //cb.AddTemplate(template, pageSize.GetRight(75) + len, pageSize.GetBottom(30));
                cb.AddTemplate(template, PageMarginRgt, pageSize.GetBottom(10));

                cb.BeginText();
                cb.SetFontAndSize(bfNormal, 7);
                cb.SetColorFill(BaseColor.BLACK);
                cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT,
                    Pagetext,
                    pageSize.GetRight(50),
                    pageSize.GetBottom(10), 0);
                //cb.SetTextMatrix(pageSize.GetRight(38), pageSize.GetBottom(30));
                cb.EndText();


            }
            public override void OnCloseDocument(PdfWriter writer, Document document)
            {
                base.OnCloseDocument(writer, document);
                template.BeginText();
                template.SetFontAndSize(bfNormal, 7);
                template.SetTextMatrix(0, 0);
                template.SetColorFill(BaseColor.BLACK);
                template.ShowText("End of Page " + (writer.PageNumber - 1));
                template.EndText();
            }
        }
    }

}
