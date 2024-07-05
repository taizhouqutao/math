using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;
using System.IO;
using NPOI.XSSF.Streaming;
using NPOI.SS.UserModel;
using Web.Help;

namespace Web.Help
{
    public static class MakeFile
    {
        public static NpoiMemoryStream GetFileStream(string[] Lessons,List<string> randomList,string selectifMany)
        {
            using(SXSSFWorkbook book = new SXSSFWorkbook())
            {
                ISheet sheet1 = book.CreateSheet("Sheet1");
                int i = 0;int rowIdx = 0;
                if (Lessons.Contains("5.1"))
                {
                    do
                    {
                        IRow row;
                        if (i == 0)
                        {
                            row = sheet1.CreateRow(rowIdx);
                        }
                        else
                        {
                            row = sheet1.GetRow(rowIdx);
                        }
                        ICellStyle cellStyle = book.CreateCellStyle();
                        IFont font = book.CreateFont();
                        font.FontHeightInPoints = 14; // 设置字体大小，单位为点
                        cellStyle.SetFont(font);

                        row.Height = 600;

                        var cell = row.CreateCell(i * 2);
                        var cellValue = randomList[0];
                        cell.SetCellValue(cellValue);
                        cell.CellStyle = cellStyle;
                        var cellAns = row.CreateCell(i * 2 + 1);
                        int Width = 9000;
                        sheet1.SetColumnWidth(i * 2 + 1, Width);
                        cellAns.CellStyle = cellStyle;
                        i = i + 1;
                        if (i == 2)
                        {
                            i = 0;
                            rowIdx = rowIdx + 1;
                        }
                        randomList.RemoveAt(0);
                    } while (randomList.Count > 0);
                }
                else if (Lessons.Contains("5.1.2"))
                {
                    do
                    {
                        IRow row;
                        if (i == 0)
                        {
                            row = sheet1.CreateRow(rowIdx);
                        }
                        else
                        {
                            row = sheet1.GetRow(rowIdx);
                        }
                        ICellStyle cellStyle = book.CreateCellStyle();
                        IFont font = book.CreateFont();
                        font.FontHeightInPoints = 14; // 设置字体大小，单位为点
                        cellStyle.SetFont(font);

                        row.Height = 600;

                        var cell = row.CreateCell(i * 2);
                        var cellValue = randomList[0];
                        cellValue = cellValue.Replace(" ", "");
                        cell.SetCellValue(cellValue);
                        cell.CellStyle = cellStyle;
                        var cellAns = row.CreateCell(i * 2 + 1);
                        int Width = 2400;
                        sheet1.SetColumnWidth(i * 2 + 1, Width);
                        cellAns.CellStyle = cellStyle;
                        i = i + 1;
                        if (i == 5)
                        {
                            i = 0;
                            rowIdx = rowIdx + 1;
                        }
                        randomList.RemoveAt(0);
                    } while (randomList.Count > 0);
                }
                else if (Lessons.Contains("6.1.2") && Lessons.Count()==1 && !string.IsNullOrEmpty(selectifMany))
                {
                    do
                    {
                        IRow row;
                        if (i == 0)
                        {
                            row = sheet1.CreateRow(rowIdx);
                        }
                        else
                        {
                            row = sheet1.GetRow(rowIdx);
                        }
                        ICellStyle cellStyle = book.CreateCellStyle();
                        IFont font = book.CreateFont();
                        font.FontHeightInPoints = 14; // 设置字体大小，单位为点
                        cellStyle.SetFont(font);

                        row.Height = 600;

                        var cell = row.CreateCell(i * 2);
                        var cellValue = randomList[0];
                        cell.SetCellValue(cellValue);
                        cell.CellStyle = cellStyle;
                        var cellAns = row.CreateCell(i * 2 + 1);
                        int Width = 2400;
                        sheet1.SetColumnWidth(i * 2 + 1, Width);
                        cellAns.CellStyle = cellStyle;
                        i = i + 1;
                        if (i == 5)
                        {
                            i = 0;
                            rowIdx = rowIdx + 1;
                        }
                        randomList.RemoveAt(0);
                    } while (randomList.Count > 0);
                }
                else
                {
                    do
                    {
                        IRow row;
                        if (i == 0)
                        {
                            row = sheet1.CreateRow(rowIdx);
                        }
                        else
                        {
                            row = sheet1.GetRow(rowIdx);
                        }
                        ICellStyle cellStyle = book.CreateCellStyle();
                        IFont font = book.CreateFont();
                        font.FontHeightInPoints = 14; // 设置字体大小，单位为点
                        cellStyle.SetFont(font);

                        row.Height = 600;

                        var cell = row.CreateCell(i * 2);
                        var cellValue = randomList[0];
                        if (!string.IsNullOrEmpty(selectifMany))
                        {
                            cellValue = cellValue.Replace(" ", "");
                        }
                        cell.SetCellValue(cellValue);
                        cell.CellStyle = cellStyle;
                        var cellAns = row.CreateCell(i * 2 + 1);
                        int Width = 2400;
                        if (!string.IsNullOrEmpty(selectifMany))
                        {
                            if (i == 3 || i == 4)
                            {
                                Width = 2850;
                            }
                            else
                            {
                                Width = 2100;
                            }
                        }
                        sheet1.SetColumnWidth(i * 2 + 1, Width);
                        cellAns.CellStyle = cellStyle;
                        i = i + 1;
                        if (i == 5)
                        {
                            i = 0;
                            rowIdx = rowIdx + 1;
                        }
                        randomList.RemoveAt(0);
                    } while (randomList.Count > 0);
                }
                var ms = new NpoiMemoryStream();
                ms.AllowClose = false;
                book.Write(ms);
                sheet1=null;
                ms.Seek(0, SeekOrigin.Begin);
                ms.AllowClose = true;
                return ms; 
            }
        }

        public class NpoiMemoryStream: MemoryStream
        {
            public NpoiMemoryStream()
            {
                AllowClose = true;
            }

            public bool AllowClose { get; set; }

            public override void Close()
            {
                if(AllowClose)
                {
                    base.Close();
                }
            }
        }
    }
}