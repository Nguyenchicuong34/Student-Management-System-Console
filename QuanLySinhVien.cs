using Do_An_N2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace Do_An_N2
{
    public class QuanLySinhVien
    {
        public List<SinhVien> DanhSach { get; set; }

        public QuanLySinhVien()
        {
            DanhSach = new List<SinhVien>();
        }

        public void Them(SinhVien sv)
        {
            DanhSach.Add(sv);
        }

        public bool Sua(string ma, SinhVien thongTinMoi)
        {
            SinhVien sv = DanhSach.FirstOrDefault(x => x.MaSV == ma);
            if (sv == null) return false;
            sv.HoTen = thongTinMoi.HoTen;
            sv.DiemChuyenCan = thongTinMoi.DiemChuyenCan;
            sv.DiemQuaTrinh = thongTinMoi.DiemQuaTrinh;
            sv.DiemCuoiKi = thongTinMoi.DiemCuoiKi;
            return true;
        }

        public bool Xoa(string ma)
        {
            SinhVien sv = DanhSach.FirstOrDefault(x => x.MaSV == ma);
            if (sv == null) return false;
            DanhSach.Remove(sv);
            return true;
        }

        public List<SinhVien> TimKiem(string tuKhoa)
        {
            string tuKhoaLower = (tuKhoa ?? "").ToLower();
            return DanhSach.Where(s =>
                (s.MaSV ?? "").ToLower().Contains(tuKhoaLower) ||
                (s.HoTen ?? "").ToLower().Contains(tuKhoaLower)).ToList();
        }

        public void SapXepTheoTen()
        {
            DanhSach = DanhSach.OrderBy(s => s.HoTen).ToList();
        }

        public void SapXepTheoDiem()
        {
            DanhSach = DanhSach.OrderByDescending(s => s.DiemTB).ToList();
        }

        private static double ParseDiem(string raw)
        {
            string s = (raw ?? "").Trim().Replace(',', '.'); // chấp nhận cả "," và "."
            if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out double v))
                return v;
            throw new FormatException("Điểm không hợp lệ: " + raw);
        }

        // ĐỌC dữ liệu từ XML (chịu được "," hoặc ".")
        public void TaiXML(string duongDan)
        {
            DanhSach.Clear();
            XmlDocument f = new XmlDocument();
            f.Load(duongDan);
            XmlNodeList ds = f.SelectNodes("/dsDanhVien/sinhVien");
            foreach (XmlNode n in ds)
            {
                SinhVien sv = new SinhVien();
                sv.MaSV = n["masv"].InnerText;
                sv.HoTen = n["hoten"].InnerText;
                sv.NgaySinh = DateTime.Parse(n["ngaysinh"].InnerText);
                sv.GioiTinh = n["gioitinh"].InnerText;
                sv.Lop = n["lop"].InnerText;
                sv.Khoa = n["khoa"].InnerText;
                sv.KhoaHoc = n["khoahoc"].InnerText;
                sv.SoDienThoai = n["sodienthoai"].InnerText;
                sv.Email = n["email"].InnerText;
                sv.DiaChi = n["diachi"].InnerText;
                sv.DiemChuyenCan = ParseDiem(n["diem1"].InnerText);
                sv.DiemQuaTrinh = ParseDiem(n["diem2"].InnerText);
                sv.DiemCuoiKi = ParseDiem(n["diem3"].InnerText);
                DanhSach.Add(sv);
            }
        }

        // GHI dữ liệu ra XML (chuẩn hoá dùng InvariantCulture: dấu ".")
        public void LuuXML(string duongDan)
        {
            XmlDocument f = new XmlDocument();
            XmlElement root = f.CreateElement("dsDanhVien");
            f.AppendChild(root);
            foreach (var sv in DanhSach)
            {
                XmlElement n = f.CreateElement("sinhVien");

                void Add(string name, string value)
                {
                    XmlElement x = f.CreateElement(name);
                    x.InnerText = value ?? "";
                    n.AppendChild(x);
                }

                Add("masv", sv.MaSV);
                Add("hoten", sv.HoTen);
                Add("ngaysinh", sv.NgaySinh.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
                Add("gioitinh", sv.GioiTinh);
                Add("lop", sv.Lop);
                Add("khoa", sv.Khoa);
                Add("khoahoc", sv.KhoaHoc);
                Add("sodienthoai", sv.SoDienThoai);
                Add("email", sv.Email);
                Add("diachi", sv.DiaChi);
                Add("diem1", sv.DiemChuyenCan.ToString("0.0", CultureInfo.InvariantCulture));
                Add("diem2", sv.DiemQuaTrinh.ToString("0.0", CultureInfo.InvariantCulture));
                Add("diem3", sv.DiemCuoiKi.ToString("0.0", CultureInfo.InvariantCulture));

                root.AppendChild(n);
            }
            f.Save(duongDan);
        }
    }
}