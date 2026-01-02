using System;
using System.Collections.Generic;
using System.Globalization;

namespace Do_An_N2
{
    public static class HienThi
    {
        public static void HienThiDanhSach(QuanLySinhVien qlsv, List<SinhVien> ds = null)
        {
            List<SinhVien> danhSachHienThi = ds ?? qlsv.DanhSach;

            // In tiêu đề bảng
            Console.WriteLine("===================================================================================================================================================================================================================");
            Console.WriteLine("| Mã SV  | Họ tên               | Ngày sinh  | GT | Lớp    | Khoa                   | Khóa học   | SDT          | Email                     | Địa chỉ         | CC   | QT   | CK   | Điểm trung bình | Xếp loại   |");
            Console.WriteLine("===================================================================================================================================================================================================================");

            var vi = new CultureInfo("vi-VN");

            // In từng sinh viên
            foreach (SinhVien sv in danhSachHienThi)
            {
                string maSV = CatChuoi(sv.MaSV, 6);
                string hoTen = CatChuoi(sv.HoTen, 20);
                string ngaySinh = sv.NgaySinh.ToString("yyyy-MM-dd");
                string gioiTinh = CatChuoi(sv.GioiTinh, 3);
                string lop = CatChuoi(sv.Lop, 7);
                string khoa = CatChuoi(sv.Khoa, 22);
                string khoaHoc = CatChuoi(sv.KhoaHoc, 10);
                string sdt = CatChuoi(sv.SoDienThoai, 12);
                string email = CatChuoi(sv.Email, 25);
                string diaChi = CatChuoi(sv.DiaChi, 15);
                string cc = sv.DiemChuyenCan.ToString("F1", vi);
                string qt = sv.DiemQuaTrinh.ToString("F1", vi);
                string ck = sv.DiemCuoiKi.ToString("F1", vi);
                string dtb = sv.DiemTB.ToString("F1", vi);
                string xepLoai = CatChuoi(sv.XepLoai, 10);

                Console.WriteLine("| " +
                    CanPhai(maSV, 6) + " | " +
                    CanTrai(hoTen, 20) + " | " +
                    CanGiua(ngaySinh, 10) + " | " +
                    CanGiua(gioiTinh, 2) + " | " +
                    CanTrai(lop, 6) + " | " +
                    CanTrai(khoa, 22) + " | " +
                    CanGiua(khoaHoc, 10) + " | " +
                    CanTrai(sdt, 12) + " | " +
                    CanTrai(email, 25) + " | " +
                    CanTrai(diaChi, 15) + " | " +
                    CanPhai(cc, 4) + " | " +
                    CanPhai(qt, 4) + " | " +
                    CanPhai(ck, 4) + " | " +
                    CanPhai(dtb, 15) + " | " +
                    CanTrai(xepLoai, 10) + " |");
            }

            Console.WriteLine("===================================================================================================================================================================================================================");
            Console.WriteLine("Tổng số sinh viên: " + danhSachHienThi.Count);
        }

        private static string CatChuoi(string chuoi, int doDai)
        {
            if (string.IsNullOrEmpty(chuoi))
                return "";

            if (chuoi.Length <= doDai)
                return chuoi;
            else
                return chuoi.Substring(0, doDai - 3) + "...";
        }

        private static string CanTrai(string chuoi, int doDai)
        {
            if (chuoi == null) chuoi = "";

            if (chuoi.Length >= doDai)
                return chuoi.Substring(0, doDai);

            while (chuoi.Length < doDai)
                chuoi += " ";
            return chuoi;
        }

        private static string CanPhai(string chuoi, int doDai)
        {
            if (chuoi == null) chuoi = "";

            if (chuoi.Length >= doDai)
                return chuoi.Substring(0, doDai);

            while (chuoi.Length < doDai)
                chuoi = " " + chuoi;
            return chuoi;
        }

        private static string CanGiua(string chuoi, int doDai)
        {
            if (chuoi == null) chuoi = "";

            if (chuoi.Length >= doDai)
                return chuoi.Substring(0, doDai);

            int khoangTrangCanThem = doDai - chuoi.Length;
            int khoangTrangTrai = khoangTrangCanThem / 2;
            int khoangTrangPhai = khoangTrangCanThem - khoangTrangTrai;

            for (int i = 0; i < khoangTrangTrai; i++)
                chuoi = " " + chuoi;
            for (int i = 0; i < khoangTrangPhai; i++)
                chuoi += " ";

            return chuoi;
        }
    }
}