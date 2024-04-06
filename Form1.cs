using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoveQueuePrint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnRemoveQueue_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo một query để lấy danh sách các hàng đợi in
                SelectQuery query = new SelectQuery("SELECT * FROM Win32_PrintJob");

                // Tạo một searcher để thực thi query
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

                // Lặp qua danh sách các công việc in và xóa chúng
                foreach (ManagementObject job in searcher.Get())
                {
                    job.Delete();
                }

                // Hiển thị thông báo khi xóa thành công
                MessageBox.Show("Đã xóa hàng đợi in thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo nếu có lỗi xảy ra
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
