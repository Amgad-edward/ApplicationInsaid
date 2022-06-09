
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using TheModels.Models;
using TheModels;
using System.ComponentModel;
using System.IO;
using System.Management;
using TheModels.Helper_Services;
using System.Drawing;
using System.Drawing.Imaging;

namespace ApplicationinCompany
{
    public static class Hex
    {
        public const ushort Max = 1700;

        private const string CodeSC = "001D0F1F90CAED110727010C";

        public const uint MaxAllowFile = 1048576;

        public static string? TaxNumberCompany = "";

        public static bool ISActive => GetActive();

        public static bool ISTry { get; set; }

        private static List<string> Extintion = new List<string> { ".jpg", ".png" };


        private static List<string> ExtintionFiles = new List<string> { ".json", ".xlsx" };

        public static Company Company { get; set; } = new Company();

        public static string Connections { get; set; } = "";

        public static string ShowImage(this byte[] source,string type = "jpg")
        {
            if(source != null)
            {
                return $"data:image/{type};base64,{Convert.ToBase64String(source)}";
            }
            return string.Empty;
        }


        public static string GetBarcodeImage(this string source)
        {
            try
            {
                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                Image image = barcode.Draw(source,30);
                var bmb = new Bitmap(image);
                var stream = new MemoryStream();
                bmb.Save(stream,ImageFormat.Jpeg);
                return $"data:image/jpg;base64,{Convert.ToBase64String(stream.ToArray())}";
            }
            catch (Exception)
            {

                return "";
            }
        }

        public static string GettypeFile(this string source)
        {
            return Path.GetExtension(source);
        }

        public static bool IsExtiotionImage(this string source)
        {
            return Extintion.Contains(Path.GetExtension(source));
        }

        public static decimal ToRound(this decimal source , int To = 0)
        {
            if(To > 0)
                return Math.Round(source, To);

            return Math.Round(source);
        }

        public static string NameToEnglish(this string Name)
        {
            string name = string.Empty;
            Name = GetFirstAndlast(Name);
            foreach (var C in Name)
            {
                try
                {
                    name += GetChar(C);
                }
                catch 
                {
                    return Name;
                }
            }

            return name;
        }

        public static string ToMoney(this decimal source)
        {
            return $"{Math.Round(source, 1)} جم";
        }

        public static string ShowDiscruotionEnum(this Enum enums)
        {
            var field = enums.GetType().GetField(enums.ToString());
            if (field != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[]) field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if(attributes is { } && attributes.Length > 0)
                {
                    return attributes[0].Description; 
                }
            }
            return string.Empty;
        }

        public static string ConvertNumberToText<Number>(this Number number)
        {
            return Create(number);
        }

        public static string Todate(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd dddd");
        }

        public static string ToDate(this DateOnly dateOnly)
        {
            return dateOnly.ToString("yy-MM-dd dddd");
        }

        private static string GetChar(char Char)
        {
            Dictionary<char, string> keys = new Dictionary<char, string>();
            keys.Add(' ', " ");
            keys.Add('ا', "A");
            keys.Add('أ', "A");
            keys.Add('إ', "E");
            keys.Add('آ', "AE");
            keys.Add('ب', "B");
            keys.Add('ت', "T");
            keys.Add('ث', "TH");
            keys.Add('ج', "GA");
            keys.Add('ح', "HA");
            keys.Add('خ', "KH");
            keys.Add('د', "D");
            keys.Add('ذ', "Z");
            keys.Add('ر', "R");
            keys.Add('ز', "ZE");
            keys.Add('س', "S");
            keys.Add('ش', "SH");
            keys.Add('ص', "SHA");
            keys.Add('ض', "DA");
            keys.Add('ط', "TA");
            keys.Add('ظ', "ZAH");
            keys.Add('ع', "A");
            keys.Add('غ', "GH");
            keys.Add('ف', "F");
            keys.Add('ق', "KA");
            keys.Add('ك', "K");
            keys.Add('ل', "L");
            keys.Add('م', "M");
            keys.Add('ن', "N");
            keys.Add('ه', "HA");
            keys.Add('و', "W");
            keys.Add('ؤ', "WI");
            keys.Add('ى', "I");
            keys.Add('ي', "EE");
            keys.Add('ء', "EE");
            keys.Add('ئ', "E");
            keys.Add('-', "-");
            keys.Add('ة', "H");

            return keys[Char];

        }

        public static string GetFirstAndlast(this string Names)
        {
            var N = Names.Split(' ');
            if (N.Length >= 2)
                return $"{N[0]} {N[1]}";
            else
                return N[0];
        }

        private static string Create<Ty>(Ty obj) 
        {
            var Result = "";
            char stop = ' ';
            string Numberstr = "";
            double Number = 0;//32 ,  256 ,302
            var plus = 0;
            switch (obj)
            {
                case string s:
                    s = NumberOnly(s);
                    if (s.Length > 0)
                    {
                        Numberstr = s;
                        Number = Convert.ToDouble(s);
                    }
                    else
                        throw new InvalidOperationException("لا توجد قيمة");
                    break;
                case double d:
                    Numberstr = d.ToString().NumberOnly();
                    Number = Convert.ToDouble(d);
                    break;
                case long L:
                    Numberstr = L.ToString().NumberOnly();
                    Number = L;
                    break;
                case float f:
                    Numberstr = f.ToString().NumberOnly();
                    Number = f;
                    break;
                case decimal m:
                    if (m < decimal.MaxValue)
                    {
                        Numberstr = m.ToString().NumberOnly();
                        Number = Convert.ToDouble(m);
                    }
                    else
                        throw new InvalidOperationException("The Number Of Decimal Can Not Be Convert");
                    break;
                case int n:
                    Numberstr = n.ToString().NumberOnly();
                    Number = Convert.ToDouble(n);
                    break;
                default:
                    string st = NumberOnly(obj.ToString());
                    if (st.Length > 0)
                    {
                        Numberstr = st;
                        Number = Convert.ToDouble(st);
                    }
                    else
                        throw new InvalidOperationException("There are no numeric values, you must enter numbers to change them ");
                    break;
            }

            foreach (char N in Numberstr)
            {
                if (Number >= 1000000 && Number <= 99000000)
                {
                    if (Number >= 1000000 && Number <= 9999999)
                    {
                        Result = Values_1(N) + " مليون";
                        Number -= Convert.ToDouble(N.ToString()) * 1000000;
                    }
                    else
                    {
                        if (stop == ' ')
                        {
                            stop = (N != '0') ? N : ' ';
                            continue;
                        }
                        else
                        {
                            Result = Values_1(N) + ((stop != '1') ? " و " : " ") + Values_10(stop) + " مليون";
                            var str = stop.ToString() + N.ToString();
                            stop = ' ';
                            Number -= Convert.ToDouble(str) * 1000000;
                        }
                    }
                }
                else if (Number < 1000000 && Number >= 100000)
                {
                    plus += 1;
                    Result += (Result != "" && N != '0' ? " و " : "") + Values_100(N) + " الف";
                    Number -= Convert.ToDouble(N.ToString()) * 100000;
                }

                else if (Number < 100000 && Number >= 10000)
                {
                    if (stop == ' ')
                    {
                        stop = (N != '0') ? N : ' ';
                        continue;
                    }
                    else
                    {
                        Result += (Result != "" ? " و " : "") + Values_1(N) + $" {((N != '0') ? "و" : "")} {Values_10(stop)}";
                        var str = stop.ToString() + N.ToString();
                        Number -= Convert.ToDouble(str) * 1000;
                        Result = Result.Replace(" الف", "");
                        Result += " الف";
                        stop = ' ';
                    }

                }
                else if (Number < 10000 && Number >= 1000)
                {
                    Result += (Result != "" && N != '0' ? " و " : "") + Values_1000(N);
                    Number -= Convert.ToDouble(N.ToString()) * 1000;
                    Result = Result.Replace(" الف", "");

                }

                else if (Number < 1000 && Number >= 100)
                {
                    if (Number >= 100)
                    {
                        Result += (Result != "" && N != '0' ? " و " : "") + Values_100(N);
                        Number -= Convert.ToDouble(N.ToString()) * 100;
                    }

                }
                else if (Number < 100 && Number >= 10)
                {
                    if (stop == ' ')
                    {
                        stop = (N != '0') ? N : ' ';
                        continue;
                    }
                    else
                    {
                        Result += (!string.IsNullOrEmpty(Result) ? " و " : "") + Values_1(N) + $" {((int.Parse(stop.ToString()) >= 2 && N != '0') ? "و" : "")} {Values_10(stop)}";
                        var str = stop.ToString() + N.ToString();
                        Number -= Convert.ToDouble(str);
                        stop = ' ';
                    }
                }
                else if (Number < 10 && Number >= 1)
                {
                    Result += (Result != "" && N != '0' ? " و " : "") + Values_1(N);
                    Number -= Convert.ToDouble(N.ToString());
                }
            }
            return Result;
        }

        private static string NumberOnly(this string Number)
        {
            var number = "";
            foreach (var N in Number)
            {
                if ((N == '1') || (N == '2') || (N == '3') || (N == '4') || (N == '5') || (N == '6') || (N == '7') || (N == '8') || (N == '9') || (N == '0') || (N == '.'))
                {
                    if (N == '.')
                        return number;

                    number += N;
                }
            }

            return number;
        }

        private static string Values_1(char Key)
        {
            Dictionary<char, string> keys = new Dictionary<char, string>();
            keys.Add('1', "واحد");
            keys.Add('2', "اثنان");
            keys.Add('3', "ثلاثة");
            keys.Add('4', "اربعة");
            keys.Add('5', "خمسة");
            keys.Add('6', "ستة");
            keys.Add('7', "سبعة");
            keys.Add('8', "ثمانية");
            keys.Add('9', "تسعة");
            keys.Add('0', "");
            return keys[Key];
        }

        private static string Values_1000(char Key)
        {
            Dictionary<char, string> keys = new Dictionary<char, string>();
            keys.Add('1', "الف");
            keys.Add('2', "الفان");
            keys.Add('3', "ثلاث الالف");
            keys.Add('4', "اربع الالف");
            keys.Add('5', "خمس الالف");
            keys.Add('6', "ستة الالف");
            keys.Add('7', "سبع الالف");
            keys.Add('8', "ثمانية الالف");
            keys.Add('9', "تسع الالف");
            keys.Add('0', "");
            return keys[Key];
        }

        private static string Values_100(char Key)
        {
            Dictionary<char, string> keys = new Dictionary<char, string>();
            keys.Add('1', "مائة");
            keys.Add('2', "مئتان");
            keys.Add('3', "ثلاثمائة");
            keys.Add('4', "اربعومائة");
            keys.Add('5', "خمسمائة");
            keys.Add('6', "ستمائة");
            keys.Add('7', "سبعومائة");
            keys.Add('8', "ثمانمائة");
            keys.Add('9', "تسعمائة");
            keys.Add('0', "");
            return keys[Key];
        }
        private static string Values_10(char Key)
        {
            Dictionary<char, string> keys = new Dictionary<char, string>();
            keys.Add('1', "عشر");
            keys.Add('2', "عشرون");
            keys.Add('3', "ثلاثون");
            keys.Add('4', "اربعون");
            keys.Add('5', "خمسون");
            keys.Add('6', "ستين");
            keys.Add('7', "سبعون");
            keys.Add('8', "ثمانين");
            keys.Add('9', "تسعون");
            keys.Add('0', "");
            return keys[Key];
        }

        private static bool GetActive() //for Windows Only
        {
            ManagementObjectCollection? collection = null;
            using var difine = new ManagementObjectSearcher("SELECT * FROM Win32_USBHub");
            if(difine.Get() is not null)
            {
                collection = difine.Get();
                foreach (var item in collection)
                {
                    var Arr = item.GetPropertyValue("DeviceID").ToString().Split('\\');
                    var N = Arr[Arr.Length - 1];
                    if (N == CodeSC)
                        return true;
                }
            }

            return false;
        }  
    }
}
