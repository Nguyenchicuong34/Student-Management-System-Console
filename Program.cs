using System;
using System.Text;

namespace Do_An_N2
{
    public class Program
    {
        static QuanLySinhVien qlsv = new QuanLySinhVien();

        static void Main(string[] args)
        {
            string duongDanXML = "C:\\Users\\admin\\Downloads\\Cuong\\Do_An_N2\\Do_An_N2\\data.xml";
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("************************************************");
                Console.WriteLine("*              QUẢN LÝ SINH VIÊN               *");
                Console.WriteLine("************************************************");
                Console.WriteLine("* 1. Thêm sinh viên                            *");
                Console.WriteLine("* 2. Sửa thông tin sinh viên                   *");
                Console.WriteLine("* 3. Xóa sinh viên                             *");
                Console.WriteLine("* 4. Tìm kiếm sinh viên                        *");
                Console.WriteLine("* 5. Hiển thị danh sách sinh viên              *");
                Console.WriteLine("* 6. Sắp xếp theo tên                          *");
                Console.WriteLine("* 7. Sắp xếp theo điểm trung bình              *");
                Console.WriteLine("* 8. Lưu dữ liệu từ file XML                   *");
                Console.WriteLine("* 9. Tải dữ liệu từ file XML                   *");
                Console.WriteLine("* 0. Thoát                                     *");
                Console.WriteLine("************************************************");
                Console.Write("Chọn chức năng: ");
                string chon = Console.ReadLine();
                switch (chon)
                {
                    case "1": NhapSuaXoa.ThemDanhSachSinhVien(qlsv); qlsv.LuuXML(duongDanXML); break;
                    case "2": NhapSuaXoa.SuaSinhVien(qlsv); break;
                    case "3": NhapSuaXoa.XoaSinhVien(qlsv); qlsv.LuuXML(duongDanXML); break;
                    case "4": NhapSuaXoa.TimKiemSinhVien(qlsv); break;
                    case "5": HienThi.HienThiDanhSach(qlsv); TienIch.DungLai(); break;
                    case "6": qlsv.SapXepTheoTen(); HienThi.HienThiDanhSach(qlsv); TienIch.DungLai(); break;
                    case "7": qlsv.SapXepTheoDiem(); HienThi.HienThiDanhSach(qlsv); TienIch.DungLai(); break;
                    case "8": qlsv.LuuXML(duongDanXML); Console.WriteLine("Đã lưu!"); TienIch.DungLai(); break;
                    case "9": qlsv.TaiXML(duongDanXML); Console.WriteLine("Đã tải!"); TienIch.DungLai(); break;
                    case "0": return;
                    default: Console.WriteLine("Chức năng không hợp lệ!, vui lòng chọn lại"); TienIch.DungLai(); break;
                }
            }
        }
    }
}