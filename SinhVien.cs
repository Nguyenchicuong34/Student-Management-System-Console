using System;

namespace Do_An_N2
{
    public class SinhVien
    {
        public string MaSV { get; set; }              // Mã sinh viên
        public string HoTen { get; set; }             // Họ tên
        public DateTime NgaySinh { get; set; }        // Ngày sinh
        public string GioiTinh { get; set; }          // Giới tính (Nam/Nữ)
        public string Lop { get; set; }               // Lớp
        public string Khoa { get; set; }              // Khoa/Viện
        public string KhoaHoc { get; set; }           // Khóa học (vd: 2021-2025)
        public string SoDienThoai { get; set; }       // Số điện thoại
        public string Email { get; set; }             // Email
        public string DiaChi { get; set; }            // Địa chỉ

        public double DiemChuyenCan { get; set; }     // Điểm chuyên cần
        public double DiemQuaTrinh { get; set; }      // Điểm quá trình
        public double DiemCuoiKi { get; set; }        // Điểm cuối kì

        public double DiemTB
        {
            get { return Math.Round((DiemChuyenCan + DiemQuaTrinh + DiemCuoiKi) / 3, 1); }
        }

        public string XepLoai
        {
            get
            {
                if (DiemTB >= 8.5) return "Giỏi";
                if (DiemTB >= 6.5) return "Khá";
                if (DiemTB >= 5) return "Trung bình";
                return "Yếu";
            }
        }
    }
}