using System;
using System.Collections.Generic;
using System.Globalization;

namespace Do_An_N2
{
    public static class NhapSuaXoa
    {
        public static void ThemDanhSachSinhVien(QuanLySinhVien qlsv)
        {
            int soLuong;
            while (true)
            {
                Console.Write("Nhập số lượng sinh viên cần thêm: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out soLuong) && soLuong > 0)
                    break;
                else
                    Console.WriteLine("Vui lòng nhập lại !");
            }

            for (int i = 1; i <= soLuong; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Nhập thông tin sinh viên thứ " + i + "");
                SinhVien sv = NhapThongTinSinhVien();
                qlsv.Them(sv);
            }
            Console.WriteLine();
            Console.WriteLine("Đã thêm " + soLuong + " sinh viên vào danh sách.");
            TienIch.DungLai();
        }

        public static void SuaSinhVien(QuanLySinhVien qlsv)
        {
            Console.Write("Nhập mã sinh viên cần sửa: ");
            string ma = Console.ReadLine();
            Console.WriteLine("Nhập thông tin mới cho sinh viên:");
            SinhVien sv = NhapThongTinSinhVien();
            sv.MaSV = ma; // giữ nguyên mã sinh viên
            bool ketQua = qlsv.Sua(ma, sv);
            if (ketQua)
                Console.WriteLine("Đã sửa thông tin!");
            else
                Console.WriteLine("Không tìm thấy sinh viên!");
            TienIch.DungLai();
        }

        public static void XoaSinhVien(QuanLySinhVien qlsv)
        {
            Console.Write("Nhập mã sinh viên cần xóa: ");
            string ma = Console.ReadLine();
            bool ketQua = qlsv.Xoa(ma);
            if (ketQua)
                Console.WriteLine("Đã xóa sinh viên!");
            else
                Console.WriteLine("Không tìm thấy sinh viên!");
            TienIch.DungLai();
        }

        public static void TimKiemSinhVien(QuanLySinhVien qlsv)
        {
            Console.Write("Nhập từ khóa tìm kiếm: ");
            string tk = Console.ReadLine();
            List<SinhVien> ketQua = qlsv.TimKiem(tk);
            HienThi.HienThiDanhSach(qlsv, ketQua);
            TienIch.DungLai();
        }

        private static SinhVien NhapThongTinSinhVien()
        {
            SinhVien sv = new SinhVien();
            Console.Write("Mã sinh viên: ");
            sv.MaSV = Console.ReadLine();
            Console.Write("Họ tên: ");
            sv.HoTen = Console.ReadLine();
            Console.Write("Ngày sinh (yyyy-MM-dd): ");
            DateTime ngaysinh;
            while (!DateTime.TryParse(Console.ReadLine(), out ngaysinh))
            {
                Console.Write("Nhập lại ngày sinh (yyyy-MM-dd): ");
            }
            sv.NgaySinh = ngaysinh;
            Console.Write("Giới tính (Nam/Nữ): ");
            sv.GioiTinh = Console.ReadLine();
            Console.Write("Lớp: ");
            sv.Lop = Console.ReadLine();
            Console.Write("Khoa: ");
            sv.Khoa = Console.ReadLine();
            Console.Write("Khóa học: ");
            sv.KhoaHoc = Console.ReadLine();
            Console.Write("Số điện thoại: ");
            sv.SoDienThoai = Console.ReadLine();
            Console.Write("Email: ");
            sv.Email = Console.ReadLine();
            Console.Write("Địa chỉ: ");
            sv.DiaChi = Console.ReadLine();
            sv.DiemChuyenCan = NhapDiem("Điểm chuyên cần: ");
            sv.DiemQuaTrinh = NhapDiem("Điểm quá trình: ");
            sv.DiemCuoiKi = NhapDiem("Điểm cuối kì : ");
            return sv;
        }

        // Cho phép: "8,5" hoặc "8.5" và ép về 0..10
        private static double NhapDiem(string tb)
        {
            while (true)
            {
                Console.Write(tb);
                string s = (Console.ReadLine() ?? string.Empty).Trim();
                s = s.Replace(',', '.');
                if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out double diem))
                {
                    if (diem < 0 || diem > 10)
                    {
                        Console.WriteLine("Điểm phải nằm trong khoảng 0..10!");
                        continue;
                    }
                    return Math.Round(diem, 1);
                }
                Console.WriteLine("Vui lòng nhập số thực hợp lệ (ví dụ: 8,5 hoặc 8.5)!");
            }
        }
    }
}